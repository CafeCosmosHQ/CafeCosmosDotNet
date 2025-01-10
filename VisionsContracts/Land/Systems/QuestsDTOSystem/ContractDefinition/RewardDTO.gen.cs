using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace VisionsContracts.Land.Systems.QuestsDTOSystem.ContractDefinition
{
    public partial class RewardDTO : RewardDTOBase { }

    public class RewardDTOBase 
    {
        [Parameter("uint256", "id", 1)]
        public virtual BigInteger Id { get; set; }
        [Parameter("tuple", "reward", 2)]
        public virtual RewardData Reward { get; set; }
    }
}
