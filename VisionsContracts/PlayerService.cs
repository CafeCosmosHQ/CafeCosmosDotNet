using Nethereum.RPC.Eth.DTOs;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using VisionsContracts.Land;

using VisionsContracts.SoftToken;
using VisionsContracts.Vesting;
using VisionsContracts.LandLocalState;
using Nethereum.Web3;
using VisionsContracts.Redistributor;
using VisionsContracts.Land.Systems.LandCreationSystem.ContractDefinition;
using Nethereum.Contracts;
using System.Linq;
using VisionsContracts.ItemsPermissioned;
using LandCreatedEventDTO = VisionsContracts.Land.Systems.LandCreationSystem.ContractDefinition.LandCreatedEventDTO;
using VisionsContracts.LandNFTs;
using Nethereum.Mud.Contracts.Core.StoreEvents;
using Nethereum.Mud.TableRepository;
using VisionsContracts.Land.Model;
using Nethereum.Mud.EncodingDecoding;
using VisionsContracts.Items.Mapping;
using VisionsContracts.Land.Systems.LandQuestsSystem.Model;
using VisionsContracts.Land.Systems.CatalogueSystem.Model;
using VisionsContracts.LandNFTs.ContractDefinition;
using VisionsContracts.Land.Exceptions;
using VisionsContracts.PlayerBalancePurchasing;

namespace VisionsContracts
{
    public partial class PlayerService
    {
        public LandNamespace LandNamespace { get; private set; }
        public PlayerBalancePurchasingService PlayerBalancePurchasingService { get; private set; }

        public SoftTokenService SoftTokenService { get; }
        public ItemsPermissionedService ItemsService { get; }
        public RedistributorService RedistributorService { get; }

        public LandNFTsService LandNFTsService { get; }
        public VestingService VestingService { get; }
        public IWeb3 Web3 { get; }
        public string PlayerAddress { get; }
        public int SelectedLandId { get; set; }

        public PlayerService(Nethereum.Web3.IWeb3 web3, VisionsContractAddresses contractAddresses, string playerAddress)
        {
            LandNamespace = new LandNamespace(web3, contractAddresses.LandAddress);
            SoftTokenService = new SoftTokenService(web3, contractAddresses.TokenAddress);
            ItemsService = new ItemsPermissionedService(web3, contractAddresses.ItemsAddress);
            RedistributorService = new RedistributorService(web3, contractAddresses.RedistributorAddress);
            VestingService = new VestingService(web3, contractAddresses.VestingAddress);
            LandNFTsService = new LandNFTsService(web3, contractAddresses.LandNFTAddress);
            Web3 = web3;
           
            PlayerAddress = playerAddress;
            PlayerBalancePurchasingService = new PlayerBalancePurchasingService(web3, playerAddress, contractAddresses.LandAddress, SoftTokenService);
        }

        public async Task<TransactionReceipt> PurchaseItemFromCatalogueAndWaitForReceiptAsync(BigInteger itemId, BigInteger quantity, PlayerLocalState playerLocalState)
        {
            var receipt = await LandNamespace.Systems.Catalogue.PurchaseCatalogueItemAndValidateBalanceRequestAndWaitForReceiptAsync(SelectedLandId, itemId, quantity, playerLocalState.PlayerLandInfo.TokenBalance);
            await ProcessAllChangesFromReceiptAsync(playerLocalState, receipt);
            return receipt;
        }

        public PlayerGuildService GetPlayerGuildService()
        {
            return new PlayerGuildService(PlayerAddress, SelectedLandId, LandNamespace);
        }

        public PlayerMarketPlaceService GetPlayerMarketPlaceService()
        {
            return new PlayerMarketPlaceService(LandNamespace, PlayerBalancePurchasingService, SelectedLandId);
        }


        public async Task<List<LandMetadata>> GetAllLandsAsync()
        {
           var response = await LandNFTsService.GetAllLandsQueryAsync();
           return response.ReturnValue1;
        }

        public async Task<List<PlayerTotalEarned>> GetAllLandsTotalEarnedAsync()
        {
            var allLands = await GetAllLandsAsync();
            return await LandNamespace.Systems.LandView.GetPlayersTotalEarnedAsync(allLands.Select(x => x.LandId).ToList());
        }

