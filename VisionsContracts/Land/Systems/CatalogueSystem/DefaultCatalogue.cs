using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using VisionsContracts.Items;
using VisionsContracts.Land.Systems.CatalogueSystem.Exceptions;
using VisionsContracts.Land.Systems.CatalogueSystem.Model;

namespace VisionsContracts.Land.Systems.CatalogueSystem
{
    public class DefaultCatalogue
    {
        public static CatalogueItem GetCatalogueItem(BigInteger itemId)
        {
            return GetAllCatalogueItems().FirstOrDefault(x => x.ItemId == itemId);
        }

        public static List<CatalogueItem> GetAllCatalogueItems()
        {
            var catalogueItems = ThemeService.GetCatalogueItems();
            return catalogueItems.Concat(DefaultItemsCatalogue.GetCatalogueItems()).ToList();
        }

        public static List<Catalogue> GetAllCatalogues()
        {
            var catalogue = DefaultItemsCatalogue.CATALOGUE;
            var allCatalogues = new List<Catalogue> { catalogue };
            allCatalogues.AddRange(ThemeService.GetCatalogues());
            return allCatalogues;
        }

        public static List<CatalogueItem> GetCatalogueItemsByCatalogueId(BigInteger catalogueId)
        {
            return GetAllCatalogueItems().Where(x => x.CatalogueId == catalogueId).ToList();
        }

        public static TotalPurchaseCostBalance CalculateTotalPurchaseCostAndBalance(BigInteger balance, List<CatalogueItemPurchase> catalogueItemPurchases)
        {
            BigInteger totalCost = 0;
            foreach (var catalogueItemPurchase in catalogueItemPurchases)
            {
                var catalogueItem = GetCatalogueItem(catalogueItemPurchase.ItemId);
                if (catalogueItem == null)
                {
                    throw new ItemNotFoundInCatalogueException(catalogueItemPurchase.ItemId);
                }
                totalCost += catalogueItem.Price * catalogueItemPurchase.Quantity;
            }
            return new TotalPurchaseCostBalance { TotalCost = totalCost, Balance = balance };
        }

        public static TotalPurchaseCostBalance CalculateTotalPurchaseCostAndBalance(BigInteger balance, BigInteger itemId, BigInteger quantity)
        {
            return CalculateTotalPurchaseCostAndBalance(balance, new List<CatalogueItemPurchase> { new CatalogueItemPurchase(itemId, quantity) });
        }

    }
}
