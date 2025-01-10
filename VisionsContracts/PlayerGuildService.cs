using Nethereum.RPC.Eth.DTOs;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using VisionsContracts.Land;
using Nethereum.Web3;
using VisionsContracts.Land.Systems.GuildSystem;
using VisionsContracts.Land.Systems.GuildSystem.Model;

namespace VisionsContracts
{
    public class PlayerGuildService
    {
        public string PlayerAddress { get; }
        public int SelectedLandId { get; }
        public LandNamespace LandNamespace { get; }
        public GuildSystemService GuildService => LandNamespace.Systems.Guild;
 
        public PlayerGuildService(string playerAddress, int selectedLandId, LandNamespace landNamespace)
        {
            PlayerAddress = playerAddress;
            SelectedLandId = selectedLandId;
            LandNamespace = landNamespace;
        }

        public Task<TransactionReceipt> CreateNewGuildAndWaitForReceiptAsync(string name)
        {
            return GuildService.CreateNewGuildValidateAndWaitForReceiptAsync(SelectedLandId, name);
        }

        public Task<string> CreateNewGuildAsync(string name)
        {
            return GuildService.CreateNewGuildAndValidateAsync(SelectedLandId, name);
        }

        public Task<List<Guild>> GetAllGuildsAsync()
        {
            return GuildService.GetAllGuildsAsync();
        }

        public Task<string> KickFromGuildAsync(BigInteger kickedLandId)
        {
            return GuildService.KickFromGuildRequestAsync(SelectedLandId, kickedLandId);
        }

        public Task<string> AcceptGuildInvitationAsync(uint guildId)
        {
            return GuildService.AcceptGuildInvitationRequestAsync(SelectedLandId, guildId);
        }

        public Task<string> InviteToGuildAsync(BigInteger landId)
        {
            return GuildService.InviteToGuildRequestAsync(SelectedLandId, landId);
        }

        public Task<string> ClaimGuildAdminAsync()
        {
            return GuildService.ClaimGuildAdminRequestAsync(SelectedLandId);
        }

        public Task<string> SetNewGuildAdminAsync(BigInteger landId)
        {
            return GuildService.SetNewGuildAdminRequestAsync(SelectedLandId, landId);
        }

        public Task<string> ExitGuildAsync()
        {
            return GuildService.ExitGuildRequestAsync(SelectedLandId);
        }

    }
}
