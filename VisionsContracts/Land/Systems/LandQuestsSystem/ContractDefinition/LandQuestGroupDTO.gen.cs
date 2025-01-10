using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace VisionsContracts.Land.Systems.LandQuestsSystem.ContractDefinition
{
    public partial class LandQuestGroupDTO : LandQuestGroupDTOBase { }

    public class LandQuestGroupDTOBase 
    {
        [Parameter("uint256", "landId", 1)]
        public virtual BigInteger LandId { get; set; }
        [Parameter("uint256", "questGroupId", 2)]
        public virtual BigInteger QuestGroupId { get; set; }
        [Parameter("tuple", "landQuestGroup", 3)]
        public virtual LandQuestGroupData LandQuestGroup { get; set; }
        [Parameter("tuple[]", "landQuests", 4)]
        public virtual List<LandQuestDTO> LandQuests { get; set; }
    }
}
