using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace VisionsContracts.Land.Systems.LandQuestsSystem.ContractDefinition
{
    public partial class LandQuestGroupData : LandQuestGroupDataBase { }

    public class LandQuestGroupDataBase 
    {
        [Parameter("bool", "active", 1)]
        public virtual bool Active { get; set; }
        [Parameter("uint256", "numberOfQuests", 2)]
        public virtual BigInteger NumberOfQuests { get; set; }
        [Parameter("uint256", "numberOfCompletedQuests", 3)]
        public virtual BigInteger NumberOfCompletedQuests { get; set; }
        [Parameter("bool", "claimed", 4)]
        public virtual bool Claimed { get; set; }
        [Parameter("uint256", "expiresAt", 5)]
        public virtual BigInteger ExpiresAt { get; set; }
    }
}
