using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using VisionsContracts.Land.Systems.LandViewSystem.ContractDefinition;

namespace VisionsContracts.Land.Model
{

   

    public class LandInfo
    {
        public virtual BigInteger LimitX { get; set; }
        public virtual BigInteger LimitY { get; set; }
        public virtual BigInteger ActiveTables { get; set; }
        public virtual BigInteger ActiveStoves { get; set; }
        public virtual bool IsInitialized { get; set; }
        public virtual uint Seed { get; set; }
        public virtual BigInteger TokenBalance { get; set; }
        public virtual BigInteger CumulativeXp { get; set; }
        public virtual BigInteger LastLevelClaimed { get; set; }
        public virtual List<BigInteger> YBound { get; set; }
    }

}
