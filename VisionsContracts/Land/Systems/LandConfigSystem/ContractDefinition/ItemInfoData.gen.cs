using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace VisionsContracts.Land.Systems.LandConfigSystem.ContractDefinition
{
    public partial class ItemInfoData : ItemInfoDataBase { }

    public class ItemInfoDataBase 
    {
        [Parameter("bool", "nonRemovable", 1)]
        public virtual bool NonRemovable { get; set; }
        [Parameter("bool", "nonPlaceable", 2)]
        public virtual bool NonPlaceable { get; set; }
        [Parameter("bool", "isTool", 3)]
        public virtual bool IsTool { get; set; }
        [Parameter("bool", "isTable", 4)]
        public virtual bool IsTable { get; set; }
        [Parameter("bool", "isChair", 5)]
        public virtual bool IsChair { get; set; }
        [Parameter("bool", "isRotatable", 6)]
        public virtual bool IsRotatable { get; set; }
        [Parameter("uint256", "themeId", 7)]
        public virtual BigInteger ThemeId { get; set; }
        [Parameter("uint256", "itemCategory", 8)]
        public virtual BigInteger ItemCategory { get; set; }
        [Parameter("uint256", "returnsItem", 9)]
        public virtual BigInteger ReturnsItem { get; set; }
    }
}
