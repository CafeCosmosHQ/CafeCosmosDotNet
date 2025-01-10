using System;
using System.Collections.Generic;
using System.Text;
using VisionsContracts.Items.Model;
using VisionsContracts.Land.Systems.CatalogueSystem.Model;
using VisionsContracts.Transformations.Model;

namespace VisionsContracts.Items.Themes
{
    public class MovieTheaterItems : ThemeItems<MovieTheaterItems>
    {
        public static readonly Catalogue CATALOGUE = new Catalogue() { CatalogueId = 7, Name = "Movie Theater" };
        // Movie Theater items
        public static readonly Item SNACK_BAR_COUNTER = new(name: "Snack Bar Counter", id: 10700, category: ItemCategory.Furniture, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item PURPLE_TABLE = new(name: "Purple Table", id: 10701, category: ItemCategory.Furniture, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item PINK_PLUSH_CHAIR = new(name: "Pink Plush Chair", id: 10702, category: ItemCategory.Furniture, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item GREEN_PLUSH_CHAIR = new(name: "Green Plush Chair", id: 10703, category: ItemCategory.Furniture, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item POPCORN_MACHINE = new(name: "Popcorn Machine", id: 10704, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item RETRO_ARCADE = new(name: "Retro Arcade", id: 10705, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item NACHO_MACHINE = new(name: "Nacho Machine", id: 10706, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item PLASMA_GLOBE = new(name: "Plasma Globe", id: 10707, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item NEON_MENU = new(name: "Neon Menu", id: 10708, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item SPOTLIGHT = new(name: "Spotlight", id: 10709, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item CLAW_MACHINE = new(name: "Claw Machine", id: 10710, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item COSMO_CRISIS_ARCADE = new(name: "Cosmo Crisis Arcade", id: 10711, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item COSMO_RUSH_DELUXE = new(name: "Cosmo Rush Deluxe", id: 10712, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item COSMO_RUSH_DELUXE_2 = new(name: "Cosmo Rush Deluxe 2", id: 10713, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item CRUISN_CAFE_RACING_MACHINE = new(name: "Cruis'n Cafe Racing Machine", id: 10714, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item PRETZEL_MACHINE = new(name: "Pretzel Machine", id: 10715, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item SODA_MACHINE = new(name: "Soda Machine", id: 10716, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item BUBBLE_GUN_MACHINE = new(name: "Bubble Gun Machine", id: 10717, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item MOVIE_THEATER_DIVIDER = new(name: "Movie Theater Divider", id: 10718, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item VENDING_MACHINE = new(name: "Vending Machine", id: 10719, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item MOVIE_THEATER_WALL_I = new(name: "Movie Theater Wall I", id: 10720, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item MOVIE_THEATER_WALL_II = new(name: "Movie Theater Wall II", id: 10721, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item DIRECTORS_CUT_CARPET = new(name: "Director's Cut Carpet", id: 10722, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: false, isInventory: true, isRemovable: true);
        public static readonly Item STAR_CARPET = new(name: "Star Carpet", id: 10723, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: false, isInventory: true, isRemovable: true);

        public override List<Item> GetAllItems()
        {
            return new List<Item>()
            {
                SNACK_BAR_COUNTER,
                PURPLE_TABLE,
                PINK_PLUSH_CHAIR,
                GREEN_PLUSH_CHAIR,
                POPCORN_MACHINE,
                RETRO_ARCADE,
                NACHO_MACHINE,
                PLASMA_GLOBE,
                NEON_MENU,
                SPOTLIGHT,
                CLAW_MACHINE,
                COSMO_CRISIS_ARCADE,
                COSMO_RUSH_DELUXE,
                COSMO_RUSH_DELUXE_2,
                CRUISN_CAFE_RACING_MACHINE,
                PRETZEL_MACHINE,
                SODA_MACHINE,
                BUBBLE_GUN_MACHINE,
                MOVIE_THEATER_DIVIDER,
                VENDING_MACHINE,
                MOVIE_THEATER_WALL_I,
                MOVIE_THEATER_WALL_II,
                DIRECTORS_CUT_CARPET,
                STAR_CARPET
            };
        }

        public override List<Item> GetCounters()
        {
            return new List<Item>()
            {
                SNACK_BAR_COUNTER
            };
        }

        public override List<Item> GetFloors()
        {
            return new List<Item>()
            {
                DIRECTORS_CUT_CARPET,
                STAR_CARPET
            };
        }

        public override List<Item> GetChairs()
        {
            return new List<Item>()
            {
                PINK_PLUSH_CHAIR,
                GREEN_PLUSH_CHAIR
            };
        }

        public override List<Item> GetTables()
        {
            return new List<Item>()
            {
                PURPLE_TABLE
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
                new CatalogueItem(SNACK_BAR_COUNTER, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(PURPLE_TABLE, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(PINK_PLUSH_CHAIR, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(GREEN_PLUSH_CHAIR, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(POPCORN_MACHINE, 7.5m * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(RETRO_ARCADE, 10 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(NACHO_MACHINE, 7.5m * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(PLASMA_GLOBE, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(NEON_MENU, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(SPOTLIGHT, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(CLAW_MACHINE, 10 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(COSMO_CRISIS_ARCADE, 10 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(COSMO_RUSH_DELUXE, 10 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(COSMO_RUSH_DELUXE_2, 10 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(CRUISN_CAFE_RACING_MACHINE, 10 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(PRETZEL_MACHINE, 7.5m * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(SODA_MACHINE, 7.5m * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(BUBBLE_GUN_MACHINE, 7.5m * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(MOVIE_THEATER_DIVIDER, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(VENDING_MACHINE, 7.5m * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(MOVIE_THEATER_WALL_I, 3 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(MOVIE_THEATER_WALL_II, 3 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(DIRECTORS_CUT_CARPET, 2 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(STAR_CARPET, 2 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId)
            };
        }


        public override List<Item> GetAllFloorStackableItems()
        {
            return new List<Item>
            {
                SNACK_BAR_COUNTER,
                PURPLE_TABLE,
                PINK_PLUSH_CHAIR,
                GREEN_PLUSH_CHAIR,
                POPCORN_MACHINE,
                RETRO_ARCADE,
                NACHO_MACHINE,
                CLAW_MACHINE,
                COSMO_CRISIS_ARCADE,
                COSMO_RUSH_DELUXE,
                COSMO_RUSH_DELUXE_2,
                CRUISN_CAFE_RACING_MACHINE,
                PRETZEL_MACHINE,
                SODA_MACHINE,
                BUBBLE_GUN_MACHINE,
                MOVIE_THEATER_DIVIDER,
                VENDING_MACHINE
            };
        }

        public override List<Transformation> GetTransformations()
        {
           return new List<Transformation>();
        }
    }
}

