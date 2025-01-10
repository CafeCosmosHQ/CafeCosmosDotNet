using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace VisionsContracts.Land.Systems.LevelingSystem.ContractDefinition
{
    public partial class LevelRewardDTO : LevelRewardDTOBase { }

    public class LevelRewardDTOBase 
    {
        [Parameter("uint256", "level", 1)]
        public virtual BigInteger Level { get; set; }
        [Parameter("uint256", "tokens", 2)]
        public virtual BigInteger Tokens { get; set; }
        [Parameter("uint256", "cumulativeXp", 3)]
        public virtual BigInteger CumulativeXp { get; set; }
        [Parameter("uint256[]", "items", 4)]
        public virtual List<BigInteger> Items { get; set; }
    }
}
