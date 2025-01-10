using System.Collections.Generic;
using System.Linq;
using VisionsContracts.Land.Systems.QuestsDTOSystem.ContractDefinition;
using VisionsContracts.Land.Systems.QuestsSystem.ContractDefinition;
using VisionsContracts.Land.Systems.QuestsSystem.Model;
using VisionsContracts.Land.Tables;

namespace VisionsContracts.Land.Systems.QuestsSystem.Mapping
{

    public static class TransformationsWithCategoriesMapping
    {
        public static TransformationWithCategoriesDTO MapToDTO(TransformationWithCategories transformationWithCategories)
        {
            return new TransformationWithCategoriesDTO
            {
                Base = transformationWithCategories.Base,
                Input = transformationWithCategories.Input,
                Categories = transformationWithCategories.CategoryIds.Select(x => x).ToList(),
            };
        }
    }
    
    public static class QuestCollectionMapping
    {
        public static QuestCollectionDTO MapToDTO(QuestCollection questCollection)
        {
            return new QuestCollectionDTO
            {
                QuestGroupType = questCollection.QuestGroupType,
                QuestIds = questCollection.QuestIds.Select(x => x).ToList() 
            };
        }

    }

    public static class RewardCollectionMapping
    {
        public static RewardCollectionDTO MapToDTO(RewardCollection rewardCollection)
        {
            return new RewardCollectionDTO
            {
                RewardType = rewardCollection.RewardType,
                RewardIds = rewardCollection.RewardIds.Select(x => x).ToList()
            };
        }

    }

        public static class RewardMapping
    {
        public static RewardDTO MapToDTO(Reward reward)
        {
            return new RewardDTO
            {
                Id = reward.Id,
                Reward = new RewardData
                {
                    RewardType = reward.RewardType,
                    ItemId = reward.ItemId,
                    Quantity = reward.Quantity
                }
            };
        }

        public static Reward MapToModel(RewardDTO rewardDTO)
        {
            return new Reward
            {
                Id = rewardDTO.Id,
                ItemId = rewardDTO.Reward.ItemId,
                RewardType = rewardDTO.Reward.RewardType,
                Quantity = rewardDTO.Reward.Quantity
            };
        }

        public static Reward MapToModel(RewardTableRecord tableRecord)
        {
            return new Reward
            {
                Id = tableRecord.Keys.Id,
                ItemId = tableRecord.Values.ItemId,
                RewardType = tableRecord.Values.RewardType,
                Quantity = tableRecord.Values.Quantity
            };
        }

        public static RewardTableRecord MapToTableRecord(Reward model)
        {
            return new RewardTableRecord
            {
                Keys = new RewardTableRecord.RewardKey
                {
                    Id = model.Id
                },
                Values = new RewardTableRecord.RewardValue
                {
                    ItemId = model.ItemId,
                    RewardType = model.RewardType,
                    Quantity = model.Quantity
                }
            };
        }

        public static RewardDTO MapToDTO(RewardTableRecord tableRecord)
        {
            return new RewardDTO
            {
                Id = tableRecord.Keys.Id,
                Reward = new RewardData
                {
                    RewardType = tableRecord.Values.RewardType,
                    ItemId = tableRecord.Values.ItemId,
                    Quantity = tableRecord.Values.Quantity
                }
            };
        }

        public static RewardTableRecord MapToTableRecord(RewardDTO dto)
        {
            return new RewardTableRecord
            {
                Keys = new RewardTableRecord.RewardKey
                {
                    Id = dto.Id
                },
                Values = new RewardTableRecord.RewardValue
                {
                    RewardType = dto.Reward.RewardType,
                    ItemId = dto.Reward.ItemId,
                    Quantity = dto.Reward.Quantity
                }
            };
        }
    }

    public static class QuestTaskMapping
    {
        public static QuestTaskDTO MapQuestTaskToDTO(QuestTask task)
        {
            return new QuestTaskDTO
            {
                TaskId = task.TaskId,
                Task = new QuestTaskData
                {
                    TaskType = task.TaskType,
                    Key = task.Key,
                    Name = task.Name,
                    TaskKeys = task.TaskKeys,
                    QuestId = task.QuestId,
                    Exists = task.Exists,
                    Quantity = task.Quantity
                }
            };
        }

        public static QuestTask MapQuestTaskDTOToModel(QuestTaskDTO questTaskDTO)
        {
            return new QuestTask
            {
                TaskId = questTaskDTO.TaskId,
                QuestId = questTaskDTO.Task.QuestId,
                Exists = questTaskDTO.Task.Exists,
                Quantity = questTaskDTO.Task.Quantity,
                Key = questTaskDTO.Task.Key,
                Name = questTaskDTO.Task.Name,
                TaskKeys = questTaskDTO.Task.TaskKeys,
                TaskType = questTaskDTO.Task.TaskType
            };
        }

