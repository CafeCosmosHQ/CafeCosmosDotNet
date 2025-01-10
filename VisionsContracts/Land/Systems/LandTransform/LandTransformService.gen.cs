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
using VisionsContracts.Land.Systems.LandTransform.ContractDefinition;

namespace VisionsContracts.Land.Systems.LandTransform
{
    public partial class LandTransformService: LandTransformServiceBase
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.IWeb3 web3, LandTransformDeployment landTransformDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<LandTransformDeployment>().SendRequestAndWaitForReceiptAsync(landTransformDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.IWeb3 web3, LandTransformDeployment landTransformDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<LandTransformDeployment>().SendRequestAsync(landTransformDeployment);
        }

        public static async Task<LandTransformService> DeployContractAndGetServiceAsync(Nethereum.Web3.IWeb3 web3, LandTransformDeployment landTransformDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, landTransformDeployment, cancellationTokenSource);
            return new LandTransformService(web3, receipt.ContractAddress);
        }

        public LandTransformService(Nethereum.Web3.IWeb3 web3, string contractAddress) : base(web3, contractAddress)
        {
        }

    }


    public partial class LandTransformServiceBase: ContractWeb3ServiceBase
    {

        public LandTransformServiceBase(Nethereum.Web3.IWeb3 web3, string contractAddress) : base(web3, contractAddress)
        {
        }

        public virtual Task<string> TransformRequestAsync(TransformFunction transformFunction)
        {
             return ContractHandler.SendRequestAsync(transformFunction);
        }

        public virtual Task<TransactionReceipt> TransformRequestAndWaitForReceiptAsync(TransformFunction transformFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transformFunction, cancellationToken);
        }

        public virtual Task<string> TransformRequestAsync(BigInteger landId, BigInteger x, BigInteger y, BigInteger input, TransformationsData config)
        {
            var transformFunction = new TransformFunction();
                transformFunction.LandId = landId;
                transformFunction.X = x;
                transformFunction.Y = y;
                transformFunction.Input = input;
                transformFunction.Config = config;
            
             return ContractHandler.SendRequestAsync(transformFunction);
        }

        public virtual Task<TransactionReceipt> TransformRequestAndWaitForReceiptAsync(BigInteger landId, BigInteger x, BigInteger y, BigInteger input, TransformationsData config, CancellationTokenSource cancellationToken = null)
        {
            var transformFunction = new TransformFunction();
                transformFunction.LandId = landId;
                transformFunction.X = x;
                transformFunction.Y = y;
                transformFunction.Input = input;
                transformFunction.Config = config;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transformFunction, cancellationToken);
        }

        public override List<Type> GetAllFunctionTypes()
        {
            return new List<Type>
            {
                typeof(TransformFunction)
            };
        }

        public override List<Type> GetAllEventTypes()
        {
            return new List<Type>
            {
                typeof(StoreDeleterecordEventDTO),
                typeof(StoreSplicestaticdataEventDTO)
            };
        }

        public override List<Type> GetAllErrorTypes()
        {
            return new List<Type>
            {
                typeof(SliceOutofboundsError),
                typeof(TransformationIncompatibleError),
                typeof(NotUnlockedYetError)
            };
        }
    }
}
