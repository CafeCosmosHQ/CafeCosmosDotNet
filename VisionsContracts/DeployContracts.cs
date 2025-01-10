using Microsoft.Extensions.Logging;
using Nethereum.Web3;
using System;
using System.Threading.Tasks;
using VisionsContracts.Land;
using VisionsContracts.PerlinItemConfig;
using VisionsContracts.Redistributor;
using VisionsContracts.Redistributor.ContractDefinition;
using VisionsContracts.SoftToken;
using VisionsContracts.SoftToken.ContractDefinition;
using VisionsContracts.Transformations;
using VisionsContracts.Transformations.Model;
using VisionsContracts.Vesting;
using VisionsContracts.Vesting.ContractDefinition;
using VisionsContracts.LandNFTs;
using VisionsContracts.ItemsPermissioned;
using System.Linq;
using VisionsContracts.ItemsPermissioned.ContractDefinition;
using Nethereum.Mud.Contracts;
using Nethereum.Contracts.Create2Deployment;
using Nethereum.Signer;
using Nethereum.Web3.Accounts;
using Nethereum.JsonRpc.Client;
using VisionsContracts.Land.Systems.LandTransform;
using VisionsContracts.Land.Systems.LandTransform.ContractDefinition;
using Nethereum.Contracts;
using System.Diagnostics;
using VisionsContracts.Land.Systems.LandTablesAndChairsContract.ContractDefinition;
using VisionsContracts.Land.Systems.LandTablesAndChairsContract;
using VisionsContracts.Land.Systems.LandQuestTaskProgressUpdate;
using Nethereum.RPC.Fee1559Suggestions;
using Nethereum.RPC.Eth.Blocks;
using System.Numerics;
using Nethereum.RPC.Eth.DTOs;

namespace VisionsContracts
{

    public class CustomFeeSuggestionStrategy : IFee1559SuggestionStrategy
    {
        public IClient Client { get; set; }
        private EthGetBlockWithTransactionsHashesByNumber _ethGetBlockWithTransactionsHashes;


        public CustomFeeSuggestionStrategy(IClient client)
        {
            Client = client;
            _ethGetBlockWithTransactionsHashes = new EthGetBlockWithTransactionsHashesByNumber(client);
        }

        public async Task<Fee1559> SuggestFeeAsync(BigInteger? maxPriorityFeePerGas = null)
        {
            if (maxPriorityFeePerGas == null) maxPriorityFeePerGas = Web3.Convert.ToWei(0.1, Nethereum.Util.UnitConversion.EthUnit.Gwei);
            var lastBlock = await _ethGetBlockWithTransactionsHashes.SendRequestAsync(BlockParameter.CreateLatest()).ConfigureAwait(false);

            var baseFee = lastBlock.BaseFeePerGas == null ? 100 : lastBlock.BaseFeePerGas.Value;
            var maxFeePerGas = maxPriorityFeePerGas;
            return new Fee1559()
            {
                BaseFee = baseFee,
                MaxPriorityFeePerGas = baseFee,
                MaxFeePerGas = baseFee
            };
        }
    }

    public class DeployContractsService
    {
        public async Task<Create2DeterministicDeploymentProxyDeployment> Create2DeterministicDeploymentProxyServiceWithRandomPKAsync(IClient client, long gasPrice = 100000000L, long gas = 40000000L)
        {  
            var pk = EthECKey.GenerateKey();
            Console.WriteLine(pk.GetPrivateKey());
            var account = new Account(pk.GetPrivateKey());
            var web3Deployer = new Web3(account, client);
            var create2DeterministicDeploymentProxyService = web3Deployer.Eth.Create2DeterministicDeploymentProxyService;
            return  await create2DeterministicDeploymentProxyService.GenerateEIP155DeterministicDeploymentAsync(gasPrice, gas);
        }

