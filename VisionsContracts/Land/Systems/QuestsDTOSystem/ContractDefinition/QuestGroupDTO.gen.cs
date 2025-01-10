using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace VisionsContracts.Land.Systems.QuestsDTOSystem.ContractDefinition
{
    public partial class QuestGroupDTO : QuestGroupDTOBase { }

    public class QuestGroupDTOBase 
    {
        [Parameter("uint256", "id", 1)]
        public virtual BigInteger Id { get; set; }
        [Parameter("tuple", "questGroup", 2)]
        public virtual QuestGroupData QuestGroup { get; set; }
        [Parameter("tuple[]", "quests", 3)]
        public virtual List<QuestDTO> Quests { get; set; }
        [Parameter("tuple[]", "rewards", 4)]
        public virtual List<RewardDTO> Rewards { get; set; }
    }
}
