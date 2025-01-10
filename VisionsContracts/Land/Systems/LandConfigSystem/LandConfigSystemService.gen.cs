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
using VisionsContracts.Land.Systems.LandConfigSystem.ContractDefinition;

namespace VisionsContracts.Land.Systems.LandConfigSystem
{
    public partial class LandConfigSystemService: LandConfigSystemServiceBase
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.IWeb3 web3, LandConfigSystemDeployment landConfigSystemDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<LandConfigSystemDeployment>().SendRequestAndWaitForReceiptAsync(landConfigSystemDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.IWeb3 web3, LandConfigSystemDeployment landConfigSystemDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<LandConfigSystemDeployment>().SendRequestAsync(landConfigSystemDeployment);
        }

        public static async Task<LandConfigSystemService> DeployContractAndGetServiceAsync(Nethereum.Web3.IWeb3 web3, LandConfigSystemDeployment landConfigSystemDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, landConfigSystemDeployment, cancellationTokenSource);
            return new LandConfigSystemService(web3, receipt.ContractAddress);
        }

        public LandConfigSystemService(Nethereum.Web3.IWeb3 web3, string contractAddress) : base(web3, contractAddress)
        {
        }

    }


    public partial class LandConfigSystemServiceBase: ContractWeb3ServiceBase
    {

        public LandConfigSystemServiceBase(Nethereum.Web3.IWeb3 web3, string contractAddress) : base(web3, contractAddress)
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

        public virtual Task<string> ApproveLandOperatorRequestAsync(ApproveLandOperatorFunction approveLandOperatorFunction)
        {
             return ContractHandler.SendRequestAsync(approveLandOperatorFunction);
        }

        public virtual Task<TransactionReceipt> ApproveLandOperatorRequestAndWaitForReceiptAsync(ApproveLandOperatorFunction approveLandOperatorFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(approveLandOperatorFunction, cancellationToken);
        }

        public virtual Task<string> ApproveLandOperatorRequestAsync(BigInteger landId, string @operator, bool status)
        {
            var approveLandOperatorFunction = new ApproveLandOperatorFunction();
                approveLandOperatorFunction.LandId = landId;
                approveLandOperatorFunction.Operator = @operator;
                approveLandOperatorFunction.Status = status;
            
             return ContractHandler.SendRequestAsync(approveLandOperatorFunction);
        }

        public virtual Task<TransactionReceipt> ApproveLandOperatorRequestAndWaitForReceiptAsync(BigInteger landId, string @operator, bool status, CancellationTokenSource cancellationToken = null)
        {
            var approveLandOperatorFunction = new ApproveLandOperatorFunction();
                approveLandOperatorFunction.LandId = landId;
                approveLandOperatorFunction.Operator = @operator;
                approveLandOperatorFunction.Status = status;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(approveLandOperatorFunction, cancellationToken);
        }

        public Task<BigInteger> GetActiveStovesQueryAsync(GetActiveStovesFunction getActiveStovesFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetActiveStovesFunction, BigInteger>(getActiveStovesFunction, blockParameter);
        }

        
        public virtual Task<BigInteger> GetActiveStovesQueryAsync(BigInteger stoveId, BlockParameter blockParameter = null)
        {
            var getActiveStovesFunction = new GetActiveStovesFunction();
                getActiveStovesFunction.StoveId = stoveId;
            
            return ContractHandler.QueryAsync<GetActiveStovesFunction, BigInteger>(getActiveStovesFunction, blockParameter);
        }

        public Task<BigInteger> GetCookingCostQueryAsync(GetCookingCostFunction getCookingCostFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetCookingCostFunction, BigInteger>(getCookingCostFunction, blockParameter);
        }

        
        public virtual Task<BigInteger> GetCookingCostQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetCookingCostFunction, BigInteger>(null, blockParameter);
        }

        public virtual Task<GetLandInfoOutputDTO> GetLandInfoQueryAsync(GetLandInfoFunction getLandInfoFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetLandInfoFunction, GetLandInfoOutputDTO>(getLandInfoFunction, blockParameter);
        }

        public virtual Task<GetLandInfoOutputDTO> GetLandInfoQueryAsync(BigInteger landId, BlockParameter blockParameter = null)
        {
            var getLandInfoFunction = new GetLandInfoFunction();
                getLandInfoFunction.LandId = landId;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetLandInfoFunction, GetLandInfoOutputDTO>(getLandInfoFunction, blockParameter);
        }

        public Task<string> GetLandTablesAndChairsAddressQueryAsync(GetLandTablesAndChairsAddressFunction getLandTablesAndChairsAddressFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetLandTablesAndChairsAddressFunction, string>(getLandTablesAndChairsAddressFunction, blockParameter);
        }

        
        public virtual Task<string> GetLandTablesAndChairsAddressQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetLandTablesAndChairsAddressFunction, string>(null, blockParameter);
        }

        public Task<BigInteger> GetSoftCostPerSquareQueryAsync(GetSoftCostPerSquareFunction getSoftCostPerSquareFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetSoftCostPerSquareFunction, BigInteger>(getSoftCostPerSquareFunction, blockParameter);
        }

        
        public virtual Task<BigInteger> GetSoftCostPerSquareQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetSoftCostPerSquareFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> GetSoftDestinationAddressQueryAsync(GetSoftDestinationAddressFunction getSoftDestinationAddressFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetSoftDestinationAddressFunction, string>(getSoftDestinationAddressFunction, blockParameter);
        }

        
        public virtual Task<string> GetSoftDestinationAddressQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetSoftDestinationAddressFunction, string>(null, blockParameter);
        }

        public Task<string> GetSoftTokenQueryAsync(GetSoftTokenFunction getSoftTokenFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetSoftTokenFunction, string>(getSoftTokenFunction, blockParameter);
        }

        
        public virtual Task<string> GetSoftTokenQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetSoftTokenFunction, string>(null, blockParameter);
        }

        public virtual Task<string> SetChairRequestAsync(SetChairFunction setChairFunction)
        {
             return ContractHandler.SendRequestAsync(setChairFunction);
        }

        public virtual Task<TransactionReceipt> SetChairRequestAndWaitForReceiptAsync(SetChairFunction setChairFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setChairFunction, cancellationToken);
        }

        public virtual Task<string> SetChairRequestAsync(BigInteger chair, bool isChair)
        {
            var setChairFunction = new SetChairFunction();
                setChairFunction.Chair = chair;
                setChairFunction.IsChair = isChair;
            
             return ContractHandler.SendRequestAsync(setChairFunction);
        }

        public virtual Task<TransactionReceipt> SetChairRequestAndWaitForReceiptAsync(BigInteger chair, bool isChair, CancellationTokenSource cancellationToken = null)
        {
            var setChairFunction = new SetChairFunction();
                setChairFunction.Chair = chair;
                setChairFunction.IsChair = isChair;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setChairFunction, cancellationToken);
        }

        public virtual Task<string> SetChunkSizeRequestAsync(SetChunkSizeFunction setChunkSizeFunction)
        {
             return ContractHandler.SendRequestAsync(setChunkSizeFunction);
        }

        public virtual Task<TransactionReceipt> SetChunkSizeRequestAndWaitForReceiptAsync(SetChunkSizeFunction setChunkSizeFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setChunkSizeFunction, cancellationToken);
        }

        public virtual Task<string> SetChunkSizeRequestAsync(BigInteger chunkSize)
        {
            var setChunkSizeFunction = new SetChunkSizeFunction();
                setChunkSizeFunction.ChunkSize = chunkSize;
            
             return ContractHandler.SendRequestAsync(setChunkSizeFunction);
        }

        public virtual Task<TransactionReceipt> SetChunkSizeRequestAndWaitForReceiptAsync(BigInteger chunkSize, CancellationTokenSource cancellationToken = null)
        {
            var setChunkSizeFunction = new SetChunkSizeFunction();
                setChunkSizeFunction.ChunkSize = chunkSize;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setChunkSizeFunction, cancellationToken);
        }

        public virtual Task<string> SetCookingCostRequestAsync(SetCookingCostFunction setCookingCostFunction)
        {
             return ContractHandler.SendRequestAsync(setCookingCostFunction);
        }

        public virtual Task<TransactionReceipt> SetCookingCostRequestAndWaitForReceiptAsync(SetCookingCostFunction setCookingCostFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setCookingCostFunction, cancellationToken);
        }

        public virtual Task<string> SetCookingCostRequestAsync(BigInteger cookingcost)
        {
            var setCookingCostFunction = new SetCookingCostFunction();
                setCookingCostFunction.Cookingcost = cookingcost;
            
             return ContractHandler.SendRequestAsync(setCookingCostFunction);
        }

        public virtual Task<TransactionReceipt> SetCookingCostRequestAndWaitForReceiptAsync(BigInteger cookingcost, CancellationTokenSource cancellationToken = null)
        {
            var setCookingCostFunction = new SetCookingCostFunction();
                setCookingCostFunction.Cookingcost = cookingcost;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setCookingCostFunction, cancellationToken);
        }

        public virtual Task<string> SetIsStackableRequestAsync(SetIsStackableFunction setIsStackableFunction)
        {
             return ContractHandler.SendRequestAsync(setIsStackableFunction);
        }

        public virtual Task<TransactionReceipt> SetIsStackableRequestAndWaitForReceiptAsync(SetIsStackableFunction setIsStackableFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setIsStackableFunction, cancellationToken);
        }

        public virtual Task<string> SetIsStackableRequestAsync(BigInteger @base, BigInteger input, bool isStackable)
        {
            var setIsStackableFunction = new SetIsStackableFunction();
                setIsStackableFunction.Base = @base;
                setIsStackableFunction.Input = input;
                setIsStackableFunction.IsStackable = isStackable;
            
             return ContractHandler.SendRequestAsync(setIsStackableFunction);
        }

        public virtual Task<TransactionReceipt> SetIsStackableRequestAndWaitForReceiptAsync(BigInteger @base, BigInteger input, bool isStackable, CancellationTokenSource cancellationToken = null)
        {
            var setIsStackableFunction = new SetIsStackableFunction();
                setIsStackableFunction.Base = @base;
                setIsStackableFunction.Input = input;
                setIsStackableFunction.IsStackable = isStackable;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setIsStackableFunction, cancellationToken);
        }

        public virtual Task<string> SetItemConfigAddressRequestAsync(SetItemConfigAddressFunction setItemConfigAddressFunction)
        {
             return ContractHandler.SendRequestAsync(setItemConfigAddressFunction);
        }

        public virtual Task<TransactionReceipt> SetItemConfigAddressRequestAndWaitForReceiptAsync(SetItemConfigAddressFunction setItemConfigAddressFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setItemConfigAddressFunction, cancellationToken);
        }

        public virtual Task<string> SetItemConfigAddressRequestAsync(string itemconfigaddress)
        {
            var setItemConfigAddressFunction = new SetItemConfigAddressFunction();
                setItemConfigAddressFunction.Itemconfigaddress = itemconfigaddress;
            
             return ContractHandler.SendRequestAsync(setItemConfigAddressFunction);
        }

        public virtual Task<TransactionReceipt> SetItemConfigAddressRequestAndWaitForReceiptAsync(string itemconfigaddress, CancellationTokenSource cancellationToken = null)
        {
            var setItemConfigAddressFunction = new SetItemConfigAddressFunction();
                setItemConfigAddressFunction.Itemconfigaddress = itemconfigaddress;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setItemConfigAddressFunction, cancellationToken);
        }

        public virtual Task<string> SetItemsRequestAsync(SetItemsFunction setItemsFunction)
        {
             return ContractHandler.SendRequestAsync(setItemsFunction);
        }

        public virtual Task<TransactionReceipt> SetItemsRequestAndWaitForReceiptAsync(SetItemsFunction setItemsFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setItemsFunction, cancellationToken);
        }

        public virtual Task<string> SetItemsRequestAsync(string items)
        {
            var setItemsFunction = new SetItemsFunction();
                setItemsFunction.Items = items;
            
             return ContractHandler.SendRequestAsync(setItemsFunction);
        }

        public virtual Task<TransactionReceipt> SetItemsRequestAndWaitForReceiptAsync(string items, CancellationTokenSource cancellationToken = null)
        {
            var setItemsFunction = new SetItemsFunction();
                setItemsFunction.Items = items;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setItemsFunction, cancellationToken);
        }

        public virtual Task<string> SetItemsRequestAsync(SetItems1Function setItems1Function)
        {
             return ContractHandler.SendRequestAsync(setItems1Function);
        }

        public virtual Task<TransactionReceipt> SetItemsRequestAndWaitForReceiptAsync(SetItems1Function setItems1Function, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setItems1Function, cancellationToken);
        }

        public virtual Task<string> SetItemsRequestAsync(List<ItemInfoDTO> items)
        {
            var setItems1Function = new SetItems1Function();
                setItems1Function.Items = items;
            
             return ContractHandler.SendRequestAsync(setItems1Function);
        }

        public virtual Task<TransactionReceipt> SetItemsRequestAndWaitForReceiptAsync(List<ItemInfoDTO> items, CancellationTokenSource cancellationToken = null)
        {
            var setItems1Function = new SetItems1Function();
                setItems1Function.Items = items;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setItems1Function, cancellationToken);
        }

        public virtual Task<string> SetLandNFTsRequestAsync(SetLandNFTsFunction setLandNFTsFunction)
        {
             return ContractHandler.SendRequestAsync(setLandNFTsFunction);
        }

        public virtual Task<TransactionReceipt> SetLandNFTsRequestAndWaitForReceiptAsync(SetLandNFTsFunction setLandNFTsFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setLandNFTsFunction, cancellationToken);
        }

        public virtual Task<string> SetLandNFTsRequestAsync(string landnfts)
        {
            var setLandNFTsFunction = new SetLandNFTsFunction();
                setLandNFTsFunction.Landnfts = landnfts;
            
             return ContractHandler.SendRequestAsync(setLandNFTsFunction);
        }

        public virtual Task<TransactionReceipt> SetLandNFTsRequestAndWaitForReceiptAsync(string landnfts, CancellationTokenSource cancellationToken = null)
        {
            var setLandNFTsFunction = new SetLandNFTsFunction();
                setLandNFTsFunction.Landnfts = landnfts;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setLandNFTsFunction, cancellationToken);
        }

        public virtual Task<string> SetLandQuestTaskProgressUpdateAddressRequestAsync(SetLandQuestTaskProgressUpdateAddressFunction setLandQuestTaskProgressUpdateAddressFunction)
        {
             return ContractHandler.SendRequestAsync(setLandQuestTaskProgressUpdateAddressFunction);
        }

        public virtual Task<TransactionReceipt> SetLandQuestTaskProgressUpdateAddressRequestAndWaitForReceiptAsync(SetLandQuestTaskProgressUpdateAddressFunction setLandQuestTaskProgressUpdateAddressFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setLandQuestTaskProgressUpdateAddressFunction, cancellationToken);
        }

        public virtual Task<string> SetLandQuestTaskProgressUpdateAddressRequestAsync(string landquesttaskprogressupdateaddress)
        {
            var setLandQuestTaskProgressUpdateAddressFunction = new SetLandQuestTaskProgressUpdateAddressFunction();
                setLandQuestTaskProgressUpdateAddressFunction.Landquesttaskprogressupdateaddress = landquesttaskprogressupdateaddress;
            
             return ContractHandler.SendRequestAsync(setLandQuestTaskProgressUpdateAddressFunction);
        }

        public virtual Task<TransactionReceipt> SetLandQuestTaskProgressUpdateAddressRequestAndWaitForReceiptAsync(string landquesttaskprogressupdateaddress, CancellationTokenSource cancellationToken = null)
        {
            var setLandQuestTaskProgressUpdateAddressFunction = new SetLandQuestTaskProgressUpdateAddressFunction();
                setLandQuestTaskProgressUpdateAddressFunction.Landquesttaskprogressupdateaddress = landquesttaskprogressupdateaddress;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setLandQuestTaskProgressUpdateAddressFunction, cancellationToken);
        }

        public virtual Task<string> SetLandTablesAndChairsAddressRequestAsync(SetLandTablesAndChairsAddressFunction setLandTablesAndChairsAddressFunction)
        {
             return ContractHandler.SendRequestAsync(setLandTablesAndChairsAddressFunction);
        }

        public virtual Task<TransactionReceipt> SetLandTablesAndChairsAddressRequestAndWaitForReceiptAsync(SetLandTablesAndChairsAddressFunction setLandTablesAndChairsAddressFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setLandTablesAndChairsAddressFunction, cancellationToken);
        }

        public virtual Task<string> SetLandTablesAndChairsAddressRequestAsync(string landtablesandchairsaddress)
        {
            var setLandTablesAndChairsAddressFunction = new SetLandTablesAndChairsAddressFunction();
                setLandTablesAndChairsAddressFunction.Landtablesandchairsaddress = landtablesandchairsaddress;
            
             return ContractHandler.SendRequestAsync(setLandTablesAndChairsAddressFunction);
        }

        public virtual Task<TransactionReceipt> SetLandTablesAndChairsAddressRequestAndWaitForReceiptAsync(string landtablesandchairsaddress, CancellationTokenSource cancellationToken = null)
        {
            var setLandTablesAndChairsAddressFunction = new SetLandTablesAndChairsAddressFunction();
                setLandTablesAndChairsAddressFunction.Landtablesandchairsaddress = landtablesandchairsaddress;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setLandTablesAndChairsAddressFunction, cancellationToken);
        }

        public virtual Task<string> SetLandTransformAddressRequestAsync(SetLandTransformAddressFunction setLandTransformAddressFunction)
        {
             return ContractHandler.SendRequestAsync(setLandTransformAddressFunction);
        }

        public virtual Task<TransactionReceipt> SetLandTransformAddressRequestAndWaitForReceiptAsync(SetLandTransformAddressFunction setLandTransformAddressFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setLandTransformAddressFunction, cancellationToken);
        }

        public virtual Task<string> SetLandTransformAddressRequestAsync(string landtransformaddress)
        {
            var setLandTransformAddressFunction = new SetLandTransformAddressFunction();
                setLandTransformAddressFunction.Landtransformaddress = landtransformaddress;
            
             return ContractHandler.SendRequestAsync(setLandTransformAddressFunction);
        }

        public virtual Task<TransactionReceipt> SetLandTransformAddressRequestAndWaitForReceiptAsync(string landtransformaddress, CancellationTokenSource cancellationToken = null)
        {
            var setLandTransformAddressFunction = new SetLandTransformAddressFunction();
                setLandTransformAddressFunction.Landtransformaddress = landtransformaddress;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setLandTransformAddressFunction, cancellationToken);
        }

        public virtual Task<string> SetMaxLevelRequestAsync(SetMaxLevelFunction setMaxLevelFunction)
        {
             return ContractHandler.SendRequestAsync(setMaxLevelFunction);
        }

        public virtual Task<TransactionReceipt> SetMaxLevelRequestAndWaitForReceiptAsync(SetMaxLevelFunction setMaxLevelFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setMaxLevelFunction, cancellationToken);
        }

        public virtual Task<string> SetMaxLevelRequestAsync(BigInteger maxlevel)
        {
            var setMaxLevelFunction = new SetMaxLevelFunction();
                setMaxLevelFunction.Maxlevel = maxlevel;
            
             return ContractHandler.SendRequestAsync(setMaxLevelFunction);
        }

        public virtual Task<TransactionReceipt> SetMaxLevelRequestAndWaitForReceiptAsync(BigInteger maxlevel, CancellationTokenSource cancellationToken = null)
        {
            var setMaxLevelFunction = new SetMaxLevelFunction();
                setMaxLevelFunction.Maxlevel = maxlevel;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setMaxLevelFunction, cancellationToken);
        }

        public virtual Task<string> SetMinStartingLimitsRequestAsync(SetMinStartingLimitsFunction setMinStartingLimitsFunction)
        {
             return ContractHandler.SendRequestAsync(setMinStartingLimitsFunction);
        }

        public virtual Task<TransactionReceipt> SetMinStartingLimitsRequestAndWaitForReceiptAsync(SetMinStartingLimitsFunction setMinStartingLimitsFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setMinStartingLimitsFunction, cancellationToken);
        }

        public virtual Task<string> SetMinStartingLimitsRequestAsync(BigInteger minStartingX, BigInteger minStartingY)
        {
            var setMinStartingLimitsFunction = new SetMinStartingLimitsFunction();
                setMinStartingLimitsFunction.MinStartingX = minStartingX;
                setMinStartingLimitsFunction.MinStartingY = minStartingY;
            
             return ContractHandler.SendRequestAsync(setMinStartingLimitsFunction);
        }

        public virtual Task<TransactionReceipt> SetMinStartingLimitsRequestAndWaitForReceiptAsync(BigInteger minStartingX, BigInteger minStartingY, CancellationTokenSource cancellationToken = null)
        {
            var setMinStartingLimitsFunction = new SetMinStartingLimitsFunction();
                setMinStartingLimitsFunction.MinStartingX = minStartingX;
                setMinStartingLimitsFunction.MinStartingY = minStartingY;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setMinStartingLimitsFunction, cancellationToken);
        }

        public virtual Task<string> SetNonPlaceableRequestAsync(SetNonPlaceableFunction setNonPlaceableFunction)
        {
             return ContractHandler.SendRequestAsync(setNonPlaceableFunction);
        }

        public virtual Task<TransactionReceipt> SetNonPlaceableRequestAndWaitForReceiptAsync(SetNonPlaceableFunction setNonPlaceableFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setNonPlaceableFunction, cancellationToken);
        }

        public virtual Task<string> SetNonPlaceableRequestAsync(BigInteger nonPlaceable, bool placeable)
        {
            var setNonPlaceableFunction = new SetNonPlaceableFunction();
                setNonPlaceableFunction.NonPlaceable = nonPlaceable;
                setNonPlaceableFunction.Placeable = placeable;
            
             return ContractHandler.SendRequestAsync(setNonPlaceableFunction);
        }

        public virtual Task<TransactionReceipt> SetNonPlaceableRequestAndWaitForReceiptAsync(BigInteger nonPlaceable, bool placeable, CancellationTokenSource cancellationToken = null)
        {
            var setNonPlaceableFunction = new SetNonPlaceableFunction();
                setNonPlaceableFunction.NonPlaceable = nonPlaceable;
                setNonPlaceableFunction.Placeable = placeable;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setNonPlaceableFunction, cancellationToken);
        }

        public virtual Task<string> SetNonPlaceableItemsRequestAsync(SetNonPlaceableItemsFunction setNonPlaceableItemsFunction)
        {
             return ContractHandler.SendRequestAsync(setNonPlaceableItemsFunction);
        }

        public virtual Task<TransactionReceipt> SetNonPlaceableItemsRequestAndWaitForReceiptAsync(SetNonPlaceableItemsFunction setNonPlaceableItemsFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setNonPlaceableItemsFunction, cancellationToken);
        }

        public virtual Task<string> SetNonPlaceableItemsRequestAsync(List<BigInteger> items)
        {
            var setNonPlaceableItemsFunction = new SetNonPlaceableItemsFunction();
                setNonPlaceableItemsFunction.Items = items;
            
             return ContractHandler.SendRequestAsync(setNonPlaceableItemsFunction);
        }

        public virtual Task<TransactionReceipt> SetNonPlaceableItemsRequestAndWaitForReceiptAsync(List<BigInteger> items, CancellationTokenSource cancellationToken = null)
        {
            var setNonPlaceableItemsFunction = new SetNonPlaceableItemsFunction();
                setNonPlaceableItemsFunction.Items = items;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setNonPlaceableItemsFunction, cancellationToken);
        }

        public virtual Task<string> SetNonRemovableRequestAsync(SetNonRemovableFunction setNonRemovableFunction)
        {
             return ContractHandler.SendRequestAsync(setNonRemovableFunction);
        }

        public virtual Task<TransactionReceipt> SetNonRemovableRequestAndWaitForReceiptAsync(SetNonRemovableFunction setNonRemovableFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setNonRemovableFunction, cancellationToken);
        }

        public virtual Task<string> SetNonRemovableRequestAsync(BigInteger nonRemovables, bool removable)
        {
            var setNonRemovableFunction = new SetNonRemovableFunction();
                setNonRemovableFunction.NonRemovables = nonRemovables;
                setNonRemovableFunction.Removable = removable;
            
             return ContractHandler.SendRequestAsync(setNonRemovableFunction);
        }

        public virtual Task<TransactionReceipt> SetNonRemovableRequestAndWaitForReceiptAsync(BigInteger nonRemovables, bool removable, CancellationTokenSource cancellationToken = null)
        {
            var setNonRemovableFunction = new SetNonRemovableFunction();
                setNonRemovableFunction.NonRemovables = nonRemovables;
                setNonRemovableFunction.Removable = removable;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setNonRemovableFunction, cancellationToken);
        }

        public virtual Task<string> SetNonRemovableItemsRequestAsync(SetNonRemovableItemsFunction setNonRemovableItemsFunction)
        {
             return ContractHandler.SendRequestAsync(setNonRemovableItemsFunction);
        }

        public virtual Task<TransactionReceipt> SetNonRemovableItemsRequestAndWaitForReceiptAsync(SetNonRemovableItemsFunction setNonRemovableItemsFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setNonRemovableItemsFunction, cancellationToken);
        }

        public virtual Task<string> SetNonRemovableItemsRequestAsync(List<BigInteger> items)
        {
            var setNonRemovableItemsFunction = new SetNonRemovableItemsFunction();
                setNonRemovableItemsFunction.Items = items;
            
             return ContractHandler.SendRequestAsync(setNonRemovableItemsFunction);
        }

        public virtual Task<TransactionReceipt> SetNonRemovableItemsRequestAndWaitForReceiptAsync(List<BigInteger> items, CancellationTokenSource cancellationToken = null)
        {
            var setNonRemovableItemsFunction = new SetNonRemovableItemsFunction();
                setNonRemovableItemsFunction.Items = items;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setNonRemovableItemsFunction, cancellationToken);
        }

        public virtual Task<string> SetRedistributorRequestAsync(SetRedistributorFunction setRedistributorFunction)
        {
             return ContractHandler.SendRequestAsync(setRedistributorFunction);
        }

        public virtual Task<TransactionReceipt> SetRedistributorRequestAndWaitForReceiptAsync(SetRedistributorFunction setRedistributorFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setRedistributorFunction, cancellationToken);
        }

        public virtual Task<string> SetRedistributorRequestAsync(string redistributor)
        {
            var setRedistributorFunction = new SetRedistributorFunction();
                setRedistributorFunction.Redistributor = redistributor;
            
             return ContractHandler.SendRequestAsync(setRedistributorFunction);
        }

        public virtual Task<TransactionReceipt> SetRedistributorRequestAndWaitForReceiptAsync(string redistributor, CancellationTokenSource cancellationToken = null)
        {
            var setRedistributorFunction = new SetRedistributorFunction();
                setRedistributorFunction.Redistributor = redistributor;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setRedistributorFunction, cancellationToken);
        }

        public virtual Task<string> SetReturnItemsRequestAsync(SetReturnItemsFunction setReturnItemsFunction)
        {
             return ContractHandler.SendRequestAsync(setReturnItemsFunction);
        }

        public virtual Task<TransactionReceipt> SetReturnItemsRequestAndWaitForReceiptAsync(SetReturnItemsFunction setReturnItemsFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setReturnItemsFunction, cancellationToken);
        }

        public virtual Task<string> SetReturnItemsRequestAsync(List<BigInteger> items, List<BigInteger> itemsReturned)
        {
            var setReturnItemsFunction = new SetReturnItemsFunction();
                setReturnItemsFunction.Items = items;
                setReturnItemsFunction.ItemsReturned = itemsReturned;
            
             return ContractHandler.SendRequestAsync(setReturnItemsFunction);
        }

        public virtual Task<TransactionReceipt> SetReturnItemsRequestAndWaitForReceiptAsync(List<BigInteger> items, List<BigInteger> itemsReturned, CancellationTokenSource cancellationToken = null)
        {
            var setReturnItemsFunction = new SetReturnItemsFunction();
                setReturnItemsFunction.Items = items;
                setReturnItemsFunction.ItemsReturned = itemsReturned;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setReturnItemsFunction, cancellationToken);
        }

        public virtual Task<string> SetReturnsItemRequestAsync(SetReturnsItemFunction setReturnsItemFunction)
        {
             return ContractHandler.SendRequestAsync(setReturnsItemFunction);
        }

        public virtual Task<TransactionReceipt> SetReturnsItemRequestAndWaitForReceiptAsync(SetReturnsItemFunction setReturnsItemFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setReturnsItemFunction, cancellationToken);
        }

        public virtual Task<string> SetReturnsItemRequestAsync(BigInteger itemId, BigInteger itemReturned)
        {
            var setReturnsItemFunction = new SetReturnsItemFunction();
                setReturnsItemFunction.ItemId = itemId;
                setReturnsItemFunction.ItemReturned = itemReturned;
            
             return ContractHandler.SendRequestAsync(setReturnsItemFunction);
        }

        public virtual Task<TransactionReceipt> SetReturnsItemRequestAndWaitForReceiptAsync(BigInteger itemId, BigInteger itemReturned, CancellationTokenSource cancellationToken = null)
        {
            var setReturnsItemFunction = new SetReturnsItemFunction();
                setReturnsItemFunction.ItemId = itemId;
                setReturnsItemFunction.ItemReturned = itemReturned;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setReturnsItemFunction, cancellationToken);
        }

        public virtual Task<string> SetRotatableRequestAsync(SetRotatableFunction setRotatableFunction)
        {
             return ContractHandler.SendRequestAsync(setRotatableFunction);
        }

        public virtual Task<TransactionReceipt> SetRotatableRequestAndWaitForReceiptAsync(SetRotatableFunction setRotatableFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setRotatableFunction, cancellationToken);
        }

        public virtual Task<string> SetRotatableRequestAsync(List<BigInteger> itemIds, bool isRotatable)
        {
            var setRotatableFunction = new SetRotatableFunction();
                setRotatableFunction.ItemIds = itemIds;
                setRotatableFunction.IsRotatable = isRotatable;
            
             return ContractHandler.SendRequestAsync(setRotatableFunction);
        }

        public virtual Task<TransactionReceipt> SetRotatableRequestAndWaitForReceiptAsync(List<BigInteger> itemIds, bool isRotatable, CancellationTokenSource cancellationToken = null)
        {
            var setRotatableFunction = new SetRotatableFunction();
                setRotatableFunction.ItemIds = itemIds;
                setRotatableFunction.IsRotatable = isRotatable;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setRotatableFunction, cancellationToken);
        }

        public virtual Task<string> SetSoftCostPerSquareRequestAsync(SetSoftCostPerSquareFunction setSoftCostPerSquareFunction)
        {
             return ContractHandler.SendRequestAsync(setSoftCostPerSquareFunction);
        }

        public virtual Task<TransactionReceipt> SetSoftCostPerSquareRequestAndWaitForReceiptAsync(SetSoftCostPerSquareFunction setSoftCostPerSquareFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setSoftCostPerSquareFunction, cancellationToken);
        }

        public virtual Task<string> SetSoftCostPerSquareRequestAsync(BigInteger softcost)
        {
            var setSoftCostPerSquareFunction = new SetSoftCostPerSquareFunction();
                setSoftCostPerSquareFunction.Softcost = softcost;
            
             return ContractHandler.SendRequestAsync(setSoftCostPerSquareFunction);
        }

        public virtual Task<TransactionReceipt> SetSoftCostPerSquareRequestAndWaitForReceiptAsync(BigInteger softcost, CancellationTokenSource cancellationToken = null)
        {
            var setSoftCostPerSquareFunction = new SetSoftCostPerSquareFunction();
                setSoftCostPerSquareFunction.Softcost = softcost;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setSoftCostPerSquareFunction, cancellationToken);
        }

        public virtual Task<string> SetSoftDestinationRequestAsync(SetSoftDestinationFunction setSoftDestinationFunction)
        {
             return ContractHandler.SendRequestAsync(setSoftDestinationFunction);
        }

        public virtual Task<TransactionReceipt> SetSoftDestinationRequestAndWaitForReceiptAsync(SetSoftDestinationFunction setSoftDestinationFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setSoftDestinationFunction, cancellationToken);
        }

        public virtual Task<string> SetSoftDestinationRequestAsync(string softdestination)
        {
            var setSoftDestinationFunction = new SetSoftDestinationFunction();
                setSoftDestinationFunction.Softdestination = softdestination;
            
             return ContractHandler.SendRequestAsync(setSoftDestinationFunction);
        }

        public virtual Task<TransactionReceipt> SetSoftDestinationRequestAndWaitForReceiptAsync(string softdestination, CancellationTokenSource cancellationToken = null)
        {
            var setSoftDestinationFunction = new SetSoftDestinationFunction();
                setSoftDestinationFunction.Softdestination = softdestination;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setSoftDestinationFunction, cancellationToken);
        }

        public virtual Task<string> SetSoftTokenRequestAsync(SetSoftTokenFunction setSoftTokenFunction)
        {
             return ContractHandler.SendRequestAsync(setSoftTokenFunction);
        }

        public virtual Task<TransactionReceipt> SetSoftTokenRequestAndWaitForReceiptAsync(SetSoftTokenFunction setSoftTokenFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setSoftTokenFunction, cancellationToken);
        }

        public virtual Task<string> SetSoftTokenRequestAsync(string softtoken)
        {
            var setSoftTokenFunction = new SetSoftTokenFunction();
                setSoftTokenFunction.Softtoken = softtoken;
            
             return ContractHandler.SendRequestAsync(setSoftTokenFunction);
        }

        public virtual Task<TransactionReceipt> SetSoftTokenRequestAndWaitForReceiptAsync(string softtoken, CancellationTokenSource cancellationToken = null)
        {
            var setSoftTokenFunction = new SetSoftTokenFunction();
                setSoftTokenFunction.Softtoken = softtoken;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setSoftTokenFunction, cancellationToken);
        }

        public virtual Task<string> SetStackableItemsRequestAsync(SetStackableItemsFunction setStackableItemsFunction)
        {
             return ContractHandler.SendRequestAsync(setStackableItemsFunction);
        }

        public virtual Task<TransactionReceipt> SetStackableItemsRequestAndWaitForReceiptAsync(SetStackableItemsFunction setStackableItemsFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setStackableItemsFunction, cancellationToken);
        }

        public virtual Task<string> SetStackableItemsRequestAsync(List<StackableItemDTO> stackableItems)
        {
            var setStackableItemsFunction = new SetStackableItemsFunction();
                setStackableItemsFunction.StackableItems = stackableItems;
            
             return ContractHandler.SendRequestAsync(setStackableItemsFunction);
        }

        public virtual Task<TransactionReceipt> SetStackableItemsRequestAndWaitForReceiptAsync(List<StackableItemDTO> stackableItems, CancellationTokenSource cancellationToken = null)
        {
            var setStackableItemsFunction = new SetStackableItemsFunction();
                setStackableItemsFunction.StackableItems = stackableItems;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setStackableItemsFunction, cancellationToken);
        }

        public virtual Task<string> SetTableRequestAsync(SetTableFunction setTableFunction)
        {
             return ContractHandler.SendRequestAsync(setTableFunction);
        }

        public virtual Task<TransactionReceipt> SetTableRequestAndWaitForReceiptAsync(SetTableFunction setTableFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setTableFunction, cancellationToken);
        }

        public virtual Task<string> SetTableRequestAsync(BigInteger table, bool isTable)
        {
            var setTableFunction = new SetTableFunction();
                setTableFunction.Table = table;
                setTableFunction.IsTable = isTable;
            
             return ContractHandler.SendRequestAsync(setTableFunction);
        }

        public virtual Task<TransactionReceipt> SetTableRequestAndWaitForReceiptAsync(BigInteger table, bool isTable, CancellationTokenSource cancellationToken = null)
        {
            var setTableFunction = new SetTableFunction();
                setTableFunction.Table = table;
                setTableFunction.IsTable = isTable;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setTableFunction, cancellationToken);
        }

        public virtual Task<string> SetToolRequestAsync(SetToolFunction setToolFunction)
        {
             return ContractHandler.SendRequestAsync(setToolFunction);
        }

        public virtual Task<TransactionReceipt> SetToolRequestAndWaitForReceiptAsync(SetToolFunction setToolFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setToolFunction, cancellationToken);
        }

        public virtual Task<string> SetToolRequestAsync(BigInteger tool, bool isTool)
        {
            var setToolFunction = new SetToolFunction();
                setToolFunction.Tool = tool;
                setToolFunction.IsTool = isTool;
            
             return ContractHandler.SendRequestAsync(setToolFunction);
        }

        public virtual Task<TransactionReceipt> SetToolRequestAndWaitForReceiptAsync(BigInteger tool, bool isTool, CancellationTokenSource cancellationToken = null)
        {
            var setToolFunction = new SetToolFunction();
                setToolFunction.Tool = tool;
                setToolFunction.IsTool = isTool;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setToolFunction, cancellationToken);
        }

        public virtual Task<string> SetVestingRequestAsync(SetVestingFunction setVestingFunction)
        {
             return ContractHandler.SendRequestAsync(setVestingFunction);
        }

        public virtual Task<TransactionReceipt> SetVestingRequestAndWaitForReceiptAsync(SetVestingFunction setVestingFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setVestingFunction, cancellationToken);
        }

        public virtual Task<string> SetVestingRequestAsync(string vesting)
        {
            var setVestingFunction = new SetVestingFunction();
                setVestingFunction.Vesting = vesting;
            
             return ContractHandler.SendRequestAsync(setVestingFunction);
        }

        public virtual Task<TransactionReceipt> SetVestingRequestAndWaitForReceiptAsync(string vesting, CancellationTokenSource cancellationToken = null)
        {
            var setVestingFunction = new SetVestingFunction();
                setVestingFunction.Vesting = vesting;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setVestingFunction, cancellationToken);
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
                typeof(ApproveLandOperatorFunction),
                typeof(GetActiveStovesFunction),
                typeof(GetCookingCostFunction),
                typeof(GetLandInfoFunction),
                typeof(GetLandTablesAndChairsAddressFunction),
                typeof(GetSoftCostPerSquareFunction),
                typeof(GetSoftDestinationAddressFunction),
                typeof(GetSoftTokenFunction),
                typeof(SetChairFunction),
                typeof(SetChunkSizeFunction),
                typeof(SetCookingCostFunction),
                typeof(SetIsStackableFunction),
                typeof(SetItemConfigAddressFunction),
                typeof(SetItemsFunction),
                typeof(SetItems1Function),
                typeof(SetLandNFTsFunction),
                typeof(SetLandQuestTaskProgressUpdateAddressFunction),
                typeof(SetLandTablesAndChairsAddressFunction),
                typeof(SetLandTransformAddressFunction),
                typeof(SetMaxLevelFunction),
                typeof(SetMinStartingLimitsFunction),
                typeof(SetNonPlaceableFunction),
                typeof(SetNonPlaceableItemsFunction),
                typeof(SetNonRemovableFunction),
                typeof(SetNonRemovableItemsFunction),
                typeof(SetRedistributorFunction),
                typeof(SetReturnItemsFunction),
                typeof(SetReturnsItemFunction),
                typeof(SetRotatableFunction),
                typeof(SetSoftCostPerSquareFunction),
                typeof(SetSoftDestinationFunction),
                typeof(SetSoftTokenFunction),
                typeof(SetStackableItemsFunction),
                typeof(SetTableFunction),
                typeof(SetToolFunction),
                typeof(SetVestingFunction),
                typeof(SupportsInterfaceFunction)
            };
        }

        public override List<Type> GetAllEventTypes()
        {
            return new List<Type>
            {
                typeof(StoreSetrecordEventDTO),
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
