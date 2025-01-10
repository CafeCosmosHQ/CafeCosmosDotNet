using System.Collections.Generic;
using System.Numerics;

namespace VisionsContracts.Land.Systems.LandQuestsSystem.Model
{
    public class LandQuestGroup
    {
        public BigInteger LandId { get; set; }
        public BigInteger QuestGroupId { get; set; }
        public bool Active { get; set; }
        public BigInteger NumberOfQuests { get; set; }
        public BigInteger NumberOfCompletedQuests { get; set; }
        public bool Claimed { get; set; }
        public BigInteger ExpiresAt { get; set; }
        public List<LandQuest> LandQuests { get; set; } = new List<LandQuest>();
    }

    public class LandQuest
    {
        public BigInteger LandId { get; set; }             
        public BigInteger QuestGroupId { get; set; }       
        public BigInteger QuestId { get; set; }            
        public BigInteger NumberOfTasks { get; set; }
        public BigInteger NumberOfCompletedTasks { get; set; }
        public bool Claimed { get; set; }
        public bool Active { get; set; }
        public BigInteger ExpiresAt { get; set; }
        public List<LandQuestTaskProgress> LandTaskProgress { get; set; } = new List<LandQuestTaskProgress>();
    }

    public class LandQuestTaskProgress
    {
        public BigInteger LandId { get; set; }             
        public BigInteger QuestGroupId { get; set; }       
        public BigInteger QuestId { get; set; }            
        public BigInteger TaskType { get; set; }
        public byte[] TaskKey { get; set; }                 
        public BigInteger TaskProgress { get; set; } 
        public bool TaskCompleted { get; set; }
    }


}
