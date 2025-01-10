using System;
using System.Collections.Generic;
using System.Text;
using VisionsContracts.Items.Model;
using VisionsContracts.Land.Systems.CatalogueSystem.Model;
using VisionsContracts.Transformations.Model;

namespace VisionsContracts.Items.Themes
{
    public class BeachBarItems : ThemeItems<BeachBarItems>
    {
        public static readonly Catalogue CATALOGUE = new Catalogue() { CatalogueId = 10, Name = "Beach Bar" };
        // Beach Bar items
        public static readonly Item BEACH_FRONT_BAR_COUNTER = new(name: "Beach Front Bar Counter", id: 11000, category: ItemCategory.Furniture, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item YELLOW_SUNSET_TABLE = new(name: "Yellow Sunset Table", id: 11001, category: ItemCategory.Furniture, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item PINK_SUNSET_TABLE = new(name: "Pink Sunset Table", id: 11002, category: ItemCategory.Furniture, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item RUM_PUNCH_RECLINER = new(name: "Rum Punch Recliner", id: 11003, category: ItemCategory.Furniture, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item COCONUT_COLADA_CHAIR = new(name: "Coconut Colada Chair", id: 11004, category: ItemCategory.Furniture, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item SLUSHIE_MACHINE = new(name: "Slushie Machine", id: 11005, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item SNOW_CONE_MACHINE = new(name: "Snow Cone Machine", id: 11006, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item BEACH_BAR_SIGN = new(name: "Beach Bar Sign", id: 11007, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item ISLAND_BREEZE_POOL = new(name: "Island Breeze Pool", id: 11008, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item BEACH_FRONT_FERN = new(name: "Beach Front Fern", id: 11009, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item SURFBOARDS = new(name: "Surfboards", id: 11010, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item MOAI_STATUE = new(name: "Moai Statue", id: 11011, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item TROPICAL_PALM_HAMMOCK = new(name: "Tropical Palm ‘n Hammock", id: 11012, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item SEASIDE_TIKI_UMBRELLA = new(name: "Seaside Tiki Umbrella", id: 11013, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item PARADISE_WALL_I = new(name: "Paradise Wall I", id: 11014, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item PARADISE_WALL_II = new(name: "Paradise Wall II", id: 11015, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item TIKI_WALL = new(name: "Tiki Wall", id: 11016, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item TORCHED_WALL = new(name: "Torched Wall", id: 11017, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item SANDY_FLOOR = new(name: "Sandy Floor", id: 11018, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: false, isInventory: true, isRemovable: true);

        public override List<Item> GetAllItems()
        {
            return new List<Item>()
            {
                BEACH_FRONT_BAR_COUNTER,
                YELLOW_SUNSET_TABLE,
                PINK_SUNSET_TABLE,
                RUM_PUNCH_RECLINER,
                COCONUT_COLADA_CHAIR,
                SLUSHIE_MACHINE,
                SNOW_CONE_MACHINE,
                BEACH_BAR_SIGN,
                ISLAND_BREEZE_POOL,
                BEACH_FRONT_FERN,
                SURFBOARDS,
                MOAI_STATUE,
                TROPICAL_PALM_HAMMOCK,
                SEASIDE_TIKI_UMBRELLA,
                PARADISE_WALL_I,
                PARADISE_WALL_II,
                TIKI_WALL,
                TORCHED_WALL,
                SANDY_FLOOR
            };
        }

        public override List<Item> GetCounters()
        {
            return new List<Item>()
            {
                BEACH_FRONT_BAR_COUNTER
            };
        }

        public override List<Item> GetFloors()
        {
            return new List<Item>()
            {
                SANDY_FLOOR
            };
        }

        public override List<Item> GetChairs()
        {
            return new List<Item>()
            {
                RUM_PUNCH_RECLINER,
                COCONUT_COLADA_CHAIR
            };
        }

        public override List<Item> GetTables()
        {
            return new List<Item>()
            {
                YELLOW_SUNSET_TABLE,
                PINK_SUNSET_TABLE
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
                new CatalogueItem(BEACH_FRONT_BAR_COUNTER, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(YELLOW_SUNSET_TABLE, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(PINK_SUNSET_TABLE, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(RUM_PUNCH_RECLINER, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(COCONUT_COLADA_CHAIR, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(SLUSHIE_MACHINE, 7.5m * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(SNOW_CONE_MACHINE, 7.5m * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(BEACH_BAR_SIGN, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(ISLAND_BREEZE_POOL, 10 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(BEACH_FRONT_FERN, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(SURFBOARDS, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(MOAI_STATUE, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(TROPICAL_PALM_HAMMOCK, 10 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(SEASIDE_TIKI_UMBRELLA, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(PARADISE_WALL_I, 3 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(PARADISE_WALL_II, 3 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(TIKI_WALL, 3 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(TORCHED_WALL, 3 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(SANDY_FLOOR, 2 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId)
            };
        }


        public override List<Item> GetAllFloorStackableItems()
        {
            return new List<Item>()
            {
                BEACH_FRONT_BAR_COUNTER,
                YELLOW_SUNSET_TABLE,
                PINK_SUNSET_TABLE,
                RUM_PUNCH_RECLINER,
                COCONUT_COLADA_CHAIR,
                SLUSHIE_MACHINE,
                SNOW_CONE_MACHINE,
                BEACH_BAR_SIGN,
                BEACH_FRONT_FERN,
                SURFBOARDS,
                MOAI_STATUE,
                SEASIDE_TIKI_UMBRELLA,
            };
        }

        public override List<Transformation> GetTransformations()
        {
            return new List<Transformation>();
        }
    }
}
