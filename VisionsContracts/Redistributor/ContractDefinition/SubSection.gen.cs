using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace VisionsContracts.Redistributor.ContractDefinition
{
    public partial class SubSection : SubSectionBase { }

    public class SubSectionBase 
    {
        [Parameter("uint256", "masterShares", 1)]
        public virtual BigInteger MasterShares { get; set; }
        [Parameter("uint256[]", "poolIds", 2)]
        public virtual List<BigInteger> PoolIds { get; set; }
        [Parameter("string", "name", 3)]
        public virtual string Name { get; set; }
    }
}
