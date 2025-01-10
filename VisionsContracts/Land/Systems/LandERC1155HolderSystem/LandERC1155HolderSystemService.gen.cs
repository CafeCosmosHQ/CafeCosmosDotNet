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
using VisionsContracts.Land.Systems.LandERC1155HolderSystem.ContractDefinition;

namespace VisionsContracts.Land.Systems.LandERC1155HolderSystem
{
    public partial class LandERC1155HolderSystemService: LandERC1155HolderSystemServiceBase
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.IWeb3 web3, LandERC1155HolderSystemDeployment landERC1155HolderSystemDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<LandERC1155HolderSystemDeployment>().SendRequestAndWaitForReceiptAsync(landERC1155HolderSystemDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.IWeb3 web3, LandERC1155HolderSystemDeployment landERC1155HolderSystemDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<LandERC1155HolderSystemDeployment>().SendRequestAsync(landERC1155HolderSystemDeployment);
        }

        public static async Task<LandERC1155HolderSystemService> DeployContractAndGetServiceAsync(Nethereum.Web3.IWeb3 web3, LandERC1155HolderSystemDeployment landERC1155HolderSystemDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, landERC1155HolderSystemDeployment, cancellationTokenSource);
            return new LandERC1155HolderSystemService(web3, receipt.ContractAddress);
        }

        public LandERC1155HolderSystemService(Nethereum.Web3.IWeb3 web3, string contractAddress) : base(web3, contractAddress)
        {
        }

    }


    public partial class LandERC1155HolderSystemServiceBase: ContractWeb3ServiceBase
    {

        public LandERC1155HolderSystemServiceBase(Nethereum.Web3.IWeb3 web3, string contractAddress) : base(web3, contractAddress)
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

        public virtual Task<string> OnERC1155BatchReceivedRequestAsync(OnERC1155BatchReceivedFunction onERC1155BatchReceivedFunction)
        {
             return ContractHandler.SendRequestAsync(onERC1155BatchReceivedFunction);
        }

        public virtual Task<TransactionReceipt> OnERC1155BatchReceivedRequestAndWaitForReceiptAsync(OnERC1155BatchReceivedFunction onERC1155BatchReceivedFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(onERC1155BatchReceivedFunction, cancellationToken);
        }

        public virtual Task<string> OnERC1155BatchReceivedRequestAsync(string returnValue1, string returnValue2, List<BigInteger> returnValue3, List<BigInteger> returnValue4, byte[] returnValue5)
        {
            var onERC1155BatchReceivedFunction = new OnERC1155BatchReceivedFunction();
                onERC1155BatchReceivedFunction.ReturnValue1 = returnValue1;
                onERC1155BatchReceivedFunction.ReturnValue2 = returnValue2;
                onERC1155BatchReceivedFunction.ReturnValue3 = returnValue3;
                onERC1155BatchReceivedFunction.ReturnValue4 = returnValue4;
                onERC1155BatchReceivedFunction.ReturnValue5 = returnValue5;
            
             return ContractHandler.SendRequestAsync(onERC1155BatchReceivedFunction);
        }

        public virtual Task<TransactionReceipt> OnERC1155BatchReceivedRequestAndWaitForReceiptAsync(string returnValue1, string returnValue2, List<BigInteger> returnValue3, List<BigInteger> returnValue4, byte[] returnValue5, CancellationTokenSource cancellationToken = null)
        {
            var onERC1155BatchReceivedFunction = new OnERC1155BatchReceivedFunction();
                onERC1155BatchReceivedFunction.ReturnValue1 = returnValue1;
                onERC1155BatchReceivedFunction.ReturnValue2 = returnValue2;
                onERC1155BatchReceivedFunction.ReturnValue3 = returnValue3;
                onERC1155BatchReceivedFunction.ReturnValue4 = returnValue4;
                onERC1155BatchReceivedFunction.ReturnValue5 = returnValue5;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(onERC1155BatchReceivedFunction, cancellationToken);
        }

        public virtual Task<string> OnERC1155ReceivedRequestAsync(OnERC1155ReceivedFunction onERC1155ReceivedFunction)
        {
             return ContractHandler.SendRequestAsync(onERC1155ReceivedFunction);
        }

        public virtual Task<TransactionReceipt> OnERC1155ReceivedRequestAndWaitForReceiptAsync(OnERC1155ReceivedFunction onERC1155ReceivedFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(onERC1155ReceivedFunction, cancellationToken);
        }

        public virtual Task<string> OnERC1155ReceivedRequestAsync(string returnValue1, string returnValue2, BigInteger returnValue3, BigInteger returnValue4, byte[] returnValue5)
        {
            var onERC1155ReceivedFunction = new OnERC1155ReceivedFunction();
                onERC1155ReceivedFunction.ReturnValue1 = returnValue1;
                onERC1155ReceivedFunction.ReturnValue2 = returnValue2;
                onERC1155ReceivedFunction.ReturnValue3 = returnValue3;
                onERC1155ReceivedFunction.ReturnValue4 = returnValue4;
                onERC1155ReceivedFunction.ReturnValue5 = returnValue5;
            
             return ContractHandler.SendRequestAsync(onERC1155ReceivedFunction);
        }

        public virtual Task<TransactionReceipt> OnERC1155ReceivedRequestAndWaitForReceiptAsync(string returnValue1, string returnValue2, BigInteger returnValue3, BigInteger returnValue4, byte[] returnValue5, CancellationTokenSource cancellationToken = null)
        {
            var onERC1155ReceivedFunction = new OnERC1155ReceivedFunction();
                onERC1155ReceivedFunction.ReturnValue1 = returnValue1;
                onERC1155ReceivedFunction.ReturnValue2 = returnValue2;
                onERC1155ReceivedFunction.ReturnValue3 = returnValue3;
                onERC1155ReceivedFunction.ReturnValue4 = returnValue4;
                onERC1155ReceivedFunction.ReturnValue5 = returnValue5;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(onERC1155ReceivedFunction, cancellationToken);
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
                typeof(OnERC1155BatchReceivedFunction),
                typeof(OnERC1155ReceivedFunction),
                typeof(SupportsInterfaceFunction)
            };
        }

        public override List<Type> GetAllEventTypes()
        {
            return new List<Type>
            {

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
