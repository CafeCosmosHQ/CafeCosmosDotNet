using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VisionsContracts.Items.Model;
using VisionsContracts.Land.Systems.CatalogueSystem.Model;
using VisionsContracts.Transformations.Model;

namespace VisionsContracts.Items.Themes
{
    public class ImperialDynastyItems : ThemeItems<ImperialDynastyItems>
    {
        public static readonly Catalogue CATALOGUE = new Catalogue() { CatalogueId = 8, Name = "Imperial Dynasty" };
        // Imperial Dynasty items
        public static readonly Item IMPERIAL_BAR_COUNTER = new(name: "Imperial Bar Counter", id: 10800, category: ItemCategory.Furniture, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item PARLOR_TABLE = new(name: "Parlor Table", id: 10801, category: ItemCategory.Furniture, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item PARLOR_SEAT = new(name: "Parlor Seat", id: 10802, category: ItemCategory.Furniture, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item OCEAN_DRAKE = new(name: "Ocean Drake", id: 10803, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item GENESIS_ARTIFACT = new(name: "Genesis Artifact", id: 10804, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item IMPERIAL_LANTERN = new(name: "Imperial Lantern", id: 10805, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item BAMBOO_SHRINE = new(name: "Bamboo Shrine", id: 10806, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item NEON_CHEF_FIXTURE = new(name: "NEON Chef Fixture", id: 10807, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item IMPERIAL_DYNASTY_SIGN = new(name: "Imperial Dynasty Sign", id: 10808, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item ROCKING_PANDA = new(name: "Rocking Panda", id: 10809, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item BLACK_WALL = new(name: "Black Wall", id: 10810, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item RED_DIVIDER = new(name: "Red Divider", id: 10811, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item HEAD_CHEFS_WALL = new(name: "Head Chef's Wall", id: 10812, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item LACQUERED_DUCK_WALL = new(name: "Lacquered Duck Wall", id: 10813, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item HEAD_CHEFS_LOOKOUT = new(name: "Head Chef's Lookout", id: 10814, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item PAVILION_FLOORING = new(name: "Pavilion Flooring", id: 10815, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: false, isInventory: true, isRemovable: true);
        public static readonly Item PANDA_TRACKS = new(name: "Panda Tracks", id: 10816, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);


        public static readonly Item BLACK_WALL_WITH_IMPERIAL_LATTERN = new(name: "Black Wall with Imperial Lantern", id: 10817, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: false, isRemovable: false);
        public static readonly Item BLACK_WALL_WITH_IMPERIAL_DYNASTY_SIGN = new(name: "Black Wall with Imperial Dynasty Sign", id: 10818, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: false, isRemovable: false);
        public static readonly Item BLACK_WALL_WITH_NEON_CHEF_FIXTURE = new(name: "Black Wall with NEON Chef Fixture", id: 10819, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: false, isRemovable: false);

        public override List<Item> GetAllItems()
        {
            return new List<Item>()
            {
                IMPERIAL_BAR_COUNTER,
                PARLOR_TABLE,
                PARLOR_SEAT,
                OCEAN_DRAKE,
                GENESIS_ARTIFACT,
                IMPERIAL_LANTERN,
                BAMBOO_SHRINE,
                NEON_CHEF_FIXTURE,
                IMPERIAL_DYNASTY_SIGN,
                ROCKING_PANDA,
                BLACK_WALL,
                RED_DIVIDER,
                HEAD_CHEFS_WALL,
                LACQUERED_DUCK_WALL,
                HEAD_CHEFS_LOOKOUT,
                PAVILION_FLOORING,
                PANDA_TRACKS,
                BLACK_WALL_WITH_IMPERIAL_LATTERN,
                BLACK_WALL_WITH_IMPERIAL_DYNASTY_SIGN,
                BLACK_WALL_WITH_NEON_CHEF_FIXTURE
            };
        }

        public override List<Item> GetCounters()
        {
            return new List<Item>()
            {
                IMPERIAL_BAR_COUNTER
            };
        }

        public override List<Item> GetFloors()
        {
            return new List<Item>()
            {
                PAVILION_FLOORING
            };
        }

        public override List<Item> GetChairs()
        {
            return new List<Item>()
            {
                PARLOR_SEAT
            };
        }

        public override List<Item> GetTables()
        {
            return new List<Item>()
            {
                PARLOR_TABLE
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
                new CatalogueItem(IMPERIAL_BAR_COUNTER, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(PARLOR_TABLE, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(PARLOR_SEAT, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(OCEAN_DRAKE, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(GENESIS_ARTIFACT, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(IMPERIAL_LANTERN, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(BAMBOO_SHRINE, 10 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(NEON_CHEF_FIXTURE, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(IMPERIAL_DYNASTY_SIGN, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(ROCKING_PANDA, 10 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(BLACK_WALL, 3 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(RED_DIVIDER, 3 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(HEAD_CHEFS_WALL, 3 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(LACQUERED_DUCK_WALL, 3 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(HEAD_CHEFS_LOOKOUT, 3 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(PAVILION_FLOORING, 2 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(PANDA_TRACKS, 2 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId)
            };
        }

        public override List<Item> GetAllFloorStackableItems()
        {
            return new List<Item>()
            {
                IMPERIAL_BAR_COUNTER,
                PARLOR_TABLE,
                PARLOR_SEAT,
                IMPERIAL_LANTERN,
                BAMBOO_SHRINE,
            };
        }

        public override List<Transformation> GetTransformations()
        {
            var transformations = new List<Transformation>();
            transformations.AddRange(GetWallTransformations(BLACK_WALL, BLACK_WALL_WITH_IMPERIAL_LATTERN, IMPERIAL_LANTERN));
            transformations.AddRange(GetWallTransformations(BLACK_WALL, BLACK_WALL_WITH_IMPERIAL_DYNASTY_SIGN, IMPERIAL_DYNASTY_SIGN));
            transformations.AddRange(GetWallTransformations(BLACK_WALL, BLACK_WALL_WITH_NEON_CHEF_FIXTURE, NEON_CHEF_FIXTURE));
            return transformations;
        }
    }
}
