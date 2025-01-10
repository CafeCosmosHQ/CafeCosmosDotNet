using System.Collections.Generic;
using VisionsContracts.Items.Model;

namespace VisionsContracts.TestScenarios
{
    public static class InventoryScenarios
    {
        public static List<InventoryItem> GetAllInventoryItemsWith20ItemsPerItem()
        {
            var inventoryItems = new List<InventoryItem>();
            var items = Items.DefaultItems.GetAllInventoryItems();
            foreach (var item in items)
            {
                inventoryItems.Add(new InventoryItem()
                {
                    Count = 20,
                    ItemId = item.Id
                });
            }

            return inventoryItems;

        }
    }
}
