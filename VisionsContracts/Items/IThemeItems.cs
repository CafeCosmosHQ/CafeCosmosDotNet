using System.Collections.Generic;
using VisionsContracts.Items.Model;
using VisionsContracts.Land.Systems.CatalogueSystem.Model;
using VisionsContracts.Transformations.Model;

namespace VisionsContracts.Items
{
    public interface IThemeItems
    {
        List<Item> GetAllItems();
        List<Item> GetTables();
        List<Item> GetChairs();
        List<Item> GetCounters();
        List<Item> GetFloors();
        List<Item> GetAllFloorStackableItems();
        Catalogue GetCatalogue();

        List<CatalogueItem> GetCatalogueItems();

        List<Transformation> GetTransformations();

        List<Item> GetCounterStackableItems();

    }
}
