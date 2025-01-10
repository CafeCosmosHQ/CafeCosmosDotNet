using System.Collections.Generic;
using System.Numerics;

namespace VisionsContracts.Land.Systems.QuestsSystem.Model
{

    public enum QuestGroupType
    {
        Daily = 0,
        Weekly = 1
    }

    public class QuestGroup
    {
        public virtual BigInteger StartsAt { get; set; }
        public virtual BigInteger ExpiresAt { get; set; }
        public virtual bool Sequential { get; set; }
        public virtual BigInteger QuestGroupType { get; set; }
        public virtual BigInteger Id { get; set; }
        public virtual List<Quest> Quests { get; set; } = new List<Quest>();
        public virtual List<Reward> Rewards { get; set; } = new List<Reward>();
        
    }

}
