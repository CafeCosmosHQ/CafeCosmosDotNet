using System.Collections.Generic;
using System.Numerics;
using System.Linq;
using VisionsContracts.PlayerBalancePurchasing;
using VisionsContracts.Land.Systems.GuildSystem.Model;

namespace VisionsContracts
{
        public class GuildEarnings
        {
            public Guild Guild { get; set; }
            
            public List<PlayerTotalEarned> MembersEarnings { get; set; }

            public List<PlayerTotalEarned> GetMembersEarningsInOrder()
            {
                return MembersEarnings.OrderByDescending(x => x.TotalEarned).ToList();
            }

            public BigInteger GetTotalEarnings()
            {
                BigInteger totalEarnings = 0;
                foreach (var member in MembersEarnings)
                {
                    totalEarnings += member.TotalEarned;
                }

                return totalEarnings;
            }

            public BigInteger GetTotalSpent()
            {
                BigInteger totalSpent = 0;
                foreach (var member in MembersEarnings)
                {
                    totalSpent += member.TotalSpent;
                }
                return totalSpent;
            }

            public decimal GetTotalEarningsToMainUnit()
            {
                return Nethereum.Web3.Web3.Convert.FromWei(GetTotalEarnings());
            }

            public decimal GetTotalSpentToMainUnit()
            {
                return Nethereum.Web3.Web3.Convert.FromWei(GetTotalSpent());
            }

            public decimal GetTotalEarningsMinusSpentToMainUnit()
            {
                return GetTotalEarningsToMainUnit() - GetTotalSpentToMainUnit();
            }
        }
}
