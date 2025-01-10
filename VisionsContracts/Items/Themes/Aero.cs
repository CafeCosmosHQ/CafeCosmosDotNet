using System;
using System.Collections.Generic;
using System.Text;
using VisionsContracts.Items.Model;
using VisionsContracts.Land.Systems.CatalogueSystem.Model;
using VisionsContracts.Transformations.Model;

namespace VisionsContracts.Items.Themes
{
    public class AeroItems : ThemeItems<AeroItems>
    {
        public static readonly Catalogue CATALOGUE = new Catalogue() { CatalogueId = 4, Name = "Aero" };
        // Aero items
        public static readonly Item CHROME_FLOOR = new(name: "Chrome Floor", id: 10400, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: false, isInventory: true, isRemovable: true);
        public static readonly Item WHITE_WALL = new(name: "White Wall", id: 10401, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item AQUARIUM_WALL_I = new(name: "Aquarium Wall I", id: 10402, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item AQUARIUM_WALL_II = new(name: "Aquarium Wall II", id: 10403, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item MODERN_ICON = new(name: "Modern Icon", id: 10404, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item CONTEMPORARY_COUNTER = new(name: "Contemporary Counter", id: 10405, category: ItemCategory.Furniture, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item SLEEK_FOLIAGE_WALL = new(name: "Sleek Foliage Wall", id: 10406, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item TRANSPARENT_WALL = new(name: "Transparent Wall", id: 10407, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item AEROBOT = new(name: "AeroBot", id: 10408, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item AERO_TABLETOP = new(name: "Aero Tabletop", id: 10409, category: ItemCategory.Furniture, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item SLEEK_TABLETOP = new(name: "Sleek Tabletop", id: 10410, category: ItemCategory.Furniture, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item PRECISION_LOUNGE_CHAIR = new(name: "Precision Lounge Chair", id: 10411, category: ItemCategory.Furniture, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item GREEN_BUBBLE_CHAIR = new(name: "Green Bubble Chair", id: 10412, category: ItemCategory.Furniture, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item ORANGE_BUBBLE_CHAIR = new(name: "Orange Bubble Chair", id: 10413, category: ItemCategory.Furniture, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item BLUE_BUBBLE_CHAIR = new(name: "Blue Bubble Chair", id: 10414, category: ItemCategory.Furniture, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item PLANTER = new(name: "Planter", id: 10415, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item SUNFLOWER = new(name: "Sunflower", id: 10416, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item MINIMALISTIC_ART = new(name: "Minimalistic Art", id: 10417, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);

        public static readonly Item WHITE_WALL_WITH_MINIMALISTIC_ART = new(name: "White Wall with Minimalistic Art", id: 10418, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: false, isRemovable: false);


        public override List<Item> GetAllItems()
        {
            return new List<Item>()
            {
                CHROME_FLOOR,
                WHITE_WALL,
                AQUARIUM_WALL_I,
                AQUARIUM_WALL_II,
                MODERN_ICON,
                CONTEMPORARY_COUNTER,
                SLEEK_FOLIAGE_WALL,
                TRANSPARENT_WALL,
                AEROBOT,
                AERO_TABLETOP,
                SLEEK_TABLETOP,
                PRECISION_LOUNGE_CHAIR,
                GREEN_BUBBLE_CHAIR,
                ORANGE_BUBBLE_CHAIR,
                BLUE_BUBBLE_CHAIR,
                PLANTER,
                SUNFLOWER,
                MINIMALISTIC_ART,
                WHITE_WALL_WITH_MINIMALISTIC_ART
            };
        }

        public override List<Item> GetCounters()
        {
            return new List<Item>()
            {
                CONTEMPORARY_COUNTER
            };
        }

        public override List<Item> GetFloors()
        {
            return new List<Item>()
            {
                CHROME_FLOOR
            };
        }

        public override List<Item> GetChairs()
        {
            return new List<Item>()
            {
                PRECISION_LOUNGE_CHAIR,
                GREEN_BUBBLE_CHAIR,
                ORANGE_BUBBLE_CHAIR,
                BLUE_BUBBLE_CHAIR
            };
        }

        public override List<Item> GetTables()
        {
            return new List<Item>()
            {
                AERO_TABLETOP,
                SLEEK_TABLETOP
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
                new CatalogueItem(CHROME_FLOOR, 2 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(WHITE_WALL, 3 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(AQUARIUM_WALL_I, 3 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(AQUARIUM_WALL_II, 3 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(MODERN_ICON, 10 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(CONTEMPORARY_COUNTER, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(SLEEK_FOLIAGE_WALL, 3 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(TRANSPARENT_WALL, 3 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(AEROBOT, 10 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(AERO_TABLETOP, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(SLEEK_TABLETOP, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(PRECISION_LOUNGE_CHAIR, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(GREEN_BUBBLE_CHAIR, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(ORANGE_BUBBLE_CHAIR, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(BLUE_BUBBLE_CHAIR, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(PLANTER, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(SUNFLOWER, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(MINIMALISTIC_ART, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId)
            };
        }


        public override List<Item> GetAllFloorStackableItems()
        {
            return new List<Item>()
            {
                CONTEMPORARY_COUNTER,
                PLANTER,
                SUNFLOWER,
                MODERN_ICON,
                AEROBOT,
                AERO_TABLETOP,
                SLEEK_TABLETOP,
                BLUE_BUBBLE_CHAIR,
                GREEN_BUBBLE_CHAIR,
                ORANGE_BUBBLE_CHAIR,
                PRECISION_LOUNGE_CHAIR,
            };
        }

        public override List<Transformation> GetTransformations()
        {
           return GetWallTransformations(WHITE_WALL, WHITE_WALL_WITH_MINIMALISTIC_ART, MINIMALISTIC_ART);
        }
    }
}

