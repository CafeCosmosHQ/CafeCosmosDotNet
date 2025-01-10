using System.Numerics;
using Nethereum.Web3;

namespace VisionsContracts.PlayerBalancePurchasing
{

    public class PlayerBalances
    {
        public BigInteger TokenBalance { get; set; }
        public BigInteger Balance { get; set; }

        public decimal TokenBalanceToMainUnit()
        {
            return Web3.Convert.FromWei(TokenBalance);
        }

        public decimal BalanceToMainUnit()
        {
            return Web3.Convert.FromWei(Balance);
        }
    }
}
