using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VisionsContracts.Items.Model;
using VisionsContracts.Land.Systems.CatalogueSystem.Model;
using VisionsContracts.Transformations.Model;

namespace VisionsContracts.Items.Themes
{
    /// <summary>
    /// Cat Cafe
    /// </summary>
    public class PurrfectPalaceItems : ThemeItems<PurrfectPalaceItems>
    {
        public static readonly Catalogue CATALOGUE = new Catalogue() { CatalogueId = 3, Name = "Purrfect Palace" };
        // Purrfect Palace items
        public static readonly Item PURRFECT_FLOORING = new(name: "Purrfect Flooring", id: 10300, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: false, isInventory: true, isRemovable: true);
        public static readonly Item CAT_NAP_WALL = new(name: "Cat Nap Wall", id: 10301, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item CAT_TOY = new(name: "Cat Toy", id: 10302, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item WHISKER_WALL = new(name: "Whisker Wall", id: 10303, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item WHISKER_WONDERLAND = new(name: "Whisker Wonderland", id: 10304, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item WHISKER_PERCH = new(name: "Whisker Perch", id: 10305, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item PURRFECT_CUSHION = new(name: "Purrfect Cushion", id: 10306, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item MEOWJESTIC_CLOCK = new(name: "Meowjestic Clock", id: 10307, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item PAWS_N_PINTS_COUNTER = new(name: "Paws 'n Pints Counter", id: 10308, category: ItemCategory.Furniture, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item PAWS_N_PINTS_COUNTER_2 = new(name: "Paws 'n Pints Counter 2", id: 10309, category: ItemCategory.Furniture, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item PURRFECT_TABLE = new(name: "Purrfect Table", id: 10310, category: ItemCategory.Furniture, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item PURRFECT_SEAT = new(name: "Purrfect Seat", id: 10311, category: ItemCategory.Furniture, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item WHISKER_WALL_WINDOW = new(name: "Whisker Wall Window", id: 10312, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item CAT_NAP_WALL_WINDOW = new(name: "Cat Nap Wall Window", id: 10313, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);


        public static readonly Item CAT_NAP_WALL_WITH_MEOWJESTIC_CLOCK = new(name: "Cat Nap Wall with MeowJestic Clock", id: 10314, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: false, isRemovable: false);
        public static readonly Item CAT_NAP_WALL_WITH_WHISKER_PERCH = new(name: "Cat Nap Wall with Whisker Perch", id: 10315, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: false, isRemovable: false);
        public static readonly Item CAT_NAP_WALL_WITH_PURRFECT_CUSHION = new(name: "Cat Nap Wall with Purrfect Cushion", id: 10316, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: false, isRemovable: false);

        public static readonly Item WHISKER_WALL_WITH_MEOWJESTIC_CLOCK = new(name: "Whisker Wall with MeowJestic Clock", id: 10317, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: false, isRemovable: false);
        public static readonly Item WHISKER_WALL_WITH_WHISKER_PERCH = new(name: "Whisker Wall with Whisker Perch", id: 10318, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: false, isRemovable: false);
        public static readonly Item WHISKER_WALL_WITH_PURRFECT_CUSHION = new(name: "Whisker Wall with Purrfect Cushion", id: 10319, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: false, isRemovable: false);

        public override List<Item> GetAllItems()
        {
            return new List<Item>()
            {
                PURRFECT_FLOORING,
                CAT_NAP_WALL,
                CAT_TOY,
                WHISKER_WALL,
                WHISKER_WONDERLAND,
                WHISKER_PERCH,
                PURRFECT_CUSHION,
                MEOWJESTIC_CLOCK,
                PAWS_N_PINTS_COUNTER,
                PAWS_N_PINTS_COUNTER_2,
                PURRFECT_TABLE,
                PURRFECT_SEAT,
                WHISKER_WALL_WINDOW,
                CAT_NAP_WALL_WINDOW,
                CAT_NAP_WALL_WITH_MEOWJESTIC_CLOCK,
                CAT_NAP_WALL_WITH_WHISKER_PERCH,
                CAT_NAP_WALL_WITH_PURRFECT_CUSHION,
                WHISKER_WALL_WITH_MEOWJESTIC_CLOCK,
                WHISKER_WALL_WITH_WHISKER_PERCH,
                WHISKER_WALL_WITH_PURRFECT_CUSHION
            };
        }

        public override List<Item> GetCounters()
        {
            return new List<Item>()
            {
                PAWS_N_PINTS_COUNTER,
                PAWS_N_PINTS_COUNTER_2
            };
        }

        public override List<Item> GetFloors()
        {
            return new List<Item>()
            {
                PURRFECT_FLOORING
            };
        }

        public override List<Item> GetChairs()
        {
            return new List<Item>()
            {
                PURRFECT_SEAT
            };
        }

        public override List<Item> GetTables()
        {
            return new List<Item>()
            {
                PURRFECT_TABLE
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
                new CatalogueItem(PURRFECT_FLOORING, 2 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(CAT_NAP_WALL, 3 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(CAT_TOY, 7.5m * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(WHISKER_WALL, 3 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(WHISKER_WONDERLAND, 10 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(WHISKER_PERCH, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(PURRFECT_CUSHION, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(MEOWJESTIC_CLOCK, 7.5m * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(PAWS_N_PINTS_COUNTER, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(PAWS_N_PINTS_COUNTER_2, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(PURRFECT_TABLE, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(PURRFECT_SEAT, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(WHISKER_WALL_WINDOW, 7.5m * PRICE_MULTIPLIER, CATALOGUE.CatalogueId), 
                new CatalogueItem(CAT_NAP_WALL_WINDOW, 7.5m * PRICE_MULTIPLIER, CATALOGUE.CatalogueId)  
            };
        }

        public override List<Item> GetAllFloorStackableItems()
        {
            return new List<Item>()
            {
                CAT_TOY,
                WHISKER_WONDERLAND,
                PAWS_N_PINTS_COUNTER,
                PAWS_N_PINTS_COUNTER_2,
                PURRFECT_TABLE,
                PURRFECT_SEAT
            };
        }

        public override List<Transformation> GetTransformations()
        {
            var transformations = new List<Transformation>();
            transformations.AddRange(GetWallTransformations(WHISKER_WALL, WHISKER_WALL_WITH_MEOWJESTIC_CLOCK, MEOWJESTIC_CLOCK));
            transformations.AddRange(GetWallTransformations(WHISKER_WALL, WHISKER_WALL_WITH_WHISKER_PERCH, WHISKER_PERCH));
            transformations.AddRange(GetWallTransformations(WHISKER_WALL, WHISKER_WALL_WITH_PURRFECT_CUSHION, PURRFECT_CUSHION));
            transformations.AddRange(GetWallTransformations(CAT_NAP_WALL, CAT_NAP_WALL_WITH_MEOWJESTIC_CLOCK, MEOWJESTIC_CLOCK));
            transformations.AddRange(GetWallTransformations(CAT_NAP_WALL, CAT_NAP_WALL_WITH_WHISKER_PERCH, WHISKER_PERCH));
            transformations.AddRange(GetWallTransformations(CAT_NAP_WALL, CAT_NAP_WALL_WITH_PURRFECT_CUSHION, PURRFECT_CUSHION));
            return transformations;
        }
    }
}
