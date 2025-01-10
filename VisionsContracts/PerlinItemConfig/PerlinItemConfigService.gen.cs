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
using VisionsContracts.PerlinItemConfig.ContractDefinition;

namespace VisionsContracts.PerlinItemConfig
{
    public partial class PerlinItemConfigService: PerlinItemConfigServiceBase
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.IWeb3 web3, PerlinItemConfigDeployment perlinItemConfigDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<PerlinItemConfigDeployment>().SendRequestAndWaitForReceiptAsync(perlinItemConfigDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.IWeb3 web3, PerlinItemConfigDeployment perlinItemConfigDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<PerlinItemConfigDeployment>().SendRequestAsync(perlinItemConfigDeployment);
        }

        public static async Task<PerlinItemConfigService> DeployContractAndGetServiceAsync(Nethereum.Web3.IWeb3 web3, PerlinItemConfigDeployment perlinItemConfigDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, perlinItemConfigDeployment, cancellationTokenSource);
            return new PerlinItemConfigService(web3, receipt.ContractAddress);
        }

        public PerlinItemConfigService(Nethereum.Web3.IWeb3 web3, string contractAddress) : base(web3, contractAddress)
        {
        }

    }


    public partial class PerlinItemConfigServiceBase: ContractWeb3ServiceBase
    {

        public PerlinItemConfigServiceBase(Nethereum.Web3.IWeb3 web3, string contractAddress) : base(web3, contractAddress)
        {
        }

        public Task<BigInteger> CalculatePerlinQueryAsync(CalculatePerlinFunction calculatePerlinFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CalculatePerlinFunction, BigInteger>(calculatePerlinFunction, blockParameter);
        }

        
        public virtual Task<BigInteger> CalculatePerlinQueryAsync(BigInteger x, BigInteger y, BigInteger seed, BlockParameter blockParameter = null)
        {
            var calculatePerlinFunction = new CalculatePerlinFunction();
                calculatePerlinFunction.X = x;
                calculatePerlinFunction.Y = y;
                calculatePerlinFunction.Seed = seed;
            
            return ContractHandler.QueryAsync<CalculatePerlinFunction, BigInteger>(calculatePerlinFunction, blockParameter);
        }

        public Task<BigInteger> CalculatePerlinAndGetItemQueryAsync(CalculatePerlinAndGetItemFunction calculatePerlinAndGetItemFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CalculatePerlinAndGetItemFunction, BigInteger>(calculatePerlinAndGetItemFunction, blockParameter);
        }

        
        public virtual Task<BigInteger> CalculatePerlinAndGetItemQueryAsync(BigInteger x, BigInteger y, BigInteger seed, BlockParameter blockParameter = null)
        {
            var calculatePerlinAndGetItemFunction = new CalculatePerlinAndGetItemFunction();
                calculatePerlinAndGetItemFunction.X = x;
                calculatePerlinAndGetItemFunction.Y = y;
                calculatePerlinAndGetItemFunction.Seed = seed;
            
            return ContractHandler.QueryAsync<CalculatePerlinAndGetItemFunction, BigInteger>(calculatePerlinAndGetItemFunction, blockParameter);
        }

        public Task<BigInteger> GetItemQueryAsync(GetItemFunction getItemFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetItemFunction, BigInteger>(getItemFunction, blockParameter);
        }

        
        public virtual Task<BigInteger> GetItemQueryAsync(BigInteger groupId, BigInteger perlin, BlockParameter blockParameter = null)
        {
            var getItemFunction = new GetItemFunction();
                getItemFunction.GroupId = groupId;
                getItemFunction.Perlin = perlin;
            
            return ContractHandler.QueryAsync<GetItemFunction, BigInteger>(getItemFunction, blockParameter);
        }

        public Task<BigInteger> ItemsQueryAsync(ItemsFunction itemsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ItemsFunction, BigInteger>(itemsFunction, blockParameter);
        }

        
        public virtual Task<BigInteger> ItemsQueryAsync(BigInteger returnValue1, BigInteger returnValue2, BlockParameter blockParameter = null)
        {
            var itemsFunction = new ItemsFunction();
                itemsFunction.ReturnValue1 = returnValue1;
                itemsFunction.ReturnValue2 = returnValue2;
            
            return ContractHandler.QueryAsync<ItemsFunction, BigInteger>(itemsFunction, blockParameter);
        }

        public Task<BigInteger> MaxGroupIdNumberQueryAsync(MaxGroupIdNumberFunction maxGroupIdNumberFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MaxGroupIdNumberFunction, BigInteger>(maxGroupIdNumberFunction, blockParameter);
        }

        
        public virtual Task<BigInteger> MaxGroupIdNumberQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MaxGroupIdNumberFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> OwnerQueryAsync(OwnerFunction ownerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(ownerFunction, blockParameter);
        }

        
        public virtual Task<string> OwnerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(null, blockParameter);
        }

        public virtual Task<string> RenounceOwnershipRequestAsync(RenounceOwnershipFunction renounceOwnershipFunction)
        {
             return ContractHandler.SendRequestAsync(renounceOwnershipFunction);
        }

        public virtual Task<string> RenounceOwnershipRequestAsync()
        {
             return ContractHandler.SendRequestAsync<RenounceOwnershipFunction>();
        }

        public virtual Task<TransactionReceipt> RenounceOwnershipRequestAndWaitForReceiptAsync(RenounceOwnershipFunction renounceOwnershipFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(renounceOwnershipFunction, cancellationToken);
        }

        public virtual Task<TransactionReceipt> RenounceOwnershipRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<RenounceOwnershipFunction>(null, cancellationToken);
        }

        public virtual Task<string> SetItemRequestAsync(SetItemFunction setItemFunction)
        {
             return ContractHandler.SendRequestAsync(setItemFunction);
        }

        public virtual Task<TransactionReceipt> SetItemRequestAndWaitForReceiptAsync(SetItemFunction setItemFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setItemFunction, cancellationToken);
        }

        public virtual Task<string> SetItemRequestAsync(BigInteger groupId, BigInteger perlin, BigInteger itemId)
        {
            var setItemFunction = new SetItemFunction();
                setItemFunction.GroupId = groupId;
                setItemFunction.Perlin = perlin;
                setItemFunction.ItemId = itemId;
            
             return ContractHandler.SendRequestAsync(setItemFunction);
        }

        public virtual Task<TransactionReceipt> SetItemRequestAndWaitForReceiptAsync(BigInteger groupId, BigInteger perlin, BigInteger itemId, CancellationTokenSource cancellationToken = null)
        {
            var setItemFunction = new SetItemFunction();
                setItemFunction.GroupId = groupId;
                setItemFunction.Perlin = perlin;
                setItemFunction.ItemId = itemId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setItemFunction, cancellationToken);
        }

        public virtual Task<string> SetItemsRequestAsync(SetItemsFunction setItemsFunction)
        {
             return ContractHandler.SendRequestAsync(setItemsFunction);
        }

        public virtual Task<TransactionReceipt> SetItemsRequestAndWaitForReceiptAsync(SetItemsFunction setItemsFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setItemsFunction, cancellationToken);
        }

        public virtual Task<string> SetItemsRequestAsync(List<PerlinConfig> perlinConfigs)
        {
            var setItemsFunction = new SetItemsFunction();
                setItemsFunction.PerlinConfigs = perlinConfigs;
            
             return ContractHandler.SendRequestAsync(setItemsFunction);
        }

        public virtual Task<TransactionReceipt> SetItemsRequestAndWaitForReceiptAsync(List<PerlinConfig> perlinConfigs, CancellationTokenSource cancellationToken = null)
        {
            var setItemsFunction = new SetItemsFunction();
                setItemsFunction.PerlinConfigs = perlinConfigs;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setItemsFunction, cancellationToken);
        }

        public virtual Task<string> TransferOwnershipRequestAsync(TransferOwnershipFunction transferOwnershipFunction)
        {
             return ContractHandler.SendRequestAsync(transferOwnershipFunction);
        }

        public virtual Task<TransactionReceipt> TransferOwnershipRequestAndWaitForReceiptAsync(TransferOwnershipFunction transferOwnershipFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferOwnershipFunction, cancellationToken);
        }

        public virtual Task<string> TransferOwnershipRequestAsync(string newOwner)
        {
            var transferOwnershipFunction = new TransferOwnershipFunction();
                transferOwnershipFunction.NewOwner = newOwner;
            
             return ContractHandler.SendRequestAsync(transferOwnershipFunction);
        }

        public virtual Task<TransactionReceipt> TransferOwnershipRequestAndWaitForReceiptAsync(string newOwner, CancellationTokenSource cancellationToken = null)
        {
            var transferOwnershipFunction = new TransferOwnershipFunction();
                transferOwnershipFunction.NewOwner = newOwner;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferOwnershipFunction, cancellationToken);
        }

        public override List<Type> GetAllFunctionTypes()
        {
            return new List<Type>
            {
                typeof(CalculatePerlinFunction),
                typeof(CalculatePerlinAndGetItemFunction),
                typeof(GetItemFunction),
                typeof(ItemsFunction),
                typeof(MaxGroupIdNumberFunction),
                typeof(OwnerFunction),
                typeof(RenounceOwnershipFunction),
                typeof(SetItemFunction),
                typeof(SetItemsFunction),
                typeof(TransferOwnershipFunction)
            };
        }

        public override List<Type> GetAllEventTypes()
        {
            return new List<Type>
            {
                typeof(OwnershipTransferredEventDTO)
            };
        }

        public override List<Type> GetAllErrorTypes()
        {
            return new List<Type>
            {

            };
        }
    }
}
