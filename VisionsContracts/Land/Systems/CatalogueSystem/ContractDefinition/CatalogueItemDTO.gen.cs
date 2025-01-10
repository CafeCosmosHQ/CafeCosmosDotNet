using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace VisionsContracts.Land.Systems.CatalogueSystem.ContractDefinition
{
    public partial class CatalogueItemDTO : CatalogueItemDTOBase { }

    public class CatalogueItemDTOBase 
    {
        [Parameter("uint256", "itemId", 1)]
        public virtual BigInteger ItemId { get; set; }
        [Parameter("uint256", "price", 2)]
        public virtual BigInteger Price { get; set; }
        [Parameter("uint256", "catalogueId", 3)]
        public virtual BigInteger CatalogueId { get; set; }
        [Parameter("bool", "exists", 4)]
        public virtual bool Exists { get; set; }
    }
}
