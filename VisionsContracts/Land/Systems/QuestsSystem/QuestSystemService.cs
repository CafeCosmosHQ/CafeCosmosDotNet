using System;
using System.Collections.Generic;
using System.Text;
using VisionsContracts.Land.Systems.LevelingSystem.ContractDefinition;
using VisionsContracts.Land.Systems.LevelingSystem;
using Nethereum.Mud.Contracts.World.Systems.BatchCallSystem.ContractDefinition;
using VisionsContracts.Land.Systems.QuestsSystem.ContractDefinition;

namespace VisionsContracts.Land.Systems.QuestsSystem
{
    public partial class QuestsSystemService
    {
        public static SystemCallData GetSystemCallDataToCreateDailyQuestIfNotExists()
        {
            return GetCreateDailyQuestIfNotExistsMulticallInput().GetSystemCallData();
        }

        public static SystemCallMulticallInput<CreateDailyQuestIfNotExistsFunction, QuestsSystemServiceResource> GetCreateDailyQuestIfNotExistsMulticallInput()
        {
            var message = new CreateDailyQuestIfNotExistsFunction();
           
            return new SystemCallMulticallInput<CreateDailyQuestIfNotExistsFunction, QuestsSystemServiceResource>(message, null);
        }
    }
}
