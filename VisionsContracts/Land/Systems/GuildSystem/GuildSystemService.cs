using Nethereum.RPC.Eth.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using VisionsContracts.Land.Systems.GuildSystem.Exceptions;
using VisionsContracts.Land.Systems.GuildSystem.Model;

namespace VisionsContracts.Land.Systems.GuildSystem
{
    public partial class GuildSystemService
    {
        public async Task<List<Guild>> GetAllGuildsAsync()
        {

            var guildDTOS = await GetAllGuildsQueryAsync();
            var returnGuilds = new List<Guild>();
            foreach(var guildDTO in guildDTOS.Guilds)
            {
                returnGuilds.Add(
                    new Guild()
                    {
                        GuildMembers = guildDTO.GuildMembers,
                        GuildAdmin = guildDTO.GuildAdmin,
                        GuildId = guildDTO.GuildId,
                        GuildName = guildDTO.GuildName
                    });
            }

            return returnGuilds;
        }

       public async Task ValidateGuildNameAsync(string name)
       {
            if (!name.All(char.IsLetterOrDigit)) throw new Exception("Only alpha numeric characters allowed");
            var inUsedAlready = await GuildNameInUseQueryAsync(name);
            if (inUsedAlready) throw new GuildNameAlreadyInUseException(name);
            
       }

       public async Task<bool> IsValidNewGuildNameAsync(string name)
       {
            if (!name.All(char.IsLetterOrDigit)) return false;
            var inUsedAlready = await GuildNameInUseQueryAsync(name);
            if (inUsedAlready) return false;
            return true;
       }

        public async Task<string> CreateNewGuildAndValidateAsync(BigInteger landId, string name)
        {
            await ValidateGuildNameAsync(name);
            return await CreateGuildRequestAsync(landId, name);
        }

        public async Task<TransactionReceipt> CreateNewGuildValidateAndWaitForReceiptAsync(BigInteger landId, string name)
        {
            await ValidateGuildNameAsync(name);
            return await CreateGuildRequestAndWaitForReceiptAsync(landId, name);
        }

       
        
    }
}
