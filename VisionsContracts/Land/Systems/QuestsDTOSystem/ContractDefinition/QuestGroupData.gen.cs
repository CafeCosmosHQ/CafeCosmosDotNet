using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace VisionsContracts.Land.Systems.QuestsDTOSystem.ContractDefinition
{
    public partial class QuestGroupData : QuestGroupDataBase { }

    public class QuestGroupDataBase 
    {
        [Parameter("uint256", "startsAt", 1)]
        public virtual BigInteger StartsAt { get; set; }
        [Parameter("uint256", "expiresAt", 2)]
        public virtual BigInteger ExpiresAt { get; set; }
        [Parameter("bool", "sequential", 3)]
        public virtual bool Sequential { get; set; }
        [Parameter("uint256", "questGroupType", 4)]
        public virtual BigInteger QuestGroupType { get; set; }
        [Parameter("uint256[]", "questIds", 5)]
        public virtual List<BigInteger> QuestIds { get; set; }
        [Parameter("uint256[]", "rewardIds", 6)]
        public virtual List<BigInteger> RewardIds { get; set; }
    }
}