        public async Task<VisionsContractAddresses> InitialDeploymentAsync(Web3 web3, DeploymentConfiguration deploymentConfiguration, ILogger logger, string create2DeployerAddress, string salt = null)
        {
            web3.TransactionManager.UseLegacyAsDefault = true;
            if (string.IsNullOrEmpty(salt)) 
            {
                var random = new Random();
                salt = Nethereum.Util.Sha3Keccack.Current.CalculateHash(random.Next(0, 1000000).ToString());
            }

            logger.LogInformation("Deploying World Factory...");
            var worldFactoryDeployerService = new WorldFactoryDeployService();
            var worldFactoryAddresses = await worldFactoryDeployerService.DeployWorldFactoryContractAndSystemDependenciesAsync(web3, create2DeployerAddress, salt);

            logger.LogInformation("Deploying World...");
            var worldEvent = await worldFactoryDeployerService.DeployWorldAsync(web3, salt, worldFactoryAddresses);
            var worldAddress = worldEvent.NewContract;
            var landNamespace = new LandNamespace(web3, worldAddress, deploymentConfiguration.TestNet);
            logger.LogInformation("Registering land namespace...");
            await landNamespace.RegisterNamespaceRequestAndWaitForReceiptAsync();
            logger.LogInformation("Registering land tables...");

            try
            {
                await landNamespace.Tables.RegisterAllTablesRequestAndWaitForLastTxnReceiptAsync();
            }
            catch (SmartContractCustomErrorRevertException e)
            {
                landNamespace.HandleCustomErrorException(e);
                throw e;
            }


            logger.LogInformation("Deploying Land Systems...");
            var results = await landNamespace.Systems.DeployAllCreate2ContractSystemsRequestAsync(create2DeployerAddress, salt, null);

            await Task.Delay(10000);

            logger.LogInformation("Registering Land Systems...");
            try
            {
                await landNamespace.Systems.BatchRegisterAllSystemsRequestAndWaitForReceiptAsync(create2DeployerAddress, salt);
            }
            catch (SmartContractCustomErrorRevertException e)
            {
                var errors = landNamespace.World.Systems.RegistrationSystem.GetAllErrorTypes();
                foreach (var error in errors)
                {
                    if (e.IsCustomErrorFor(error))
                    {
                        logger.LogError("Error registering system: {0}", error);
                        throw;
                    }
                }
            }

            var chainId = await web3.Eth.ChainId.SendRequestAsync();



            logger.LogInformation("Deploying contracts...");
            logger.LogInformation("Deploying SoftToken...");

            SoftTokenService tokenService = null;
            if (string.IsNullOrWhiteSpace(deploymentConfiguration.TokenAddress))
            {
                var sofTokenDeployment = new SoftTokenDeployment() { Name = deploymentConfiguration.TokenName, Symbol = deploymentConfiguration.TokenSymbol };
                tokenService = await SoftTokenService.DeployContractAndGetServiceAsync(web3, sofTokenDeployment);
            }
            else
            {
                tokenService = new SoftTokenService(web3, deploymentConfiguration.TokenAddress);
            }



            logger.LogInformation("Deploying Items...");

            var itemsService = await ItemsPermissionedService.DeployContractAndGetServiceAsync(web3, new ItemsPermissionedDeployment() { Uri = deploymentConfiguration.ItemsNFTUrl });
        
            logger.LogInformation("Deploying LandNFT...");

            var landNFTService = await LandNFTsService.DeployContractAndGetServiceAsync(web3, new LandNFTs.ContractDefinition.LandNFTsDeployment()
            {
                Name = deploymentConfiguration.LandNFTName,
                Symbol = deploymentConfiguration.LandNFTSymbol,
            });

            
            

            logger.LogInformation("Deploying Redistributor...");
            var redistributorService = await RedistributorService.DeployContractAndGetServiceAsync(web3, new RedistributorDeployment()
            {
                Token = tokenService.ContractHandler.ContractAddress,
                Land = landNamespace.ContractAddress,
            });

            
            await redistributorService.CreateDefaultSubSectionsRequestAsync();

            var redistributorAddress = redistributorService.ContractHandler.ContractAddress;
            var tokenAddress = tokenService.ContractHandler.ContractAddress;
            var itemsAddress = itemsService.ContractHandler.ContractAddress;
            var landAddress = landNamespace.ContractAddress;
            var landNFTAddress = landNFTService.ContractHandler.ContractAddress;
            //string craftingAddress = craftingService.ContractHandler.ContractAddress;

            logger.LogInformation("Deploying Vesting...");

            var vestingDeployment = await VestingService.CreateVestingDeploymentStartingNowAsync(web3, tokenAddress, redistributorAddress, DateTime.Now.AddDays(7));

            var vestingService = await VestingService.DeployContractAndGetServiceAsync(web3, vestingDeployment);
            var vestingAddress = vestingService.ContractHandler.ContractAddress;

            logger.LogInformation("Deploying Land Transform...");
            var landTransformService = await LandTransformService.DeployContractAndGetServiceAsync(web3, new LandTransformDeployment());
          
            var landTransformAddress = landTransformService.ContractHandler.ContractAddress;

            logger.LogInformation("Deploying Land Tables and Chairs...");
            var landTablesAndChairsService = await LandTablesAndChairsContractService.DeployContractAndGetServiceAsync(web3, new LandTablesAndChairsContractDeployment());
            var landTablesAndChairsAddress = landTablesAndChairsService.ContractHandler.ContractAddress;

            var landQuestTaskProgressUpdateService = await LandQuestTaskProgressUpdateService.DeployContractAndGetServiceAsync(web3, new Land.Systems.LandQuestTaskProgressUpdate.ContractDefinition.LandQuestTaskProgressUpdateDeployment());
            var landQuestTaskProgressUpdateServiceAddress = landQuestTaskProgressUpdateService.ContractHandler.ContractAddress;

            logger.LogInformation("Deploying Perlin Config...");


            var perlinItemConfigService = await PerlinItemConfigService.DeployContractAndGetServiceAsync(web3, new PerlinItemConfig.ContractDefinition.PerlinItemConfigDeployment());

            var perlinItemConfigAddress = perlinItemConfigService.ContractHandler.ContractAddress;

            await perlinItemConfigService.InitialisePerlinMappingsRequestAsync();

            logger.LogInformation("Configuring Land NFT");
            await landNFTService.SetLandRequestAsync(landAddress);

            logger.LogInformation("Configuring Land... ");

            logger.LogInformation("Configuring Land... config facet ");

            // why not use a struct?
            await landNamespace.Systems.LandConfig.SetSoftTokenRequestAsync(tokenAddress);



            await landNamespace.Systems.LandConfig.SetSoftCostPerSquareRequestAsync(Web3.Convert.ToWei(deploymentConfiguration.LandCostPerSquare));
            await landNamespace.Systems.LandConfig.SetSoftDestinationRequestAsync(vestingAddress);
            await landNamespace.Systems.LandConfig.SetRedistributorRequestAsync(redistributorAddress);
            await landNamespace.Systems.LandConfig.SetLandNFTsRequestAsync(landNFTAddress);
            await landNamespace.Systems.LandConfig.SetCookingCostRequestAsync(Web3.Convert.ToWei(deploymentConfiguration.CookingCost));
            



            await landNamespace.Systems.LandConfig.SetDefaultNonRemovableItemsRequestAsync();
            await landNamespace.Systems.LandConfig.SetDefaultRotatableItemsRequestAsync();
            await landNamespace.Systems.LandConfig.BatchSetDefaultChairsRequestAsync();
            await landNamespace.Systems.LandConfig.BatchSetDefaultTablesRequestAsync();
            await landNamespace.Systems.LandConfig.SetMaxLevelRequestAsync(deploymentConfiguration.MaxLevel);   

            await landNamespace.Systems.LandConfig.SetItemsRequestAsync(itemsAddress);



            await landNamespace.Systems.LandConfig.SetVestingRequestAsync(vestingAddress);

            await landNamespace.Systems.LandConfig.SetLandTablesAndChairsAddressRequestAsync(landTablesAndChairsAddress);
            await landNamespace.Systems.LandConfig.SetLandTransformAddressRequestAsync(landTransformAddress);
            await landNamespace.Systems.LandConfig.SetItemConfigAddressRequestAsync(perlinItemConfigAddress);
            await landNamespace.Systems.LandConfig.SetLandQuestTaskProgressUpdateAddressRequestAsync(landQuestTaskProgressUpdateServiceAddress);

            await landNamespace.Systems.LandConfig.BatchSetToolsDefaultRequestAsync();
            await landNamespace.Systems.LandConfig.BatchSetStackingsDefaultRequestAsync();
            await landNamespace.Systems.LandConfig.BatchSetNonPlaceableDefaultRequestAsync();
            await landNamespace.Systems.LandConfig.SetDefaultReturnItemsRequestAsync();
            await landNamespace.Systems.LandConfig.SetChunkSizeRequestAsync(deploymentConfiguration.LandExpansionChunkSize);



            logger.LogInformation("Configuring land.. land creation facet");

            await landNamespace.Systems.LandCreation.InitialiseDefaultLandLimitsAsync();
            await landNamespace.Systems.LandCreation.SetInitialLandItemsInGroupsAndRandomlyPositionedRequestAsync();

            var waterControllerConfiguration = deploymentConfiguration.WaterControllerConfiguration;

            logger.LogInformation("Configuring land.. water controller facet");
            await landNamespace.Systems.WaterController.SetWaterControllerParametersRequestAsync(waterControllerConfiguration.NumSamples,
                                                                       waterControllerConfiguration.BlockInterval,
                                                                       waterControllerConfiguration.MinYieldTime,
                                                                       waterControllerConfiguration.MaxYieldTime,
                                                                       waterControllerConfiguration.EndBlockSlippage,
                                                                       waterControllerConfiguration.MinDelta,
                                                                       waterControllerConfiguration.MaxDelta);

            await landNamespace.Systems.WaterController.InitialiseWaterControllerRequestAsync(deploymentConfiguration.AxionConfiguration.AxiomV2QueryAddress,
                                                                                           deploymentConfiguration.AxionConfiguration.CallbackSourceChainId,
                                                                                            deploymentConfiguration.AxionConfiguration.QuerySchema);
            if (deploymentConfiguration.TestNet)
            {
                logger.LogInformation("Configuring catalogue");
                await landNamespace.Systems.Catalogue.UpsertDefaultAndThemeCatalogueItemsRequestAsync();
            }

            logger.LogInformation("Configuring levelling...");
            await landNamespace.Systems.Leveling.UpsertDefaultLevelRewardsRequestAsync();


            logger.LogInformation("Configuring items...");
            await itemsService.SetWhitelistRequestAsync(new string[] { landAddress }.ToList(), new bool[] { true }.ToList());


            logger.LogInformation("Configuring crafting...");

            await landNamespace.Systems.Crafting.InitialiseCraftingServiceRequestAsync();

            logger.LogInformation("Configuring soft Token...");

            //await tokenService.SetLandAddressRequestAsync(landAddress);

            logger.LogInformation("Configuring land parameters...");

            await landNamespace.Systems.Transformations.SetDefaultTransformationsRequestAsync();

            logger.LogInformation("Configuring  Vrgda...");
            await landNamespace.Systems.Vrgda.SetDefaultVrgdaParametersAsync();

            try

            {
                logger.LogInformation("Configuring quests...");
                await landNamespace.Systems.QuestsDTOs.SetDefaultDataRequestAsync();

            }catch (SmartContractCustomErrorRevertException e)
            {
                var error = landNamespace.FindCustomErrorException(e);
                if (error != null)
                {
                    logger.LogError("Error configuring quests: {0}", error);
                    throw error;
                }
                throw e;
            }


            logger.LogInformation("softToken: {0}", tokenAddress);
            logger.LogInformation("items: {0}", itemsAddress);
            logger.LogInformation("land: {0}", landAddress);
            logger.LogInformation("redistributor: {0}", redistributorAddress);
            logger.LogInformation("vesting: {0}", vestingAddress);
            logger.LogInformation("landNFT: {0}", landNFTAddress);


            return new VisionsContractAddresses
            {
                TokenAddress = tokenAddress,
                RedistributorAddress = redistributorAddress,
                ItemsAddress = itemsAddress,
                LandAddress = landAddress,
                VestingAddress = vestingAddress,
                LandNFTAddress = landNFTAddress,
                ChainId = (int)chainId.Value

            };

        }

    }
}
