using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace VisionsContracts.Land.Systems.LandCreationSystem.ContractDefinition
{
    public partial class InitialLandItem : InitialLandItemBase { }

    public class InitialLandItemBase 
    {
        [Parameter("uint256", "x", 1)]
        public virtual BigInteger X { get; set; }
        [Parameter("uint256", "y", 2)]
        public virtual BigInteger Y { get; set; }
        [Parameter("uint256", "z", 3)]
        public virtual BigInteger Z { get; set; }
        [Parameter("uint256", "itemId", 4)]
        public virtual BigInteger ItemId { get; set; }
        [Parameter("bool", "rotated", 5)]
        public virtual bool Rotated { get; set; }
    }
}
