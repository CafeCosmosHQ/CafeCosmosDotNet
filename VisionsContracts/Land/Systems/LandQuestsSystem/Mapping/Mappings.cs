using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VisionsContracts.Land.Systems.LandQuestsSystem.ContractDefinition;
using VisionsContracts.Land.Systems.LandQuestsSystem.Model;
using VisionsContracts.Land.Tables;

namespace VisionsContracts.Land.Systems.LandQuestsSystem.Mapping
{
    public static class LandQuestMapping
    {
        public static LandQuestDTO MapLandQuestToDTO(LandQuestTableRecord tableRecord)
        {
            return new LandQuestDTO
            {
                LandId = tableRecord.Keys.LandId,
                QuestGroupId = tableRecord.Keys.QuestGroupId,
                QuestId = tableRecord.Keys.QuestId,
                LandQuest = new LandQuestData
                {
                    NumberOfTasks = tableRecord.Values.NumberOfTasks,
                    NumberOfCompletedTasks = tableRecord.Values.NumberOfCompletedTasks,
                    Claimed = tableRecord.Values.Claimed,
                    Active = tableRecord.Values.Active,
                    ExpiresAt = tableRecord.Values.ExpiresAt
                }
            };
        }

        public static LandQuestTableRecord MapToTableRecord(LandQuestDTO dto)
        {
            return new LandQuestTableRecord
            {
                Keys = new LandQuestTableRecord.LandQuestKey
                {
                    LandId = dto.LandId,
                    QuestGroupId = dto.QuestGroupId,
                    QuestId = dto.QuestId
                },
                Values = new LandQuestTableRecord.LandQuestValue
                {
                    NumberOfTasks = dto.LandQuest.NumberOfTasks,
                    NumberOfCompletedTasks = dto.LandQuest.NumberOfCompletedTasks,
                    Claimed = dto.LandQuest.Claimed,
                    Active = dto.LandQuest.Active,
                    ExpiresAt = dto.LandQuest.ExpiresAt
                }
            };
        }

     

        public static LandQuest MapToModel(LandQuestTableRecord tableRecord)
        {
            return new LandQuest
            {
                LandId = tableRecord.Keys.LandId,
                QuestGroupId = tableRecord.Keys.QuestGroupId,
                QuestId = tableRecord.Keys.QuestId,
                NumberOfTasks = tableRecord.Values.NumberOfTasks,
                NumberOfCompletedTasks = tableRecord.Values.NumberOfCompletedTasks,
                Claimed = tableRecord.Values.Claimed,
                Active = tableRecord.Values.Active,
                ExpiresAt = tableRecord.Values.ExpiresAt
            };
        }

        public static LandQuest MapToModel(LandQuestDTO dto) {

            return new LandQuest
            {
                LandId = dto.LandId,
                QuestGroupId = dto.QuestGroupId,
                QuestId = dto.QuestId,
                NumberOfTasks = dto.LandQuest.NumberOfTasks,
                NumberOfCompletedTasks = dto.LandQuest.NumberOfCompletedTasks,
                Claimed = dto.LandQuest.Claimed,
                Active = dto.LandQuest.Active,
                ExpiresAt = dto.LandQuest.ExpiresAt,
                LandTaskProgress = dto.LandQuestTasks.Select(x => LandQuestTaskProgressMapping.MapToModel(x)).ToList()

            };
        
        }


        public static LandQuestTableRecord MapToTableRecord(LandQuest model)
        {
            return new LandQuestTableRecord
            {
                Keys = new LandQuestTableRecord.LandQuestKey
                {
                    LandId = model.LandId,
                    QuestGroupId = model.QuestGroupId,
                    QuestId = model.QuestId
                },
                Values = new LandQuestTableRecord.LandQuestValue
                {
                    NumberOfTasks = model.NumberOfTasks,
                    NumberOfCompletedTasks = model.NumberOfCompletedTasks,
                    Claimed = model.Claimed,
                    Active = model.Active,
                    ExpiresAt = model.ExpiresAt
                }
            };
        }
    }


    public static class LandQuestGroupMapping
    {
        public static LandQuestGroupDTO MapLandQuestGroupToDTO(LandQuestGroupTableRecord tableRecord)
        {
            return new LandQuestGroupDTO
            {
                LandId = tableRecord.Keys.LandId,
                QuestGroupId = tableRecord.Keys.QuestGroupId,
                LandQuestGroup = new LandQuestGroupData
                {
                    Active = tableRecord.Values.Active,
                    NumberOfQuests = tableRecord.Values.NumberOfQuests,
                    NumberOfCompletedQuests = tableRecord.Values.NumberOfCompletedQuests,
                    Claimed = tableRecord.Values.Claimed,
                    ExpiresAt = tableRecord.Values.ExpiresAt
                },
               
            };
        }

        public static LandQuestGroupTableRecord MapToTableRecord(LandQuestGroupDTO dto)
        {
            return new LandQuestGroupTableRecord
            {
                Keys = new LandQuestGroupTableRecord.LandQuestGroupKey
                {
                    LandId = dto.LandId,
                    QuestGroupId = dto.QuestGroupId
                },
                Values = new LandQuestGroupTableRecord.LandQuestGroupValue
                {
                    Active = dto.LandQuestGroup.Active,
                    NumberOfQuests = dto.LandQuestGroup.NumberOfQuests,
                    NumberOfCompletedQuests = dto.LandQuestGroup.NumberOfCompletedQuests,
                    Claimed = dto.LandQuestGroup.Claimed,
                    ExpiresAt = dto.LandQuestGroup.ExpiresAt
                }
            };
        }

