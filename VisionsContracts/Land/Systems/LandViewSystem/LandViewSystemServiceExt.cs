using Nethereum.ABI;
using Nethereum.RPC.Eth.DTOs;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using VisionsContracts.Land.Systems.LandViewSystem.ContractDefinition;
using VisionsContracts.PlayerBalancePurchasing;

namespace VisionsContracts.Land.Systems.LandViewSystem
{
    public partial class LandViewSystemService
    {
        public async Task<PlayerTotalEarned> GetPlayerTotalEarnedAsync(BigInteger landId)
        {
            var playerTotalEarnedDTO = await GetTotalEarnedQueryAsync(landId);
            return MapPlayerTotalEarnedDTOToModel(playerTotalEarnedDTO.PlayerTotalEarned);
        }

        private static PlayerTotalEarned MapPlayerTotalEarnedDTOToModel(PlayerTotalEarnedDTO playerTotalEarnedDTO)
        {
            return new PlayerTotalEarned()
            {
                LandId = playerTotalEarnedDTO.LandId,
                TotalEarned = playerTotalEarnedDTO.TotalEarned,
                TotalSpent = playerTotalEarnedDTO.TotalSpent
            };
        }

        private static List<PlayerTotalEarned> MapPlayersTotalEarnedDTOToModel(List<PlayerTotalEarnedDTO> playersTotalEarnedDTO)
        {
            return playersTotalEarnedDTO.ConvertAll(MapPlayerTotalEarnedDTOToModel);
        }

        public async Task<List<PlayerTotalEarned>> GetPlayersTotalEarnedAsync(List<BigInteger> landIds)
        {
            var playersTotalEarnedDTO = await GetLandsTotalEarnedQueryAsync(landIds);
            return MapPlayersTotalEarnedDTOToModel(playersTotalEarnedDTO.PlayerTotalEarned);
        }
    }
}
