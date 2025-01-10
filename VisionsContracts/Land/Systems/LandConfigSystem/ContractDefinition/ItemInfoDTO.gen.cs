using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace VisionsContracts.Land.Systems.LandConfigSystem.ContractDefinition
{
    public partial class ItemInfoDTO : ItemInfoDTOBase { }

    public class ItemInfoDTOBase 
    {
        [Parameter("uint256", "itemId", 1)]
        public virtual BigInteger ItemId { get; set; }
        [Parameter("tuple", "itemInfo", 2)]
        public virtual ItemInfoData ItemInfo { get; set; }
    }
}
