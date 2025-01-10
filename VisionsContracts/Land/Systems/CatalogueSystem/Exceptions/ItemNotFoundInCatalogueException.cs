using System;
using System.Numerics;

namespace VisionsContracts.Land.Systems.CatalogueSystem.Exceptions
{
    public class ItemNotFoundInCatalogueException : Exception
    {
        public ItemNotFoundInCatalogueException(BigInteger itemId) : base("Item not found in catalogue:" + itemId.ToString())
        {
            ItemId = itemId;
        }

        public BigInteger ItemId { get; }
    }
}
