using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace VisionsContracts.LandNFTs.ContractDefinition
{
    public partial class LandMetadata : LandMetadataBase { }

    public class LandMetadataBase 
    {
        [Parameter("uint256", "landId", 1)]
        public virtual BigInteger LandId { get; set; }
        [Parameter("string", "name", 2)]
        public virtual string Name { get; set; }
    }
}
