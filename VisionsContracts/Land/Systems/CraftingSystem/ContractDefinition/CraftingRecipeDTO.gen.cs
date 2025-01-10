using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace VisionsContracts.Land.Systems.CraftingSystem.ContractDefinition
{
    public partial class CraftingRecipeDTO : CraftingRecipeDTOBase { }

    public class CraftingRecipeDTOBase 
    {
        [Parameter("uint256", "output", 1)]
        public virtual BigInteger Output { get; set; }
        [Parameter("uint256", "outputQuantity", 2)]
        public virtual BigInteger OutputQuantity { get; set; }
        [Parameter("uint256", "xp", 3)]
        public virtual BigInteger Xp { get; set; }
        [Parameter("bool", "exists", 4)]
        public virtual bool Exists { get; set; }
        [Parameter("uint256[]", "inputs", 5)]
        public virtual List<BigInteger> Inputs { get; set; }
        [Parameter("uint256[]", "quantities", 6)]
        public virtual List<BigInteger> Quantities { get; set; }
    }
}
