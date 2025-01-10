using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace VisionsContracts.Redistributor.ContractDefinition
{
    public partial class SubSectionCreation : SubSectionCreationBase { }

    public class SubSectionCreationBase 
    {
        [Parameter("uint256", "masterShares", 1)]
        public virtual BigInteger MasterShares { get; set; }
        [Parameter("string", "name", 2)]
        public virtual string Name { get; set; }
        [Parameter("uint256[]", "poolIdentifiers", 3)]
        public virtual List<BigInteger> PoolIdentifiers { get; set; }
    }
}
