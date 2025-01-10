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
using VisionsContracts.Land.Systems.LandItemsSystem.ContractDefinition;

namespace VisionsContracts.Land.Systems.LandItemsSystem
{
    public partial class LandItemsSystemService: LandItemsSystemServiceBase
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.IWeb3 web3, LandItemsSystemDeployment landItemsSystemDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<LandItemsSystemDeployment>().SendRequestAndWaitForReceiptAsync(landItemsSystemDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.IWeb3 web3, LandItemsSystemDeployment landItemsSystemDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<LandItemsSystemDeployment>().SendRequestAsync(landItemsSystemDeployment);
        }

        public static async Task<LandItemsSystemService> DeployContractAndGetServiceAsync(Nethereum.Web3.IWeb3 web3, LandItemsSystemDeployment landItemsSystemDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, landItemsSystemDeployment, cancellationTokenSource);
            return new LandItemsSystemService(web3, receipt.ContractAddress);
        }

        public LandItemsSystemService(Nethereum.Web3.IWeb3 web3, string contractAddress) : base(web3, contractAddress)
        {
        }

    }


    public partial class LandItemsSystemServiceBase: ContractWeb3ServiceBase
    {

        public LandItemsSystemServiceBase(Nethereum.Web3.IWeb3 web3, string contractAddress) : base(web3, contractAddress)
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

        public virtual Task<string> DepositItemsRequestAsync(DepositItemsFunction depositItemsFunction)
        {
             return ContractHandler.SendRequestAsync(depositItemsFunction);
        }

        public virtual Task<TransactionReceipt> DepositItemsRequestAndWaitForReceiptAsync(DepositItemsFunction depositItemsFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(depositItemsFunction, cancellationToken);
        }

        public virtual Task<string> DepositItemsRequestAsync(BigInteger landId, List<BigInteger> itemIds, List<BigInteger> amounts)
        {
            var depositItemsFunction = new DepositItemsFunction();
                depositItemsFunction.LandId = landId;
                depositItemsFunction.ItemIds = itemIds;
                depositItemsFunction.Amounts = amounts;
            
             return ContractHandler.SendRequestAsync(depositItemsFunction);
        }

        public virtual Task<TransactionReceipt> DepositItemsRequestAndWaitForReceiptAsync(BigInteger landId, List<BigInteger> itemIds, List<BigInteger> amounts, CancellationTokenSource cancellationToken = null)
        {
            var depositItemsFunction = new DepositItemsFunction();
                depositItemsFunction.LandId = landId;
                depositItemsFunction.ItemIds = itemIds;
                depositItemsFunction.Amounts = amounts;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(depositItemsFunction, cancellationToken);
        }

        public Task<BigInteger> ItemBalanceOfQueryAsync(ItemBalanceOfFunction itemBalanceOfFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ItemBalanceOfFunction, BigInteger>(itemBalanceOfFunction, blockParameter);
        }

        
        public virtual Task<BigInteger> ItemBalanceOfQueryAsync(BigInteger landId, BigInteger itemId, BlockParameter blockParameter = null)
        {
            var itemBalanceOfFunction = new ItemBalanceOfFunction();
                itemBalanceOfFunction.LandId = landId;
                itemBalanceOfFunction.ItemId = itemId;
            
            return ContractHandler.QueryAsync<ItemBalanceOfFunction, BigInteger>(itemBalanceOfFunction, blockParameter);
        }

        public Task<List<BigInteger>> ItemBalanceOfBatchQueryAsync(ItemBalanceOfBatchFunction itemBalanceOfBatchFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ItemBalanceOfBatchFunction, List<BigInteger>>(itemBalanceOfBatchFunction, blockParameter);
        }

        
        public virtual Task<List<BigInteger>> ItemBalanceOfBatchQueryAsync(BigInteger landId, List<BigInteger> ids, BlockParameter blockParameter = null)
        {
            var itemBalanceOfBatchFunction = new ItemBalanceOfBatchFunction();
                itemBalanceOfBatchFunction.LandId = landId;
                itemBalanceOfBatchFunction.Ids = ids;
            
            return ContractHandler.QueryAsync<ItemBalanceOfBatchFunction, List<BigInteger>>(itemBalanceOfBatchFunction, blockParameter);
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

        public virtual Task<string> WithdrawItemsRequestAsync(WithdrawItemsFunction withdrawItemsFunction)
        {
             return ContractHandler.SendRequestAsync(withdrawItemsFunction);
        }

        public virtual Task<TransactionReceipt> WithdrawItemsRequestAndWaitForReceiptAsync(WithdrawItemsFunction withdrawItemsFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(withdrawItemsFunction, cancellationToken);
        }

        public virtual Task<string> WithdrawItemsRequestAsync(BigInteger landId, List<BigInteger> itemIds, List<BigInteger> amounts)
        {
            var withdrawItemsFunction = new WithdrawItemsFunction();
                withdrawItemsFunction.LandId = landId;
                withdrawItemsFunction.ItemIds = itemIds;
                withdrawItemsFunction.Amounts = amounts;
            
             return ContractHandler.SendRequestAsync(withdrawItemsFunction);
        }

        public virtual Task<TransactionReceipt> WithdrawItemsRequestAndWaitForReceiptAsync(BigInteger landId, List<BigInteger> itemIds, List<BigInteger> amounts, CancellationTokenSource cancellationToken = null)
        {
            var withdrawItemsFunction = new WithdrawItemsFunction();
                withdrawItemsFunction.LandId = landId;
                withdrawItemsFunction.ItemIds = itemIds;
                withdrawItemsFunction.Amounts = amounts;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(withdrawItemsFunction, cancellationToken);
        }

        public override List<Type> GetAllFunctionTypes()
        {
            return new List<Type>
            {
                typeof(MsgSenderFunction),
                typeof(MsgValueFunction),
                typeof(WorldFunction),
                typeof(DepositItemsFunction),
                typeof(ItemBalanceOfFunction),
                typeof(ItemBalanceOfBatchFunction),
                typeof(SupportsInterfaceFunction),
                typeof(WithdrawItemsFunction)
            };
        }

        public override List<Type> GetAllEventTypes()
        {
            return new List<Type>
            {
                typeof(StoreSplicestaticdataEventDTO)
            };
        }

        public override List<Type> GetAllErrorTypes()
        {
            return new List<Type>
            {
                typeof(AccessByNoOperatorError),
                typeof(SliceOutofboundsError)
            };
        }
    }
}
