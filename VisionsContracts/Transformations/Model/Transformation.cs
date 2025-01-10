using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace VisionsContracts.Transformations.Model
{
    public partial class Transformation
    {

        public virtual BigInteger Base { get; set; }

        public virtual BigInteger Input { get; set; }

        public virtual BigInteger Next { get; set; }

        public virtual BigInteger InputNext { get; set; }
        public virtual BigInteger Yield { get; set; }

        public virtual BigInteger YieldQuantity { get; set; }

        public virtual BigInteger UnlockTime { get; set; }

        public virtual BigInteger Timeout { get; set; }

        public virtual BigInteger TimeoutYield { get; set; }

        public virtual BigInteger TimeoutYieldQuantity { get; set; }

        public virtual BigInteger TimeoutNext { get; set; }

        public virtual bool IsRecipe { get; set; }

        public virtual bool IsWaterCollection { get; set; }

        public virtual BigInteger Xp { get; set; } = 0;

        public virtual bool Exists { get; set; }
    }
    
}
