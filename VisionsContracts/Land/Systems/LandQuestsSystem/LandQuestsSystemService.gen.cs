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
using VisionsContracts.Land.Systems.LandQuestsSystem.ContractDefinition;

namespace VisionsContracts.Land.Systems.LandQuestsSystem
{
    public partial class LandQuestsSystemService: LandQuestsSystemServiceBase
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.IWeb3 web3, LandQuestsSystemDeployment landQuestsSystemDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<LandQuestsSystemDeployment>().SendRequestAndWaitForReceiptAsync(landQuestsSystemDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.IWeb3 web3, LandQuestsSystemDeployment landQuestsSystemDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<LandQuestsSystemDeployment>().SendRequestAsync(landQuestsSystemDeployment);
        }

        public static async Task<LandQuestsSystemService> DeployContractAndGetServiceAsync(Nethereum.Web3.IWeb3 web3, LandQuestsSystemDeployment landQuestsSystemDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, landQuestsSystemDeployment, cancellationTokenSource);
            return new LandQuestsSystemService(web3, receipt.ContractAddress);
        }

        public LandQuestsSystemService(Nethereum.Web3.IWeb3 web3, string contractAddress) : base(web3, contractAddress)
        {
        }

    }


    public partial class LandQuestsSystemServiceBase: ContractWeb3ServiceBase
    {

        public LandQuestsSystemServiceBase(Nethereum.Web3.IWeb3 web3, string contractAddress) : base(web3, contractAddress)
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

        public virtual Task<string> ActivateAllQuestGroupsRequestAsync(ActivateAllQuestGroupsFunction activateAllQuestGroupsFunction)
        {
             return ContractHandler.SendRequestAsync(activateAllQuestGroupsFunction);
        }

        public virtual Task<TransactionReceipt> ActivateAllQuestGroupsRequestAndWaitForReceiptAsync(ActivateAllQuestGroupsFunction activateAllQuestGroupsFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(activateAllQuestGroupsFunction, cancellationToken);
        }

        public virtual Task<string> ActivateAllQuestGroupsRequestAsync(BigInteger landId)
        {
            var activateAllQuestGroupsFunction = new ActivateAllQuestGroupsFunction();
                activateAllQuestGroupsFunction.LandId = landId;
            
             return ContractHandler.SendRequestAsync(activateAllQuestGroupsFunction);
        }

        public virtual Task<TransactionReceipt> ActivateAllQuestGroupsRequestAndWaitForReceiptAsync(BigInteger landId, CancellationTokenSource cancellationToken = null)
        {
            var activateAllQuestGroupsFunction = new ActivateAllQuestGroupsFunction();
                activateAllQuestGroupsFunction.LandId = landId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(activateAllQuestGroupsFunction, cancellationToken);
        }

        public virtual Task<string> ActivateLandQuestGroupRequestAsync(ActivateLandQuestGroupFunction activateLandQuestGroupFunction)
        {
             return ContractHandler.SendRequestAsync(activateLandQuestGroupFunction);
        }

        public virtual Task<TransactionReceipt> ActivateLandQuestGroupRequestAndWaitForReceiptAsync(ActivateLandQuestGroupFunction activateLandQuestGroupFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(activateLandQuestGroupFunction, cancellationToken);
        }

        public virtual Task<string> ActivateLandQuestGroupRequestAsync(BigInteger landId, BigInteger questGroupId)
        {
            var activateLandQuestGroupFunction = new ActivateLandQuestGroupFunction();
                activateLandQuestGroupFunction.LandId = landId;
                activateLandQuestGroupFunction.QuestGroupId = questGroupId;
            
             return ContractHandler.SendRequestAsync(activateLandQuestGroupFunction);
        }

        public virtual Task<TransactionReceipt> ActivateLandQuestGroupRequestAndWaitForReceiptAsync(BigInteger landId, BigInteger questGroupId, CancellationTokenSource cancellationToken = null)
        {
            var activateLandQuestGroupFunction = new ActivateLandQuestGroupFunction();
                activateLandQuestGroupFunction.LandId = landId;
                activateLandQuestGroupFunction.QuestGroupId = questGroupId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(activateLandQuestGroupFunction, cancellationToken);
        }

        public virtual Task<GetActiveLandQuestGroupsOutputDTO> GetActiveLandQuestGroupsQueryAsync(GetActiveLandQuestGroupsFunction getActiveLandQuestGroupsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetActiveLandQuestGroupsFunction, GetActiveLandQuestGroupsOutputDTO>(getActiveLandQuestGroupsFunction, blockParameter);
        }

        public virtual Task<GetActiveLandQuestGroupsOutputDTO> GetActiveLandQuestGroupsQueryAsync(BigInteger landId, BlockParameter blockParameter = null)
        {
            var getActiveLandQuestGroupsFunction = new GetActiveLandQuestGroupsFunction();
                getActiveLandQuestGroupsFunction.LandId = landId;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetActiveLandQuestGroupsFunction, GetActiveLandQuestGroupsOutputDTO>(getActiveLandQuestGroupsFunction, blockParameter);
        }

        public virtual Task<GetLandQuestGroupOutputDTO> GetLandQuestGroupQueryAsync(GetLandQuestGroupFunction getLandQuestGroupFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetLandQuestGroupFunction, GetLandQuestGroupOutputDTO>(getLandQuestGroupFunction, blockParameter);
        }

        public virtual Task<GetLandQuestGroupOutputDTO> GetLandQuestGroupQueryAsync(BigInteger landId, BigInteger questGroupId, BlockParameter blockParameter = null)
        {
            var getLandQuestGroupFunction = new GetLandQuestGroupFunction();
                getLandQuestGroupFunction.LandId = landId;
                getLandQuestGroupFunction.QuestGroupId = questGroupId;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetLandQuestGroupFunction, GetLandQuestGroupOutputDTO>(getLandQuestGroupFunction, blockParameter);
        }

        public virtual Task<string> RemoveAllExpiredQuestGroupsRequestAsync(RemoveAllExpiredQuestGroupsFunction removeAllExpiredQuestGroupsFunction)
        {
             return ContractHandler.SendRequestAsync(removeAllExpiredQuestGroupsFunction);
        }

        public virtual Task<TransactionReceipt> RemoveAllExpiredQuestGroupsRequestAndWaitForReceiptAsync(RemoveAllExpiredQuestGroupsFunction removeAllExpiredQuestGroupsFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeAllExpiredQuestGroupsFunction, cancellationToken);
        }

        public virtual Task<string> RemoveAllExpiredQuestGroupsRequestAsync(BigInteger landId)
        {
            var removeAllExpiredQuestGroupsFunction = new RemoveAllExpiredQuestGroupsFunction();
                removeAllExpiredQuestGroupsFunction.LandId = landId;
            
             return ContractHandler.SendRequestAsync(removeAllExpiredQuestGroupsFunction);
        }

        public virtual Task<TransactionReceipt> RemoveAllExpiredQuestGroupsRequestAndWaitForReceiptAsync(BigInteger landId, CancellationTokenSource cancellationToken = null)
        {
            var removeAllExpiredQuestGroupsFunction = new RemoveAllExpiredQuestGroupsFunction();
                removeAllExpiredQuestGroupsFunction.LandId = landId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeAllExpiredQuestGroupsFunction, cancellationToken);
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
                typeof(ActivateAllQuestGroupsFunction),
                typeof(ActivateLandQuestGroupFunction),
                typeof(GetActiveLandQuestGroupsFunction),
                typeof(GetLandQuestGroupFunction),
                typeof(RemoveAllExpiredQuestGroupsFunction),
                typeof(SupportsInterfaceFunction)
            };
        }

        public override List<Type> GetAllEventTypes()
        {
            return new List<Type>
            {
                typeof(StoreSetrecordEventDTO),
                typeof(StoreSplicedynamicdataEventDTO),
                typeof(StoreSplicestaticdataEventDTO)
            };
        }

        public override List<Type> GetAllErrorTypes()
        {
            return new List<Type>
            {
                typeof(AccessByNoOperatorError),
                typeof(EncodedlengthsInvalidlengthError),
                typeof(SliceOutofboundsError),
                typeof(StoreIndexoutofboundsError),
                typeof(StoreInvalidresourcetypeError),
                typeof(StoreInvalidspliceError)
            };
        }
    }
}
