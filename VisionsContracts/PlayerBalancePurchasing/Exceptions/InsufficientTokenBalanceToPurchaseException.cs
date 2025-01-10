using System;
using System.Numerics;

namespace VisionsContracts.PlayerBalancePurchasing.Exceptions
{
    [Serializable]
    public class InsufficientTokenBalanceToPurchaseException : Exception
    {
        public BigInteger TokenBalance { get; }
        public BigInteger Amount { get; }


        public InsufficientTokenBalanceToPurchaseException(BigInteger tokenBalance, BigInteger amount) : base($"Insufficient balance {tokenBalance} to purchase {amount}")
        {
            TokenBalance = tokenBalance;
            Amount = amount;
        }
    }
}