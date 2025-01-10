using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace VisionsContracts.Land.Systems.QuestsDTOSystem.ContractDefinition
{
    public partial class QuestData : QuestDataBase { }

    public class QuestDataBase 
    {
        [Parameter("uint256", "duration", 1)]
        public virtual BigInteger Duration { get; set; }
        [Parameter("bool", "exists", 2)]
        public virtual bool Exists { get; set; }
        [Parameter("string", "questName", 3)]
        public virtual string QuestName { get; set; }
        [Parameter("uint256[]", "rewardIds", 4)]
        public virtual List<BigInteger> RewardIds { get; set; }
        [Parameter("bytes32[]", "tasks", 5)]
        public virtual List<byte[]> Tasks { get; set; }
    }
}
