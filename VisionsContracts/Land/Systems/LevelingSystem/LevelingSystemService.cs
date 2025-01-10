using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VisionsContracts.Land.Systems.LevelingSystem.Model;
using VisionsContracts.Land.Systems.LevelingSystem.Mapping;
using System.Threading;
using Nethereum.RPC.Eth.DTOs;
using System.Numerics;
using Nethereum.Mud.Contracts.World.Systems.BatchCallSystem.ContractDefinition;
using VisionsContracts.Land.Systems.LevelingSystem.ContractDefinition;
using VisionsContracts.Land.Systems.LandItemInteractionSystem.ContractDefinition;
using VisionsContracts.Land.Systems.LandItemInteractionSystem;

namespace VisionsContracts.Land.Systems.LevelingSystem
{
    public partial class LevelingSystemService
    {
        public async Task<string> UpsertDefaultLevelRewardsRequestAsync()
        {
            var levelRewards = DefaultLevelRewards.GetRewards();
            return await this.UpsertLevelRewardsRequestAsync(levelRewards.MapToDTO());
        }

        public async Task<TransactionReceipt> UpsertDefaultLevelRewardsRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
            var levelRewards = DefaultLevelRewards.GetRewards();
            return await this.UpsertLevelRewardsRequestAndWaitForReceiptAsync(levelRewards.MapToDTO(), cancellationToken);
        }

        public static SystemCallData GetSystemCallDataToUnlockAllLevels(BigInteger landId)
        {
           return GetSystemCallMulticallInputToUnlockAllLevels(landId).GetSystemCallData();
        }

        public static SystemCallMulticallInput<UnlockAllLevelsFunction, LevelingSystemServiceResource> GetSystemCallMulticallInputToUnlockAllLevels(BigInteger landId)
        {
            var unlockFunction = new UnlockAllLevelsFunction()
            {
                LandId = landId
            };
            return new SystemCallMulticallInput<UnlockAllLevelsFunction, LevelingSystemServiceResource>(unlockFunction, null);
        }
    }
}
