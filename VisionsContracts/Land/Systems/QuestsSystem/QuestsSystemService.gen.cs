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
using VisionsContracts.Land.Systems.QuestsSystem.ContractDefinition;

namespace VisionsContracts.Land.Systems.QuestsSystem
{
    public partial class QuestsSystemService: QuestsSystemServiceBase
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.IWeb3 web3, QuestsSystemDeployment questsSystemDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<QuestsSystemDeployment>().SendRequestAndWaitForReceiptAsync(questsSystemDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.IWeb3 web3, QuestsSystemDeployment questsSystemDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<QuestsSystemDeployment>().SendRequestAsync(questsSystemDeployment);
        }

        public static async Task<QuestsSystemService> DeployContractAndGetServiceAsync(Nethereum.Web3.IWeb3 web3, QuestsSystemDeployment questsSystemDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, questsSystemDeployment, cancellationTokenSource);
            return new QuestsSystemService(web3, receipt.ContractAddress);
        }

        public QuestsSystemService(Nethereum.Web3.IWeb3 web3, string contractAddress) : base(web3, contractAddress)
        {
        }

    }


    public partial class QuestsSystemServiceBase: ContractWeb3ServiceBase
    {

        public QuestsSystemServiceBase(Nethereum.Web3.IWeb3 web3, string contractAddress) : base(web3, contractAddress)
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

        public virtual Task<string> CreateDailyQuestIfNotExistsRequestAsync(CreateDailyQuestIfNotExistsFunction createDailyQuestIfNotExistsFunction)
        {
             return ContractHandler.SendRequestAsync(createDailyQuestIfNotExistsFunction);
        }

        public virtual Task<string> CreateDailyQuestIfNotExistsRequestAsync()
        {
             return ContractHandler.SendRequestAsync<CreateDailyQuestIfNotExistsFunction>();
        }

        public virtual Task<TransactionReceipt> CreateDailyQuestIfNotExistsRequestAndWaitForReceiptAsync(CreateDailyQuestIfNotExistsFunction createDailyQuestIfNotExistsFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createDailyQuestIfNotExistsFunction, cancellationToken);
        }

        public virtual Task<TransactionReceipt> CreateDailyQuestIfNotExistsRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<CreateDailyQuestIfNotExistsFunction>(null, cancellationToken);
        }

        public virtual Task<string> CreateWeeklyQuestIfNotExistsRequestAsync(CreateWeeklyQuestIfNotExistsFunction createWeeklyQuestIfNotExistsFunction)
        {
             return ContractHandler.SendRequestAsync(createWeeklyQuestIfNotExistsFunction);
        }

        public virtual Task<string> CreateWeeklyQuestIfNotExistsRequestAsync()
        {
             return ContractHandler.SendRequestAsync<CreateWeeklyQuestIfNotExistsFunction>();
        }

        public virtual Task<TransactionReceipt> CreateWeeklyQuestIfNotExistsRequestAndWaitForReceiptAsync(CreateWeeklyQuestIfNotExistsFunction createWeeklyQuestIfNotExistsFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createWeeklyQuestIfNotExistsFunction, cancellationToken);
        }

        public virtual Task<TransactionReceipt> CreateWeeklyQuestIfNotExistsRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<CreateWeeklyQuestIfNotExistsFunction>(null, cancellationToken);
        }

        public Task<List<BigInteger>> GetAllActiveQuestGroupIdsQueryAsync(GetAllActiveQuestGroupIdsFunction getAllActiveQuestGroupIdsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetAllActiveQuestGroupIdsFunction, List<BigInteger>>(getAllActiveQuestGroupIdsFunction, blockParameter);
        }

        
        public virtual Task<List<BigInteger>> GetAllActiveQuestGroupIdsQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetAllActiveQuestGroupIdsFunction, List<BigInteger>>(null, blockParameter);
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
                typeof(CreateDailyQuestIfNotExistsFunction),
                typeof(CreateWeeklyQuestIfNotExistsFunction),
                typeof(GetAllActiveQuestGroupIdsFunction),
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
                typeof(EncodedlengthsInvalidlengthError),
                typeof(SliceOutofboundsError),
                typeof(StoreIndexoutofboundsError),
                typeof(StoreInvalidresourcetypeError),
                typeof(StoreInvalidspliceError)
            };
        }
    }
}
