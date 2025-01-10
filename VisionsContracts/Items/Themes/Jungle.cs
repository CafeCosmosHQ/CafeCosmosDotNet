using System;
using System.Collections.Generic;
using System.Text;
using VisionsContracts.Items.Model;
using VisionsContracts.Land.Systems.CatalogueSystem.Model;
using VisionsContracts.Transformations.Model;

namespace VisionsContracts.Items.Themes
{
    public class JungleItems : ThemeItems<JungleItems>
    {
        public static readonly Catalogue CATALOGUE = new Catalogue() { CatalogueId = 5, Name = "Jungle" };
        // Jungle items
        public static readonly Item ROCKY_PATHWAY = new(name: "Rocky Pathway", id: 10500, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item MOSSY_PATHWAY = new(name: "Mossy Pathway", id: 10501, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item JUNGLE_WALL = new(name: "Jungle Wall", id: 10502, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item RAINFOREST_WALL = new(name: "Rainforest Wall", id: 10503, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item JUNGLE_BAR_COUNTER = new(name: "Jungle Bar Counter", id: 10504, category: ItemCategory.Furniture, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item TROPICAL_WALL = new(name: "Tropical Wall", id: 10505, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item LINGAM_FOUNTAIN = new(name: "Lingam Fountain", id: 10506, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item YONI_FOUNTAIN = new(name: "Yoni Fountain", id: 10507, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item WHISPERING_WILLOW = new(name: "Whispering Willow", id: 10508, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item WHITE_MONSTERA = new(name: "White Monstera", id: 10509, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item RED_PETUNIA = new(name: "Red Petunia", id: 10510, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item BIRD_OF_PARADISE = new(name: "Bird of Paradise", id: 10511, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item CROTON = new(name: "Croton", id: 10512, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item JUNGLE_OASIS_FOUNTAIN = new(name: "Jungle Oasis Fountain", id: 10513, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item BARREL_TABLE = new(name: "Barrel Table", id: 10514, category: ItemCategory.Furniture, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item ROCK_CHAIR = new(name: "Rock Chair", id: 10515, category: ItemCategory.Furniture, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);

        public override List<Item> GetAllItems()
        {
            return new List<Item>()
            {
                ROCKY_PATHWAY,
                MOSSY_PATHWAY,
                JUNGLE_WALL,
                RAINFOREST_WALL,
                JUNGLE_BAR_COUNTER,
                TROPICAL_WALL,
                LINGAM_FOUNTAIN,
                YONI_FOUNTAIN,
                WHISPERING_WILLOW,
                WHITE_MONSTERA,
                RED_PETUNIA,
                BIRD_OF_PARADISE,
                CROTON,
                JUNGLE_OASIS_FOUNTAIN,
                BARREL_TABLE,
                ROCK_CHAIR
            };
        }

        public override List<Item> GetCounters()
        {
            return new List<Item>()
            {
                JUNGLE_BAR_COUNTER
            };
        }

        public override List<Item> GetFloors()
        {
            return new List<Item>()
            {
                ROCKY_PATHWAY,
                MOSSY_PATHWAY
            };
        }

        public override List<Item> GetChairs()
        {
            return new List<Item>()
            {
                ROCK_CHAIR
            };
        }

        public override List<Item> GetTables()
        {
            return new List<Item>()
            {
                BARREL_TABLE
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
                new CatalogueItem(ROCKY_PATHWAY, 2 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(MOSSY_PATHWAY, 2 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(JUNGLE_WALL, 3 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(RAINFOREST_WALL, 3 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(JUNGLE_BAR_COUNTER, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(TROPICAL_WALL, 3 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(LINGAM_FOUNTAIN, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(YONI_FOUNTAIN, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(WHISPERING_WILLOW, 10 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(WHITE_MONSTERA, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(RED_PETUNIA, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(BIRD_OF_PARADISE, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(CROTON, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(JUNGLE_OASIS_FOUNTAIN, 10 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(BARREL_TABLE, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(ROCK_CHAIR, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId)
            };
        }


        public override List<Item> GetAllFloorStackableItems()
        {
            return new List<Item>()
            {
                JUNGLE_BAR_COUNTER,
                ROCK_CHAIR,
                BARREL_TABLE,
                CROTON,
                WHITE_MONSTERA
            };
        }

        public override List<Transformation> GetTransformations()
        {
            return new List<Transformation>();
        }
    }
}
