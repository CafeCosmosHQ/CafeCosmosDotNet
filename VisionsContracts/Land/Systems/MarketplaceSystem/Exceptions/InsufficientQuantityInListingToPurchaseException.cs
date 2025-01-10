using System;
using System.Numerics;
using System.Runtime.Serialization;
using VisionsContracts.Land.Systems.MarketplaceSystem.ContractDefinition;

namespace VisionsContracts.Land.Systems.MarketplaceSystem.Exceptions
{
    [Serializable]
    internal class InsufficientQuantityInMarketplaceListingToPurchaseException : Exception
    {
        public MarketPlaceListingDTO Listing { get; }
        public BigInteger Quantity { get; }

     
        public InsufficientQuantityInMarketplaceListingToPurchaseException(MarketPlaceListingDTO listing, BigInteger quantity) : base($"Insufficient quantity {listing.Quantity} in marketplace listing {listing.ListingId} to purchase {quantity}")
        {
            Listing = listing;
            Quantity = quantity;
        }


    }
}