        public static List<LandQuestGroup> MapToModel(List<LandQuestGroupDTO> dtos)
        {
            return dtos.Select(x => MapToModel(x)).ToList();
        }

        public static LandQuestGroup MapToModel(LandQuestGroupDTO dto)
        {
            return new LandQuestGroup
            {
                LandId = dto.LandId,
                QuestGroupId = dto.QuestGroupId,
                Active = dto.LandQuestGroup.Active,
                NumberOfQuests = dto.LandQuestGroup.NumberOfQuests,
                NumberOfCompletedQuests = dto.LandQuestGroup.NumberOfCompletedQuests,
                Claimed = dto.LandQuestGroup.Claimed,
                ExpiresAt = dto.LandQuestGroup.ExpiresAt,
                LandQuests = dto.LandQuests.Select(x => LandQuestMapping.MapToModel(x)).ToList(),
            };

        }

        public static LandQuestGroup MapToModel(LandQuestGroupTableRecord tableRecord)
        {
            return new LandQuestGroup
            {
                LandId = tableRecord.Keys.LandId,
                QuestGroupId = tableRecord.Keys.QuestGroupId,
                Active = tableRecord.Values.Active,
                NumberOfQuests = tableRecord.Values.NumberOfQuests,
                NumberOfCompletedQuests = tableRecord.Values.NumberOfCompletedQuests,
                Claimed = tableRecord.Values.Claimed,
                ExpiresAt = tableRecord.Values.ExpiresAt,
                
            };
        }

        public static LandQuestGroupTableRecord MapToTableRecord(LandQuestGroup model)
        {
            return new LandQuestGroupTableRecord
            {
                Keys = new LandQuestGroupTableRecord.LandQuestGroupKey
                {
                    LandId = model.LandId,
                    QuestGroupId = model.QuestGroupId
                },
                Values = new LandQuestGroupTableRecord.LandQuestGroupValue
                {
                    Active = model.Active,
                    NumberOfQuests = model.NumberOfQuests,
                    NumberOfCompletedQuests = model.NumberOfCompletedQuests,
                    Claimed = model.Claimed,
                    ExpiresAt = model.ExpiresAt
                }
            };
        }
    }

    public static class LandQuestTaskProgressMapping
    {
        public static LandQuestTaskDTO MapToDTO(LandQuestTaskProgress model)
        {
            return new LandQuestTaskDTO
            {
                LandId = model.LandId,
                QuestGroupId = model.QuestGroupId,
                QuestId = model.QuestId,
                Key = model.TaskKey,
                TaskType = model.TaskType,
                LandQuestTask = new LandQuestTaskProgressData
                {
                    TaskProgress = model.TaskProgress,
                    TaskCompleted = model.TaskCompleted
                }
            };
        }

        public static List<LandQuestTaskProgress> MapToModel(List<LandQuestTaskDTO> dtos)
        {
            return dtos.Select(MapToModel).ToList();   
        }

        public static LandQuestTaskProgress MapToModel(LandQuestTaskDTO dto)
        {
            return new LandQuestTaskProgress
            {
                LandId = dto.LandId,
                QuestGroupId = dto.QuestGroupId,
                QuestId = dto.QuestId,
                TaskKey = dto.Key,
                TaskType = dto.TaskType,
                TaskProgress = dto.LandQuestTask.TaskProgress,
                TaskCompleted = dto.LandQuestTask.TaskCompleted,
            };
        }

        public static LandQuestTaskProgressTableRecord MapToTableRecord(LandQuestTaskProgress model)
        {
            return new LandQuestTaskProgressTableRecord
            {
                Keys = new LandQuestTaskProgressTableRecord.LandQuestTaskProgressKey
                {
                    LandId = model.LandId,
                    QuestGroupId = model.QuestGroupId,
                    QuestId = model.QuestId,
                    TaskType = model.TaskType,
                    TaskKey = model.TaskKey,
                },
                Values = new LandQuestTaskProgressTableRecord.LandQuestTaskProgressValue
                {
                    TaskProgress = model.TaskProgress,
                    TaskCompleted = model.TaskCompleted
                }
            };
        }

        public static LandQuestTaskProgress MapToModel(LandQuestTaskProgressTableRecord tableRecord)
        {
            return new LandQuestTaskProgress
            {
                LandId = tableRecord.Keys.LandId,
                QuestGroupId = tableRecord.Keys.QuestGroupId,
                QuestId = tableRecord.Keys.QuestId,
                TaskType = tableRecord.Keys.TaskType,
                TaskKey = tableRecord.Keys.TaskKey,
                TaskProgress = tableRecord.Values.TaskProgress,
                TaskCompleted = tableRecord.Values.TaskCompleted
            };
        }

        public static LandQuestTaskDTO MapToDTO(LandQuestTaskProgressTableRecord tableRecord)
        {
            return new LandQuestTaskDTO
            {
                LandId = tableRecord.Keys.LandId,
                QuestGroupId = tableRecord.Keys.QuestGroupId,
                QuestId = tableRecord.Keys.QuestId,
                TaskType = tableRecord.Keys.TaskType,
                Key = tableRecord.Keys.TaskKey, 
                LandQuestTask = new LandQuestTaskProgressData
                {
                    TaskProgress = tableRecord.Values.TaskProgress,
                    TaskCompleted = tableRecord.Values.TaskCompleted
                }
            };
        }
    }




}
