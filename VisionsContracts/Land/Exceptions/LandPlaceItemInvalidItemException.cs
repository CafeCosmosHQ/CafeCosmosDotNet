using System;

namespace VisionsContracts.Land.Exceptions
{
    public class LandPlaceItemInvalidItemException : Exception
    {
        public LandPlaceItemInvalidItemException() : base("Invalid item to place, not a valid transformation or stackable") { }
    }

}
