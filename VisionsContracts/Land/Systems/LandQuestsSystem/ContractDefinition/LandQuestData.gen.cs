using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace VisionsContracts.Land.Systems.LandQuestsSystem.ContractDefinition
{
    public partial class LandQuestData : LandQuestDataBase { }

    public class LandQuestDataBase 
    {
        [Parameter("uint256", "numberOfTasks", 1)]
        public virtual BigInteger NumberOfTasks { get; set; }
        [Parameter("uint256", "numberOfCompletedTasks", 2)]
        public virtual BigInteger NumberOfCompletedTasks { get; set; }
        [Parameter("bool", "claimed", 3)]
        public virtual bool Claimed { get; set; }
        [Parameter("bool", "active", 4)]
        public virtual bool Active { get; set; }
        [Parameter("uint256", "expiresAt", 5)]
        public virtual BigInteger ExpiresAt { get; set; }
    }
}
