using System;
using System.Numerics;
using System.Runtime.Serialization;

namespace VisionsContracts.PlayerBalancePurchasing.Exceptions
{

    [Serializable]
    public class InsufficientBalanceToPurchaseException : Exception
    {
        public BigInteger Balance { get; }
        public BigInteger Amount { get; }

        public InsufficientBalanceToPurchaseException(BigInteger balance, BigInteger amount) : base($"Insufficient balance {balance} to purchase {amount}")
        {
            Balance = balance;
            Amount = amount;
        }
    }
}