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
using VisionsContracts.Land.Systems.CatalogueSystem.ContractDefinition;

namespace VisionsContracts.Land.Systems.CatalogueSystem
{
    public partial class CatalogueSystemService: CatalogueSystemServiceBase
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.IWeb3 web3, CatalogueSystemDeployment catalogueSystemDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<CatalogueSystemDeployment>().SendRequestAndWaitForReceiptAsync(catalogueSystemDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.IWeb3 web3, CatalogueSystemDeployment catalogueSystemDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<CatalogueSystemDeployment>().SendRequestAsync(catalogueSystemDeployment);
        }

        public static async Task<CatalogueSystemService> DeployContractAndGetServiceAsync(Nethereum.Web3.IWeb3 web3, CatalogueSystemDeployment catalogueSystemDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, catalogueSystemDeployment, cancellationTokenSource);
            return new CatalogueSystemService(web3, receipt.ContractAddress);
        }

        public CatalogueSystemService(Nethereum.Web3.IWeb3 web3, string contractAddress) : base(web3, contractAddress)
        {
        }

    }


    public partial class CatalogueSystemServiceBase: ContractWeb3ServiceBase
    {

        public CatalogueSystemServiceBase(Nethereum.Web3.IWeb3 web3, string contractAddress) : base(web3, contractAddress)
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

        public Task<BigInteger> GetTotalCostQueryAsync(GetTotalCostFunction getTotalCostFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetTotalCostFunction, BigInteger>(getTotalCostFunction, blockParameter);
        }

        
        public virtual Task<BigInteger> GetTotalCostQueryAsync(List<CatalogueItemPurchaseDTO> items, BlockParameter blockParameter = null)
        {
            var getTotalCostFunction = new GetTotalCostFunction();
                getTotalCostFunction.Items = items;
            
            return ContractHandler.QueryAsync<GetTotalCostFunction, BigInteger>(getTotalCostFunction, blockParameter);
        }

        public virtual Task<GetTotalCostAndSufficientBalanceToPurchaseItemOutputDTO> GetTotalCostAndSufficientBalanceToPurchaseItemQueryAsync(GetTotalCostAndSufficientBalanceToPurchaseItemFunction getTotalCostAndSufficientBalanceToPurchaseItemFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetTotalCostAndSufficientBalanceToPurchaseItemFunction, GetTotalCostAndSufficientBalanceToPurchaseItemOutputDTO>(getTotalCostAndSufficientBalanceToPurchaseItemFunction, blockParameter);
        }

        public virtual Task<GetTotalCostAndSufficientBalanceToPurchaseItemOutputDTO> GetTotalCostAndSufficientBalanceToPurchaseItemQueryAsync(BigInteger landId, BigInteger itemId, BigInteger quantity, BlockParameter blockParameter = null)
        {
            var getTotalCostAndSufficientBalanceToPurchaseItemFunction = new GetTotalCostAndSufficientBalanceToPurchaseItemFunction();
                getTotalCostAndSufficientBalanceToPurchaseItemFunction.LandId = landId;
                getTotalCostAndSufficientBalanceToPurchaseItemFunction.ItemId = itemId;
                getTotalCostAndSufficientBalanceToPurchaseItemFunction.Quantity = quantity;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetTotalCostAndSufficientBalanceToPurchaseItemFunction, GetTotalCostAndSufficientBalanceToPurchaseItemOutputDTO>(getTotalCostAndSufficientBalanceToPurchaseItemFunction, blockParameter);
        }

        public virtual Task<GetTotalCostAndSufficientBalanceToPurchaseItemsOutputDTO> GetTotalCostAndSufficientBalanceToPurchaseItemsQueryAsync(GetTotalCostAndSufficientBalanceToPurchaseItemsFunction getTotalCostAndSufficientBalanceToPurchaseItemsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetTotalCostAndSufficientBalanceToPurchaseItemsFunction, GetTotalCostAndSufficientBalanceToPurchaseItemsOutputDTO>(getTotalCostAndSufficientBalanceToPurchaseItemsFunction, blockParameter);
        }

        public virtual Task<GetTotalCostAndSufficientBalanceToPurchaseItemsOutputDTO> GetTotalCostAndSufficientBalanceToPurchaseItemsQueryAsync(BigInteger landId, List<CatalogueItemPurchaseDTO> items, BlockParameter blockParameter = null)
        {
            var getTotalCostAndSufficientBalanceToPurchaseItemsFunction = new GetTotalCostAndSufficientBalanceToPurchaseItemsFunction();
                getTotalCostAndSufficientBalanceToPurchaseItemsFunction.LandId = landId;
                getTotalCostAndSufficientBalanceToPurchaseItemsFunction.Items = items;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetTotalCostAndSufficientBalanceToPurchaseItemsFunction, GetTotalCostAndSufficientBalanceToPurchaseItemsOutputDTO>(getTotalCostAndSufficientBalanceToPurchaseItemsFunction, blockParameter);
        }

        public virtual Task<string> PurchaseCatalogueItemRequestAsync(PurchaseCatalogueItemFunction purchaseCatalogueItemFunction)
        {
             return ContractHandler.SendRequestAsync(purchaseCatalogueItemFunction);
        }

        public virtual Task<TransactionReceipt> PurchaseCatalogueItemRequestAndWaitForReceiptAsync(PurchaseCatalogueItemFunction purchaseCatalogueItemFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(purchaseCatalogueItemFunction, cancellationToken);
        }

        public virtual Task<string> PurchaseCatalogueItemRequestAsync(BigInteger landId, BigInteger itemId, BigInteger quantity)
        {
            var purchaseCatalogueItemFunction = new PurchaseCatalogueItemFunction();
                purchaseCatalogueItemFunction.LandId = landId;
                purchaseCatalogueItemFunction.ItemId = itemId;
                purchaseCatalogueItemFunction.Quantity = quantity;
            
             return ContractHandler.SendRequestAsync(purchaseCatalogueItemFunction);
        }

        public virtual Task<TransactionReceipt> PurchaseCatalogueItemRequestAndWaitForReceiptAsync(BigInteger landId, BigInteger itemId, BigInteger quantity, CancellationTokenSource cancellationToken = null)
        {
            var purchaseCatalogueItemFunction = new PurchaseCatalogueItemFunction();
                purchaseCatalogueItemFunction.LandId = landId;
                purchaseCatalogueItemFunction.ItemId = itemId;
                purchaseCatalogueItemFunction.Quantity = quantity;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(purchaseCatalogueItemFunction, cancellationToken);
        }

        public virtual Task<string> PurchaseCatalogueItemsRequestAsync(PurchaseCatalogueItemsFunction purchaseCatalogueItemsFunction)
        {
             return ContractHandler.SendRequestAsync(purchaseCatalogueItemsFunction);
        }

        public virtual Task<TransactionReceipt> PurchaseCatalogueItemsRequestAndWaitForReceiptAsync(PurchaseCatalogueItemsFunction purchaseCatalogueItemsFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(purchaseCatalogueItemsFunction, cancellationToken);
        }

        public virtual Task<string> PurchaseCatalogueItemsRequestAsync(BigInteger landId, List<CatalogueItemPurchaseDTO> items)
        {
            var purchaseCatalogueItemsFunction = new PurchaseCatalogueItemsFunction();
                purchaseCatalogueItemsFunction.LandId = landId;
                purchaseCatalogueItemsFunction.Items = items;
            
             return ContractHandler.SendRequestAsync(purchaseCatalogueItemsFunction);
        }

        public virtual Task<TransactionReceipt> PurchaseCatalogueItemsRequestAndWaitForReceiptAsync(BigInteger landId, List<CatalogueItemPurchaseDTO> items, CancellationTokenSource cancellationToken = null)
        {
            var purchaseCatalogueItemsFunction = new PurchaseCatalogueItemsFunction();
                purchaseCatalogueItemsFunction.LandId = landId;
                purchaseCatalogueItemsFunction.Items = items;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(purchaseCatalogueItemsFunction, cancellationToken);
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

        public virtual Task<string> UpsertCatalogueItemsRequestAsync(UpsertCatalogueItemsFunction upsertCatalogueItemsFunction)
        {
             return ContractHandler.SendRequestAsync(upsertCatalogueItemsFunction);
        }

        public virtual Task<TransactionReceipt> UpsertCatalogueItemsRequestAndWaitForReceiptAsync(UpsertCatalogueItemsFunction upsertCatalogueItemsFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(upsertCatalogueItemsFunction, cancellationToken);
        }

        public virtual Task<string> UpsertCatalogueItemsRequestAsync(List<CatalogueItemDTO> items)
        {
            var upsertCatalogueItemsFunction = new UpsertCatalogueItemsFunction();
                upsertCatalogueItemsFunction.Items = items;
            
             return ContractHandler.SendRequestAsync(upsertCatalogueItemsFunction);
        }

        public virtual Task<TransactionReceipt> UpsertCatalogueItemsRequestAndWaitForReceiptAsync(List<CatalogueItemDTO> items, CancellationTokenSource cancellationToken = null)
        {
            var upsertCatalogueItemsFunction = new UpsertCatalogueItemsFunction();
                upsertCatalogueItemsFunction.Items = items;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(upsertCatalogueItemsFunction, cancellationToken);
        }

        public override List<Type> GetAllFunctionTypes()
        {
            return new List<Type>
            {
                typeof(MsgSenderFunction),
                typeof(MsgValueFunction),
                typeof(WorldFunction),
                typeof(GetTotalCostFunction),
                typeof(GetTotalCostAndSufficientBalanceToPurchaseItemFunction),
                typeof(GetTotalCostAndSufficientBalanceToPurchaseItemsFunction),
                typeof(PurchaseCatalogueItemFunction),
                typeof(PurchaseCatalogueItemsFunction),
                typeof(SupportsInterfaceFunction),
                typeof(UpsertCatalogueItemsFunction)
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
                typeof(AccessByNoOperatorError),
                typeof(SliceOutofboundsError),
                typeof(WorldAccessdeniedError)
            };
        }
    }
}