        public static QuestTask MapToModel(QuestTaskTableRecord tableRecord)
        {
            return new QuestTask
            {
                TaskId = tableRecord.Keys.TaskId,
                QuestId = tableRecord.Values.QuestId,
                Exists = tableRecord.Values.Exists,
                Quantity = tableRecord.Values.Quantity,
                Key = tableRecord.Values.Key,
                Name = tableRecord.Values.Name,
                TaskType = tableRecord.Values.TaskType,
                TaskKeys = tableRecord.Values.TaskKeys
            };
        }

        public static QuestTaskTableRecord MapToTableRecord(QuestTask model)
        {
            return new QuestTaskTableRecord
            {
                Keys = new QuestTaskTableRecord.QuestTaskKey
                {
                    TaskId = model.TaskId
                },
                Values = new QuestTaskTableRecord.QuestTaskValue
                {
                    QuestId = model.QuestId,
                    Exists = model.Exists,
                    Quantity = model.Quantity,
                    Key = model.Key,
                    Name = model.Name,
                    TaskKeys = model.TaskKeys,
                    TaskType = model.TaskType
                }
            };
        }

        public static QuestTaskDTO MapToDTO(QuestTaskTableRecord tableRecord)
        {
            return new QuestTaskDTO
            {
                TaskId = tableRecord.Keys.TaskId,
                Task = new QuestTaskData
                {
                    TaskType = tableRecord.Values.TaskType,
                    Key = tableRecord.Values.Key,
                    QuestId = tableRecord.Values.QuestId,
                    Exists = tableRecord.Values.Exists,
                    Quantity = tableRecord.Values.Quantity,
                    Name = tableRecord.Values.Name,
                    TaskKeys = tableRecord.Values.TaskKeys
                }
            };
        }

        public static QuestTaskTableRecord MapToTableRecord(QuestTaskDTO dto)
        {
            return new QuestTaskTableRecord
            {
                Keys = new QuestTaskTableRecord.QuestTaskKey
                {
                    TaskId = dto.TaskId
                },
                Values = new QuestTaskTableRecord.QuestTaskValue
                {
                    TaskType = dto.Task.TaskType,
                    Key = dto.Task.Key,
                    QuestId = dto.Task.QuestId,
                    Exists = dto.Task.Exists,
                    Quantity = dto.Task.Quantity,
                    Name = dto.Task.Name,
                    TaskKeys = dto.Task.TaskKeys
                }
            };
        }
    }

    public static class QuestMapping
    {
        public static QuestDTO MapToDTO(Quest quest)
        {
            return new QuestDTO
            {
                Id = quest.Id,
                Quest = new QuestData
                {
                    QuestName = quest.QuestName,
                    Exists = quest.Exists,
                    Duration = quest.Duration,
                    RewardIds = quest.Rewards.Select(x => x.Id).ToList(),
                    Tasks = quest.Tasks.Select(x => x.TaskId).ToList()
                },
                Tasks = quest.Tasks.Select(x => QuestTaskMapping.MapQuestTaskToDTO(x)).ToList(),
                Rewards = quest.Rewards.Select(x => RewardMapping.MapToDTO(x)).ToList()
            };
        }

        public static Quest MapToModel(QuestDTO questDTO)
        {
            return new Quest
            {
                Id = questDTO.Id,
                QuestName = questDTO.Quest.QuestName,
                Exists = questDTO.Quest.Exists,
                Duration = questDTO.Quest.Duration,
                Tasks = questDTO.Tasks.Select(x => QuestTaskMapping.MapQuestTaskDTOToModel(x)).ToList(),
                Rewards = questDTO.Rewards.Select(x => RewardMapping.MapToModel(x)).ToList()
            };
        }

        public static Quest MapToModel(QuestTableRecord tableRecord)
        {
            return new Quest
            {
                Id = tableRecord.Keys.Id,
                QuestName = tableRecord.Values.QuestName,
                Exists = tableRecord.Values.Exists,
                Duration = tableRecord.Values.Duration,
               
            };
        }

        public static QuestTableRecord MapToTableRecord(Quest model)
        {
            return new QuestTableRecord
            {
                Keys = new QuestTableRecord.QuestKey
                {
                    Id = model.Id
                },
                Values = new QuestTableRecord.QuestValue
                {
                    QuestName = model.QuestName,
                    Exists = model.Exists,
                    Duration = model.Duration,
                    Tasks = model.Tasks.Select(q => q.TaskId).ToList(),
                    RewardIds = model.Rewards.Select(r => r.Id).ToList()
                }
            };
        }

        public static QuestDTO MapToDTO(QuestTableRecord tableRecord)
        {
            return new QuestDTO
            {
                Id = tableRecord.Keys.Id,
                Quest = new QuestData
                {
                    QuestName = tableRecord.Values.QuestName,
                    Exists = tableRecord.Values.Exists,
                    Duration = tableRecord.Values.Duration,
                    RewardIds = tableRecord.Values.RewardIds,
                    Tasks = tableRecord.Values.Tasks
                }
             };
        }

