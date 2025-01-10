using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using VisionsContracts.Land.Systems.LevelingSystem.ContractDefinition;
using VisionsContracts.Land.Systems.LevelingSystem.Model;

namespace VisionsContracts.Land.Systems.LevelingSystem.Mapping
{
    public static class LevelRewardMapping
    {
        public static LevelRewardDTO MapToDTO(this LevelReward levelReward)
        {
            if(levelReward.Items == null)
            {
                levelReward.Items = new List<BigInteger>();
            }   
            return new LevelRewardDTO
            {
                Level = levelReward.Level,
                CumulativeXp = levelReward.CumulativeXp,
                Tokens = levelReward.Tokens,
                Items = levelReward.Items,
            };
        }

        public static LevelReward MapToModel(this LevelRewardDTO levelRewardDTO)
        {
            if (levelRewardDTO.Items == null)
            {
                levelRewardDTO.Items = new List<BigInteger>();
            }
            return new LevelReward
            {
                Level = (int)levelRewardDTO.Level,
                Tokens = levelRewardDTO.Tokens,
                CumulativeXp = (int)levelRewardDTO.CumulativeXp,
                Items = levelRewardDTO.Items,
            };
        }

        public static List<LevelRewardDTO> MapToDTO(this List<LevelReward> levelRewards)
        {
            List<LevelRewardDTO> levelRewardDTOs = new List<LevelRewardDTO>();
            foreach (var levelReward in levelRewards)
            {
                levelRewardDTOs.Add(levelReward.MapToDTO());
            }
            return levelRewardDTOs;
        }

        public static List<LevelReward> MapToModel(this List<LevelRewardDTO> levelRewardDTOs)
        {
            List<LevelReward> levelRewards = new List<LevelReward>();
            foreach (var levelRewardDTO in levelRewardDTOs)
            {
                levelRewards.Add(levelRewardDTO.MapToModel());
            }
            return levelRewards;
        }
    }
}
