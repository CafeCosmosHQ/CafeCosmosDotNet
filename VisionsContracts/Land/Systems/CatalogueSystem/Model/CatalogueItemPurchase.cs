using System.Numerics;

namespace VisionsContracts.Land.Systems.CatalogueSystem.Model
{
    public class CatalogueItemPurchase
    {
        public BigInteger ItemId { get; set; }
        public BigInteger Quantity { get; set; }

        public CatalogueItemPurchase()
        {
        }

        public CatalogueItemPurchase(BigInteger itemId, BigInteger quantity)
        {
            this.ItemId = itemId;
            this.Quantity = quantity;
        }
    }
}
