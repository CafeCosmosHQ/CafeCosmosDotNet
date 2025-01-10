using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VisionsContracts.Items.Model;
using VisionsContracts.Land.Systems.CatalogueSystem.Model;
using VisionsContracts.Transformations.Model;

namespace VisionsContracts.Items.Themes
{

    //Study Cafe items
    public class AthenaeumItems : ThemeItems<AthenaeumItems>
    {
        public static readonly Catalogue CATALOGUE = new Catalogue() { CatalogueId = 2, Name = "Athenaeum" };
        
            public static readonly Item LIBRARY_FLOOR = new(name: "Library Floor", id: 10200, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: false, isInventory: true, isRemovable: true);
            public static readonly Item HELIX_STAIRCASE = new(name: "Helix Staircase", id: 10201, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
            public static readonly Item LIBRARY_WALL = new(name: "Library Wall", id: 10202, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);
            public static readonly Item SCHOLARS_SEAT = new(name: "Scholar's Seat", id: 10203, category: ItemCategory.Furniture, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
            public static readonly Item SCHOLARS_DESK = new(name: "Scholar's Desk", id: 10204, category: ItemCategory.Furniture, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
            public static readonly Item SCHOLARS_BAR_COUNTER = new(name: "Scholar's Bar Counter", id: 10205, category: ItemCategory.Furniture, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
            public static readonly Item BOOKSHELF_WALL_I = new(name: "Bookshelf Wall I", id: 10206, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);
            public static readonly Item BOOKSHELF_WALL_II = new(name: "Bookshelf Wall II", id: 10207, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);
            public static readonly Item GUARDIAN_OF_WISDOM = new(name: "Guardian of Wisdom", id: 10208, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
            public static readonly Item TROPHY_WALL = new(name: "Trophy Wall", id: 10209, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);
            public static readonly Item HEADMASTERS_BUST = new(name: "Headmaster's Bust", id: 10210, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
            public static readonly Item SCHOLARS_HEAP = new(name: "Scholar's Heap", id: 10211, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
            public static readonly Item SCHOLARS_THESIS = new(name: "Scholar's Thesis", id: 10212, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
            public static readonly Item GRAND_ILLUMINATORS = new(name: "Grand Illuminators", id: 10213, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
            public static readonly Item CODEX_OF_SECRETS = new(name: "Codex of Secrets", id: 10214, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
            public static readonly Item SCHOLARS_CHESSBOARD = new(name: "Scholar's Chessboard", id: 10215, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
            public static readonly Item SCHOLARS_GLOBE = new(name: "Scholar's Globe", id: 10216, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);

            public static readonly Item LIBRARY_WALL_WITH_GUARDIAN_OF_WISDOM = new(name: "Library Wall with Guardian of Wisdom", id: 10217, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: false, isRemovable: false); 


        public override List<Transformation> GetTransformations()
        {
            return
                GetWallTransformations(LIBRARY_WALL, LIBRARY_WALL_WITH_GUARDIAN_OF_WISDOM, GUARDIAN_OF_WISDOM);
        }

        public override List<Item> GetAllItems()
        {
            return new List<Item>()
        {
            LIBRARY_FLOOR,
            HELIX_STAIRCASE,
            LIBRARY_WALL,
            SCHOLARS_SEAT,
            SCHOLARS_DESK,
            SCHOLARS_BAR_COUNTER,
            BOOKSHELF_WALL_I,
            BOOKSHELF_WALL_II,
            GUARDIAN_OF_WISDOM,
            TROPHY_WALL,
            HEADMASTERS_BUST,
            SCHOLARS_HEAP,
            SCHOLARS_THESIS,
            GRAND_ILLUMINATORS,
            CODEX_OF_SECRETS,
            SCHOLARS_CHESSBOARD,
            SCHOLARS_GLOBE,
            LIBRARY_WALL_WITH_GUARDIAN_OF_WISDOM
        };
        }

        public override List<Item> GetChairs()
        {
            return new List<Item>()
        {
            SCHOLARS_SEAT
        };
        }

        public override List<Item> GetCounters()
        {
            return new List<Item>()
        {
            SCHOLARS_BAR_COUNTER
        };
        }

        public override List<Item> GetFloors()
        {
            return new List<Item>()
        {
            LIBRARY_FLOOR
        };
        }

        public override List<Item> GetTables()
        {
            return new List<Item>()
        {
            SCHOLARS_DESK
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
                new CatalogueItem(LIBRARY_FLOOR.Id, 3m * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(HELIX_STAIRCASE.Id, 5m * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(LIBRARY_WALL.Id, 5m * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(SCHOLARS_SEAT.Id, 5m * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(SCHOLARS_DESK.Id, 5m * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(SCHOLARS_BAR_COUNTER.Id, 5m * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(BOOKSHELF_WALL_I.Id, 5m * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(BOOKSHELF_WALL_II.Id, 5m * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(GUARDIAN_OF_WISDOM.Id, 10m * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(TROPHY_WALL.Id, 5m * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(HEADMASTERS_BUST.Id, 5m * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(SCHOLARS_HEAP.Id, 5m * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(SCHOLARS_THESIS.Id, 10m * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(GRAND_ILLUMINATORS.Id, 5m * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(CODEX_OF_SECRETS.Id, 10m * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(SCHOLARS_CHESSBOARD.Id, 5m * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(SCHOLARS_GLOBE.Id, 5m * PRICE_MULTIPLIER, CATALOGUE.CatalogueId)
            };
        }

        public override List<Item> GetAllFloorStackableItems()
        {
            return new List<Item>()
            {
                SCHOLARS_DESK,
                SCHOLARS_SEAT,
                SCHOLARS_BAR_COUNTER,
                HELIX_STAIRCASE,
                HEADMASTERS_BUST,
                SCHOLARS_HEAP,
                SCHOLARS_THESIS,
                GRAND_ILLUMINATORS,
                CODEX_OF_SECRETS,
                SCHOLARS_CHESSBOARD,
                SCHOLARS_GLOBE
            };
        }
    }
}
