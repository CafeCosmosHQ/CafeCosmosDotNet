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
using VisionsContracts.Land.Systems.LandItemInteractionSystem.ContractDefinition;

namespace VisionsContracts.Land.Systems.LandItemInteractionSystem
{
    public partial class LandItemInteractionSystemService: LandItemInteractionSystemServiceBase
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.IWeb3 web3, LandItemInteractionSystemDeployment landItemInteractionSystemDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<LandItemInteractionSystemDeployment>().SendRequestAndWaitForReceiptAsync(landItemInteractionSystemDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.IWeb3 web3, LandItemInteractionSystemDeployment landItemInteractionSystemDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<LandItemInteractionSystemDeployment>().SendRequestAsync(landItemInteractionSystemDeployment);
        }

        public static async Task<LandItemInteractionSystemService> DeployContractAndGetServiceAsync(Nethereum.Web3.IWeb3 web3, LandItemInteractionSystemDeployment landItemInteractionSystemDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, landItemInteractionSystemDeployment, cancellationTokenSource);
            return new LandItemInteractionSystemService(web3, receipt.ContractAddress);
        }

        public LandItemInteractionSystemService(Nethereum.Web3.IWeb3 web3, string contractAddress) : base(web3, contractAddress)
        {
        }

    }


    public partial class LandItemInteractionSystemServiceBase: ContractWeb3ServiceBase
    {

        public LandItemInteractionSystemServiceBase(Nethereum.Web3.IWeb3 web3, string contractAddress) : base(web3, contractAddress)
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

        public virtual Task<string> MoveItemRequestAsync(MoveItemFunction moveItemFunction)
        {
             return ContractHandler.SendRequestAsync(moveItemFunction);
        }

        public virtual Task<TransactionReceipt> MoveItemRequestAndWaitForReceiptAsync(MoveItemFunction moveItemFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(moveItemFunction, cancellationToken);
        }

        public virtual Task<string> MoveItemRequestAsync(BigInteger landId, BigInteger srcX, BigInteger srcY, BigInteger dstX, BigInteger dstY)
        {
            var moveItemFunction = new MoveItemFunction();
                moveItemFunction.LandId = landId;
                moveItemFunction.SrcX = srcX;
                moveItemFunction.SrcY = srcY;
                moveItemFunction.DstX = dstX;
                moveItemFunction.DstY = dstY;
            
             return ContractHandler.SendRequestAsync(moveItemFunction);
        }

        public virtual Task<TransactionReceipt> MoveItemRequestAndWaitForReceiptAsync(BigInteger landId, BigInteger srcX, BigInteger srcY, BigInteger dstX, BigInteger dstY, CancellationTokenSource cancellationToken = null)
        {
            var moveItemFunction = new MoveItemFunction();
                moveItemFunction.LandId = landId;
                moveItemFunction.SrcX = srcX;
                moveItemFunction.SrcY = srcY;
                moveItemFunction.DstX = dstX;
                moveItemFunction.DstY = dstY;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(moveItemFunction, cancellationToken);
        }

        public virtual Task<string> PlaceItemRequestAsync(PlaceItemFunction placeItemFunction)
        {
             return ContractHandler.SendRequestAsync(placeItemFunction);
        }

        public virtual Task<TransactionReceipt> PlaceItemRequestAndWaitForReceiptAsync(PlaceItemFunction placeItemFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(placeItemFunction, cancellationToken);
        }

        public virtual Task<string> PlaceItemRequestAsync(BigInteger landId, BigInteger x, BigInteger y, BigInteger itemId)
        {
            var placeItemFunction = new PlaceItemFunction();
                placeItemFunction.LandId = landId;
                placeItemFunction.X = x;
                placeItemFunction.Y = y;
                placeItemFunction.ItemId = itemId;
            
             return ContractHandler.SendRequestAsync(placeItemFunction);
        }

        public virtual Task<TransactionReceipt> PlaceItemRequestAndWaitForReceiptAsync(BigInteger landId, BigInteger x, BigInteger y, BigInteger itemId, CancellationTokenSource cancellationToken = null)
        {
            var placeItemFunction = new PlaceItemFunction();
                placeItemFunction.LandId = landId;
                placeItemFunction.X = x;
                placeItemFunction.Y = y;
                placeItemFunction.ItemId = itemId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(placeItemFunction, cancellationToken);
        }

        public virtual Task<string> RemoveItemRequestAsync(RemoveItemFunction removeItemFunction)
        {
             return ContractHandler.SendRequestAsync(removeItemFunction);
        }

        public virtual Task<TransactionReceipt> RemoveItemRequestAndWaitForReceiptAsync(RemoveItemFunction removeItemFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeItemFunction, cancellationToken);
        }

        public virtual Task<string> RemoveItemRequestAsync(BigInteger landId, BigInteger x, BigInteger y)
        {
            var removeItemFunction = new RemoveItemFunction();
                removeItemFunction.LandId = landId;
                removeItemFunction.X = x;
                removeItemFunction.Y = y;
            
             return ContractHandler.SendRequestAsync(removeItemFunction);
        }

        public virtual Task<TransactionReceipt> RemoveItemRequestAndWaitForReceiptAsync(BigInteger landId, BigInteger x, BigInteger y, CancellationTokenSource cancellationToken = null)
        {
            var removeItemFunction = new RemoveItemFunction();
                removeItemFunction.LandId = landId;
                removeItemFunction.X = x;
                removeItemFunction.Y = y;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeItemFunction, cancellationToken);
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

        public virtual Task<string> TimestampCheckRequestAsync(TimestampCheckFunction timestampCheckFunction)
        {
             return ContractHandler.SendRequestAsync(timestampCheckFunction);
        }

        public virtual Task<string> TimestampCheckRequestAsync()
        {
             return ContractHandler.SendRequestAsync<TimestampCheckFunction>();
        }

        public virtual Task<TransactionReceipt> TimestampCheckRequestAndWaitForReceiptAsync(TimestampCheckFunction timestampCheckFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(timestampCheckFunction, cancellationToken);
        }

        public virtual Task<TransactionReceipt> TimestampCheckRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<TimestampCheckFunction>(null, cancellationToken);
        }

        public virtual Task<string> ToggleRotationRequestAsync(ToggleRotationFunction toggleRotationFunction)
        {
             return ContractHandler.SendRequestAsync(toggleRotationFunction);
        }

        public virtual Task<TransactionReceipt> ToggleRotationRequestAndWaitForReceiptAsync(ToggleRotationFunction toggleRotationFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(toggleRotationFunction, cancellationToken);
        }

        public virtual Task<string> ToggleRotationRequestAsync(BigInteger landId, BigInteger x, BigInteger y, BigInteger z)
        {
            var toggleRotationFunction = new ToggleRotationFunction();
                toggleRotationFunction.LandId = landId;
                toggleRotationFunction.X = x;
                toggleRotationFunction.Y = y;
                toggleRotationFunction.Z = z;
            
             return ContractHandler.SendRequestAsync(toggleRotationFunction);
        }

        public virtual Task<TransactionReceipt> ToggleRotationRequestAndWaitForReceiptAsync(BigInteger landId, BigInteger x, BigInteger y, BigInteger z, CancellationTokenSource cancellationToken = null)
        {
            var toggleRotationFunction = new ToggleRotationFunction();
                toggleRotationFunction.LandId = landId;
                toggleRotationFunction.X = x;
                toggleRotationFunction.Y = y;
                toggleRotationFunction.Z = z;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(toggleRotationFunction, cancellationToken);
        }

        public override List<Type> GetAllFunctionTypes()
        {
            return new List<Type>
            {
                typeof(MsgSenderFunction),
                typeof(MsgValueFunction),
                typeof(WorldFunction),
                typeof(MoveItemFunction),
                typeof(PlaceItemFunction),
                typeof(RemoveItemFunction),
                typeof(SupportsInterfaceFunction),
                typeof(TimestampCheckFunction),
                typeof(ToggleRotationFunction)
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
                typeof(AccessByNoOperatorError),
                typeof(SliceOutofboundsError),
                typeof(TransformationIncompatibleError)
            };
        }
    }
}
