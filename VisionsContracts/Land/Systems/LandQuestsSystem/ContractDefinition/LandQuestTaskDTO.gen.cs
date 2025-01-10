using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace VisionsContracts.Land.Systems.LandQuestsSystem.ContractDefinition
{
    public partial class LandQuestTaskDTO : LandQuestTaskDTOBase { }

    public class LandQuestTaskDTOBase 
    {
        [Parameter("bytes32", "taskId", 1)]
        public virtual byte[] TaskId { get; set; }
        [Parameter("uint256", "landId", 2)]
        public virtual BigInteger LandId { get; set; }
        [Parameter("uint256", "questGroupId", 3)]
        public virtual BigInteger QuestGroupId { get; set; }
        [Parameter("uint256", "questId", 4)]
        public virtual BigInteger QuestId { get; set; }
        [Parameter("uint256", "taskType", 5)]
        public virtual BigInteger TaskType { get; set; }
        [Parameter("bytes32", "key", 6)]
        public virtual byte[] Key { get; set; }
        [Parameter("uint256", "quantity", 7)]
        public virtual BigInteger Quantity { get; set; }
        [Parameter("tuple", "landQuestTask", 8)]
        public virtual LandQuestTaskProgressData LandQuestTask { get; set; }
    }
}
