using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace VisionsContracts.Land.Systems.QuestsDTOSystem.ContractDefinition
{
    public partial class QuestCollectionDTO : QuestCollectionDTOBase { }

    public class QuestCollectionDTOBase 
    {
        [Parameter("uint256", "questGroupType", 1)]
        public virtual BigInteger QuestGroupType { get; set; }
        [Parameter("uint256[]", "questIds", 2)]
        public virtual List<BigInteger> QuestIds { get; set; }
    }
}
