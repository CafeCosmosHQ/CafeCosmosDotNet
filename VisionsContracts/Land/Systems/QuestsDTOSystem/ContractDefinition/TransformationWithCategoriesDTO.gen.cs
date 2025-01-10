using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace VisionsContracts.Land.Systems.QuestsDTOSystem.ContractDefinition
{
    public partial class TransformationWithCategoriesDTO : TransformationWithCategoriesDTOBase { }

    public class TransformationWithCategoriesDTOBase 
    {
        [Parameter("uint256", "base", 1)]
        public virtual BigInteger Base { get; set; }
        [Parameter("uint256", "input", 2)]
        public virtual BigInteger Input { get; set; }
        [Parameter("uint256[]", "categories", 3)]
        public virtual List<BigInteger> Categories { get; set; }
    }
}
