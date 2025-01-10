using Nethereum.Mud.TableRepository;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using VisionsContracts.Land.Systems.LandQuestsSystem.Mapping;
using VisionsContracts.Land.Systems.LandQuestsSystem.Model;
using VisionsContracts.Land.Systems.QuestsSystem.ContractDefinition;
using VisionsContracts.Land.Systems.QuestsSystem;
using VisionsContracts.Land.Systems.QuestsSystem.Mapping;
using VisionsContracts.Land.Systems.QuestsSystem.Model;
using VisionsContracts.Land.Tables;
using Nethereum.Mud.Contracts.World.Systems.BatchCallSystem.ContractDefinition;
using VisionsContracts.Land.Systems.LandQuestsSystem.ContractDefinition;

namespace VisionsContracts.Land.Systems.LandQuestsSystem
{
    public partial class LandQuestsSystemService: LandQuestsSystemServiceBase
    {
        public async Task<List<LandQuestGroup>> GetAllActiveQuestGroupsAsync(BigInteger landId, BlockParameter blockParameter = null)
        {
            var landQuestGroupsDTO = await GetActiveLandQuestGroupsQueryAsync(landId, blockParameter);
            return LandQuestGroupMapping.MapToModel(landQuestGroupsDTO.ReturnValue1);
        }

        public async Task<LandQuestGroup> GetLandQuestGroupAsync(BigInteger landId, BigInteger questGroupId, BlockParameter blockParameter = null)
        {
            var landQuestGroupDTO = await GetLandQuestGroupQueryAsync(landId, questGroupId, blockParameter);
            return LandQuestGroupMapping.MapToModel(landQuestGroupDTO.ReturnValue1);
        }

        public async Task InsertLandQuestGroupsIntoTableStorage(List<LandQuestGroup> landQuestGroups, InMemoryTableRepository tableRepository)
        {

            var landQuestGroupRecords = new List<LandQuestGroupTableRecord>();
            var landQuestRecords = new List<LandQuestTableRecord>();
            var landTaskProgressRecords = new List<LandQuestTaskProgressTableRecord>();
         

            foreach (var landQuestGroup in landQuestGroups)
            {
                var landQuestGroupRecord = LandQuestGroupMapping.MapToTableRecord(landQuestGroup);
                landQuestGroupRecords.Add(landQuestGroupRecord);

                if (landQuestGroup.LandQuests != null)
                {
                    foreach (var landQuest in landQuestGroup.LandQuests)
                    {
                        landQuestRecords.Add(LandQuestMapping.MapToTableRecord(landQuest));
                        if (landQuest.LandTaskProgress != null)
                        {
                            foreach (var landTaskProgress in landQuest.LandTaskProgress)
                            {
                                landTaskProgressRecords.Add(LandQuestTaskProgressMapping.MapToTableRecord(landTaskProgress));
                            }

                        }
                    }
                }
            }

            await tableRepository.SetRecordsAsync(landQuestGroupRecords);
            await tableRepository.SetRecordsAsync(landQuestRecords);
            await tableRepository.SetRecordsAsync(landTaskProgressRecords);
        }

        public static SystemCallData GetSystemCallDataToActivateAllQuestsGroups(BigInteger landId)
        {
            return GetActivateAllQuestsGroupsMulticallInput(landId).GetSystemCallData();
        }

        public static SystemCallMulticallInput<ActivateAllQuestGroupsFunction, LandQuestsSystemServiceResource> GetActivateAllQuestsGroupsMulticallInput(BigInteger landId)
        {
            var message = new ActivateAllQuestGroupsFunction()
            {
                LandId = landId
            };

            return new SystemCallMulticallInput<ActivateAllQuestGroupsFunction, LandQuestsSystemServiceResource>(message, null);
        }
    }
}
