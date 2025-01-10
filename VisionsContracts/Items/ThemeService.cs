using System.Collections.Generic;
using VisionsContracts.Items.Model;
using VisionsContracts.Items.Themes;
using VisionsContracts.Land.Systems.CatalogueSystem.Model;
using VisionsContracts.Transformations.Model;


namespace VisionsContracts.Items
{
    public class ThemeService
    {
        public static List<IThemeItems> GetAllThemes()
        {
            return new List<IThemeItems>
             {
                 AthenaeumItems.Instance,
                 AeroItems.Instance,
                 BathItems.Instance,
                 BeachBarItems.Instance,
                 ImperialDynastyItems.Instance,
                 JungleItems.Instance,
                 MovieTheaterItems.Instance,
                 PurrfectPalaceItems.Instance,
                 RecordingStudioItems.Instance,
                 ZenGardenItems.Instance
             };
        }

        public static List<Item> GetAllItems()
        {
            var list = new List<Item>();
            foreach (var theme in GetAllThemes())
            {
                list.AddRange(theme.GetAllItems());
            }
            return list;
        }

        public static List<Item> GetCounters()
        {
            var list = new List<Item>();
            foreach (var theme in GetAllThemes())
            {
                list.AddRange(theme.GetCounters());
            }
            return list;
        }

        public static List<Item> GetFloors()
        {
            var list = new List<Item>();
            foreach (var theme in GetAllThemes())
            {
                list.AddRange(theme.GetFloors());
            }
            return list;
        }

        public static List<Item> GetChairs()
        {
            var list = new List<Item>();
            foreach (var theme in GetAllThemes())
            {
                list.AddRange(theme.GetChairs());
            }
            return list;
        }

        public static List<Item> GetTables()
        {
            var list = new List<Item>();
            foreach (var theme in GetAllThemes())
            {
                list.AddRange(theme.GetTables());
            }
            return list;
        }

        public static List<Catalogue> GetCatalogues()
        {
            var catalogues = new List<Catalogue>();
            foreach (var theme in GetAllThemes())
            {
                catalogues.Add(theme.GetCatalogue());
            }
            return catalogues;
        }

        public static List<CatalogueItem> GetCatalogueItems()
        {
            var catalogueItems = new List<CatalogueItem>();
            foreach (var theme in GetAllThemes())
            {
                catalogueItems.AddRange(theme.GetCatalogueItems());
            }

            return catalogueItems;
        }

        public static List<Item> GetAllFloorStackableItems()
        {
            var list = new List<Item>();
            foreach (var theme in GetAllThemes())
            {
                list.AddRange(theme.GetAllFloorStackableItems());
            }
            return list;

        }

        public static List<Transformation> GetTransformations()
        {
            var list = new List<Transformation>();
            foreach (var theme in GetAllThemes())
            {
                list.AddRange(theme.GetTransformations());
            }
            return list;
        }

        public static List<Item> GetCounterStackableItems()
        {
            var list = new List<Item>();
            foreach (var theme in GetAllThemes())
            {
                list.AddRange(theme.GetCounterStackableItems());
            }
            return list;
        }

    }

}
