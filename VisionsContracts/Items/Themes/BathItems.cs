using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VisionsContracts.Items.Model;
using VisionsContracts.Land.Systems.CatalogueSystem.Model;
using VisionsContracts.Transformations.Model;

namespace VisionsContracts.Items.Themes
{
    public class BathItems : ThemeItems<BathItems>
    {
        public static readonly Catalogue CATALOGUE = new Catalogue() { CatalogueId = 1, Name = "Bath" };
        // Bath items
        public static readonly Item BATH_TILE_WALL = new(name: "Bath Tile Wall", id: 10100, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item BATH_GLASS_WALL = new(name: "Bath Glass Wall", id: 10101, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item BATH_BAR_COUNTER = new(name: "Bath Bar Counter", id: 10102, category: ItemCategory.Furniture, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item BATH_SHELF = new(name: "Bath Shelf", id: 10103, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item BATH_TILE_FLOOR = new(name: "Bath Tile Floor", id: 10104, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: false, isInventory: true, isRemovable: true);
        public static readonly Item BATH_RHOMBUS_FLOOR = new(name: "Bath Rhombus Floor", id: 10105, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: false, isInventory: true, isRemovable: true);
        public static readonly Item RUBBER_DUCK_MAT = new(name: "Rubber Duck Mat", id: 10106, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item QUACK_FOUNTAIN = new(name: "Quack Fountain", id: 10107, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item MIRROR = new(name: "Mirror", id: 10108, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item TOILET = new(name: "Toilet", id: 10109, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item SINK = new(name: "Sink", id: 10110, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item DRYER = new(name: "Dryer", id: 10111, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item BATH = new(name: "Bath", id: 10112, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item SHOWER = new(name: "Shower", id: 10113, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item WASHING_MACHINE = new(name: "Washing Machine", id: 10114, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);

        //MIRROR, BATH_SHELF
        public static readonly Item BATH_TILE_WALL_WITH_MIRROR = new(name: "Bath Tile Wall with Mirror", id: 10115, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: false, isRemovable: false);
        public static readonly Item BATH_TILE_WALL_WITH_BATH_SHELF = new(name: "Bath Tile Wall with Bath Shelf", id: 10116, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: false, isRemovable: false);

        public override List<Item> GetAllItems()
        {
            return new List<Item>()
        {
            BATH_TILE_WALL,
            BATH_GLASS_WALL,
            BATH_BAR_COUNTER,
            BATH_SHELF,
            BATH_TILE_FLOOR,
            BATH_RHOMBUS_FLOOR,
            RUBBER_DUCK_MAT,
            QUACK_FOUNTAIN,
            MIRROR,
            TOILET,
            SINK,
            DRYER,
            BATH,
            SHOWER,
            WASHING_MACHINE,
            BATH_TILE_WALL_WITH_MIRROR,
            BATH_TILE_WALL_WITH_BATH_SHELF
        };
        }

        public override List<Item> GetCounters()
        {
            return new List<Item>()
        {
            BATH_BAR_COUNTER
        };
        }

        public override List<Item> GetFloors()
        {
            return new List<Item>()
        {
            BATH_TILE_FLOOR,
            BATH_RHOMBUS_FLOOR
        };
        }

        public override List<Item> GetChairs()
        {
            return new List<Item>();
        }

        public override List<Item> GetTables()
        {
            return new List<Item>();
        }

        public override Catalogue GetCatalogue()
        {
            return CATALOGUE;
        }

        public override List<CatalogueItem> GetCatalogueItems()
        {

            return new List<CatalogueItem>()
            {
                new CatalogueItem(BATH_TILE_WALL, 3 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(BATH_GLASS_WALL, 3 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(BATH_BAR_COUNTER, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(BATH_SHELF, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(BATH_TILE_FLOOR, 2 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(BATH_RHOMBUS_FLOOR, 2 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(RUBBER_DUCK_MAT, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(QUACK_FOUNTAIN, 10 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(MIRROR, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(TOILET, 10 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(SINK, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(DRYER, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(BATH, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(SHOWER, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(WASHING_MACHINE, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId)
            };
        }

        public override List<Item> GetAllFloorStackableItems()
        {
            return new List<Item>()
            {
                BATH_BAR_COUNTER,
                RUBBER_DUCK_MAT,
                QUACK_FOUNTAIN,
                TOILET,
                SINK,
                DRYER,
                BATH,
                SHOWER,
                WASHING_MACHINE
            };
        }

        public override List<Transformation> GetTransformations()
        {
            var transformations = new List<Transformation>();
            transformations.AddRange(GetWallTransformations(BATH_TILE_WALL, BATH_TILE_WALL_WITH_MIRROR, MIRROR));
            transformations.AddRange(GetWallTransformations(BATH_TILE_WALL, BATH_TILE_WALL_WITH_BATH_SHELF, BATH_SHELF));
            return transformations;
            
        }
    }
}
