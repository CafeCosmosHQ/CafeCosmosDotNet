using System;
using System.Runtime.Serialization;

namespace VisionsContracts.Land.Exceptions
{
    [Serializable]
    public class LandPlaceItemRecipeNoActiveTableException : Exception
    {
        public LandPlaceItemRecipeNoActiveTableException()
        {
        }

        public LandPlaceItemRecipeNoActiveTableException(string message) : base(message)
        {
        }

        public LandPlaceItemRecipeNoActiveTableException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected LandPlaceItemRecipeNoActiveTableException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}