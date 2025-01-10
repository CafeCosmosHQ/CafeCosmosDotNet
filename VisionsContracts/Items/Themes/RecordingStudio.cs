using System;
using System.Collections.Generic;
using System.Text;
using VisionsContracts.Items.Model;
using VisionsContracts.Land.Systems.CatalogueSystem.Model;
using VisionsContracts.Transformations.Model;

namespace VisionsContracts.Items.Themes
{
    public class RecordingStudioItems : ThemeItems<RecordingStudioItems>
    {
        public static readonly Catalogue CATALOGUE = new Catalogue() { CatalogueId = 6, Name = "Recording Studio" };
        // Recording Studio items
        public static readonly Item SOUNDPROOF_FLOORING = new(name: "Soundproof Flooring", id: 10600, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: false, isInventory: true, isRemovable: true);
        public static readonly Item ACOUSTIC_FLOORING = new(name: "Acoustic Flooring", id: 10601, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: false, isInventory: true, isRemovable: true);
        public static readonly Item ACOUSTIC_WALL = new(name: "Acoustic Wall", id: 10602, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item SURROUND_SOUND_WALL = new(name: "Surround Sound Wall", id: 10603, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item SOUNDPROOF_WALL = new(name: "Soundproof Wall", id: 10604, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item AMPLIFIED_BAR_COUNTER = new(name: "Amplified Bar Counter", id: 10605, category: ItemCategory.Furniture, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item STUDIO_RACKMOUNT = new(name: "Studio Rackmount", id: 10606, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item PRODUCERS_WORKSTATION = new(name: "Producer's Workstation", id: 10607, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item MIXING_WORKSTATION = new(name: "Mixing Workstation", id: 10608, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item NEON_DOTS_SIGN = new(name: "Neon D.O.T.S. Sign", id: 10609, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
        public static readonly Item LIVE_WORKSTATION = new(name: "Live Workstation", id: 10610, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);

        public override List<Item> GetAllItems()
        {
            return new List<Item>()
            {
                SOUNDPROOF_FLOORING,
                ACOUSTIC_FLOORING,
                ACOUSTIC_WALL,
                SURROUND_SOUND_WALL,
                SOUNDPROOF_WALL,
                AMPLIFIED_BAR_COUNTER,
                STUDIO_RACKMOUNT,
                PRODUCERS_WORKSTATION,
                MIXING_WORKSTATION,
                NEON_DOTS_SIGN,
                LIVE_WORKSTATION
            };
        }

        public override List<Item> GetCounters()
        {
            return new List<Item>()
            {
                AMPLIFIED_BAR_COUNTER
            };
        }

        public override List<Item> GetFloors()
        {
            return new List<Item>()
            {
                SOUNDPROOF_FLOORING,
                ACOUSTIC_FLOORING
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
                new CatalogueItem(SOUNDPROOF_FLOORING, 2 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(ACOUSTIC_FLOORING, 2 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(ACOUSTIC_WALL, 3 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(SURROUND_SOUND_WALL, 3 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(SOUNDPROOF_WALL, 3 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(AMPLIFIED_BAR_COUNTER, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(STUDIO_RACKMOUNT, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(PRODUCERS_WORKSTATION, 10 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(MIXING_WORKSTATION, 10 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(NEON_DOTS_SIGN, 5 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId),
                new CatalogueItem(LIVE_WORKSTATION, 10 * PRICE_MULTIPLIER, CATALOGUE.CatalogueId)
            };
        }


        public override List<Item> GetAllFloorStackableItems()
        {
            return new List<Item>()
            {
                AMPLIFIED_BAR_COUNTER,
                PRODUCERS_WORKSTATION,
                MIXING_WORKSTATION,
                LIVE_WORKSTATION
            };

        }

        public override List<Transformation> GetTransformations()
        {
            return new List<Transformation>();
        }
    }
}

