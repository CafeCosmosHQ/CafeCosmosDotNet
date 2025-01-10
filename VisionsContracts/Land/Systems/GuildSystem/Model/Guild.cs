using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace VisionsContracts.Land.Systems.GuildSystem.Model
{
    public class Guild
    {
        public uint GuildId { get; set; }
       
        public BigInteger GuildAdmin { get; set; }
       
        public string GuildName { get; set; }
       
        public List<BigInteger> GuildMembers { get; set; }
    }
}
