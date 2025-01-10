using System;
using System.Numerics;

namespace VisionsContracts.Items.Model
{
    public class InventoryItem: ICloneable
    {
        public BigInteger ItemId { get; set; }
        public BigInteger Count { get; set; }

        public object Clone()
        {
            return new InventoryItem()
            {
                ItemId = ItemId,
                Count = Count
            };
        }
    }

}
