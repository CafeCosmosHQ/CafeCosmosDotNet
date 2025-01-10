using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace VisionsContracts.Land.Systems.CatalogueSystem.ContractDefinition
{
    public partial class CatalogueItemPurchaseDTO : CatalogueItemPurchaseDTOBase { }

    public class CatalogueItemPurchaseDTOBase 
    {
        [Parameter("uint256", "itemId", 1)]
        public virtual BigInteger ItemId { get; set; }
        [Parameter("uint256", "quantity", 2)]
        public virtual BigInteger Quantity { get; set; }
    }
}
