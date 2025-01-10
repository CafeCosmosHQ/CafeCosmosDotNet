using Nethereum.Web3;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using VisionsContracts.Items.Model;

namespace VisionsContracts.Land.Systems.MarketplaceSystem.Model
{
    public class MarketPlaceListing
    {
        public virtual BigInteger ListingId { get; set; }
        
        public virtual BigInteger Owner { get; set; }
        
        public virtual BigInteger ItemId { get; set; }

        public Item Item { get; set; }

        public virtual BigInteger UnitPrice { get; set; }

        public decimal UnitPriceInMainUnit => Web3.Convert.FromWei(UnitPrice);

        public virtual BigInteger Quantity { get; set; }
        
    }
}
