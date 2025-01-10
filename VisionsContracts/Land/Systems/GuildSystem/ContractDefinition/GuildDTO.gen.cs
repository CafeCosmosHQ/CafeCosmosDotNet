using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace VisionsContracts.Land.Systems.GuildSystem.ContractDefinition
{
    public partial class GuildDTO : GuildDTOBase { }

    public class GuildDTOBase 
    {
        [Parameter("uint32", "guildId", 1)]
        public virtual uint GuildId { get; set; }
        [Parameter("uint256", "guildAdmin", 2)]
        public virtual BigInteger GuildAdmin { get; set; }
        [Parameter("string", "guildName", 3)]
        public virtual string GuildName { get; set; }
        [Parameter("uint256[]", "guildMembers", 4)]
        public virtual List<BigInteger> GuildMembers { get; set; }
    }
}
