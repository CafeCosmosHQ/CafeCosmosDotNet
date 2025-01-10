using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace VisionsContracts.PerlinItemConfig.ContractDefinition
{
    public partial class PerlinConfig : PerlinConfigBase { }

    public class PerlinConfigBase 
    {
        [Parameter("uint256", "groupId", 1)]
        public virtual BigInteger GroupId { get; set; }
        [Parameter("uint256", "perlinId", 2)]
        public virtual BigInteger PerlinId { get; set; }
        [Parameter("uint256", "itemId", 3)]
        public virtual BigInteger ItemId { get; set; }
    }
}
