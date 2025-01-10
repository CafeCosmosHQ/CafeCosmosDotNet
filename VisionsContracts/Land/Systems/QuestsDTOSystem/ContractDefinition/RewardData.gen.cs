using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace VisionsContracts.Land.Systems.QuestsDTOSystem.ContractDefinition
{
    public partial class RewardData : RewardDataBase { }

    public class RewardDataBase 
    {
        [Parameter("uint256", "itemId", 1)]
        public virtual BigInteger ItemId { get; set; }
        [Parameter("uint256", "rewardType", 2)]
        public virtual BigInteger RewardType { get; set; }
        [Parameter("uint256", "quantity", 3)]
        public virtual BigInteger Quantity { get; set; }
    }
}
