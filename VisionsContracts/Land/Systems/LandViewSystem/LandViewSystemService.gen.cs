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
using VisionsContracts.Land.Systems.LandViewSystem.ContractDefinition;

namespace VisionsContracts.Land.Systems.LandViewSystem
{
    public partial class LandViewSystemService: LandViewSystemServiceBase
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.IWeb3 web3, LandViewSystemDeployment landViewSystemDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<LandViewSystemDeployment>().SendRequestAndWaitForReceiptAsync(landViewSystemDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.IWeb3 web3, LandViewSystemDeployment landViewSystemDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<LandViewSystemDeployment>().SendRequestAsync(landViewSystemDeployment);
        }

        public static async Task<LandViewSystemService> DeployContractAndGetServiceAsync(Nethereum.Web3.IWeb3 web3, LandViewSystemDeployment landViewSystemDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, landViewSystemDeployment, cancellationTokenSource);
            return new LandViewSystemService(web3, receipt.ContractAddress);
        }

        public LandViewSystemService(Nethereum.Web3.IWeb3 web3, string contractAddress) : base(web3, contractAddress)
        {
        }

    }


    public partial class LandViewSystemServiceBase: ContractWeb3ServiceBase
    {

        public LandViewSystemServiceBase(Nethereum.Web3.IWeb3 web3, string contractAddress) : base(web3, contractAddress)
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

        public Task<BigInteger> GetActiveTablesQueryAsync(GetActiveTablesFunction getActiveTablesFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetActiveTablesFunction, BigInteger>(getActiveTablesFunction, blockParameter);
        }

        
        public virtual Task<BigInteger> GetActiveTablesQueryAsync(BigInteger landId, BlockParameter blockParameter = null)
        {
            var getActiveTablesFunction = new GetActiveTablesFunction();
                getActiveTablesFunction.LandId = landId;
            
            return ContractHandler.QueryAsync<GetActiveTablesFunction, BigInteger>(getActiveTablesFunction, blockParameter);
        }

        public Task<List<BigInteger>> GetChairsOfTablesQueryAsync(GetChairsOfTablesFunction getChairsOfTablesFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetChairsOfTablesFunction, List<BigInteger>>(getChairsOfTablesFunction, blockParameter);
        }

        
        public virtual Task<List<BigInteger>> GetChairsOfTablesQueryAsync(BigInteger landId, BigInteger x, BigInteger y, BlockParameter blockParameter = null)
        {
            var getChairsOfTablesFunction = new GetChairsOfTablesFunction();
                getChairsOfTablesFunction.LandId = landId;
                getChairsOfTablesFunction.X = x;
                getChairsOfTablesFunction.Y = y;
            
            return ContractHandler.QueryAsync<GetChairsOfTablesFunction, List<BigInteger>>(getChairsOfTablesFunction, blockParameter);
        }

        public virtual Task<GetLandItemsOutputDTO> GetLandItemsQueryAsync(GetLandItemsFunction getLandItemsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetLandItemsFunction, GetLandItemsOutputDTO>(getLandItemsFunction, blockParameter);
        }

        public virtual Task<GetLandItemsOutputDTO> GetLandItemsQueryAsync(BigInteger landId, BigInteger x, BigInteger y, BlockParameter blockParameter = null)
        {
            var getLandItemsFunction = new GetLandItemsFunction();
                getLandItemsFunction.LandId = landId;
                getLandItemsFunction.X = x;
                getLandItemsFunction.Y = y;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetLandItemsFunction, GetLandItemsOutputDTO>(getLandItemsFunction, blockParameter);
        }

        public virtual Task<GetLandItems3dOutputDTO> GetLandItems3dQueryAsync(GetLandItems3dFunction getLandItems3dFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetLandItems3dFunction, GetLandItems3dOutputDTO>(getLandItems3dFunction, blockParameter);
        }

        public virtual Task<GetLandItems3dOutputDTO> GetLandItems3dQueryAsync(BigInteger landId, BlockParameter blockParameter = null)
        {
            var getLandItems3dFunction = new GetLandItems3dFunction();
                getLandItems3dFunction.LandId = landId;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetLandItems3dFunction, GetLandItems3dOutputDTO>(getLandItems3dFunction, blockParameter);
        }

        public virtual Task<GetLandsTotalEarnedOutputDTO> GetLandsTotalEarnedQueryAsync(GetLandsTotalEarnedFunction getLandsTotalEarnedFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetLandsTotalEarnedFunction, GetLandsTotalEarnedOutputDTO>(getLandsTotalEarnedFunction, blockParameter);
        }

        public virtual Task<GetLandsTotalEarnedOutputDTO> GetLandsTotalEarnedQueryAsync(List<BigInteger> landIds, BlockParameter blockParameter = null)
        {
            var getLandsTotalEarnedFunction = new GetLandsTotalEarnedFunction();
                getLandsTotalEarnedFunction.LandIds = landIds;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetLandsTotalEarnedFunction, GetLandsTotalEarnedOutputDTO>(getLandsTotalEarnedFunction, blockParameter);
        }

        public Task<BigInteger> GetPlacementTimeQueryAsync(GetPlacementTimeFunction getPlacementTimeFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetPlacementTimeFunction, BigInteger>(getPlacementTimeFunction, blockParameter);
        }

        
        public virtual Task<BigInteger> GetPlacementTimeQueryAsync(BigInteger landId, BigInteger x, BigInteger y, BlockParameter blockParameter = null)
        {
            var getPlacementTimeFunction = new GetPlacementTimeFunction();
                getPlacementTimeFunction.LandId = landId;
                getPlacementTimeFunction.X = x;
                getPlacementTimeFunction.Y = y;
            
            return ContractHandler.QueryAsync<GetPlacementTimeFunction, BigInteger>(getPlacementTimeFunction, blockParameter);
        }

        public Task<bool> GetRotationQueryAsync(GetRotationFunction getRotationFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetRotationFunction, bool>(getRotationFunction, blockParameter);
        }

        
        public virtual Task<bool> GetRotationQueryAsync(BigInteger landId, BigInteger x, BigInteger y, BlockParameter blockParameter = null)
        {
            var getRotationFunction = new GetRotationFunction();
                getRotationFunction.LandId = landId;
                getRotationFunction.X = x;
                getRotationFunction.Y = y;
            
            return ContractHandler.QueryAsync<GetRotationFunction, bool>(getRotationFunction, blockParameter);
        }

        public Task<List<BigInteger>> GetTablesOfChairsQueryAsync(GetTablesOfChairsFunction getTablesOfChairsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetTablesOfChairsFunction, List<BigInteger>>(getTablesOfChairsFunction, blockParameter);
        }

        
        public virtual Task<List<BigInteger>> GetTablesOfChairsQueryAsync(BigInteger landId, BigInteger x, BigInteger y, BlockParameter blockParameter = null)
        {
            var getTablesOfChairsFunction = new GetTablesOfChairsFunction();
                getTablesOfChairsFunction.LandId = landId;
                getTablesOfChairsFunction.X = x;
                getTablesOfChairsFunction.Y = y;
            
            return ContractHandler.QueryAsync<GetTablesOfChairsFunction, List<BigInteger>>(getTablesOfChairsFunction, blockParameter);
        }

        public virtual Task<GetTotalEarnedOutputDTO> GetTotalEarnedQueryAsync(GetTotalEarnedFunction getTotalEarnedFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetTotalEarnedFunction, GetTotalEarnedOutputDTO>(getTotalEarnedFunction, blockParameter);
        }

        public virtual Task<GetTotalEarnedOutputDTO> GetTotalEarnedQueryAsync(BigInteger landId, BlockParameter blockParameter = null)
        {
            var getTotalEarnedFunction = new GetTotalEarnedFunction();
                getTotalEarnedFunction.LandId = landId;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetTotalEarnedFunction, GetTotalEarnedOutputDTO>(getTotalEarnedFunction, blockParameter);
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
                typeof(GetActiveTablesFunction),
                typeof(GetChairsOfTablesFunction),
                typeof(GetLandItemsFunction),
                typeof(GetLandItems3dFunction),
                typeof(GetLandsTotalEarnedFunction),
                typeof(GetPlacementTimeFunction),
                typeof(GetRotationFunction),
                typeof(GetTablesOfChairsFunction),
                typeof(GetTotalEarnedFunction),
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
                typeof(SliceOutofboundsError)
            };
        }
    }
}
