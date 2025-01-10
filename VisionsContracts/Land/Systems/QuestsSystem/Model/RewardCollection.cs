using System.Collections.Generic;
using System.Numerics;

namespace VisionsContracts.Land.Systems.QuestsSystem.Model
{
    public class RewardCollection
    {
        public  BigInteger RewardType { get; set; }
        public  List<BigInteger> RewardIds { get; set; }
    }

    public class DefaultRewardsCollections
    {
        public static List<RewardCollection> GetAll()
        {
            return new List<RewardCollection>() { DailyQuestsService.GetDailyRewardCollection() };
        }
    }

    public class DefaultQuestCollections
    {
        public static List<QuestCollection> GetAll()
        {
            return new List<QuestCollection>() { DailyQuestsService.GetDailyQuestCollection() };
        }
    }

}