        public async Task<GuildsAndPlayersEarnings> GetGuildsAndPlayersEarningsAsync()
        {
            var guilds = await LandNamespace.Systems.Guild.GetAllGuildsAsync();
            var playersEarnings = await GetAllLandsTotalEarnedAsync();

            var guildsEarnings = new List<GuildEarnings>();
            foreach (var guild in guilds)
            {
                var guildEarnings = new GuildEarnings()
                {
                    Guild = guild,
                    MembersEarnings = guild.GuildMembers.Select(x => playersEarnings.FirstOrDefault(y => y.LandId == x)).ToList()
                };
                guildsEarnings.Add(guildEarnings);
            }
           
            return new GuildsAndPlayersEarnings()
            {
                GuildsEarnings = guildsEarnings,
                PlayersEarnings = playersEarnings
            };
            
        }

        public async Task<TransactionReceipt> SetLandNameAndWaitForReceiptAsync(string name, PlayerLocalState playerLocalState)
        {
            var lands = await GetAllLandsAsync();
            if (lands.Any(x => x.Name == name)) throw new LandNameAlreadyExistsException();
            var receipt = await LandNamespace.Systems.LandCreation.SetLandNameRequestAndWaitForReceiptAsync(SelectedLandId, name);
            playerLocalState.LandName = name;
            return receipt;
        }

        public async Task<TransactionReceipt> SavePlayerStateAndWaitForReceiptAsync(PlayerLocalState playerLocalState)
        {
            var receipt = await LandNamespace.Systems.LandItemInteraction.UpdateLandRequestAndWaitForReceiptAsync(playerLocalState);
            await ProcessAllChangesFromReceiptAsync(playerLocalState, receipt);

            return receipt;
        }

        private async Task ProcessAllChangesFromReceiptAsync(PlayerLocalState playerLocalState, TransactionReceipt receipt)
        {
            await StoreEventsLogProcessingService.ProcessAllStoreChangesFromLogs(playerLocalState.InMemoryTableRepository, receipt);
            var landInfo = await LandNamespace.GetFirstLandInfoFromTableRepository(playerLocalState.InMemoryTableRepository);
            var landItems = await LandNamespace.GetAllLandItemVOsFromLandTableRepositoryAsync(playerLocalState.InMemoryTableRepository);
            var inventoryItems = await LandNamespace.GetAllInventoryItemsFromTableRepositoryAsync(playerLocalState.InMemoryTableRepository, SelectedLandId);
            var landQuestStateData = await GetActiveQuestsAndLandQuestsStateDataAsync(playerLocalState.InMemoryTableRepository);

            playerLocalState.Initialise(landInfo, inventoryItems, landItems);
            playerLocalState.LandQuestsLocalState = landQuestStateData;
        }

        public Task<TransactionReceipt> SetDelegateeRequestAndWaitForReceiptAsync(string delegatee)
        {
            return LandNamespace.World.Systems.RegistrationSystem.RegisterDelegationRequestAndWaitForReceiptAsync(delegatee, ResourceEncoder.EncodeUnlimitedAccess(), new byte[] { });
        }

        public void SetDelegator(string delegator)
        {
            LandNamespace.Systems.SetSystemsCallFromDelegatorContractHandler(delegator);
        }

