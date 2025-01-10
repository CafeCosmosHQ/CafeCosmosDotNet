using Nethereum.RPC.Eth.DTOs;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using VisionsContracts.Items;
using VisionsContracts.Land.Systems.MarketplaceSystem.ContractDefinition;
using VisionsContracts.Land.Systems.MarketplaceSystem.Exceptions;
using VisionsContracts.Land.Systems.MarketplaceSystem.Model;
using VisionsContracts.PlayerBalancePurchasing;

namespace VisionsContracts.Land.Systems.MarketplaceSystem
{
    public partial class MarketplaceSystemService
    {
        public async Task<List<MarketPlaceListing>> GetMarketPlaceListingsAsync()
        {
            var marketPlaceListings = new List<MarketPlaceListing>();
            var marketPlaceListingResult = await GetAllListingsQueryAsync();
            foreach (var marketPlaceListingDTO in marketPlaceListingResult.MarketPlaceListings)
            {
                marketPlaceListings.Add(new MarketPlaceListing
                {
                    ListingId = marketPlaceListingDTO.ListingId,
                    Owner = marketPlaceListingDTO.Owner,
                    ItemId = marketPlaceListingDTO.ItemId,
                    Item = DefaultItems.FindItemById(marketPlaceListingDTO.ItemId),
                    UnitPrice = marketPlaceListingDTO.UnitPrice,
                    Quantity = marketPlaceListingDTO.Quantity
                });
            }
            return marketPlaceListings;
        }

        public async Task<string> BuyValidateAndApproveItemRequestAsync(BigInteger landId, BigInteger listingId, BigInteger quantity, PlayerBalancePurchasingService playerBalancePurchasingService, bool useToken = false)
        {
            var request = await GeneratePurchaseRequestAndApprovalAsync(landId, listingId, quantity, playerBalancePurchasingService, useToken);
            return await BuyItemRequestAsync(request);
        }

        public async Task<TransactionReceipt> BuyValidateAndApproveItemRequestAndWaitForReceiptAsync(BigInteger landId, BigInteger listingId, BigInteger quantity, PlayerBalancePurchasingService playerBalancePurchasingService, bool useToken = false)
        {
            var request = await GeneratePurchaseRequestAndApprovalAsync(landId, listingId, quantity, playerBalancePurchasingService, useToken);
            return await BuyItemRequestAndWaitForReceiptAsync(request);
        }

        private async Task<BuyItemFunction> GeneratePurchaseRequestAndApprovalAsync(BigInteger landId, BigInteger listingId, BigInteger quantity, PlayerBalancePurchasingService playerBalancePurchasingService, bool useToken)
        {
            var listingResponse = await GetListingQueryAsync(listingId);
            var listing = listingResponse.MarketPlaceListing;
            if (listing.Quantity < quantity)
            {
                throw new InsufficientQuantityInMarketplaceListingToPurchaseException(listing, quantity);
            }

            var totalCost = listing.UnitPrice * quantity;

            var request = await playerBalancePurchasingService.ValidateBalanceApproveAndBuildPurchaseRequestAsync<BuyItemFunction>(totalCost, useToken);
            request.LandId = landId;
            request.ListingId = listingId;
            request.Quantity = quantity;
            return request;
        }
    }
}
