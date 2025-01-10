using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace VisionsContracts.Land.Systems.TransformationsSystem.ContractDefinition
{
    public partial class TransformationDTO : TransformationDTOBase { }

    public class TransformationDTOBase 
    {
        [Parameter("uint256", "base", 1)]
        public virtual BigInteger Base { get; set; }
        [Parameter("uint256", "input", 2)]
        public virtual BigInteger Input { get; set; }
        [Parameter("uint256", "next", 3)]
        public virtual BigInteger Next { get; set; }
        [Parameter("uint256", "yield", 4)]
        public virtual BigInteger Yield { get; set; }
        [Parameter("uint256", "inputNext", 5)]
        public virtual BigInteger InputNext { get; set; }
        [Parameter("uint256", "yieldQuantity", 6)]
        public virtual BigInteger YieldQuantity { get; set; }
        [Parameter("uint256", "unlockTime", 7)]
        public virtual BigInteger UnlockTime { get; set; }
        [Parameter("uint256", "timeout", 8)]
        public virtual BigInteger Timeout { get; set; }
        [Parameter("uint256", "timeoutYield", 9)]
        public virtual BigInteger TimeoutYield { get; set; }
        [Parameter("uint256", "timeoutYieldQuantity", 10)]
        public virtual BigInteger TimeoutYieldQuantity { get; set; }
        [Parameter("uint256", "timeoutNext", 11)]
        public virtual BigInteger TimeoutNext { get; set; }
        [Parameter("bool", "isRecipe", 12)]
        public virtual bool IsRecipe { get; set; }
        [Parameter("bool", "isWaterCollection", 13)]
        public virtual bool IsWaterCollection { get; set; }
        [Parameter("uint256", "xp", 14)]
        public virtual BigInteger Xp { get; set; }
        [Parameter("bool", "exists", 15)]
        public virtual bool Exists { get; set; }
    }
}