        public async Task<LandLocalStateData> GetLandLocalStateDataAsync(int landId)
        {
            var playerLocalStateData = new LandLocalStateData();
            var playerLandInfo = await GetLandInfoAsync(landId);
            if (playerLandInfo == null) return null;
            var landItems = await LandNamespace.GetLandItemsAsync(landId);
            if (landItems == null) return null;
            if (landItems.Count == 0) return null;

            var landItemsTableRecords = LandItemMapping.MapToLandItemTableRecord(landItems, landId);

            var inMemoryTableRepository = new InMemoryTableRepository();

            await inMemoryTableRepository.SetRecordsAsync(landItemsTableRecords.Where(x => x.Values.ItemId >= 0)); 
            //if chunked we set the itemId as -1 so this is not part of the real state and we don't want to add it to the memory

            var landInfo = LandInfoMapping.MapToTableRecord(playerLandInfo, landId);

            await inMemoryTableRepository.SetRecordAsync(landInfo);

            var inventoryItems = await LandNamespace.Systems.LandItems.GetAllInventoryItemsBalancesAsync(landId);

            var inventoryItemsRecords = ItemMappings.MapInventoryItemsToTableRecords(landId, inventoryItems);

            await inMemoryTableRepository.SetRecordsAsync(inventoryItemsRecords);

            var landName = await LandNFTsService.GetLandNameQueryAsync(landId);


            playerLocalStateData.LandInfo = playerLandInfo;
            playerLocalStateData.InventoryItems = inventoryItems;
            playerLocalStateData.LandItems = landItems;
            playerLocalStateData.TableRepository = inMemoryTableRepository;
            playerLocalStateData.LandId = SelectedLandId;
            playerLocalStateData.LandName = landName;
            return playerLocalStateData;
        }


        public Task<LandLocalStateData> GetLandLocalStateDataAsync()
        {
            return GetLandLocalStateDataAsync(SelectedLandId);
        }

        public Task<TransactionReceipt> ActivateAllQuestGroupsRequestAndWaitForReceiptAsync()
        {
            return LandNamespace.Systems.LandQuests.ActivateAllQuestGroupsRequestAndWaitForReceiptAsync(SelectedLandId);
        }

        public async Task<LandQuestsLocalState> GetActiveQuestsAndLandQuestsStateDataAsync(InMemoryTableRepository inMemoryTableRepository)
        {
            var activeQuestGroups = await LandNamespace.Systems.QuestsDTOs.GetAllActiveQuestGroupsAsync();
            await LandNamespace.Systems.QuestsDTOs.InsertQuestGroupsIntoTableStorage(activeQuestGroups, inMemoryTableRepository);

            var activeLandQuestGroups = await LandNamespace.Systems.LandQuests.GetAllActiveQuestGroupsAsync(SelectedLandId);
            await LandNamespace.Systems.LandQuests.InsertLandQuestGroupsIntoTableStorage(activeLandQuestGroups, inMemoryTableRepository);

            var completedLandQuestGroup = new List<LandQuestGroup>();
            foreach (var questGroup in activeQuestGroups)
            {
               var landQuestGroup = activeLandQuestGroups.FirstOrDefault(x => x.QuestGroupId == questGroup.Id);
               if (landQuestGroup == null)
               {
                    landQuestGroup = await LandNamespace.Systems.LandQuests.GetLandQuestGroupAsync(SelectedLandId, questGroup.Id);
                    completedLandQuestGroup.Add(landQuestGroup);
               }
            }

            return new LandQuestsLocalState()
            {
                ActiveQuestGroups = activeQuestGroups,
                ActiveLandQuestGroups = activeLandQuestGroups,
                CompletedActiveLandQuestGroups = completedLandQuestGroup,
                InMemoryTableRepository = inMemoryTableRepository
            };
        }

        public async Task EnsureInitialisedSelectedLandIdToFirstLandIfNotSetAsync()
        {
            if (SelectedLandId == 0) 
            { 
                var tokensBalances = await LandNFTsService.BalanceOfQueryAsync(PlayerAddress);
                if (tokensBalances != 0)
                {
                    var firstLandId = await LandNFTsService.TokenOfOwnerByIndexQueryAsync(PlayerAddress, 0);
                    SelectedLandId = (int)firstLandId;

                }
            }
        }

        public async Task<TransactionReceipt> PurchaseNewLandAndWaitForReceiptAsync(bool useToken = false)
        {
           var request =  await ValidateAndApproveLandPurchaseCostAsync(useToken);
            
           
            var estimatedGas = await LandNamespace.Systems.LandCreation.ContractHandler.EstimateGasAsync(request);
            request.Gas = estimatedGas.Value + 2000000;

            var receipt = await LandNamespace.Systems.LandCreation.CreatePlayerInitialLandRequestAndWaitForReceiptAsync(request);
            var landCreated = receipt.DecodeAllEvents<LandCreatedEventDTO>().FirstOrDefault();
            SelectedLandId = (int)landCreated.Event.LandId;
            return receipt;
        }

