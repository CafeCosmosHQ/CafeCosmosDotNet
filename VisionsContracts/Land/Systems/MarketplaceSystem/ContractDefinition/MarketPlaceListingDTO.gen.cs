using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace VisionsContracts.Land.Systems.MarketplaceSystem.ContractDefinition
{
    public partial class MarketPlaceListingDTO : MarketPlaceListingDTOBase { }

    public class MarketPlaceListingDTOBase 
    {
        [Parameter("uint256", "listingId", 1)]
        public virtual BigInteger ListingId { get; set; }
        [Parameter("uint256", "owner", 2)]
        public virtual BigInteger Owner { get; set; }
        [Parameter("uint256", "itemId", 3)]
        public virtual BigInteger ItemId { get; set; }
        [Parameter("uint256", "unitPrice", 4)]
        public virtual BigInteger UnitPrice { get; set; }
        [Parameter("uint256", "quantity", 5)]
        public virtual BigInteger Quantity { get; set; }
    }
}
