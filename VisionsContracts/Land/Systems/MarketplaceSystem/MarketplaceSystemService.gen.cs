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
using VisionsContracts.Land.Systems.MarketplaceSystem.ContractDefinition;

namespace VisionsContracts.Land.Systems.MarketplaceSystem
{
    public partial class MarketplaceSystemService: MarketplaceSystemServiceBase
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.IWeb3 web3, MarketplaceSystemDeployment marketplaceSystemDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<MarketplaceSystemDeployment>().SendRequestAndWaitForReceiptAsync(marketplaceSystemDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.IWeb3 web3, MarketplaceSystemDeployment marketplaceSystemDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<MarketplaceSystemDeployment>().SendRequestAsync(marketplaceSystemDeployment);
        }

        public static async Task<MarketplaceSystemService> DeployContractAndGetServiceAsync(Nethereum.Web3.IWeb3 web3, MarketplaceSystemDeployment marketplaceSystemDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, marketplaceSystemDeployment, cancellationTokenSource);
            return new MarketplaceSystemService(web3, receipt.ContractAddress);
        }

        public MarketplaceSystemService(Nethereum.Web3.IWeb3 web3, string contractAddress) : base(web3, contractAddress)
        {
        }

    }


    public partial class MarketplaceSystemServiceBase: ContractWeb3ServiceBase
    {

        public MarketplaceSystemServiceBase(Nethereum.Web3.IWeb3 web3, string contractAddress) : base(web3, contractAddress)
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

        public virtual Task<string> BuyItemRequestAsync(BuyItemFunction buyItemFunction)
        {
             return ContractHandler.SendRequestAsync(buyItemFunction);
        }

        public virtual Task<TransactionReceipt> BuyItemRequestAndWaitForReceiptAsync(BuyItemFunction buyItemFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(buyItemFunction, cancellationToken);
        }

        public virtual Task<string> BuyItemRequestAsync(BigInteger landId, BigInteger listingId, BigInteger quantity)
        {
            var buyItemFunction = new BuyItemFunction();
                buyItemFunction.LandId = landId;
                buyItemFunction.ListingId = listingId;
                buyItemFunction.Quantity = quantity;
            
             return ContractHandler.SendRequestAsync(buyItemFunction);
        }

        public virtual Task<TransactionReceipt> BuyItemRequestAndWaitForReceiptAsync(BigInteger landId, BigInteger listingId, BigInteger quantity, CancellationTokenSource cancellationToken = null)
        {
            var buyItemFunction = new BuyItemFunction();
                buyItemFunction.LandId = landId;
                buyItemFunction.ListingId = listingId;
                buyItemFunction.Quantity = quantity;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(buyItemFunction, cancellationToken);
        }

        public virtual Task<string> CancelListingRequestAsync(CancelListingFunction cancelListingFunction)
        {
             return ContractHandler.SendRequestAsync(cancelListingFunction);
        }

        public virtual Task<TransactionReceipt> CancelListingRequestAndWaitForReceiptAsync(CancelListingFunction cancelListingFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(cancelListingFunction, cancellationToken);
        }

        public virtual Task<string> CancelListingRequestAsync(BigInteger landId, BigInteger listingId)
        {
            var cancelListingFunction = new CancelListingFunction();
                cancelListingFunction.LandId = landId;
                cancelListingFunction.ListingId = listingId;
            
             return ContractHandler.SendRequestAsync(cancelListingFunction);
        }

        public virtual Task<TransactionReceipt> CancelListingRequestAndWaitForReceiptAsync(BigInteger landId, BigInteger listingId, CancellationTokenSource cancellationToken = null)
        {
            var cancelListingFunction = new CancelListingFunction();
                cancelListingFunction.LandId = landId;
                cancelListingFunction.ListingId = listingId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(cancelListingFunction, cancellationToken);
        }

        public virtual Task<string> EditListingRequestAsync(EditListingFunction editListingFunction)
        {
             return ContractHandler.SendRequestAsync(editListingFunction);
        }

        public virtual Task<TransactionReceipt> EditListingRequestAndWaitForReceiptAsync(EditListingFunction editListingFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(editListingFunction, cancellationToken);
        }

        public virtual Task<string> EditListingRequestAsync(BigInteger landId, BigInteger listingId, BigInteger price, BigInteger quantity)
        {
            var editListingFunction = new EditListingFunction();
                editListingFunction.LandId = landId;
                editListingFunction.ListingId = listingId;
                editListingFunction.Price = price;
                editListingFunction.Quantity = quantity;
            
             return ContractHandler.SendRequestAsync(editListingFunction);
        }

        public virtual Task<TransactionReceipt> EditListingRequestAndWaitForReceiptAsync(BigInteger landId, BigInteger listingId, BigInteger price, BigInteger quantity, CancellationTokenSource cancellationToken = null)
        {
            var editListingFunction = new EditListingFunction();
                editListingFunction.LandId = landId;
                editListingFunction.ListingId = listingId;
                editListingFunction.Price = price;
                editListingFunction.Quantity = quantity;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(editListingFunction, cancellationToken);
        }

        public virtual Task<GetAllListingsOutputDTO> GetAllListingsQueryAsync(GetAllListingsFunction getAllListingsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetAllListingsFunction, GetAllListingsOutputDTO>(getAllListingsFunction, blockParameter);
        }

        public virtual Task<GetAllListingsOutputDTO> GetAllListingsQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetAllListingsFunction, GetAllListingsOutputDTO>(null, blockParameter);
        }

        public virtual Task<GetListingOutputDTO> GetListingQueryAsync(GetListingFunction getListingFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetListingFunction, GetListingOutputDTO>(getListingFunction, blockParameter);
        }

        public virtual Task<GetListingOutputDTO> GetListingQueryAsync(BigInteger listingId, BlockParameter blockParameter = null)
        {
            var getListingFunction = new GetListingFunction();
                getListingFunction.ListingId = listingId;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetListingFunction, GetListingOutputDTO>(getListingFunction, blockParameter);
        }

        public virtual Task<string> ListItemRequestAsync(ListItemFunction listItemFunction)
        {
             return ContractHandler.SendRequestAsync(listItemFunction);
        }

        public virtual Task<TransactionReceipt> ListItemRequestAndWaitForReceiptAsync(ListItemFunction listItemFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(listItemFunction, cancellationToken);
        }

        public virtual Task<string> ListItemRequestAsync(BigInteger landId, BigInteger itemId, BigInteger price, BigInteger quantity)
        {
            var listItemFunction = new ListItemFunction();
                listItemFunction.LandId = landId;
                listItemFunction.ItemId = itemId;
                listItemFunction.Price = price;
                listItemFunction.Quantity = quantity;
            
             return ContractHandler.SendRequestAsync(listItemFunction);
        }

        public virtual Task<TransactionReceipt> ListItemRequestAndWaitForReceiptAsync(BigInteger landId, BigInteger itemId, BigInteger price, BigInteger quantity, CancellationTokenSource cancellationToken = null)
        {
            var listItemFunction = new ListItemFunction();
                listItemFunction.LandId = landId;
                listItemFunction.ItemId = itemId;
                listItemFunction.Price = price;
                listItemFunction.Quantity = quantity;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(listItemFunction, cancellationToken);
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
                typeof(BuyItemFunction),
                typeof(CancelListingFunction),
                typeof(EditListingFunction),
                typeof(GetAllListingsFunction),
                typeof(GetListingFunction),
                typeof(ListItemFunction),
                typeof(SupportsInterfaceFunction)
            };
        }

        public override List<Type> GetAllEventTypes()
        {
            return new List<Type>
            {
                typeof(MarketplaceItemCancelledEventDTO),
                typeof(MarketplaceItemListedEventDTO),
                typeof(MarketplaceItemPurchasedEventDTO),
                typeof(StoreDeleterecordEventDTO),
                typeof(StoreSetrecordEventDTO),
                typeof(StoreSplicestaticdataEventDTO)
            };
        }

        public override List<Type> GetAllErrorTypes()
        {
            return new List<Type>
            {
                typeof(AccessByNoOperatorError),
                typeof(SliceOutofboundsError)
            };
        }
    }
}
