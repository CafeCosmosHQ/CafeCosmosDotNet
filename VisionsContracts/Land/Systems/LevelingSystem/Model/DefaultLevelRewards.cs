using System.Collections.Generic;
using System.Linq;

namespace VisionsContracts.Land.Systems.LevelingSystem.Model
{
    public class DefaultLevelRewards
    {
        public static List<LevelReward> GetRewards()
        {
            return new List<LevelReward>
        {
            new LevelReward(1, 0, 0),
            new LevelReward(2, 12,  0),
            new LevelReward(3, 25,  0),
            new LevelReward(4, 38,  0),
            new LevelReward(5, 52,  0),
            new LevelReward(6, 66,  0),
            new LevelReward(7, 81,  0),
            new LevelReward(8, 96,  0),
            new LevelReward(9, 111, 0),
            new LevelReward(10, 127,  0  ),
            new LevelReward(11, 143,  0  ),
            new LevelReward(12, 159,  0  ),
            new LevelReward(13, 175,  0  ),
            new LevelReward(14, 202,  0  ),
            new LevelReward(15, 229,  0  ),
            new LevelReward(16, 256,  0  ),
            new LevelReward(17, 283,  0  ),
            new LevelReward(18, 310,  0  ),
            new LevelReward(19, 338,  0  ),
            new LevelReward(20, 366,  0  ),
            new LevelReward(21, 394,  0  ),
            new LevelReward(22, 422,  0  ),
            new LevelReward(23, 460,  0  ),
            new LevelReward(24, 498,  0  ),
            new LevelReward(25, 536,  0  ),
            new LevelReward(26, 574,  0  ),
            new LevelReward(27, 613,  0  ),
            new LevelReward(28, 662,  0  ),
            new LevelReward(29, 711,  0  ),
            new LevelReward(30, 760,  0  ),
            new LevelReward(31, 809,  0  ),
            new LevelReward(32, 858,  0  ),
            new LevelReward(33, 917,  0  ),
            new LevelReward(34, 976,  0  ),
            new LevelReward(35, 1035, 0 ),
            new LevelReward(36, 1094, 0 ),
            new LevelReward(37, 1163, 0 ),
            new LevelReward(38, 1233, 0 ),
            new LevelReward(39, 1303, 0 ),
            new LevelReward(40, 1373, 0 ),
            new LevelReward(41, 1453, 0 ),
            new LevelReward(42, 1533, 0 ),
            new LevelReward(43, 1613, 0 ),
            new LevelReward(44, 1703, 0 ),
            new LevelReward(45, 1793, 0 ),
            new LevelReward(46, 1883, 0 ),
            new LevelReward(47, 1973, 0 ),
            new LevelReward(48, 2073, 0 ),
            new LevelReward(49, 2173, 0 ),
            new LevelReward(50, 2283, 0 )
        };
        }

        public LevelReward GetLevelReward(int level)
        {
            return GetRewards().FirstOrDefault(r => r.Level == level);
        }

        public LevelReward GetLevelRewardByCumulativeXp(int cumulativeXp)
        {
            return GetRewards().FirstOrDefault(r => r.CumulativeXp == cumulativeXp);
        }
    }
}

