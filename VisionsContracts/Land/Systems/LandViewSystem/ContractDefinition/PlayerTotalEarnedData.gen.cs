using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace VisionsContracts.Land.Systems.LandViewSystem.ContractDefinition
{
    public partial class PlayerTotalEarnedData : PlayerTotalEarnedDataBase { }

    public class PlayerTotalEarnedDataBase 
    {
        [Parameter("uint256", "totalEarned", 1)]
        public virtual BigInteger TotalEarned { get; set; }
        [Parameter("uint256", "totalSpent", 2)]
        public virtual BigInteger TotalSpent { get; set; }
    }
}
