using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace VisionsContracts.Land.Systems.QuestsDTOSystem.ContractDefinition
{
    public partial class RewardCollectionDTO : RewardCollectionDTOBase { }

    public class RewardCollectionDTOBase 
    {
        [Parameter("uint256", "rewardType", 1)]
        public virtual BigInteger RewardType { get; set; }
        [Parameter("uint256[]", "rewardIds", 2)]
        public virtual List<BigInteger> RewardIds { get; set; }
    }
}
