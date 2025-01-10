using System;

namespace VisionsContracts.Land.Exceptions
{
    public class LandPlaceItemFromInventoryNotFoundException : Exception
    {
        public LandPlaceItemFromInventoryNotFoundException() : base("Inventory item could not be found to place in land") { }
    }

}
