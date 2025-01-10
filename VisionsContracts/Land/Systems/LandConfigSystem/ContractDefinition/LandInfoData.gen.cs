using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace VisionsContracts.Land.Systems.LandConfigSystem.ContractDefinition
{
    public partial class LandInfoData : LandInfoDataBase { }

    public class LandInfoDataBase 
    {
        [Parameter("uint256", "limitX", 1)]
        public virtual BigInteger LimitX { get; set; }
        [Parameter("uint256", "limitY", 2)]
        public virtual BigInteger LimitY { get; set; }
        [Parameter("uint256", "activeTables", 3)]
        public virtual BigInteger ActiveTables { get; set; }
        [Parameter("uint256", "activeStoves", 4)]
        public virtual BigInteger ActiveStoves { get; set; }
        [Parameter("bool", "isInitialized", 5)]
        public virtual bool IsInitialized { get; set; }
        [Parameter("uint32", "seed", 6)]
        public virtual uint Seed { get; set; }
        [Parameter("uint256", "tokenBalance", 7)]
        public virtual BigInteger TokenBalance { get; set; }
        [Parameter("uint256", "cumulativeXp", 8)]
        public virtual BigInteger CumulativeXp { get; set; }
        [Parameter("uint256", "lastLevelClaimed", 9)]
        public virtual BigInteger LastLevelClaimed { get; set; }
        [Parameter("uint256[]", "yBound", 10)]
        public virtual List<BigInteger> YBound { get; set; }
    }
}
