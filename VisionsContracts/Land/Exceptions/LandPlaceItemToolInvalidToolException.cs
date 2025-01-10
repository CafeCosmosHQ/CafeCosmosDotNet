using System;
using System.Numerics;

namespace VisionsContracts.Land.Exceptions
{
    public class LandPlaceItemToolInvalidToolException : Exception
    {
        public LandPlaceItemToolInvalidToolException(BigInteger inventoryId)
        {
            InventoryId = inventoryId;
        }

        public BigInteger InventoryId { get; }
    }

}
