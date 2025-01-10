using Nethereum.Web3;
using System.Numerics;

namespace VisionsContracts.Land.Model
{

    public class LandPurchaseCost
    {
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

        public decimal CurrentBalanceInMainUnit
        {
            get
            {
                return Web3.Convert.FromWei(CurrentBalance);
            }
        }

        public decimal CurrentTokenBalanceInMainUnit
        {
            get
            {
                return Web3.Convert.FromWei(CurrentTokenBalance);
            }
        }

        public bool HasGotEnoughBalanceToPurchaseLand()
        {
            return CurrentBalance >= LandCost;
        }

        public bool HasGotEnoughTokenBalanceToPurchaseLand()
        {
            return CurrentTokenBalance >= LandCost;
        }
    }

}
