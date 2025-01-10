using System.Numerics;
using Nethereum.Web3;

namespace VisionsContracts.PlayerBalancePurchasing
{
    public class PlayerTotalEarned
    {
        public virtual BigInteger LandId { get; set; }
        public virtual BigInteger TotalEarned { get; set; }
        public virtual BigInteger TotalSpent { get; set; }

        public decimal TokenEarnedToMainUnit()
        {
            return Web3.Convert.FromWei(TotalEarned);
        }

        public decimal TotalSpentToMainUnit()
        {
            return Web3.Convert.FromWei(TotalSpent);
        }
    }
}
