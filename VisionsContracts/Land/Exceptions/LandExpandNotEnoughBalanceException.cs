using System;
using System.Numerics;

namespace VisionsContracts.Land
{
    public partial class LandService
    {
        public class LandExpandNotEnoughBalanceException: Exception
        {
            public LandExpandNotEnoughBalanceException(string message, BigInteger cost, BigInteger balance): base(message)
            {
                Cost = cost;
                Balance = balance;
              
            }

            public LandExpandNotEnoughBalanceException(BigInteger cost, BigInteger balance) : base($"Soft balance required: {cost}, available: {balance}")
            {
                Cost = cost;
                Balance = balance;

            }

            public BigInteger Cost { get; set; }
            public BigInteger Balance { get; set;}

        }
    }
}
