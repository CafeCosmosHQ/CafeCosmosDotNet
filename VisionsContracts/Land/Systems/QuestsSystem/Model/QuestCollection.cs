using System.Collections.Generic;
using System.Numerics;

namespace VisionsContracts.Land.Systems.QuestsSystem.Model
{
    public class QuestCollection
    {
        public virtual BigInteger QuestGroupType { get; set; }
        public virtual List<BigInteger> QuestIds { get; set; }
    }

}
