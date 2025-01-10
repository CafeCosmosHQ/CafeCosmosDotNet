using Nethereum.Mud.Contracts.Core.Tables;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;

namespace VisionsContracts.Land.Tables
{
    public partial class CraftingRecipeTableService : TableService<CraftingRecipeTableRecord, CraftingRecipeTableRecord.CraftingRecipeKey, CraftingRecipeTableRecord.CraftingRecipeValue>
    { 

        // Add the SetRecordRequestAsync method here
        public virtual Task<string> SetRecordRequestAsync(
            BigInteger output,
            List<BigInteger> inputs,
            List<BigInteger> quantities,
            BigInteger outputQuantity,
            BigInteger xp,
            bool exists
           )
        {
            var key = new CraftingRecipeTableRecord.CraftingRecipeKey
            {
                Output = output
            };

            var values = new CraftingRecipeTableRecord.CraftingRecipeValue
            {
                Inputs = inputs,
                Quantities = quantities,
                OutputQuantity = outputQuantity,
                Xp = xp,
                Exists = exists

            };

            return SetRecordRequestAsync(key, values);
        }

        // Add the SetRecordRequestAndWaitForReceiptAsync method here
        public async Task<TransactionReceipt> SetRecordRequestAndWaitForReceiptAsync(
            BigInteger output,
            List<BigInteger> inputs,
            List<BigInteger> quantities,
            BigInteger outputQuantity,
            BigInteger xp,
            bool exists
           )
        {
            var key = new CraftingRecipeTableRecord.CraftingRecipeKey
            {
                Output = output
            };

            var values = new CraftingRecipeTableRecord.CraftingRecipeValue
            {
                Inputs = inputs,
                Quantities = quantities,
                OutputQuantity = outputQuantity,
                Xp = xp,
                Exists = exists

            };

            return await SetRecordRequestAndWaitForReceiptAsync(key, values);
        }

    }
}
