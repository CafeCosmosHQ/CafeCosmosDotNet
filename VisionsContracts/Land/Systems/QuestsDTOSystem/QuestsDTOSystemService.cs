using Nethereum.Mud.TableRepository;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using Org.BouncyCastle.Asn1.Mozilla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VisionsContracts.Land.Systems.QuestsSystem.ContractDefinition;
using VisionsContracts.Land.Systems.QuestsSystem.Mapping;
using VisionsContracts.Land.Systems.QuestsSystem.Model;
using VisionsContracts.Land.Tables;

namespace VisionsContracts.Land.Systems.QuestsDTOSystem
{
    public partial class QuestsDTOSystemService : QuestsDTOSystemServiceBase
    {
        public async Task<string> SetDefaultDataRequestAsync()
        {
           
            await this.SetDefaultQuestsRequestAsync();
            await this.AddDefaultQuestCollectionsRequestAsync();
            await this.AddDefaultRewardsRequestAsync();
            await this.AddDefaultRewardCollectionsRequestAsync();
            return await this.AddDefaultTransformationsWithCategoriesRequestAsync();
        }


        public async Task<string> SetDefaultQuestsRequestAsync()
        {
             var quests = DefaultQuests.GetAll().Select(x => QuestMapping.MapToDTO(x)).ToList();
             var split = quests.Count / 2;
            var questsFirst = quests.Take(split).ToList();
            var questsSecond = quests.Skip(split).ToList();
            await this.AddNewQuestsRequestAsync(questsFirst);
            return await this.AddNewQuestsRequestAsync(questsSecond);
        }

        public Task<TransactionReceipt> SetDefaultQuestsRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
            var quests = DefaultQuests.GetAll().Select(x => QuestMapping.MapToDTO(x)).ToList();
            return this.AddNewQuestsRequestAndWaitForReceiptAsync(quests, cancellationToken);
        }

        public Task<string> AddDefaultQuestCollectionsRequestAsync()
        {
            var questCollections = DefaultQuestCollections.GetAll().Select(x => QuestCollectionMapping.MapToDTO(x)).ToList();
            return this.UpsertQuestCollectionsRequestAsync(questCollections);
        }

        public Task<TransactionReceipt> AddDefaultQuestCollectionsRequestAndWaitForReceiptAsync()
        {
            var questCollections = DefaultQuestCollections.GetAll().Select(x => QuestCollectionMapping.MapToDTO(x)).ToList();
            return this.UpsertQuestCollectionsRequestAndWaitForReceiptAsync(questCollections);
        }

        public Task<string> AddDefaultRewardsRequestAsync()
        {
            var rewards = DefaultRewards.GetAll().Select(x => RewardMapping.MapToDTO(x)).ToList();
            return this.AddRewardsRequestAsync(rewards);
        }

        public Task<TransactionReceipt> AddDefaultRewardsRequestAndWaitForReceiptAsync()
        {
            var rewards = DefaultRewards.GetAll().Select(x => RewardMapping.MapToDTO(x)).ToList();
            return this.AddRewardsRequestAndWaitForReceiptAsync(rewards);
        }

        public Task<string> AddDefaultRewardCollectionsRequestAsync()
        {
            var rewardCollections = DefaultRewardsCollections.GetAll().Select(x => RewardCollectionMapping.MapToDTO(x)).ToList();
            return this.UpsertRewardColletionsRequestAsync(rewardCollections);
        }

        public Task<TransactionReceipt> AddDefaultRewardCollectionsRequestAndWaitForReceiptAsync()
        {
            var rewardCollections = DefaultRewardsCollections.GetAll().Select(x => RewardCollectionMapping.MapToDTO(x)).ToList();
            return this.UpsertRewardColletionsRequestAndWaitForReceiptAsync(rewardCollections);
        }

        public Task<string> AddDefaultTransformationsWithCategoriesRequestAsync()
        {
            var transactionCategories = DefaultTransformationsWithCategories.GetAll().Select(x => TransformationsWithCategoriesMapping.MapToDTO(x)).ToList();
            return this.UpsertTransformationCategoriesRequestAsync(transactionCategories);
        }

        public Task<TransactionReceipt> AddDefaultTransformationsWithCategoriesRequestAndWaitForReceiptAsync()
        {
            var transactionCategories = DefaultTransformationsWithCategories.GetAll().Select(x => TransformationsWithCategoriesMapping.MapToDTO(x)).ToList();
            return this.UpsertTransformationCategoriesRequestAndWaitForReceiptAsync(transactionCategories);
        }

        public async Task<List<QuestGroup>> GetAllActiveQuestGroupsAsync(BlockParameter blockParameter = null)
        {
            var questGroupsDTO =  await GetAllActiveQuestGroupsQueryAsync(blockParameter);
            return QuestGroupMapping.MapToModel(questGroupsDTO.QuestGroups);
        }

       

        public async Task InsertQuestGroupsIntoTableStorage(List<QuestGroup> questGroups, InMemoryTableRepository tableRepository) {

            var questGroupRecords = new List<QuestGroupTableRecord>();
            var questRecords = new List<QuestTableRecord>();
            var rewards = new List<RewardTableRecord>();
            var questTasks = new List<QuestTaskTableRecord>();

            foreach (var questGroup in questGroups)
            {
                var questGroupRecord = QuestGroupMapping.MapToTableRecord(questGroup);
                questGroupRecords.Add(questGroupRecord);

                foreach (var quest in questGroup.Quests)
                {
                    questRecords.Add(QuestMapping.MapToTableRecord(quest));
                    foreach (var reward in quest.Rewards)
                    {
                        rewards.Add(RewardMapping.MapToTableRecord(reward));
                    }

                    foreach (var task in quest.Tasks)
                    {
                        questTasks.Add(QuestTaskMapping.MapToTableRecord(task));
                    }
                }

                foreach (var reward in questGroup.Rewards)
                {
                    rewards.Add(RewardMapping.MapToTableRecord(reward));
                }
            }

            await tableRepository.SetRecordsAsync(questRecords);
            await tableRepository.SetRecordsAsync(questGroupRecords);
            await tableRepository.SetRecordsAsync(questTasks);
            await tableRepository.SetRecordsAsync(rewards);

        }
    }
}
