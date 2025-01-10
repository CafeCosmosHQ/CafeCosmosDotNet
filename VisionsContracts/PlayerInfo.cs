using VisionsContracts.Land.Extensions;
using VisionsContracts.Land.Model;
using VisionsContracts.PlayerBalancePurchasing;

namespace VisionsContracts
{
    public class PlayerInfo
    {
        public LandInfo PlayerLandInfo { get; set; } = new LandInfo();

        public PlayerBalances PlayerBalances { get; set; } = new PlayerBalances();

        public PlayerTotalEarned PlayerTotalEarnedSpent { get; set; } = new PlayerTotalEarned();

        public decimal BalanceToMainUnit()
        {
            return  PlayerBalances.BalanceToMainUnit();
        }

        public decimal TokenBalanceToMainUnit()
        {
            return PlayerBalances.TokenBalanceToMainUnit();
        }

        public bool HasLand()
        {
            if(PlayerLandInfo == null) return false;
            return PlayerLandInfo.HasLand();
        }
        
    }
}
