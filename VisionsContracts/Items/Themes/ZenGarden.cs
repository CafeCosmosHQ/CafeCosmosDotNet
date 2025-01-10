using System;
using System.Collections.Generic;
using System.Text;
using VisionsContracts.Items.Model;
using VisionsContracts.Land.Systems.CatalogueSystem.Model;
using VisionsContracts.Transformations.Model;

namespace VisionsContracts.Items.Themes
{
    public class ZenGardenItems : ThemeItems<ZenGardenItems>
    {
        public static readonly Catalogue CATALOGUE = new Catalogue() { CatalogueId = 9, Name = "Zen Garden" };
        // Zen Garden items
        public static readonly Item CHARM_COUNTER_I = new(name: "Charm Counter I", id: 10900, category: ItemCategory.Furniture, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item CHARM_COUNTER_II = new(name: "Charm Counter II", id: 10901, category: ItemCategory.Furniture, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item ZEN_GARDEN_TABLE = new(name: "Zen Garden Table", id: 10902, category: ItemCategory.Furniture, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item ZEN_GARDEN_SEAT = new(name: "Zen Garden Seat", id: 10903, category: ItemCategory.Furniture, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item BONSAI_TREE = new(name: "Bonsai Tree", id: 10904, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item ANCIENT_LAMP = new(name: "Ancient Lamp", id: 10905, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item DOGE_SHRINE = new(name: "Doge Shrine", id: 10906, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item ZEN_GARDEN_SIGN = new(name: "Zen Garden Sign", id: 10907, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item ZEN_CAPYBARA = new(name: "Zen Capybara", id: 10908, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item SHIBAKEN = new(name: "Shibaken", id: 10909, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item SERENE_BAMBOO_GROVE = new(name: "Serene Bamboo Grove", id: 10910, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item CHERRY_BLOSSOM_TREE = new(name: "Cherry Blossom Tree", id: 10911, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item SERENE_CITRUS_POND = new(name: "Serene Citrus Pond", id: 10912, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item ZEN_PAPER_WALL = new(name: "Zen Paper Wall", id: 10913, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item PAPER_WALL = new(name: "Paper Wall", id: 10914, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item SAKURA_WALL = new(name: "Sakura Wall", id: 10915, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item BAMBOO_WALL = new(name: "Bamboo Wall", id: 10916, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item ZEN_FLOORING = new(name: "Zen Flooring", id: 10917, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item ZEN_PATHWAY_I = new(name: "Zen Pathway I", id: 10918, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item ZEN_PATHWAY_II = new(name: "Zen Pathway II", id: 10919, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item ZEN_PATHWAY_III = new(name: "Zen Pathway III", id: 10920, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);

        public override List<Item> GetAllItems()
        {
            return new List<Item>()
            {
                CHARM_COUNTER_I,
                CHARM_COUNTER_II,
                ZEN_GARDEN_TABLE,
                ZEN_GARDEN_SEAT,
                BONSAI_TREE,
                ANCIENT_LAMP,
                DOGE_SHRINE,
                ZEN_GARDEN_SIGN,
                ZEN_CAPYBARA,
                SHIBAKEN,
                SERENE_BAMBOO_GROVE,
                CHERRY_BLOSSOM_TREE,
                SERENE_CITRUS_POND,
                ZEN_PAPER_WALL,
                PAPER_WALL,
                SAKURA_WALL,
                BAMBOO_WALL,
                ZEN_FLOORING,
                ZEN_PATHWAY_I,
                ZEN_PATHWAY_II,
                ZEN_PATHWAY_III
            };
        }

        public override List<Item> GetCounters()
        {
            return new List<Item>()
            {
                CHARM_COUNTER_I,
                CHARM_COUNTER_II
            };
        }

        public override List<Item> GetFloors()
        {
            return new List<Item>()
            {
                ZEN_FLOORING
            };
        }

        public override List<Item> GetChairs()
        {
            return new List<Item>()
            {
                ZEN_GARDEN_SEAT
            };
        }

        public override List<Item> GetTables()
        {
            return new List<Item>()
            {
                ZEN_GARDEN_TABLE
            };
        }

        public override Catalogue GetCatalogue()
        {
            return CATALOGUE;
        }

        public override List<CatalogueItem> GetCatalogueItems()
        {
            return new List<CatalogueItem>()
            {
                new CatalogueItem(CHARM_COUNTER_I, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(CHARM_COUNTER_II, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(ZEN_GARDEN_TABLE, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(ZEN_GARDEN_SEAT, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(BONSAI_TREE, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(ANCIENT_LAMP, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(DOGE_SHRINE, 0 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(ZEN_GARDEN_SIGN, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(ZEN_CAPYBARA, 7.5m * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(SHIBAKEN, 20 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(SERENE_BAMBOO_GROVE, 7.5m * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(CHERRY_BLOSSOM_TREE, 15 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(SERENE_CITRUS_POND, 10 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(ZEN_PAPER_WALL, 3 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(PAPER_WALL, 3 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(SAKURA_WALL, 3 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(BAMBOO_WALL, 3 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(ZEN_FLOORING, 2 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(ZEN_PATHWAY_I, 2 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(ZEN_PATHWAY_II, 2 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(ZEN_PATHWAY_III, 2 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId)
            };
        }


        public override List<Item> GetAllFloorStackableItems()
        {
            return new List<Item>()
            {
                CHARM_COUNTER_I,
                CHARM_COUNTER_II,
                ZEN_GARDEN_TABLE,
                ZEN_GARDEN_SEAT,
                BONSAI_TREE,
                ANCIENT_LAMP,
                SHIBAKEN
            };
        }

        public override List<Transformation> GetTransformations()
        {
           return new List<Transformation>();
        }
    }
}

