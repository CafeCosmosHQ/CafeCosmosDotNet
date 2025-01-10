using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using VisionsContracts.Land.Systems.LandScenarioUserTestingSystem.ContractDefinition;

namespace VisionsContracts.Land.Systems.LandScenarioUserTestingSystem
{
    public partial class LandScenarioUserTestingSystemService: LandScenarioUserTestingSystemServiceBase
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.IWeb3 web3, LandScenarioUserTestingSystemDeployment landScenarioUserTestingSystemDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<LandScenarioUserTestingSystemDeployment>().SendRequestAndWaitForReceiptAsync(landScenarioUserTestingSystemDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.IWeb3 web3, LandScenarioUserTestingSystemDeployment landScenarioUserTestingSystemDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<LandScenarioUserTestingSystemDeployment>().SendRequestAsync(landScenarioUserTestingSystemDeployment);
        }

        public static async Task<LandScenarioUserTestingSystemService> DeployContractAndGetServiceAsync(Nethereum.Web3.IWeb3 web3, LandScenarioUserTestingSystemDeployment landScenarioUserTestingSystemDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, landScenarioUserTestingSystemDeployment, cancellationTokenSource);
            return new LandScenarioUserTestingSystemService(web3, receipt.ContractAddress);
        }

        public LandScenarioUserTestingSystemService(Nethereum.Web3.IWeb3 web3, string contractAddress) : base(web3, contractAddress)
        {
        }

    }


    public partial class LandScenarioUserTestingSystemServiceBase: ContractWeb3ServiceBase
    {

        public LandScenarioUserTestingSystemServiceBase(Nethereum.Web3.IWeb3 web3, string contractAddress) : base(web3, contractAddress)
        {
        }

        public Task<string> MsgSenderQueryAsync(MsgSenderFunction msgSenderFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MsgSenderFunction, string>(msgSenderFunction, blockParameter);
        }

        
        public virtual Task<string> MsgSenderQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MsgSenderFunction, string>(null, blockParameter);
        }

        public Task<BigInteger> MsgValueQueryAsync(MsgValueFunction msgValueFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MsgValueFunction, BigInteger>(msgValueFunction, blockParameter);
        }

        
        public virtual Task<BigInteger> MsgValueQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MsgValueFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> WorldQueryAsync(WorldFunction worldFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<WorldFunction, string>(worldFunction, blockParameter);
        }

        
        public virtual Task<string> WorldQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<WorldFunction, string>(null, blockParameter);
        }

        public virtual Task<string> CreateUserTestScerarioLandRequestAsync(CreateUserTestScerarioLandFunction createUserTestScerarioLandFunction)
        {
             return ContractHandler.SendRequestAsync(createUserTestScerarioLandFunction);
        }

        public virtual Task<TransactionReceipt> CreateUserTestScerarioLandRequestAndWaitForReceiptAsync(CreateUserTestScerarioLandFunction createUserTestScerarioLandFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createUserTestScerarioLandFunction, cancellationToken);
        }

        public virtual Task<string> CreateUserTestScerarioLandRequestAsync(string player, BigInteger limitX, BigInteger limitY, List<LandItemDTO> landItems)
        {
            var createUserTestScerarioLandFunction = new CreateUserTestScerarioLandFunction();
                createUserTestScerarioLandFunction.Player = player;
                createUserTestScerarioLandFunction.LimitX = limitX;
                createUserTestScerarioLandFunction.LimitY = limitY;
                createUserTestScerarioLandFunction.LandItems = landItems;
            
             return ContractHandler.SendRequestAsync(createUserTestScerarioLandFunction);
        }

        public virtual Task<TransactionReceipt> CreateUserTestScerarioLandRequestAndWaitForReceiptAsync(string player, BigInteger limitX, BigInteger limitY, List<LandItemDTO> landItems, CancellationTokenSource cancellationToken = null)
        {
            var createUserTestScerarioLandFunction = new CreateUserTestScerarioLandFunction();
                createUserTestScerarioLandFunction.Player = player;
                createUserTestScerarioLandFunction.LimitX = limitX;
                createUserTestScerarioLandFunction.LimitY = limitY;
                createUserTestScerarioLandFunction.LandItems = landItems;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createUserTestScerarioLandFunction, cancellationToken);
        }

        public virtual Task<string> ResetUserTestLandScenarioRequestAsync(ResetUserTestLandScenarioFunction resetUserTestLandScenarioFunction)
        {
             return ContractHandler.SendRequestAsync(resetUserTestLandScenarioFunction);
        }

        public virtual Task<TransactionReceipt> ResetUserTestLandScenarioRequestAndWaitForReceiptAsync(ResetUserTestLandScenarioFunction resetUserTestLandScenarioFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(resetUserTestLandScenarioFunction, cancellationToken);
        }

        public virtual Task<string> ResetUserTestLandScenarioRequestAsync(BigInteger landId, BigInteger limitX, BigInteger limitY, List<LandItemDTO> landItems)
        {
            var resetUserTestLandScenarioFunction = new ResetUserTestLandScenarioFunction();
                resetUserTestLandScenarioFunction.LandId = landId;
                resetUserTestLandScenarioFunction.LimitX = limitX;
                resetUserTestLandScenarioFunction.LimitY = limitY;
                resetUserTestLandScenarioFunction.LandItems = landItems;
            
             return ContractHandler.SendRequestAsync(resetUserTestLandScenarioFunction);
        }

        public virtual Task<TransactionReceipt> ResetUserTestLandScenarioRequestAndWaitForReceiptAsync(BigInteger landId, BigInteger limitX, BigInteger limitY, List<LandItemDTO> landItems, CancellationTokenSource cancellationToken = null)
        {
            var resetUserTestLandScenarioFunction = new ResetUserTestLandScenarioFunction();
                resetUserTestLandScenarioFunction.LandId = landId;
                resetUserTestLandScenarioFunction.LimitX = limitX;
                resetUserTestLandScenarioFunction.LimitY = limitY;
                resetUserTestLandScenarioFunction.LandItems = landItems;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(resetUserTestLandScenarioFunction, cancellationToken);
        }

        public Task<bool> SupportsInterfaceQueryAsync(SupportsInterfaceFunction supportsInterfaceFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SupportsInterfaceFunction, bool>(supportsInterfaceFunction, blockParameter);
        }

        
        public virtual Task<bool> SupportsInterfaceQueryAsync(byte[] interfaceId, BlockParameter blockParameter = null)
        {
            var supportsInterfaceFunction = new SupportsInterfaceFunction();
                supportsInterfaceFunction.InterfaceId = interfaceId;
            
            return ContractHandler.QueryAsync<SupportsInterfaceFunction, bool>(supportsInterfaceFunction, blockParameter);
        }

        public override List<Type> GetAllFunctionTypes()
        {
            return new List<Type>
            {
                typeof(MsgSenderFunction),
                typeof(MsgValueFunction),
                typeof(WorldFunction),
                typeof(CreateUserTestScerarioLandFunction),
                typeof(ResetUserTestLandScenarioFunction),
                typeof(SupportsInterfaceFunction)
            };
        }

        public override List<Type> GetAllEventTypes()
        {
            return new List<Type>
            {
                typeof(LandCreatedEventDTO),
                typeof(StoreDeleterecordEventDTO),
                typeof(StoreSplicedynamicdataEventDTO),
                typeof(StoreSplicestaticdataEventDTO)
            };
        }

        public override List<Type> GetAllErrorTypes()
        {
            return new List<Type>
            {
                typeof(EncodedlengthsInvalidlengthError),
                typeof(SliceOutofboundsError),
                typeof(StoreIndexoutofboundsError),
                typeof(StoreInvalidresourcetypeError),
                typeof(StoreInvalidspliceError),
                typeof(WorldAccessdeniedError)
            };
        }
    }
}