        public static QuestTableRecord MapToTableRecord(QuestDTO dto)
        {
            return new QuestTableRecord
            {
                Keys = new QuestTableRecord.QuestKey
                {
                    Id = dto.Id
                },
                Values = new QuestTableRecord.QuestValue
                {
                    QuestName = dto.Quest.QuestName,
                    Exists = dto.Quest.Exists,
                    Duration = dto.Quest.Duration,
                    Tasks = dto.Quest.Tasks,
                    RewardIds = dto.Quest.RewardIds
                }
            };
        }
    }

    public static class QuestGroupMapping
    {
        public static QuestGroupDTO MapToDTO(QuestGroup questGroup)
        {
            return new QuestGroupDTO
            {
                Id = questGroup.Id,
                QuestGroup = new QuestGroupData
                {
                    StartsAt = questGroup.StartsAt,
                    ExpiresAt = questGroup.ExpiresAt,
                    Sequential = questGroup.Sequential,
                    QuestGroupType = questGroup.QuestGroupType,
                    QuestIds = questGroup.Quests.Select(x => x.Id).ToList(),
                    RewardIds = questGroup.Rewards.Select(x => x.Id).ToList()
                },
                Quests = questGroup.Quests.Select(x => QuestMapping.MapToDTO(x)).ToList(),
                Rewards = questGroup.Rewards.Select(x => RewardMapping.MapToDTO(x)).ToList()
            };
        }

        public static List<QuestGroup> MapToModel(List<QuestGroupDTO> questGroupDTOs)
        {
            return questGroupDTOs.Select(x => MapToModel(x)).ToList();
        }

        public static QuestGroup MapToModel(QuestGroupDTO questGroupDTO)
        {
            
            return new QuestGroup
            {
                Id = questGroupDTO.Id,
                StartsAt = questGroupDTO.QuestGroup.StartsAt,
                ExpiresAt = questGroupDTO.QuestGroup.ExpiresAt,
                Sequential = questGroupDTO.QuestGroup.Sequential,
                QuestGroupType = questGroupDTO.QuestGroup.QuestGroupType,
                Quests = questGroupDTO.Quests.Select(x => QuestMapping.MapToModel(x)).ToList(),
                Rewards = questGroupDTO.Rewards.Select(x => RewardMapping.MapToModel(x)).ToList()
            };
        }

        public static QuestGroup MapToModel(QuestGroupTableRecord tableRecord)
        {
            return new QuestGroup
            {
                Id = tableRecord.Keys.Id,  
                StartsAt = tableRecord.Values.StartsAt, 
                ExpiresAt = tableRecord.Values.ExpiresAt,
                Sequential = tableRecord.Values.Sequential,
                QuestGroupType = tableRecord.Values.QuestGroupType,
                Quests = tableRecord.Values.QuestIds.Select(id => new Quest { Id = id }).ToList(), 
                Rewards = tableRecord.Values.RewardIds.Select(id => new Reward { Id = id }).ToList() 
            };
        }

        public static QuestGroupTableRecord MapToTableRecord(QuestGroup model)
        {
            return new QuestGroupTableRecord
            {
                Keys = new QuestGroupTableRecord.QuestGroupKey  
                {
                    Id = model.Id
                },
                Values = new QuestGroupTableRecord.QuestGroupValue  
                {
                    StartsAt = model.StartsAt,
                    ExpiresAt = model.ExpiresAt,
                    Sequential = model.Sequential,
                    QuestGroupType = model.QuestGroupType,
                    QuestIds = model.Quests.Select(q => q.Id).ToList(),
                    RewardIds = model.Rewards.Select(r => r.Id).ToList()
                }
            };
        }

        public static QuestGroupDTO MapToDTO(QuestGroupTableRecord tableRecord)
        {
            return new QuestGroupDTO
            {
                Id = tableRecord.Keys.Id,  
                QuestGroup = new QuestGroupData
                {
                    StartsAt = tableRecord.Values.StartsAt, 
                    ExpiresAt = tableRecord.Values.ExpiresAt,
                    Sequential = tableRecord.Values.Sequential,
                    QuestGroupType = tableRecord.Values.QuestGroupType,
                    QuestIds = tableRecord.Values.QuestIds,
                    RewardIds = tableRecord.Values.RewardIds
                }
            };
        }

        public static QuestGroupTableRecord MapToTableRecord(QuestGroupDTO dto)
        {
            return new QuestGroupTableRecord
            {
                Keys = new QuestGroupTableRecord.QuestGroupKey 
                {
                    Id = dto.Id
                },
                Values = new QuestGroupTableRecord.QuestGroupValue 
                {
                    StartsAt = dto.QuestGroup.StartsAt,
                    ExpiresAt = dto.QuestGroup.ExpiresAt,
                    Sequential = dto.QuestGroup.Sequential,
                    QuestGroupType = dto.QuestGroup.QuestGroupType,
                    QuestIds = dto.QuestGroup.QuestIds,
                    RewardIds = dto.QuestGroup.RewardIds
                }
            };
        }
    }

}