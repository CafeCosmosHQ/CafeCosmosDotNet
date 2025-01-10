using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using VisionsContracts.Items.Model;
using VisionsContracts.Land.Tables;

namespace VisionsContracts.Items.Mapping
{
    public static class ItemMappings
    {
        public static InventoryTableRecord MapInventoryItemToTableRecord(BigInteger landId, InventoryItem item)
        {
            var inventoryItem = new InventoryTableRecord();
            inventoryItem.Keys = new InventoryTableRecord.InventoryKey();
            inventoryItem.Keys.LandId = landId;
            inventoryItem.Keys.Item = item.ItemId;
            inventoryItem.Values = new InventoryTableRecord.InventoryValue();
            inventoryItem.Values.Quantity = item.Count;
            return inventoryItem;
        }

        public static List<InventoryTableRecord> MapInventoryItemsToTableRecords(BigInteger landId, IEnumerable<InventoryItem> items)
        {
            return items.Select(x =>  MapInventoryItemToTableRecord(landId, x)).ToList();
        }

    }
}
