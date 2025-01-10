using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace VisionsContracts.Redistributor.ContractDefinition
{
    public partial class Pool : PoolBase { }

    public class PoolBase 
    {
        [Parameter("uint256", "tokenBalance", 1)]
        public virtual BigInteger TokenBalance { get; set; }
        [Parameter("uint256", "totalShares", 2)]
        public virtual BigInteger TotalShares { get; set; }
        [Parameter("bool", "isActive", 3)]
        public virtual bool IsActive { get; set; }
    }
}
