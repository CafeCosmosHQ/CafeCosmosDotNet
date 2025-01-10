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
using VisionsContracts.Vesting.ContractDefinition;

namespace VisionsContracts.Vesting
{
    public partial class VestingService: VestingServiceBase
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.IWeb3 web3, VestingDeployment vestingDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<VestingDeployment>().SendRequestAndWaitForReceiptAsync(vestingDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.IWeb3 web3, VestingDeployment vestingDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<VestingDeployment>().SendRequestAsync(vestingDeployment);
        }

        public static async Task<VestingService> DeployContractAndGetServiceAsync(Nethereum.Web3.IWeb3 web3, VestingDeployment vestingDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, vestingDeployment, cancellationTokenSource);
            return new VestingService(web3, receipt.ContractAddress);
        }

        public VestingService(Nethereum.Web3.IWeb3 web3, string contractAddress) : base(web3, contractAddress)
        {
        }

    }


    public partial class VestingServiceBase: ContractWeb3ServiceBase
    {

        public VestingServiceBase(Nethereum.Web3.IWeb3 web3, string contractAddress) : base(web3, contractAddress)
        {
        }

        public Task<string> BeneficiaryQueryAsync(BeneficiaryFunction beneficiaryFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BeneficiaryFunction, string>(beneficiaryFunction, blockParameter);
        }

        
        public virtual Task<string> BeneficiaryQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BeneficiaryFunction, string>(null, blockParameter);
        }

        public Task<BigInteger> DurationQueryAsync(DurationFunction durationFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DurationFunction, BigInteger>(durationFunction, blockParameter);
        }

        
        public virtual Task<BigInteger> DurationQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DurationFunction, BigInteger>(null, blockParameter);
        }

        public Task<BigInteger> ReleasableQueryAsync(ReleasableFunction releasableFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ReleasableFunction, BigInteger>(releasableFunction, blockParameter);
        }

        
        public virtual Task<BigInteger> ReleasableQueryAsync(string token, BlockParameter blockParameter = null)
        {
            var releasableFunction = new ReleasableFunction();
                releasableFunction.Token = token;
            
            return ContractHandler.QueryAsync<ReleasableFunction, BigInteger>(releasableFunction, blockParameter);
        }

        public virtual Task<string> ReleaseRequestAsync(ReleaseFunction releaseFunction)
        {
             return ContractHandler.SendRequestAsync(releaseFunction);
        }

        public virtual Task<string> ReleaseRequestAsync()
        {
             return ContractHandler.SendRequestAsync<ReleaseFunction>();
        }

        public virtual Task<TransactionReceipt> ReleaseRequestAndWaitForReceiptAsync(ReleaseFunction releaseFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(releaseFunction, cancellationToken);
        }

        public virtual Task<TransactionReceipt> ReleaseRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<ReleaseFunction>(null, cancellationToken);
        }

        public Task<BigInteger> ReleasedQueryAsync(ReleasedFunction releasedFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ReleasedFunction, BigInteger>(releasedFunction, blockParameter);
        }

        
        public virtual Task<BigInteger> ReleasedQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ReleasedFunction, BigInteger>(null, blockParameter);
        }

        public Task<BigInteger> ReleasedQueryAsync(Released1Function released1Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<Released1Function, BigInteger>(released1Function, blockParameter);
        }

        
        public virtual Task<BigInteger> ReleasedQueryAsync(string token, BlockParameter blockParameter = null)
        {
            var released1Function = new Released1Function();
                released1Function.Token = token;
            
            return ContractHandler.QueryAsync<Released1Function, BigInteger>(released1Function, blockParameter);
        }

        public Task<string> SoftTokenQueryAsync(SoftTokenFunction softTokenFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SoftTokenFunction, string>(softTokenFunction, blockParameter);
        }

        
        public virtual Task<string> SoftTokenQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SoftTokenFunction, string>(null, blockParameter);
        }

        public Task<BigInteger> StartQueryAsync(StartFunction startFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<StartFunction, BigInteger>(startFunction, blockParameter);
        }

        
        public virtual Task<BigInteger> StartQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<StartFunction, BigInteger>(null, blockParameter);
        }

        public Task<BigInteger> VestedAmountQueryAsync(VestedAmountFunction vestedAmountFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<VestedAmountFunction, BigInteger>(vestedAmountFunction, blockParameter);
        }

        
        public virtual Task<BigInteger> VestedAmountQueryAsync(string token, ulong timestamp, BlockParameter blockParameter = null)
        {
            var vestedAmountFunction = new VestedAmountFunction();
                vestedAmountFunction.Token = token;
                vestedAmountFunction.Timestamp = timestamp;
            
            return ContractHandler.QueryAsync<VestedAmountFunction, BigInteger>(vestedAmountFunction, blockParameter);
        }

        public override List<Type> GetAllFunctionTypes()
        {
            return new List<Type>
            {
                typeof(BeneficiaryFunction),
                typeof(DurationFunction),
                typeof(ReleasableFunction),
                typeof(ReleaseFunction),
                typeof(ReleasedFunction),
                typeof(Released1Function),
                typeof(SoftTokenFunction),
                typeof(StartFunction),
                typeof(VestedAmountFunction)
            };
        }

        public override List<Type> GetAllEventTypes()
        {
            return new List<Type>
            {
                typeof(ERC20ReleasedEventDTO)
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
