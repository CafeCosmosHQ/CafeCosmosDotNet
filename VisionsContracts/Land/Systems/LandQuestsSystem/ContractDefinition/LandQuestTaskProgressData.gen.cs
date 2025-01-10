using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace VisionsContracts.Land.Systems.LandQuestsSystem.ContractDefinition
{
    public partial class LandQuestTaskProgressData : LandQuestTaskProgressDataBase { }

    public class LandQuestTaskProgressDataBase 
    {
        [Parameter("uint256", "taskProgress", 1)]
        public virtual BigInteger TaskProgress { get; set; }
        [Parameter("bool", "taskCompleted", 2)]
        public virtual bool TaskCompleted { get; set; }
    }
}
