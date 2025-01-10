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
using VisionsContracts.Land.Systems.LandCreationSystem.ContractDefinition;

namespace VisionsContracts.Land.Systems.LandCreationSystem
{
    public partial class LandCreationSystemService: LandCreationSystemServiceBase
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.IWeb3 web3, LandCreationSystemDeployment landCreationSystemDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<LandCreationSystemDeployment>().SendRequestAndWaitForReceiptAsync(landCreationSystemDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.IWeb3 web3, LandCreationSystemDeployment landCreationSystemDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<LandCreationSystemDeployment>().SendRequestAsync(landCreationSystemDeployment);
        }

        public static async Task<LandCreationSystemService> DeployContractAndGetServiceAsync(Nethereum.Web3.IWeb3 web3, LandCreationSystemDeployment landCreationSystemDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, landCreationSystemDeployment, cancellationTokenSource);
            return new LandCreationSystemService(web3, receipt.ContractAddress);
        }

        public LandCreationSystemService(Nethereum.Web3.IWeb3 web3, string contractAddress) : base(web3, contractAddress)
        {
        }

    }


    public partial class LandCreationSystemServiceBase: ContractWeb3ServiceBase
    {

        public LandCreationSystemServiceBase(Nethereum.Web3.IWeb3 web3, string contractAddress) : base(web3, contractAddress)
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

        public Task<BigInteger> CalculateAreaQueryAsync(CalculateAreaFunction calculateAreaFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CalculateAreaFunction, BigInteger>(calculateAreaFunction, blockParameter);
        }

        
        public virtual Task<BigInteger> CalculateAreaQueryAsync(BigInteger x, BigInteger y, BlockParameter blockParameter = null)
        {
            var calculateAreaFunction = new CalculateAreaFunction();
                calculateAreaFunction.X = x;
                calculateAreaFunction.Y = y;
            
            return ContractHandler.QueryAsync<CalculateAreaFunction, BigInteger>(calculateAreaFunction, blockParameter);
        }

        public Task<BigInteger> CalculateExpansionAreaQueryAsync(CalculateExpansionAreaFunction calculateExpansionAreaFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CalculateExpansionAreaFunction, BigInteger>(calculateExpansionAreaFunction, blockParameter);
        }

        
        public virtual Task<BigInteger> CalculateExpansionAreaQueryAsync(BigInteger landId, BigInteger x1, BigInteger y1, BlockParameter blockParameter = null)
        {
            var calculateExpansionAreaFunction = new CalculateExpansionAreaFunction();
                calculateExpansionAreaFunction.LandId = landId;
                calculateExpansionAreaFunction.X1 = x1;
                calculateExpansionAreaFunction.Y1 = y1;
            
            return ContractHandler.QueryAsync<CalculateExpansionAreaFunction, BigInteger>(calculateExpansionAreaFunction, blockParameter);
        }

        public Task<BigInteger> CalculateLandCostQueryAsync(CalculateLandCostFunction calculateLandCostFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CalculateLandCostFunction, BigInteger>(calculateLandCostFunction, blockParameter);
        }

        
        public virtual Task<BigInteger> CalculateLandCostQueryAsync(BigInteger x0, BigInteger y0, BlockParameter blockParameter = null)
        {
            var calculateLandCostFunction = new CalculateLandCostFunction();
                calculateLandCostFunction.X0 = x0;
                calculateLandCostFunction.Y0 = y0;
            
            return ContractHandler.QueryAsync<CalculateLandCostFunction, BigInteger>(calculateLandCostFunction, blockParameter);
        }

        public Task<BigInteger> CalculateLandExpansionCostQueryAsync(CalculateLandExpansionCostFunction calculateLandExpansionCostFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CalculateLandExpansionCostFunction, BigInteger>(calculateLandExpansionCostFunction, blockParameter);
        }

        
        public virtual Task<BigInteger> CalculateLandExpansionCostQueryAsync(BigInteger landId, BigInteger x1, BigInteger y1, BlockParameter blockParameter = null)
        {
            var calculateLandExpansionCostFunction = new CalculateLandExpansionCostFunction();
                calculateLandExpansionCostFunction.LandId = landId;
                calculateLandExpansionCostFunction.X1 = x1;
                calculateLandExpansionCostFunction.Y1 = y1;
            
            return ContractHandler.QueryAsync<CalculateLandExpansionCostFunction, BigInteger>(calculateLandExpansionCostFunction, blockParameter);
        }

        public Task<BigInteger> CalculateLandInitialPurchaseCostQueryAsync(CalculateLandInitialPurchaseCostFunction calculateLandInitialPurchaseCostFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CalculateLandInitialPurchaseCostFunction, BigInteger>(calculateLandInitialPurchaseCostFunction, blockParameter);
        }

        
        public virtual Task<BigInteger> CalculateLandInitialPurchaseCostQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CalculateLandInitialPurchaseCostFunction, BigInteger>(null, blockParameter);
        }

        public Task<BigInteger> CalculateVrgdaCostQueryAsync(CalculateVrgdaCostFunction calculateVrgdaCostFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CalculateVrgdaCostFunction, BigInteger>(calculateVrgdaCostFunction, blockParameter);
        }

        
        public virtual Task<BigInteger> CalculateVrgdaCostQueryAsync(BigInteger area, BlockParameter blockParameter = null)
        {
            var calculateVrgdaCostFunction = new CalculateVrgdaCostFunction();
                calculateVrgdaCostFunction.Area = area;
            
            return ContractHandler.QueryAsync<CalculateVrgdaCostFunction, BigInteger>(calculateVrgdaCostFunction, blockParameter);
        }

        public virtual Task<string> CreateLandRequestAsync(CreateLandFunction createLandFunction)
        {
             return ContractHandler.SendRequestAsync(createLandFunction);
        }

        public virtual Task<TransactionReceipt> CreateLandRequestAndWaitForReceiptAsync(CreateLandFunction createLandFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createLandFunction, cancellationToken);
        }

        public virtual Task<string> CreateLandRequestAsync(BigInteger limitX, BigInteger limitY)
        {
            var createLandFunction = new CreateLandFunction();
                createLandFunction.LimitX = limitX;
                createLandFunction.LimitY = limitY;
            
             return ContractHandler.SendRequestAsync(createLandFunction);
        }

        public virtual Task<TransactionReceipt> CreateLandRequestAndWaitForReceiptAsync(BigInteger limitX, BigInteger limitY, CancellationTokenSource cancellationToken = null)
        {
            var createLandFunction = new CreateLandFunction();
                createLandFunction.LimitX = limitX;
                createLandFunction.LimitY = limitY;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createLandFunction, cancellationToken);
        }

        public virtual Task<string> CreatePlayerInitialLandRequestAsync(CreatePlayerInitialLandFunction createPlayerInitialLandFunction)
        {
             return ContractHandler.SendRequestAsync(createPlayerInitialLandFunction);
        }

        public virtual Task<string> CreatePlayerInitialLandRequestAsync()
        {
             return ContractHandler.SendRequestAsync<CreatePlayerInitialLandFunction>();
        }

        public virtual Task<TransactionReceipt> CreatePlayerInitialLandRequestAndWaitForReceiptAsync(CreatePlayerInitialLandFunction createPlayerInitialLandFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createPlayerInitialLandFunction, cancellationToken);
        }

        public virtual Task<TransactionReceipt> CreatePlayerInitialLandRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<CreatePlayerInitialLandFunction>(null, cancellationToken);
        }

        public virtual Task<string> ExpandLandRequestAsync(ExpandLandFunction expandLandFunction)
        {
             return ContractHandler.SendRequestAsync(expandLandFunction);
        }

        public virtual Task<TransactionReceipt> ExpandLandRequestAndWaitForReceiptAsync(ExpandLandFunction expandLandFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(expandLandFunction, cancellationToken);
        }

        public virtual Task<string> ExpandLandRequestAsync(BigInteger landId, BigInteger x1, BigInteger y1)
        {
            var expandLandFunction = new ExpandLandFunction();
                expandLandFunction.LandId = landId;
                expandLandFunction.X1 = x1;
                expandLandFunction.Y1 = y1;
            
             return ContractHandler.SendRequestAsync(expandLandFunction);
        }

        public virtual Task<TransactionReceipt> ExpandLandRequestAndWaitForReceiptAsync(BigInteger landId, BigInteger x1, BigInteger y1, CancellationTokenSource cancellationToken = null)
        {
            var expandLandFunction = new ExpandLandFunction();
                expandLandFunction.LandId = landId;
                expandLandFunction.X1 = x1;
                expandLandFunction.Y1 = y1;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(expandLandFunction, cancellationToken);
        }

        public virtual Task<string> GenerateChunkRequestAsync(GenerateChunkFunction generateChunkFunction)
        {
             return ContractHandler.SendRequestAsync(generateChunkFunction);
        }

        public virtual Task<TransactionReceipt> GenerateChunkRequestAndWaitForReceiptAsync(GenerateChunkFunction generateChunkFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(generateChunkFunction, cancellationToken);
        }

        public virtual Task<string> GenerateChunkRequestAsync(BigInteger landId)
        {
            var generateChunkFunction = new GenerateChunkFunction();
                generateChunkFunction.LandId = landId;
            
             return ContractHandler.SendRequestAsync(generateChunkFunction);
        }

        public virtual Task<TransactionReceipt> GenerateChunkRequestAndWaitForReceiptAsync(BigInteger landId, CancellationTokenSource cancellationToken = null)
        {
            var generateChunkFunction = new GenerateChunkFunction();
                generateChunkFunction.LandId = landId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(generateChunkFunction, cancellationToken);
        }

        public virtual Task<string> SetInitialLandItemsRequestAsync(SetInitialLandItemsFunction setInitialLandItemsFunction)
        {
             return ContractHandler.SendRequestAsync(setInitialLandItemsFunction);
        }

        public virtual Task<TransactionReceipt> SetInitialLandItemsRequestAndWaitForReceiptAsync(SetInitialLandItemsFunction setInitialLandItemsFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setInitialLandItemsFunction, cancellationToken);
        }

        public virtual Task<string> SetInitialLandItemsRequestAsync(List<InitialLandItem> items, BigInteger landIndex, BigInteger initialLandItemsDefaultIndex)
        {
            var setInitialLandItemsFunction = new SetInitialLandItemsFunction();
                setInitialLandItemsFunction.Items = items;
                setInitialLandItemsFunction.LandIndex = landIndex;
                setInitialLandItemsFunction.InitialLandItemsDefaultIndex = initialLandItemsDefaultIndex;
            
             return ContractHandler.SendRequestAsync(setInitialLandItemsFunction);
        }

        public virtual Task<TransactionReceipt> SetInitialLandItemsRequestAndWaitForReceiptAsync(List<InitialLandItem> items, BigInteger landIndex, BigInteger initialLandItemsDefaultIndex, CancellationTokenSource cancellationToken = null)
        {
            var setInitialLandItemsFunction = new SetInitialLandItemsFunction();
                setInitialLandItemsFunction.Items = items;
                setInitialLandItemsFunction.LandIndex = landIndex;
                setInitialLandItemsFunction.InitialLandItemsDefaultIndex = initialLandItemsDefaultIndex;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setInitialLandItemsFunction, cancellationToken);
        }

        public virtual Task<string> SetInitialLandLimitsRequestAsync(SetInitialLandLimitsFunction setInitialLandLimitsFunction)
        {
             return ContractHandler.SendRequestAsync(setInitialLandLimitsFunction);
        }

        public virtual Task<TransactionReceipt> SetInitialLandLimitsRequestAndWaitForReceiptAsync(SetInitialLandLimitsFunction setInitialLandLimitsFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setInitialLandLimitsFunction, cancellationToken);
        }

        public virtual Task<string> SetInitialLandLimitsRequestAsync(BigInteger limitX, BigInteger limitY)
        {
            var setInitialLandLimitsFunction = new SetInitialLandLimitsFunction();
                setInitialLandLimitsFunction.LimitX = limitX;
                setInitialLandLimitsFunction.LimitY = limitY;
            
             return ContractHandler.SendRequestAsync(setInitialLandLimitsFunction);
        }

        public virtual Task<TransactionReceipt> SetInitialLandLimitsRequestAndWaitForReceiptAsync(BigInteger limitX, BigInteger limitY, CancellationTokenSource cancellationToken = null)
        {
            var setInitialLandLimitsFunction = new SetInitialLandLimitsFunction();
                setInitialLandLimitsFunction.LimitX = limitX;
                setInitialLandLimitsFunction.LimitY = limitY;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setInitialLandLimitsFunction, cancellationToken);
        }

        public virtual Task<string> SetLandNameRequestAsync(SetLandNameFunction setLandNameFunction)
        {
             return ContractHandler.SendRequestAsync(setLandNameFunction);
        }

        public virtual Task<TransactionReceipt> SetLandNameRequestAndWaitForReceiptAsync(SetLandNameFunction setLandNameFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setLandNameFunction, cancellationToken);
        }

        public virtual Task<string> SetLandNameRequestAsync(BigInteger landId, string name)
        {
            var setLandNameFunction = new SetLandNameFunction();
                setLandNameFunction.LandId = landId;
                setLandNameFunction.Name = name;
            
             return ContractHandler.SendRequestAsync(setLandNameFunction);
        }

        public virtual Task<TransactionReceipt> SetLandNameRequestAndWaitForReceiptAsync(BigInteger landId, string name, CancellationTokenSource cancellationToken = null)
        {
            var setLandNameFunction = new SetLandNameFunction();
                setLandNameFunction.LandId = landId;
                setLandNameFunction.Name = name;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setLandNameFunction, cancellationToken);
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
                typeof(CalculateAreaFunction),
                typeof(CalculateExpansionAreaFunction),
                typeof(CalculateLandCostFunction),
                typeof(CalculateLandExpansionCostFunction),
                typeof(CalculateLandInitialPurchaseCostFunction),
                typeof(CalculateVrgdaCostFunction),
                typeof(CreateLandFunction),
                typeof(CreatePlayerInitialLandFunction),
                typeof(ExpandLandFunction),
                typeof(GenerateChunkFunction),
                typeof(SetInitialLandItemsFunction),
                typeof(SetInitialLandLimitsFunction),
                typeof(SetLandNameFunction),
                typeof(SupportsInterfaceFunction)
            };
        }

        public override List<Type> GetAllEventTypes()
        {
            return new List<Type>
            {
                typeof(LandCreatedEventDTO),
                typeof(LandExpandedEventDTO),
                typeof(LandPurchaseEventDTO),
                typeof(StoreDeleterecordEventDTO),
                typeof(StoreSetrecordEventDTO),
                typeof(StoreSplicedynamicdataEventDTO),
                typeof(StoreSplicestaticdataEventDTO)
            };
        }

        public override List<Type> GetAllErrorTypes()
        {
            return new List<Type>
            {
                typeof(AccessByNoOperatorError),
                typeof(EncodedlengthsInvalidlengthError),
                typeof(SliceOutofboundsError),
                typeof(StoreIndexoutofboundsError),
                typeof(StoreInvalidresourcetypeError),
                typeof(StoreInvalidspliceError),
                typeof(WorldAccessdeniedError)
            };
        }
    }
}
