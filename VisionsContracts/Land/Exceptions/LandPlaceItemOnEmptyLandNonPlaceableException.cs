using System;

namespace VisionsContracts.Land.Exceptions
{
    public class LandPlaceItemOnEmptyLandNonPlaceableException : Exception
    {
        public LandPlaceItemOnEmptyLandNonPlaceableException() : base("Non placeable Item with no valid matching transformation") { }
    }

}
