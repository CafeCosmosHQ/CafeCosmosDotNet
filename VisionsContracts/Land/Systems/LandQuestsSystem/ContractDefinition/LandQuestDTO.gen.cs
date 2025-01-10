using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace VisionsContracts.Land.Systems.LandQuestsSystem.ContractDefinition
{
    public partial class LandQuestDTO : LandQuestDTOBase { }

    public class LandQuestDTOBase 
    {
        [Parameter("uint256", "landId", 1)]
        public virtual BigInteger LandId { get; set; }
        [Parameter("uint256", "questGroupId", 2)]
        public virtual BigInteger QuestGroupId { get; set; }
        [Parameter("uint256", "questId", 3)]
        public virtual BigInteger QuestId { get; set; }
        [Parameter("tuple", "landQuest", 4)]
        public virtual LandQuestData LandQuest { get; set; }
        [Parameter("tuple[]", "landQuestTasks", 5)]
        public virtual List<LandQuestTaskDTO> LandQuestTasks { get; set; }
    }
}