        public async Task<ExpandLandFunction> ValidateAndApproveLandExpansionCostAsync(BigInteger landId, BigInteger limitX, BigInteger limitY, bool useToken = false)
        {
            var landCost = await LandNamespace.Systems.LandCreation.CalculateLandExpansionCostQueryAsync(landId, limitX, limitY);
            return await PlayerBalancePurchasingService.ValidateBalanceApproveAndBuildPurchaseRequestAsync<ExpandLandFunction>(landCost, useToken);
        }


        public async Task<CreatePlayerInitialLandFunction> ValidateAndApproveLandPurchaseCostAsync(bool useToken = false)
        {
            var landCost = await LandNamespace.Systems.LandCreation.CalculateLandInitialPurchaseCostQueryAsync();
            return await PlayerBalancePurchasingService.ValidateBalanceApproveAndBuildPurchaseRequestAsync<CreatePlayerInitialLandFunction>(landCost, useToken);

        }

        public Task<LandExpansionCost> GetLandExpansionCostAndBalancesAsync(BigInteger limitX, BigInteger limitY)
        {
            return GetLandExpansionCostAndBalancesAsync(SelectedLandId, limitX, limitY);
        }

        public async Task<LandExpansionCost> GetLandExpansionCostAndBalancesAsync(BigInteger landId, BigInteger limitX, BigInteger limitY)
        {
            var landExpansionCost = new LandExpansionCost
            {
                LimitX = limitX,
                LimitY = limitY
            };

            var landCost = await LandNamespace.Systems.LandCreation.CalculateLandExpansionCostQueryAsync(landId, limitX, limitY);
            landExpansionCost.LandCost = landCost;

            var balances = await GetPlayerBalancesAsync();
            landExpansionCost.CurrentBalance = balances.Balance;
            landExpansionCost.CurrentTokenBalance = balances.TokenBalance;

            var currentAllowance = await SoftTokenService.AllowanceQueryAsync(PlayerAddress, LandNamespace.ContractAddress);
            landExpansionCost.CurrentAllowanceToLand = currentAllowance;
            return landExpansionCost;
        }

        public async Task<LandPurchaseCost> GetLandInitialPurchaseCostAndBalancesAsync()
        {
            var landPurchaseCost = new LandPurchaseCost();
            var landCost = await LandNamespace.Systems.LandCreation.CalculateLandInitialPurchaseCostQueryAsync();
            landPurchaseCost.LandCost = landCost;

            var balances = await GetPlayerBalancesAsync();
            landPurchaseCost.CurrentBalance = balances.Balance;
            landPurchaseCost.CurrentTokenBalance = balances.TokenBalance;
          

            var currentAllowance = await SoftTokenService.AllowanceQueryAsync(PlayerAddress, LandNamespace.ContractAddress);
            landPurchaseCost.CurrentAllowanceToLand = currentAllowance;
            return landPurchaseCost;
        }

        public Task<BigInteger> CalculateLandCostQueryAsync(BigInteger limitX, BigInteger limitY)
        {
            return LandNamespace.Systems.LandCreation.CalculateLandCostQueryAsync(limitX, limitY);
        }

        public Task<BigInteger> CalculateLandExpansionCostQueryAsync(BigInteger limitX, BigInteger limitY)
        {
            return LandNamespace.Systems.LandCreation.CalculateLandExpansionCostQueryAsync(SelectedLandId, limitX, limitY);
        }

        public Task<BigInteger> CalculateInitialPurchaseCostQueryAsync()
        {
            return LandNamespace.Systems.LandCreation.CalculateLandInitialPurchaseCostQueryAsync();
        }

        public async Task<TransactionReceipt> PurchaseItemsFromCatalogueAndWaitForReceiptAsync(List<CatalogueItemPurchase> catalogueItemPurchases, PlayerLocalState playerLocalState)
        {
            var receipt = await LandNamespace.Systems.Catalogue.PurchaseCatalogueItemsAndValidateBalanceRequestAndWaitForReceiptAsync(SelectedLandId, catalogueItemPurchases, playerLocalState.PlayerLandInfo.TokenBalance);
            await ProcessAllChangesFromReceiptAsync(playerLocalState, receipt);
            return receipt;
        }

     

