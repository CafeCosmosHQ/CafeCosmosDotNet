using System;
using System.Collections.Generic;
using System.Text;
using VisionsContracts.Land.Systems.CatalogueSystem.ContractDefinition;
using VisionsContracts.Land.Systems.CatalogueSystem.Model;

namespace VisionsContracts.Land.Systems.CatalogueSystem.Mapping
{


    public static class CatalogueItemMapping
    {
        public static CatalogueItemDTO MapToDTO(this CatalogueItem catalogueItem)
        {
            return new CatalogueItemDTO
            {
                ItemId = catalogueItem.ItemId,
                Price = catalogueItem.Price,
                CatalogueId = catalogueItem.CatalogueId,
                Exists = catalogueItem.Exists
            };
        }

        public static CatalogueItem MapToModel(this CatalogueItemDTO catalogueItemDTO)
        {
            return new CatalogueItem
            {
                ItemId = catalogueItemDTO.ItemId,
                Price = catalogueItemDTO.Price,
                CatalogueId = catalogueItemDTO.CatalogueId,
                Exists = catalogueItemDTO.Exists
            };
        }

        public static List<CatalogueItemDTO> MapToDTO(this List<CatalogueItem> catalogueItems)
        {
            List<CatalogueItemDTO> catalogueItemDTOs = new List<CatalogueItemDTO>();
            foreach (var catalogueItem in catalogueItems)
            {
                catalogueItemDTOs.Add(catalogueItem.MapToDTO());
            }
            return catalogueItemDTOs;
        }

        public static List<CatalogueItem> MapToModel(this List<CatalogueItemDTO> catalogueItemDTOs)
        {
            List<CatalogueItem> catalogueItems = new List<CatalogueItem>();
            foreach (var catalogueItemDTO in catalogueItemDTOs)
            {
                catalogueItems.Add(catalogueItemDTO.MapToModel());
            }
            return catalogueItems;
        }
    }
}
