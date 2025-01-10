using System.Collections.Generic;
using VisionsContracts.Land.Systems.CatalogueSystem.ContractDefinition;
using VisionsContracts.Land.Systems.CatalogueSystem.Model;

namespace VisionsContracts.Land.Systems.CatalogueSystem.Mapping
{
    public static class CatalogueItemPurchaseMapping
    {
        public static CatalogueItemPurchaseDTO MapToDTO(this CatalogueItemPurchase catalogueItemPurchase)
        {
            return new CatalogueItemPurchaseDTO
            {
            
                ItemId = catalogueItemPurchase.ItemId,
                Quantity = catalogueItemPurchase.Quantity,
            };
        }

        public static List<CatalogueItemPurchaseDTO> MapToDTO(this List<CatalogueItemPurchase> catalogueItemPurchases)
        {
            List<CatalogueItemPurchaseDTO> catalogueItemPurchaseDTOs = new List<CatalogueItemPurchaseDTO>();
            foreach (var catalogueItemPurchase in catalogueItemPurchases)
            {
                catalogueItemPurchaseDTOs.Add(catalogueItemPurchase.MapToDTO());
            }
            return catalogueItemPurchaseDTOs;
        }

    }
}
