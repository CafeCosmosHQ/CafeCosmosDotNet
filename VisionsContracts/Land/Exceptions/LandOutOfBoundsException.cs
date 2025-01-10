using System;

namespace VisionsContracts.Land.Exceptions
{
    public class LandOutOfBoundsException : Exception
    {
        public LandOutOfBoundsException() : base("Invalid item to place, out of bounds") { }
    }

}
