using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.RPC.Eth.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisionsContracts.Items.Model;
using VisionsContracts.Items;
using System.Numerics;

namespace VisionsContracts.Land.Systems.LandItemsSystem
{
    public partial class LandItemsSystemService
    {
        public async Task<List<InventoryItem>> GetAllSeedsBalancesAsync(BigInteger landId)
        {
            var inventoryItems = new List<InventoryItem>();
            var seeds = DefaultItems.GetAllSeedItems();
            var ids = seeds.Select(x => (BigInteger)x.Id).ToList();
            var balances = await ItemBalanceOfBatchQueryAsync(landId, ids);
            for (int i = 0; i < seeds.Count; i++)
            {
                Item item = seeds[i];
                inventoryItems.Add(new InventoryItem() { ItemId = seeds[i].Id, Count = balances[i] });
            }
            return inventoryItems;
        }

        public async Task<List<InventoryItem>> GetAllInventoryItemsBalancesAsync(BigInteger landId, BlockParameter blockParameter = null)
        {
            var inventoryItems = new List<InventoryItem>();
            var seeds = DefaultItems.GetAllInventoryItems();
            var ids = seeds.Select(x => (BigInteger)x.Id).ToList();
            var balances = await this.ItemBalanceOfBatchQueryAsync(landId, ids, blockParameter);
            for (int i = 0; i < seeds.Count; i++)
            {
                Item item = seeds[i];
                inventoryItems.Add(new InventoryItem() { ItemId = seeds[i].Id, Count = balances[i] });
            }
            return inventoryItems;
        }

        public Task<string> DepositDefaultLandToolsRequestAsync(BigInteger landId)
        {
            var tools = DefaultItems.GetDefaultLandTools();
            var numberOfItems = new List<BigInteger>();
            foreach (var item in tools) { numberOfItems.Add(1); }
            return DepositItemsRequestAsync(landId, tools.Select(x => (BigInteger)x.Id).ToList(), numberOfItems);
        }


        public Task<string> DepositInventoryItemsAsync(BigInteger landId, List<InventoryItem> inventoryItems)
        {
            return DepositItemsRequestAsync(landId, inventoryItems.Select(x => x.ItemId).ToList(), inventoryItems.Select(x => x.Count).ToList());
        }

        public Task<TransactionReceipt> DepositInventoryItemsAndWaitForReceiptAsync(BigInteger landId, List<InventoryItem> inventoryItems)
        {
            return DepositItemsRequestAndWaitForReceiptAsync(landId, inventoryItems.Select(x => x.ItemId).ToList(), inventoryItems.Select(x => x.Count).ToList());
        }
    }
}
