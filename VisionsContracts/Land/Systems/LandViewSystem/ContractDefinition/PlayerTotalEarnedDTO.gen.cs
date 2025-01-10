using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace VisionsContracts.Land.Systems.LandViewSystem.ContractDefinition
{
    public partial class PlayerTotalEarnedDTO : PlayerTotalEarnedDTOBase { }

    public class PlayerTotalEarnedDTOBase 
    {
        [Parameter("uint256", "landId", 1)]
        public virtual BigInteger LandId { get; set; }
        [Parameter("uint256", "totalEarned", 2)]
        public virtual BigInteger TotalEarned { get; set; }
        [Parameter("uint256", "totalSpent", 3)]
        public virtual BigInteger TotalSpent { get; set; }
    }
}
