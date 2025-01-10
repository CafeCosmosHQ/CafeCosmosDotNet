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
using VisionsContracts.Land.Systems.LandQuestTaskProgressUpdate.ContractDefinition;

namespace VisionsContracts.Land.Systems.LandQuestTaskProgressUpdate
{
    public partial class LandQuestTaskProgressUpdateService: LandQuestTaskProgressUpdateServiceBase
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.IWeb3 web3, LandQuestTaskProgressUpdateDeployment landQuestTaskProgressUpdateDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<LandQuestTaskProgressUpdateDeployment>().SendRequestAndWaitForReceiptAsync(landQuestTaskProgressUpdateDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.IWeb3 web3, LandQuestTaskProgressUpdateDeployment landQuestTaskProgressUpdateDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<LandQuestTaskProgressUpdateDeployment>().SendRequestAsync(landQuestTaskProgressUpdateDeployment);
        }

        public static async Task<LandQuestTaskProgressUpdateService> DeployContractAndGetServiceAsync(Nethereum.Web3.IWeb3 web3, LandQuestTaskProgressUpdateDeployment landQuestTaskProgressUpdateDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, landQuestTaskProgressUpdateDeployment, cancellationTokenSource);
            return new LandQuestTaskProgressUpdateService(web3, receipt.ContractAddress);
        }

        public LandQuestTaskProgressUpdateService(Nethereum.Web3.IWeb3 web3, string contractAddress) : base(web3, contractAddress)
        {
        }

    }


    public partial class LandQuestTaskProgressUpdateServiceBase: ContractWeb3ServiceBase
    {

        public LandQuestTaskProgressUpdateServiceBase(Nethereum.Web3.IWeb3 web3, string contractAddress) : base(web3, contractAddress)
        {
        }

        public virtual Task<string> IncrementProgressCollectItemRequestAsync(IncrementProgressCollectItemFunction incrementProgressCollectItemFunction)
        {
             return ContractHandler.SendRequestAsync(incrementProgressCollectItemFunction);
        }

        public virtual Task<TransactionReceipt> IncrementProgressCollectItemRequestAndWaitForReceiptAsync(IncrementProgressCollectItemFunction incrementProgressCollectItemFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(incrementProgressCollectItemFunction, cancellationToken);
        }

        public virtual Task<string> IncrementProgressCollectItemRequestAsync(BigInteger landId, BigInteger itemId)
        {
            var incrementProgressCollectItemFunction = new IncrementProgressCollectItemFunction();
                incrementProgressCollectItemFunction.LandId = landId;
                incrementProgressCollectItemFunction.ItemId = itemId;
            
             return ContractHandler.SendRequestAsync(incrementProgressCollectItemFunction);
        }

        public virtual Task<TransactionReceipt> IncrementProgressCollectItemRequestAndWaitForReceiptAsync(BigInteger landId, BigInteger itemId, CancellationTokenSource cancellationToken = null)
        {
            var incrementProgressCollectItemFunction = new IncrementProgressCollectItemFunction();
                incrementProgressCollectItemFunction.LandId = landId;
                incrementProgressCollectItemFunction.ItemId = itemId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(incrementProgressCollectItemFunction, cancellationToken);
        }

        public virtual Task<string> IncrementProgressCraftRequestAsync(IncrementProgressCraftFunction incrementProgressCraftFunction)
        {
             return ContractHandler.SendRequestAsync(incrementProgressCraftFunction);
        }

        public virtual Task<TransactionReceipt> IncrementProgressCraftRequestAndWaitForReceiptAsync(IncrementProgressCraftFunction incrementProgressCraftFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(incrementProgressCraftFunction, cancellationToken);
        }

        public virtual Task<string> IncrementProgressCraftRequestAsync(BigInteger landId, BigInteger outputItemId)
        {
            var incrementProgressCraftFunction = new IncrementProgressCraftFunction();
                incrementProgressCraftFunction.LandId = landId;
                incrementProgressCraftFunction.OutputItemId = outputItemId;
            
             return ContractHandler.SendRequestAsync(incrementProgressCraftFunction);
        }

        public virtual Task<TransactionReceipt> IncrementProgressCraftRequestAndWaitForReceiptAsync(BigInteger landId, BigInteger outputItemId, CancellationTokenSource cancellationToken = null)
        {
            var incrementProgressCraftFunction = new IncrementProgressCraftFunction();
                incrementProgressCraftFunction.LandId = landId;
                incrementProgressCraftFunction.OutputItemId = outputItemId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(incrementProgressCraftFunction, cancellationToken);
        }

        public virtual Task<string> IncrementProgressTransformRequestAsync(IncrementProgressTransformFunction incrementProgressTransformFunction)
        {
             return ContractHandler.SendRequestAsync(incrementProgressTransformFunction);
        }

        public virtual Task<TransactionReceipt> IncrementProgressTransformRequestAndWaitForReceiptAsync(IncrementProgressTransformFunction incrementProgressTransformFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(incrementProgressTransformFunction, cancellationToken);
        }

        public virtual Task<string> IncrementProgressTransformRequestAsync(BigInteger landId, BigInteger @base, BigInteger input)
        {
            var incrementProgressTransformFunction = new IncrementProgressTransformFunction();
                incrementProgressTransformFunction.LandId = landId;
                incrementProgressTransformFunction.Base = @base;
                incrementProgressTransformFunction.Input = input;
            
             return ContractHandler.SendRequestAsync(incrementProgressTransformFunction);
        }

        public virtual Task<TransactionReceipt> IncrementProgressTransformRequestAndWaitForReceiptAsync(BigInteger landId, BigInteger @base, BigInteger input, CancellationTokenSource cancellationToken = null)
        {
            var incrementProgressTransformFunction = new IncrementProgressTransformFunction();
                incrementProgressTransformFunction.LandId = landId;
                incrementProgressTransformFunction.Base = @base;
                incrementProgressTransformFunction.Input = input;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(incrementProgressTransformFunction, cancellationToken);
        }

        public virtual Task<string> IncrementQuestProgressStackItemRequestAsync(IncrementQuestProgressStackItemFunction incrementQuestProgressStackItemFunction)
        {
             return ContractHandler.SendRequestAsync(incrementQuestProgressStackItemFunction);
        }

        public virtual Task<TransactionReceipt> IncrementQuestProgressStackItemRequestAndWaitForReceiptAsync(IncrementQuestProgressStackItemFunction incrementQuestProgressStackItemFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(incrementQuestProgressStackItemFunction, cancellationToken);
        }

        public virtual Task<string> IncrementQuestProgressStackItemRequestAsync(BigInteger landId, BigInteger @base, BigInteger input)
        {
            var incrementQuestProgressStackItemFunction = new IncrementQuestProgressStackItemFunction();
                incrementQuestProgressStackItemFunction.LandId = landId;
                incrementQuestProgressStackItemFunction.Base = @base;
                incrementQuestProgressStackItemFunction.Input = input;
            
             return ContractHandler.SendRequestAsync(incrementQuestProgressStackItemFunction);
        }

        public virtual Task<TransactionReceipt> IncrementQuestProgressStackItemRequestAndWaitForReceiptAsync(BigInteger landId, BigInteger @base, BigInteger input, CancellationTokenSource cancellationToken = null)
        {
            var incrementQuestProgressStackItemFunction = new IncrementQuestProgressStackItemFunction();
                incrementQuestProgressStackItemFunction.LandId = landId;
                incrementQuestProgressStackItemFunction.Base = @base;
                incrementQuestProgressStackItemFunction.Input = input;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(incrementQuestProgressStackItemFunction, cancellationToken);
        }

        public override List<Type> GetAllFunctionTypes()
        {
            return new List<Type>
            {
                typeof(IncrementProgressCollectItemFunction),
                typeof(IncrementProgressCraftFunction),
                typeof(IncrementProgressTransformFunction),
                typeof(IncrementQuestProgressStackItemFunction)
            };
        }

        public override List<Type> GetAllEventTypes()
        {
            return new List<Type>
            {
                typeof(LandQuestCompletedEventDTO),
                typeof(LandQuestGroupCompletedEventDTO),
                typeof(LandQuestItemRewardClaimedEventDTO),
                typeof(LandQuestTaskCompletedEventDTO),
                typeof(LandQuestXPRewardClaimedEventDTO),
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