        public async Task<TransactionReceipt> RevealAndGenerateChunkAndWaitForReceiptAsync(PlayerLocalState playerLocalState)
        {
            var request = new GenerateChunkFunction();
            request.LandId = SelectedLandId;
            var estimatedGas = await LandNamespace.Systems.LandCreation.ContractHandler.EstimateGasAsync(request);
           
            //note as we know the amount of land items to be revealed (fixed) we could fix the gas to that amount plus a bit
            request.Gas = estimatedGas.Value + 2000000;
           
            var receipt = await LandNamespace.Systems.LandCreation.GenerateChunkRequestAndWaitForReceiptAsync(request);
           
            await ProcessAllChangesFromReceiptAsync(playerLocalState, receipt);
            
            return receipt;
        }

      

        public async Task<TransactionReceipt> ExpandPlayerLandRevealingAllChunksAndWaitForReceiptAsync(BigInteger limitX, BigInteger limitY, PlayerLocalState playerLocalState, bool useToken = false)
        {
            var request = await ValidateAndApproveLandExpansionCostAsync(SelectedLandId, limitX, limitY, useToken);

            request.LandId = SelectedLandId;
            request.X1 = limitX;
            request.Y1 = limitY;
            request.FromAddress = PlayerAddress;

            var estimatedGas = await LandNamespace.Systems.LandCreation.ContractHandler.EstimateGasAsync(request);
            request.Gas = estimatedGas.Value + 2000000;
         

            var receipt = await LandNamespace.Systems.LandCreation.ExpandLandRequestAndWaitForReceiptAsync(request);
            await ProcessAllChangesFromReceiptAsync(playerLocalState, receipt);

            var landInfo = playerLocalState.PlayerLandInfo;
            
            while (landInfo.YBound.Any( y => y < landInfo.LimitX))
            {
                await RevealAndGenerateChunkAndWaitForReceiptAsync(playerLocalState);
                landInfo = playerLocalState.PlayerLandInfo;
            }
            
            return receipt;

        }

        public async Task<TransactionReceipt> ExpandPlayerLandApprovingCostAsync(BigInteger limitX, BigInteger limitY, bool useToken = false)
        {
            var request = await ValidateAndApproveLandExpansionCostAsync(SelectedLandId, limitX, limitY, useToken);

            request.LandId = SelectedLandId;
            request.X1 = limitX;
            request.Y1 = limitY;
            request.FromAddress = PlayerAddress;

            var estimatedGas = await LandNamespace.Systems.LandCreation.ContractHandler.EstimateGasAsync(request);
            request.Gas = estimatedGas.Value + 2000000;
            

            var receipt = await LandNamespace.Systems.LandCreation.ExpandLandRequestAndWaitForReceiptAsync(request);
            return receipt;

        }

        public Task<LandInfo> GetPlayerLandInfoAsync(BlockParameter blockParameter = null)
        {
            return GetLandInfoAsync(SelectedLandId, blockParameter);
        }

        public async Task<LandInfo> GetLandInfoAsync(BigInteger landId, BlockParameter blockParameter = null)
        {
            var result = await LandNamespace.Systems.LandConfig.GetLandInfoQueryAsync(landId, blockParameter);
            if (result == null) return null;
            return LandInfoMapping.MapToLandInfoModel(result.LandInfo);
        }

        public Task<PlayerBalances> GetPlayerBalancesAsync(BlockParameter blockParameter = null)
        {
            return PlayerBalancePurchasingService.GetPlayerBalancesAsync();
        }

        public Task<List<LandItem>> GetPlayerLandAsync()
        {
            return LandNamespace.GetLandItemsAsync(SelectedLandId);
        }

