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
using VisionsContracts.Land.Systems.WaterControllerSystem.ContractDefinition;

namespace VisionsContracts.Land.Systems.WaterControllerSystem
{
    public partial class WaterControllerSystemService: WaterControllerSystemServiceBase
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.IWeb3 web3, WaterControllerSystemDeployment waterControllerSystemDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<WaterControllerSystemDeployment>().SendRequestAndWaitForReceiptAsync(waterControllerSystemDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.IWeb3 web3, WaterControllerSystemDeployment waterControllerSystemDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<WaterControllerSystemDeployment>().SendRequestAsync(waterControllerSystemDeployment);
        }

        public static async Task<WaterControllerSystemService> DeployContractAndGetServiceAsync(Nethereum.Web3.IWeb3 web3, WaterControllerSystemDeployment waterControllerSystemDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, waterControllerSystemDeployment, cancellationTokenSource);
            return new WaterControllerSystemService(web3, receipt.ContractAddress);
        }

        public WaterControllerSystemService(Nethereum.Web3.IWeb3 web3, string contractAddress) : base(web3, contractAddress)
        {
        }

    }


    public partial class WaterControllerSystemServiceBase: ContractWeb3ServiceBase
    {

        public WaterControllerSystemServiceBase(Nethereum.Web3.IWeb3 web3, string contractAddress) : base(web3, contractAddress)
        {
        }

        public virtual Task<string> InitialiseWaterControllerRequestAsync(InitialiseWaterControllerFunction initialiseWaterControllerFunction)
        {
             return ContractHandler.SendRequestAsync(initialiseWaterControllerFunction);
        }

        public virtual Task<TransactionReceipt> InitialiseWaterControllerRequestAndWaitForReceiptAsync(InitialiseWaterControllerFunction initialiseWaterControllerFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(initialiseWaterControllerFunction, cancellationToken);
        }

        public virtual Task<string> InitialiseWaterControllerRequestAsync(string axiomV2QueryAddress, ulong callbackSourceChainId, byte[] querySchema)
        {
            var initialiseWaterControllerFunction = new InitialiseWaterControllerFunction();
                initialiseWaterControllerFunction.AxiomV2QueryAddress = axiomV2QueryAddress;
                initialiseWaterControllerFunction.CallbackSourceChainId = callbackSourceChainId;
                initialiseWaterControllerFunction.QuerySchema = querySchema;
            
             return ContractHandler.SendRequestAsync(initialiseWaterControllerFunction);
        }

        public virtual Task<TransactionReceipt> InitialiseWaterControllerRequestAndWaitForReceiptAsync(string axiomV2QueryAddress, ulong callbackSourceChainId, byte[] querySchema, CancellationTokenSource cancellationToken = null)
        {
            var initialiseWaterControllerFunction = new InitialiseWaterControllerFunction();
                initialiseWaterControllerFunction.AxiomV2QueryAddress = axiomV2QueryAddress;
                initialiseWaterControllerFunction.CallbackSourceChainId = callbackSourceChainId;
                initialiseWaterControllerFunction.QuerySchema = querySchema;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(initialiseWaterControllerFunction, cancellationToken);
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

        public virtual Task<string> AxiomV2CallbackRequestAsync(AxiomV2CallbackFunction axiomV2CallbackFunction)
        {
             return ContractHandler.SendRequestAsync(axiomV2CallbackFunction);
        }

        public virtual Task<TransactionReceipt> AxiomV2CallbackRequestAndWaitForReceiptAsync(AxiomV2CallbackFunction axiomV2CallbackFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(axiomV2CallbackFunction, cancellationToken);
        }

        public virtual Task<string> AxiomV2CallbackRequestAsync(ulong sourceChainId, string caller, byte[] querySchema, BigInteger queryId, List<byte[]> axiomResults, byte[] extraData)
        {
            var axiomV2CallbackFunction = new AxiomV2CallbackFunction();
                axiomV2CallbackFunction.SourceChainId = sourceChainId;
                axiomV2CallbackFunction.Caller = caller;
                axiomV2CallbackFunction.QuerySchema = querySchema;
                axiomV2CallbackFunction.QueryId = queryId;
                axiomV2CallbackFunction.AxiomResults = axiomResults;
                axiomV2CallbackFunction.ExtraData = extraData;
            
             return ContractHandler.SendRequestAsync(axiomV2CallbackFunction);
        }

        public virtual Task<TransactionReceipt> AxiomV2CallbackRequestAndWaitForReceiptAsync(ulong sourceChainId, string caller, byte[] querySchema, BigInteger queryId, List<byte[]> axiomResults, byte[] extraData, CancellationTokenSource cancellationToken = null)
        {
            var axiomV2CallbackFunction = new AxiomV2CallbackFunction();
                axiomV2CallbackFunction.SourceChainId = sourceChainId;
                axiomV2CallbackFunction.Caller = caller;
                axiomV2CallbackFunction.QuerySchema = querySchema;
                axiomV2CallbackFunction.QueryId = queryId;
                axiomV2CallbackFunction.AxiomResults = axiomResults;
                axiomV2CallbackFunction.ExtraData = extraData;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(axiomV2CallbackFunction, cancellationToken);
        }

        public virtual Task<string> AxiomV2OffchainCallbackRequestAsync(AxiomV2OffchainCallbackFunction axiomV2OffchainCallbackFunction)
        {
             return ContractHandler.SendRequestAsync(axiomV2OffchainCallbackFunction);
        }

        public virtual Task<TransactionReceipt> AxiomV2OffchainCallbackRequestAndWaitForReceiptAsync(AxiomV2OffchainCallbackFunction axiomV2OffchainCallbackFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(axiomV2OffchainCallbackFunction, cancellationToken);
        }

        public virtual Task<string> AxiomV2OffchainCallbackRequestAsync(ulong sourceChainId, string caller, byte[] querySchema, BigInteger queryId, List<byte[]> axiomResults, byte[] extraData)
        {
            var axiomV2OffchainCallbackFunction = new AxiomV2OffchainCallbackFunction();
                axiomV2OffchainCallbackFunction.SourceChainId = sourceChainId;
                axiomV2OffchainCallbackFunction.Caller = caller;
                axiomV2OffchainCallbackFunction.QuerySchema = querySchema;
                axiomV2OffchainCallbackFunction.QueryId = queryId;
                axiomV2OffchainCallbackFunction.AxiomResults = axiomResults;
                axiomV2OffchainCallbackFunction.ExtraData = extraData;
            
             return ContractHandler.SendRequestAsync(axiomV2OffchainCallbackFunction);
        }

        public virtual Task<TransactionReceipt> AxiomV2OffchainCallbackRequestAndWaitForReceiptAsync(ulong sourceChainId, string caller, byte[] querySchema, BigInteger queryId, List<byte[]> axiomResults, byte[] extraData, CancellationTokenSource cancellationToken = null)
        {
            var axiomV2OffchainCallbackFunction = new AxiomV2OffchainCallbackFunction();
                axiomV2OffchainCallbackFunction.SourceChainId = sourceChainId;
                axiomV2OffchainCallbackFunction.Caller = caller;
                axiomV2OffchainCallbackFunction.QuerySchema = querySchema;
                axiomV2OffchainCallbackFunction.QueryId = queryId;
                axiomV2OffchainCallbackFunction.AxiomResults = axiomResults;
                axiomV2OffchainCallbackFunction.ExtraData = extraData;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(axiomV2OffchainCallbackFunction, cancellationToken);
        }

        public Task<string> AxiomV2QueryAddressQueryAsync(AxiomV2QueryAddressFunction axiomV2QueryAddressFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AxiomV2QueryAddressFunction, string>(axiomV2QueryAddressFunction, blockParameter);
        }

        
        public virtual Task<string> AxiomV2QueryAddressQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AxiomV2QueryAddressFunction, string>(null, blockParameter);
        }

        public Task<BigInteger> GetWaterYieldTimeQueryAsync(GetWaterYieldTimeFunction getWaterYieldTimeFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetWaterYieldTimeFunction, BigInteger>(getWaterYieldTimeFunction, blockParameter);
        }

        
        public virtual Task<BigInteger> GetWaterYieldTimeQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetWaterYieldTimeFunction, BigInteger>(null, blockParameter);
        }

        public virtual Task<string> SetAxionV2QueryAddressRequestAsync(SetAxionV2QueryAddressFunction setAxionV2QueryAddressFunction)
        {
             return ContractHandler.SendRequestAsync(setAxionV2QueryAddressFunction);
        }

        public virtual Task<TransactionReceipt> SetAxionV2QueryAddressRequestAndWaitForReceiptAsync(SetAxionV2QueryAddressFunction setAxionV2QueryAddressFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setAxionV2QueryAddressFunction, cancellationToken);
        }

        public virtual Task<string> SetAxionV2QueryAddressRequestAsync(string axiomV2QueryAddress)
        {
            var setAxionV2QueryAddressFunction = new SetAxionV2QueryAddressFunction();
                setAxionV2QueryAddressFunction.AxiomV2QueryAddress = axiomV2QueryAddress;
            
             return ContractHandler.SendRequestAsync(setAxionV2QueryAddressFunction);
        }

        public virtual Task<TransactionReceipt> SetAxionV2QueryAddressRequestAndWaitForReceiptAsync(string axiomV2QueryAddress, CancellationTokenSource cancellationToken = null)
        {
            var setAxionV2QueryAddressFunction = new SetAxionV2QueryAddressFunction();
                setAxionV2QueryAddressFunction.AxiomV2QueryAddress = axiomV2QueryAddress;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setAxionV2QueryAddressFunction, cancellationToken);
        }

        public virtual Task<string> SetWaterControllerParametersRequestAsync(SetWaterControllerParametersFunction setWaterControllerParametersFunction)
        {
             return ContractHandler.SendRequestAsync(setWaterControllerParametersFunction);
        }

        public virtual Task<TransactionReceipt> SetWaterControllerParametersRequestAndWaitForReceiptAsync(SetWaterControllerParametersFunction setWaterControllerParametersFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setWaterControllerParametersFunction, cancellationToken);
        }

        public virtual Task<string> SetWaterControllerParametersRequestAsync(BigInteger numSamples, BigInteger blockInterval, BigInteger minYieldTime, BigInteger maxYieldTime, BigInteger endBlockSlippage, BigInteger minDelta, BigInteger maxDelta)
        {
            var setWaterControllerParametersFunction = new SetWaterControllerParametersFunction();
                setWaterControllerParametersFunction.NumSamples = numSamples;
                setWaterControllerParametersFunction.BlockInterval = blockInterval;
                setWaterControllerParametersFunction.MinYieldTime = minYieldTime;
                setWaterControllerParametersFunction.MaxYieldTime = maxYieldTime;
                setWaterControllerParametersFunction.EndBlockSlippage = endBlockSlippage;
                setWaterControllerParametersFunction.MinDelta = minDelta;
                setWaterControllerParametersFunction.MaxDelta = maxDelta;
            
             return ContractHandler.SendRequestAsync(setWaterControllerParametersFunction);
        }

        public virtual Task<TransactionReceipt> SetWaterControllerParametersRequestAndWaitForReceiptAsync(BigInteger numSamples, BigInteger blockInterval, BigInteger minYieldTime, BigInteger maxYieldTime, BigInteger endBlockSlippage, BigInteger minDelta, BigInteger maxDelta, CancellationTokenSource cancellationToken = null)
        {
            var setWaterControllerParametersFunction = new SetWaterControllerParametersFunction();
                setWaterControllerParametersFunction.NumSamples = numSamples;
                setWaterControllerParametersFunction.BlockInterval = blockInterval;
                setWaterControllerParametersFunction.MinYieldTime = minYieldTime;
                setWaterControllerParametersFunction.MaxYieldTime = maxYieldTime;
                setWaterControllerParametersFunction.EndBlockSlippage = endBlockSlippage;
                setWaterControllerParametersFunction.MinDelta = minDelta;
                setWaterControllerParametersFunction.MaxDelta = maxDelta;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setWaterControllerParametersFunction, cancellationToken);
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
                typeof(InitialiseWaterControllerFunction),
                typeof(MsgSenderFunction),
                typeof(MsgValueFunction),
                typeof(WorldFunction),
                typeof(AxiomV2CallbackFunction),
                typeof(AxiomV2OffchainCallbackFunction),
                typeof(AxiomV2QueryAddressFunction),
                typeof(GetWaterYieldTimeFunction),
                typeof(SetAxionV2QueryAddressFunction),
                typeof(SetWaterControllerParametersFunction),
                typeof(SupportsInterfaceFunction)
            };
        }

        public override List<Type> GetAllEventTypes()
        {
            return new List<Type>
            {
                typeof(AxiomV2CallEventDTO),
                typeof(AxiomV2OffchainCallEventDTO),
                typeof(StoreSetrecordEventDTO),
                typeof(StoreSplicestaticdataEventDTO)
            };
        }

        public override List<Type> GetAllErrorTypes()
        {
            return new List<Type>
            {
                typeof(AxiomV2QueryAddressIsZeroError),
                typeof(CallerMustBeAxiomV2QueryError),
                typeof(SliceOutofboundsError),
                typeof(WorldAccessdeniedError)
            };
        }
    }
}
