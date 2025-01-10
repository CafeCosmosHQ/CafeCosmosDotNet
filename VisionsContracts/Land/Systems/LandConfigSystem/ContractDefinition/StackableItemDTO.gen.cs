using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace VisionsContracts.Land.Systems.LandConfigSystem.ContractDefinition
{
    public partial class StackableItemDTO : StackableItemDTOBase { }

    public class StackableItemDTOBase 
    {
        [Parameter("uint256", "base", 1)]
        public virtual BigInteger Base { get; set; }
        [Parameter("uint256", "input", 2)]
        public virtual BigInteger Input { get; set; }
        [Parameter("bool", "stackable", 3)]
        public virtual bool Stackable { get; set; }
    }
}
