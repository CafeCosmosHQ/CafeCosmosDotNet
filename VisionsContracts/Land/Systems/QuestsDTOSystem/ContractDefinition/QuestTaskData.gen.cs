using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace VisionsContracts.Land.Systems.QuestsDTOSystem.ContractDefinition
{
    public partial class QuestTaskData : QuestTaskDataBase { }

    public class QuestTaskDataBase 
    {
        [Parameter("uint256", "questId", 1)]
        public virtual BigInteger QuestId { get; set; }
        [Parameter("uint256", "taskType", 2)]
        public virtual BigInteger TaskType { get; set; }
        [Parameter("bytes32", "key", 3)]
        public virtual byte[] Key { get; set; }
        [Parameter("uint256", "quantity", 4)]
        public virtual BigInteger Quantity { get; set; }
        [Parameter("bool", "exists", 5)]
        public virtual bool Exists { get; set; }
        [Parameter("string", "name", 6)]
        public virtual string Name { get; set; }
        [Parameter("bytes32[]", "taskKeys", 7)]
        public virtual List<byte[]> TaskKeys { get; set; }
    }
}
