using Nethereum.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisionsContracts.Items.Model;
using VisionsContracts.Items;
using VisionsContracts.Land.Systems.LandConfigSystem.ContractDefinition;
using Nethereum.RPC.Eth.DTOs;
using System.Numerics;
using VisionsContracts.Land.Model;
using Nethereum.Mud.Contracts.World.Systems.BatchCallSystem;
using Nethereum.Mud.Contracts.World.Systems.BatchCallSystem.ContractDefinition;
using Nethereum.Mud;
using VisionsContracts.Land.Systems.CraftingSystem;

namespace VisionsContracts.Land.Systems.LandConfigSystem
{
    public partial class LandConfigSystemService
    {

        public const int DefaultBatchSize = 100;
        public BatchCallSystemService GetBatchCallSystem()
        {
           return new BatchCallSystemService(this.Web3, this.ContractAddress);
        }

        public Task<string> MulticallRequestAsync(List<byte[]> callDatas)
        {
            var batchCallSystem = GetBatchCallSystem();
            var systemCallDatas = callDatas.Select(x => new SystemCallData() { CallData = x, SystemId = ResourceRegistry.GetResourceEncoded<LandConfigSystemServiceResource>() }).ToList();
            return batchCallSystem.BatchCallRequestAsync(systemCallDatas);
         
        }

        public Task<TransactionReceipt> MulticallRequestAndWaitForReceiptAsync(List<byte[]> callDatas)
        {
            var batchCallSystem = GetBatchCallSystem();
            var systemCallDatas = callDatas.Select(x => new SystemCallData() { CallData = x, SystemId = ResourceRegistry.GetResourceEncoded<LandConfigSystemServiceResource>() }).ToList();
            return batchCallSystem.BatchCallRequestAndWaitForReceiptAsync(systemCallDatas);
        }

        public Task<string> BatchSetToolsRequestAsync(List<Item> items)
        {
            var toolRequests = GetSetToolsRequests(items);
            return this.MulticallRequestAsync(toolRequests.Select(x => x.GetCallData()).ToList());
        }

        public Task<string> SetDefaultNonRemovableItemsRequestAsync()
        {
            return SetNonRemovableItemsRequestAsync(DefaultItems.GetAllNonRemovableItems().Select(x => (BigInteger)x.Id).ToList());
        }

        public Task<string> SetDefaultRotatableItemsRequestAsync()
        {
            return SetRotatableRequestAsync(DefaultItems.GetAllRotatableItems().Select(x => (BigInteger)x.Id).ToList(), true);
        } 

        public static List<SetToolFunction> GetSetToolsRequests(List<Item> items)
        {
            var returnItems = new List<SetToolFunction>();
            foreach (var item in items)
            {
                returnItems.Add(new SetToolFunction() { IsTool = true, Tool = item.Id });
            }

            return returnItems;
        }

        public static List<SetIsStackableFunction> GetSetIsStackableRequests(List<Stacking> items)
        {
            var returnItems = new List<SetIsStackableFunction>();
            foreach (var item in items)
            {
                returnItems.Add(new SetIsStackableFunction() { Base = item.Base, Input = item.Input, IsStackable = true });
            }

            return returnItems;
        }

        public static List<SetNonPlaceableFunction> GetSetNonPlaceableRequests(List<Item> items)
        {
            var returnItems = new List<SetNonPlaceableFunction>();
            foreach (var item in items)
            {
                returnItems.Add(new SetNonPlaceableFunction() { NonPlaceable = item.Id, Placeable = false });
            }

            return returnItems;
        }

        public static List<SetChairFunction> GetSetChairRequests(List<Item> items)
        {
            var returnItems = new List<SetChairFunction>();
            foreach (var item in items)
            {
                returnItems.Add(new SetChairFunction() { Chair = item.Id, IsChair = true });
            }

            return returnItems;
        }


        public static List<SetTableFunction> GetSetTablesRequests(List<Item> items)
        {
            var returnItems = new List<SetTableFunction>();
            foreach (var item in items)
            {
                returnItems.Add(new SetTableFunction() { Table = item.Id, IsTable = true });
            }

            return returnItems;
        }

        public static List<SetChairFunction> GetDefaultChairRequests()
        {
            return GetSetChairRequests(DefaultItems.GetChairs());
        }

        public static List<SetTableFunction> GetDefaultTableRequests()
        {
            return GetSetTablesRequests(DefaultItems.GetTables());
        }

        public static List<SetIsStackableFunction> GetDefaultIsStackableRequests()
        {
            return GetSetIsStackableRequests(DefaultStackings.GetAllStackableItems());
        }

        public static List<SetNonPlaceableFunction> GetDefaultNotPlaceableRequests()
        {
            return GetSetNonPlaceableRequests(DefaultItems.GetAllNonPlaceableItems());
        }

        public Task<string> BatchSetDefaultChairsRequestAsync()
        {
            var chairFunctions = GetDefaultChairRequests();
            return this.MulticallRequestAsync(chairFunctions.Select(x => x.GetCallData()).ToList());
        }

        public Task<string> BatchSetDefaultTablesRequestAsync()
        {
            var tables = GetDefaultTableRequests();
            return this.MulticallRequestAsync(tables.Select(x => x.GetCallData()).ToList());
        }

        public async Task<string> BatchSetStackingsDefaultRequestAsync()
        {
            var stackRequests = GetDefaultIsStackableRequests();

            // Split the requests into batches
            var batchedRequests = SplitIntoBatches(stackRequests, DefaultBatchSize);

            // Initialize a list to store the results
            var results = new List<string>();

            // Process each batch of requests
            foreach (var batch in batchedRequests)
            {
                var batchResult = await this.MulticallRequestAsync(batch.Select(x => x.GetCallData()).ToList());
                results.Add(batchResult);
            }

            return results.Last();
        }

        private List<List<T>> SplitIntoBatches<T>(List<T> items, int batchSize)
        {
            return items
                .Select((item, index) => new { Item = item, Index = index })
                .GroupBy(x => x.Index / batchSize)
                .Select(g => g.Select(x => x.Item).ToList())
                .ToList();
        }

        public Task<string> BatchSetNonPlaceableDefaultRequestAsync()
        {
            var nonPlaceableFunctions = GetDefaultNotPlaceableRequests();
            return this.MulticallRequestAsync(nonPlaceableFunctions.Select(x => x.GetCallData()).ToList());
        }


        public Task<string> BatchSetToolsDefaultRequestAsync()
        {
            return BatchSetToolsRequestAsync(DefaultItems.GetDefaultLandTools());
        }

        public Task<string> SetDefaultReturnItemsRequestAsync()
        {
            var returnedItems = DefaultCraftingRecipes.GetReturnedCraftingItems();
            return SetReturnItemsRequestAsync(returnedItems.Select(x => (BigInteger)x.Item.Id).ToList(), returnedItems.Select(x => (BigInteger)x.ItemReturned.Id).ToList());
        }

        public Task<TransactionReceipt> SetDefaultReturnItemsRequestAndWaitForReceiptAsync()
        {
            var returnedItems = DefaultCraftingRecipes.GetReturnedCraftingItems();
            return SetReturnItemsRequestAndWaitForReceiptAsync(returnedItems.Select(x => (BigInteger)x.Item.Id).ToList(), returnedItems.Select(x => (BigInteger)x.ItemReturned.Id).ToList());
        }



    }
}
