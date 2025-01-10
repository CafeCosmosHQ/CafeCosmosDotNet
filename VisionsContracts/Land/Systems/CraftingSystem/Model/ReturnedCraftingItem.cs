using System.Numerics;
using VisionsContracts.Items.Model;


namespace VisionsContracts.CraftingSystem.Model
{
    public record ReturnedCraftingItem
    {
        public ReturnedCraftingItem(Item item, Item itemReturned)
        {
            Item = item;
            ItemReturned = itemReturned;
        }

        public Item Item { get; init; }
        public Item ItemReturned { get; init; }

    }

}
