using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace VisionsContracts.Land.Systems.QuestsDTOSystem.ContractDefinition
{
    public partial class QuestDTO : QuestDTOBase { }

    public class QuestDTOBase 
    {
        [Parameter("uint256", "id", 1)]
        public virtual BigInteger Id { get; set; }
        [Parameter("tuple", "quest", 2)]
        public virtual QuestData Quest { get; set; }
        [Parameter("tuple[]", "tasks", 3)]
        public virtual List<QuestTaskDTO> Tasks { get; set; }
        [Parameter("tuple[]", "rewards", 4)]
        public virtual List<RewardDTO> Rewards { get; set; }
    }
}
