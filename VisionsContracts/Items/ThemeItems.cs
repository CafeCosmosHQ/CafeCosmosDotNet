using System.Collections.Generic;
using VisionsContracts.Items.Model;
using VisionsContracts.Land.Systems.CatalogueSystem.Model;
using VisionsContracts.Transformations.Model;

namespace VisionsContracts.Items
{
    public abstract class ThemeItems<T> : IThemeItems where T : ThemeItems<T>, new()
    {

        public const decimal PRICE_MULTIPLIER = 2m;

        public static T Instance { get; private set; } = new T();
        public abstract List<Item> GetAllItems();
        public abstract List<Item> GetChairs();
        public abstract List<Item> GetCounters();
        public abstract List<Item> GetFloors();
        public abstract List<Item> GetTables();
        public abstract Catalogue GetCatalogue();

        public abstract List<Item> GetAllFloorStackableItems();

        public abstract List<CatalogueItem> GetCatalogueItems();

        public abstract List<Transformation> GetTransformations();

        public virtual List<Item> GetCounterStackableItems()
        {
            return new List<Item>();
        }

        public List<Transformation> GetWallTransformations(Item wall, Item wallWithDecoration, Item decoration)
        {
            return WallDecorationTransformationFactory.CreateTransformations(wall, wallWithDecoration, decoration);
        }

    }
}
