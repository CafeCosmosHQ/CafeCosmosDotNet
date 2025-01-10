using System;
using System.Numerics;
using System.Runtime.Serialization;

namespace VisionsContracts.Land.Exceptions
{
    [Serializable]
    internal class LandPurchaseNotEnoughBalanceException : Exception
    {
        private BigInteger landCost;
        private BigInteger currentBalance;

        public LandPurchaseNotEnoughBalanceException()
        {
        }

        public LandPurchaseNotEnoughBalanceException(string message) : base(message)
        {
        }

        public LandPurchaseNotEnoughBalanceException(BigInteger landCost, BigInteger currentBalance)
        {
            this.landCost = landCost;
            this.currentBalance = currentBalance;
        }

        public LandPurchaseNotEnoughBalanceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected LandPurchaseNotEnoughBalanceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}