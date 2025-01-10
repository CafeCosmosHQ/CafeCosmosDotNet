using Nethereum.Contracts;
using Nethereum.Mud;
using Nethereum.Mud.Contracts.World.Systems.BatchCallSystem;
using Nethereum.Mud.Contracts.World.Systems.BatchCallSystem.ContractDefinition;
using Nethereum.RPC.Eth.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisionsContracts.Land.Systems.LandItemInteractionSystem.ContractDefinition;
using VisionsContracts.LandLocalState;
using VisionsContracts.Land.Exceptions;
using VisionsContracts.Land.Systems.LandTransform.ContractDefinition;
using Nethereum.Mud.Contracts.Core.Systems;
using Nethereum.Mud.Contracts.ContractHandlers;
using VisionsContracts.Land.Systems.LevelingSystem;
using VisionsContracts.Land.Systems.QuestsSystem;
using VisionsContracts.Land.Systems.LandQuestsSystem;

namespace VisionsContracts.Land.Systems.LandItemInteractionSystem
{
    public partial class LandItemInteractionSystemService
    {
        public BatchCallSystemService GetBatchCallSystem()
        {
            return new BatchCallSystemService(Web3, ContractAddress);
        }

        public Task<string> MulticallRequestAsync(List<byte[]> callDatas)
        {
            var batchCallSystem = GetBatchCallSystem();
            if (this.ContractHandler is MudCallFromContractHandler mudCallFromContractHandler)
            {
                var systemCallDatas = callDatas.Select(x => new SystemCallFromData() { From = mudCallFromContractHandler.Delegator, CallData = x, SystemId = ResourceRegistry.GetResourceEncoded<LandItemInteractionSystemServiceResource>() }).ToList();
                return batchCallSystem.BatchCallFromRequestAsync(systemCallDatas);
            }
            else
            {
                var systemCallDatas = callDatas.Select(x => new SystemCallData() { CallData = x, SystemId = ResourceRegistry.GetResourceEncoded<LandItemInteractionSystemServiceResource>() }).ToList();
                return batchCallSystem.BatchCallRequestAsync(systemCallDatas);
            }
            

        }

        public Task<TransactionReceipt> MulticallRequestAndWaitForReceiptAsync(List<byte[]> callDatas)
        {
            var batchCallSystem = GetBatchCallSystem();
            if (this.ContractHandler is MudCallFromContractHandler mudCallFromContractHandler)
            {
                var systemCallDatas = callDatas.Select(x => new SystemCallFromData() { From = mudCallFromContractHandler.Delegator, CallData = x, SystemId = ResourceRegistry.GetResourceEncoded<LandItemInteractionSystemServiceResource>() }).ToList();
                return batchCallSystem.BatchCallFromRequestAndWaitForReceiptAsync(systemCallDatas);
            }
            else
            {
                var systemCallDatas = callDatas.Select(x => new SystemCallData() { CallData = x, SystemId = ResourceRegistry.GetResourceEncoded<LandItemInteractionSystemServiceResource>() }).ToList();
                return batchCallSystem.BatchCallRequestAndWaitForReceiptAsync(systemCallDatas);
            }
        }

        public Task<TransactionReceipt> MulticallRequestAndWaitForReceiptAsync(List<SystemCallData> systemCallDatas)
        {
            var batchCallSystem = GetBatchCallSystem();
            if (this.ContractHandler is MudCallFromContractHandler mudCallFromContractHandler)
            {
                var callDataFrom = systemCallDatas.Select(x => new SystemCallFromData() { From = mudCallFromContractHandler.Delegator, CallData = x.CallData, SystemId = x.SystemId }).ToList();
                return batchCallSystem.BatchCallFromRequestAndWaitForReceiptAsync(callDataFrom);
            }
            else
            {
                return batchCallSystem.BatchCallRequestAndWaitForReceiptAsync(systemCallDatas);
            }
        }

        public Task<string> MulticallRequestAsync(List<SystemCallData> systemCallDatas)
        {
            var batchCallSystem = GetBatchCallSystem();
            if (this.ContractHandler is MudCallFromContractHandler mudCallFromContractHandler)
            {
                var callDataFrom = systemCallDatas.Select(x => new SystemCallFromData() { From = mudCallFromContractHandler.Delegator, CallData = x.CallData, SystemId = x.SystemId }).ToList();
                return batchCallSystem.BatchCallFromRequestAsync(callDataFrom);
            }
            else
            {
                return batchCallSystem.BatchCallRequestAsync(systemCallDatas);
            }
        }

        public async Task<string> UpdateLandRequestAsync(PlayerLocalState updateLandOperations)
        {
            var requests = new List<SystemCallData>();
            foreach (var request in updateLandOperations.UpdateLandOperations)
            {
                requests.Add(request.GetSystemCallData());
            }
            return await this.MulticallRequestAsync(requests);
        }

        public async Task<TransactionReceipt> UpdateLandRequestAndWaitForReceiptAsync(PlayerLocalState updateLandOperations)
        {
            //Console.WriteLine("Start");
            //var ensureTimeStamp = await this.TimestampCheckRequestAndWaitForReceiptAsync();
            //Console.WriteLine("Finish");
            var requests = new List<SystemCallData>();
           
            var createDailyQuestIfNotExists = QuestsSystemService.GetSystemCallDataToCreateDailyQuestIfNotExists();
            var activateQuests = LandQuestsSystemService.GetSystemCallDataToActivateAllQuestsGroups(updateLandOperations.LandId); 
            
            requests.Add(createDailyQuestIfNotExists); // Add the create daily quest request to the list of requests so it executes first
            requests.Add(activateQuests); // Add the activate quests request to the list of requests so it executes after the create daily quest request

            foreach (var request in updateLandOperations.UpdateLandOperations)
            {
                requests.Add(request.GetSystemCallData());
            }

            
            // Add the unlock all levels request to the list of requests at the end so it executes after all the other requests
            var unlockAllLevels = LevelingSystemService.GetSystemCallMulticallInputToUnlockAllLevels(updateLandOperations.LandId);
            requests.Add(unlockAllLevels.GetSystemCallData());
            try
            {
                return await this.MulticallRequestAndWaitForReceiptAsync(requests);
            }
            catch (SmartContractCustomErrorRevertException e)
            {
                //var errorHandled = this.FindCustomErrorException(e);
                //if (errorHandled != null) throw errorHandled;

                //Console.WriteLine("Not found");
                    ;
                if (e.IsCustomErrorFor<LandItemInteractionSystem.ContractDefinition.TransformationIncompatibleError>())
                {
                    var error = e.DecodeError<LandItemInteractionSystem.ContractDefinition.TransformationIncompatibleError>();
                   // throw new SmartContractCustomErrorRevertException<LandItemInteractionSystem.ContractDefinition.TransformationIncompatibleError>(error, e);
                }

                if (e.IsCustomErrorFor<NotUnlockedYetError>())
                {

                    var error = e.DecodeError<NotUnlockedYetError>();
                    Console.WriteLine(error.X);
                    Console.WriteLine(error.Y);
                    Console.WriteLine("Unlock Time");
                    Console.WriteLine(error.UnlockTime);
                    Console.WriteLine("Time now");
                    Console.WriteLine(error.TimeNow);
                   
                    
                    //throw new SmartContractCustomErrorRevertException<NotUnlockedYetError>(error, e);
                }

                throw e;
            }
        }
    }
}
