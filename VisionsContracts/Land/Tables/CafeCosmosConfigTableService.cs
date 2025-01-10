using Nethereum.Mud.Contracts.Core.Tables;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;


namespace VisionsContracts.Land.Tables
{
    public partial class CafeCosmosConfigTableService : TableSingletonService<CafeCosmosConfigTableRecord, CafeCosmosConfigTableRecord.CafeCosmosConfigValue>
    {
      
        public virtual Task<string> SetRecordRequestAsync(
         
            BigInteger cookingCost,
            BigInteger softCostPerSquare,
            BigInteger landNonce,
            BigInteger initialLimitX,
            BigInteger initialLimitY,
            BigInteger minStartingX,
            BigInteger minStartingY,
            BigInteger totalLandSlotsSold,
            BigInteger startTime,
            BigInteger defaultLandType,
            long seedMask,
            BigInteger globalBoosterId,
            BigInteger maxGroupIdNumber,
            BigInteger chunkSize,
            BigInteger maxLevel,
            List<BigInteger> categoryMaxBoost,
            List<BigInteger> maxBoosts,
            List<BigInteger> startingItems,
            List<BigInteger> startingItemsQuantities)
        {
            var values = new CafeCosmosConfigTableRecord.CafeCosmosConfigValue
            {
       
                CookingCost = cookingCost,
                SoftCostPerSquare = softCostPerSquare,
                LandNonce = landNonce,
                InitialLimitX = initialLimitX,
                InitialLimitY = initialLimitY,
                MinStartingX = minStartingX,
                MinStartingY = minStartingY,
                TotalLandSlotsSold = totalLandSlotsSold,
                StartTime = startTime,
                DefaultLandType = defaultLandType,
                SeedMask = seedMask,
                GlobalBoosterId = globalBoosterId,
                MaxGroupIdNumber = maxGroupIdNumber,
                ChunkSize = chunkSize,
                MaxLevel = maxLevel,
                CategoryMaxBoost = categoryMaxBoost,
                MaxBoosts = maxBoosts,

                StartingItems = startingItems,
                StartingItemsQuantities = startingItemsQuantities
            };

            return SetRecordRequestAsync(values);
        }

        public async Task<TransactionReceipt> SetRecordRequestAndWaitForReceiptAsync(
      
            BigInteger cookingCost,
            BigInteger softCostPerSquare,
            BigInteger landNonce,
            BigInteger initialLimitX,
            BigInteger initialLimitY,
            BigInteger minStartingX,
            BigInteger minStartingY,
            BigInteger totalLandSlotsSold,
            BigInteger startTime,
            BigInteger defaultLandType,
            long seedMask,
            BigInteger globalBoosterId,
            BigInteger maxGroupIdNumber,
            BigInteger chunkSize,
            BigInteger maxLevel,
            List<BigInteger> categoryMaxBoost,
            List<BigInteger> maxBoosts,
            List<BigInteger> startingItems,
            List<BigInteger> startingItemsQuantities)
        {
            var values = new CafeCosmosConfigTableRecord.CafeCosmosConfigValue
            {
               
                CookingCost = cookingCost,
                SoftCostPerSquare = softCostPerSquare,
                LandNonce = landNonce,
                InitialLimitX = initialLimitX,
                InitialLimitY = initialLimitY,
                MinStartingX = minStartingX,
                MinStartingY = minStartingY,
                TotalLandSlotsSold = totalLandSlotsSold,
                StartTime = startTime,
                DefaultLandType = defaultLandType,
                SeedMask = seedMask,
                GlobalBoosterId = globalBoosterId,
                MaxGroupIdNumber = maxGroupIdNumber,
                ChunkSize = chunkSize,
                MaxLevel = maxLevel,
                CategoryMaxBoost = categoryMaxBoost,
                MaxBoosts = maxBoosts,
                StartingItems = startingItems,
                StartingItemsQuantities = startingItemsQuantities
            };

            return await SetRecordRequestAndWaitForReceiptAsync(values);
        }
    }
}

