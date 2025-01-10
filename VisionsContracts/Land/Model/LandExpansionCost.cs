using Nethereum.Web3;
using System.Numerics;

namespace VisionsContracts.Land.Model
{


    public class LandExpansionCost
    {
        public BigInteger LimitX { get; set; }
        public BigInteger LimitY { get; set; }
        public BigInteger LandCost { get; set; }
        public BigInteger CurrentBalance { get; set; }
        public BigInteger CurrentTokenBalance { get; set; }
        public BigInteger CurrentAllowanceToLand { get; set; }

        public decimal LandCostInMainUnit
        {
            get
            {
                return Web3.Convert.FromWei(LandCost);
            }
        }

        public bool HasGotEnoughBalanceToExpandLand()
        {
            return CurrentBalance >= LandCost;
        }

        public bool HasGotEnoughTokenBalanceToExpandLand()
        {
            return CurrentTokenBalance >= LandCost;
        }

        public decimal CurrentBalanceInMainUnit
        {
            get
            {
                return Web3.Convert.FromWei(CurrentBalance);
            }
        }
    }
}

