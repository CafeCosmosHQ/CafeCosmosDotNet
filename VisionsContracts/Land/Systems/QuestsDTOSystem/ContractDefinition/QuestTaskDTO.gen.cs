using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace VisionsContracts.Land.Systems.QuestsDTOSystem.ContractDefinition
{
    public partial class QuestTaskDTO : QuestTaskDTOBase { }

    public class QuestTaskDTOBase 
    {
        [Parameter("bytes32", "taskId", 1)]
        public virtual byte[] TaskId { get; set; }
        [Parameter("tuple", "task", 2)]
        public virtual QuestTaskData Task { get; set; }
    }
}
