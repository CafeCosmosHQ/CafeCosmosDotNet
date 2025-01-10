using Nethereum.Hex.HexConvertors.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using VisionsContracts.Items.Model;
using Nethereum.RPC.Eth.DTOs;
using VisionsContracts.Items;


namespace VisionsContracts.ItemsPermissioned
{
    public partial class ItemsPermissionedService
    {
        public Task<string> MintDefaultLandToolsToPLayerRequestAsync(string player)
        {
            var tools = DefaultItems.GetDefaultLandTools();
            var numberOfItems = new List<BigInteger>();
            foreach (var item in tools) { numberOfItems.Add(1); }
            return MintBatchRequestAsync(player, tools.Select(x => (BigInteger)x.Id).ToList(), numberOfItems, "0x0003".HexToByteArray());
        }


        public Task<string> MintTestInventoryItemsAsync(string player, List<InventoryItem> inventoryItems)
        {
            return MintBatchRequestAsync(player, inventoryItems.Select(x => x.ItemId).ToList(), inventoryItems.Select(x => x.Count).ToList(), "0x0003".HexToByteArray());
        }

        public Task<TransactionReceipt> MintTestInventoryItemsAndWaitForReceiptAsync(string player, List<InventoryItem> inventoryItems)
        {
            return MintBatchRequestAndWaitForReceiptAsync(player, inventoryItems.Select(x => x.ItemId).ToList(), inventoryItems.Select(x => x.Count).ToList(), "0x0003".HexToByteArray());
        }

        public async Task<List<InventoryItem>> GetAllSeedsBalancesAsync(string address)
        {
            var inventoryItems = new List<InventoryItem>();
            var seeds = DefaultItems.GetAllSeedItems();
            var ids = seeds.Select(x => (BigInteger)x.Id).ToList();
            var balances = await BalanceOfBatchSingleQueryAsync(address, ids);
            for (int i = 0; i < seeds.Count; i++)
            {
                Item item = seeds[i];
                inventoryItems.Add(new InventoryItem() { ItemId = seeds[i].Id, Count = balances[i] });
            }
            return inventoryItems;
        }

        public async Task<List<InventoryItem>> GetAllInventoryItemsBalancesAsync(string address, BlockParameter blockParameter = null)
        {
            var inventoryItems = new List<InventoryItem>();
            var seeds = DefaultItems.GetAllInventoryItems();
            var ids = seeds.Select(x => (BigInteger)x.Id).ToList();
            var balances = await this.BalanceOfBatchSingleQueryAsync(address, ids, blockParameter);
            for (int i = 0; i < seeds.Count; i++)
            {
                Item item = seeds[i];
                inventoryItems.Add(new InventoryItem() { ItemId = seeds[i].Id, Count = balances[i] });
            }
            return inventoryItems;
        }
    }

}