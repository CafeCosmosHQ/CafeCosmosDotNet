using Nethereum.Web3;
using System;
using System.Numerics;

namespace VisionsContracts.Land.Systems.CatalogueSystem.Exceptions
{
    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(BigInteger balance, BigInteger cost) : base("Insufficient balance:" + Web3.Convert.FromWei(balance) + " cost:" + Web3.Convert.FromWei(cost))
        {
            Balance = balance;
            Cost = cost;
        }
        public BigInteger Balance { get; }
        public decimal BalanceInEtherUnit => Web3.Convert.FromWei(Balance);
        public BigInteger Cost { get; }
        public decimal CostInEtherUnit => Web3.Convert.FromWei(Cost);
    }
}
