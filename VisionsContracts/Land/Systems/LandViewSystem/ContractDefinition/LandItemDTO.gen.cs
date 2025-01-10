using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace VisionsContracts.Land.Systems.LandViewSystem.ContractDefinition
{
    public partial class LandItemDTO : LandItemDTOBase { }

    public class LandItemDTOBase 
    {
        [Parameter("uint256", "x", 1)]
        public virtual BigInteger X { get; set; }
        [Parameter("uint256", "y", 2)]
        public virtual BigInteger Y { get; set; }
        [Parameter("uint256", "itemId", 3)]
        public virtual BigInteger ItemId { get; set; }
        [Parameter("uint256", "placementTime", 4)]
        public virtual BigInteger PlacementTime { get; set; }
        [Parameter("uint256", "stackIndex", 5)]
        public virtual BigInteger StackIndex { get; set; }
        [Parameter("bool", "isRotated", 6)]
        public virtual bool IsRotated { get; set; }
        [Parameter("uint256", "dynamicUnlockTime", 7)]
        public virtual BigInteger DynamicUnlockTime { get; set; }
        [Parameter("uint256", "dynamicTimeoutTime", 8)]
        public virtual BigInteger DynamicTimeoutTime { get; set; }
    }
}