        public async Task<PlayerLocalState> GetNewPlayerLocalStateAsync()
        {
            var playerLocalStateData = await GetLandLocalStateDataAsync();
            var landQuestStateData = await GetActiveQuestsAndLandQuestsStateDataAsync(playerLocalStateData.TableRepository);
            var playerLocalState = new PlayerLocalState(playerLocalStateData.LandInfo, playerLocalStateData.InventoryItems, playerLocalStateData.LandItems);
            playerLocalState.LandQuestsLocalState = landQuestStateData;
            playerLocalState.InMemoryTableRepository = playerLocalStateData.TableRepository;
            playerLocalState.LandId = SelectedLandId;
           
            
            return playerLocalState;
        }

        public async Task<PlayerLocalState> GetLandViewLocalStateAsync(BigInteger landId)
        {
            var playerLocalStateData = await GetLandLocalStateDataAsync((int)landId);
            var playerLocalState = new PlayerLocalState(playerLocalStateData.LandInfo, playerLocalStateData.InventoryItems, playerLocalStateData.LandItems);
            playerLocalState.LandId = (int)landId;
            return playerLocalState;
        }

        public async Task<PlayerLocalState> ReloadPlayerLocalStateAsync(PlayerLocalState playerLocalState, BlockParameter blockParameter = null)
        {
            var playerLocalStateData = await GetLandLocalStateDataAsync();
            var landQuestStateData = await GetActiveQuestsAndLandQuestsStateDataAsync(playerLocalStateData.TableRepository);
            playerLocalState.LandQuestsLocalState = landQuestStateData;
            playerLocalState.InMemoryTableRepository = playerLocalStateData.TableRepository;
            playerLocalState.LandId = SelectedLandId;
            playerLocalState.Initialise(playerLocalStateData.LandInfo, playerLocalStateData.InventoryItems, playerLocalStateData.LandItems);
            playerLocalState.LandId = SelectedLandId;
            playerLocalState.LandName = playerLocalStateData.LandName;
            var inMemoryTableRepository = await LandNamespace.GetLandItemsFromStoreAsync(SelectedLandId);
            playerLocalState.InMemoryTableRepository = inMemoryTableRepository;
            return playerLocalState;
        }


        public async Task<MergedExpansionResult> MergeAfterExpandingPlayerLocalStateAsync(PlayerLocalState playerLocalState, BlockParameter blockParameter = null)
        {
            var playerLandInfo = await GetPlayerLandInfoAsync(blockParameter);
            var landItems = await LandNamespace.GetLandItemsAsync(SelectedLandId, blockParameter);
            var mergedValid = playerLocalState.MergeAfterExpandingPreservingUpdatedChanges(playerLandInfo, landItems);
            if (mergedValid)
            {
                return new MergedExpansionResult()
                {
                    ChangesFoundInChain = false,
                    NewOrMergedPlayerLocalState = playerLocalState,
                };
                 
            }
            else
            {
                var inventoryItems = await LandNamespace.Systems.LandItems.GetAllInventoryItemsBalancesAsync(SelectedLandId, blockParameter);
                playerLocalState.Initialise(playerLandInfo, inventoryItems, landItems);
                playerLocalState.LandId = SelectedLandId;
                return new MergedExpansionResult()
                {
                    ChangesFoundInChain = true,
                    NewOrMergedPlayerLocalState = playerLocalState,
                };
            }
        }

        public async Task<PlayerInfo> GetPlayerInfoAsync(BlockParameter blockParameter = null)
        {
            var balances = await GetPlayerBalancesAsync(blockParameter);
            var playerLandInfo = await GetPlayerLandInfoAsync(blockParameter);
            var playerTotalEarnedSpent = await LandNamespace.Systems.LandView.GetPlayerTotalEarnedAsync(SelectedLandId);
            return new PlayerInfo() { PlayerLandInfo = playerLandInfo,
            PlayerBalances = balances,
            PlayerTotalEarnedSpent = playerTotalEarnedSpent
            };
        }

        public async Task<bool> PlayerHasAnyLandPurchasedAsync()
        {
            try
            {
                var landId = await LandNFTsService.TokenOfOwnerByIndexQueryAsync(PlayerAddress, 0);
                return landId > 0;
            }
            catch //This throws SmartContractRevertException: Smart contract error: ERC721Enumerable: owner index out of bounds
            {
                return false;
            }
            
        }
    }
}
