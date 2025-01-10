using System.Collections.Generic;
using System.Numerics;
using System.Linq;
using VisionsContracts.PlayerBalancePurchasing;

namespace VisionsContracts
{
        public class GuildsAndPlayersEarnings
        {
            public List<GuildEarnings> GuildsEarnings { get; set; }
            public List<PlayerTotalEarned> PlayersEarnings { get; set; }

            public List<GuildEarnings> GetGuildEarningsInOrder()
            {
                return GuildsEarnings.OrderByDescending(x => x.GetTotalEarnings()).ToList();
            }

            public List<PlayerTotalEarned> GetPlayersEarningsInOrder()
            {
                return PlayersEarnings.OrderByDescending(x => x.TotalEarned).ToList();
            }

            public List<BigInteger> GetPlayersInGuilds()
            {
                return GuildsEarnings.SelectMany(x => x.MembersEarnings.Select(y => y.LandId)).ToList();
            }

            public List<PlayerTotalEarned> GetPlayersEarningsInOrderThatAreNotInGuilds()
            {
                var playersInGuilds = GetPlayersInGuilds();
                return PlayersEarnings.Where(x => !playersInGuilds.Contains(x.LandId)).OrderByDescending(x => x.TotalEarned).ToList();
            }

        
    }
}
