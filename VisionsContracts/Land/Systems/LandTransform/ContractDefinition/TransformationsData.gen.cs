using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace VisionsContracts.Land.Systems.LandTransform.ContractDefinition
{
    public partial class TransformationsData : TransformationsDataBase { }

    public class TransformationsDataBase 
    {
        [Parameter("uint256", "next", 1)]
        public virtual BigInteger Next { get; set; }
        [Parameter("uint256", "yield", 2)]
        public virtual BigInteger Yield { get; set; }
        [Parameter("uint256", "inputNext", 3)]
        public virtual BigInteger InputNext { get; set; }
        [Parameter("uint256", "yieldQuantity", 4)]
        public virtual BigInteger YieldQuantity { get; set; }
        [Parameter("uint256", "unlockTime", 5)]
        public virtual BigInteger UnlockTime { get; set; }
        [Parameter("uint256", "timeout", 6)]
        public virtual BigInteger Timeout { get; set; }
        [Parameter("uint256", "timeoutYield", 7)]
        public virtual BigInteger TimeoutYield { get; set; }
        [Parameter("uint256", "timeoutYieldQuantity", 8)]
        public virtual BigInteger TimeoutYieldQuantity { get; set; }
        [Parameter("uint256", "timeoutNext", 9)]
        public virtual BigInteger TimeoutNext { get; set; }
        [Parameter("bool", "isRecipe", 10)]
        public virtual bool IsRecipe { get; set; }
        [Parameter("bool", "isWaterCollection", 11)]
        public virtual bool IsWaterCollection { get; set; }
        [Parameter("uint256", "xp", 12)]
        public virtual BigInteger Xp { get; set; }
        [Parameter("bool", "exists", 13)]
        public virtual bool Exists { get; set; }
    }
}
