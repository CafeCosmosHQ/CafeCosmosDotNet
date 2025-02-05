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
using VisionsContracts.Land.Systems.VrgdaSystem.ContractDefinition;

namespace VisionsContracts.Land.Systems.VrgdaSystem
{
    public partial class VrgdaSystemService: VrgdaSystemServiceBase
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.IWeb3 web3, VrgdaSystemDeployment vrgdaSystemDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<VrgdaSystemDeployment>().SendRequestAndWaitForReceiptAsync(vrgdaSystemDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.IWeb3 web3, VrgdaSystemDeployment vrgdaSystemDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<VrgdaSystemDeployment>().SendRequestAsync(vrgdaSystemDeployment);
        }

        public static async Task<VrgdaSystemService> DeployContractAndGetServiceAsync(Nethereum.Web3.IWeb3 web3, VrgdaSystemDeployment vrgdaSystemDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, vrgdaSystemDeployment, cancellationTokenSource);
            return new VrgdaSystemService(web3, receipt.ContractAddress);
        }

        public VrgdaSystemService(Nethereum.Web3.IWeb3 web3, string contractAddress) : base(web3, contractAddress)
        {
        }

    }


    public partial class VrgdaSystemServiceBase: ContractWeb3ServiceBase
    {

        public VrgdaSystemServiceBase(Nethereum.Web3.IWeb3 web3, string contractAddress) : base(web3, contractAddress)
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

        public virtual Task<string> SetVrgdaParametersRequestAsync(SetVrgdaParametersFunction setVrgdaParametersFunction)
        {
             return ContractHandler.SendRequestAsync(setVrgdaParametersFunction);
        }

        public virtual Task<TransactionReceipt> SetVrgdaParametersRequestAndWaitForReceiptAsync(SetVrgdaParametersFunction setVrgdaParametersFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setVrgdaParametersFunction, cancellationToken);
        }

        public virtual Task<string> SetVrgdaParametersRequestAsync(BigInteger targetPrice, BigInteger priceDecayPercent, BigInteger perTimeUnit)
        {
            var setVrgdaParametersFunction = new SetVrgdaParametersFunction();
                setVrgdaParametersFunction.TargetPrice = targetPrice;
                setVrgdaParametersFunction.PriceDecayPercent = priceDecayPercent;
                setVrgdaParametersFunction.PerTimeUnit = perTimeUnit;
            
             return ContractHandler.SendRequestAsync(setVrgdaParametersFunction);
        }

        public virtual Task<TransactionReceipt> SetVrgdaParametersRequestAndWaitForReceiptAsync(BigInteger targetPrice, BigInteger priceDecayPercent, BigInteger perTimeUnit, CancellationTokenSource cancellationToken = null)
        {
            var setVrgdaParametersFunction = new SetVrgdaParametersFunction();
                setVrgdaParametersFunction.TargetPrice = targetPrice;
                setVrgdaParametersFunction.PriceDecayPercent = priceDecayPercent;
                setVrgdaParametersFunction.PerTimeUnit = perTimeUnit;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setVrgdaParametersFunction, cancellationToken);
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
                typeof(SetVrgdaParametersFunction),
                typeof(SupportsInterfaceFunction)
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
                typeof(SliceOutofboundsError),
                typeof(WorldAccessdeniedError)
            };
        }
    }
}
