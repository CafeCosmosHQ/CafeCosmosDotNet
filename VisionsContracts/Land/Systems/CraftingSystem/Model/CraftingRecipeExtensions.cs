using System.Collections.Generic;
using System.Linq;
using VisionsContracts.Land.Systems.CraftingSystem.ContractDefinition;
using VisionsContracts.Items.Model;
using CraftRecipeFunction =  VisionsContracts.Land.Systems.CraftingSystem.ContractDefinition.CraftRecipeFunction;
using LBINT = System.Collections.Generic.List<System.Numerics.BigInteger>;
using LBINT2D = System.Collections.Generic.List<System.Collections.Generic.List<System.Numerics.BigInteger>>;
using VisionsContracts.Items;
using System.Runtime.InteropServices;
using System.Numerics;

namespace VisionsContracts.Land.Systems.CraftingSystem.Model
{
    public static class CraftingRecipeExtensions
    {
        public static List<InventoryItem> ConvertToInventoryItemsRequired(this CraftingRecipe recipe)
        {
            return recipe.GetAllRecipeRequiredInventoryItems();
        }

        public static bool IsRecipeTheSame(this CraftingRecipe recipe, LBINT secondInputs, LBINT secondQuantities)
        {
            if (recipe == null || secondInputs == null || secondQuantities == null) return false;
            if (recipe.Inputs.Count != secondInputs.Count) return false;
            for (int i = 0; i < recipe.Inputs.Count; i++)
            {
                var indexOfSecondInput = secondInputs.IndexOf(recipe.Inputs[i]);
                if (indexOfSecondInput == -1) return false;
                if (recipe.InputQuantities[i] != secondQuantities[indexOfSecondInput]) return false;
            }
            return true;
        }

        public static bool IsRecipeTheSame(this LBINT2D first, LBINT2D second)
        {
            if (first == null || second == null) return false;
            if (first.Count != second.Count) return false;
            for (int i = 0; i < first.Count; i++)
            {
                if (first[i].Count != second[i].Count) return false;
                for (int x = 0; x < first[i].Count; x++)
                {
                    if (first[i][x] != second[i][x]) return false;
                }
            }
            return true;
        }

        public static bool HasGotInventoryItemsToCraftRecipe(this CraftingRecipe recipe, List<InventoryItem> items)
        {
            var inventoryItemsRequired = recipe.ConvertToInventoryItemsRequired();
            foreach (var inventoryItemRequired in inventoryItemsRequired)
            {
                if (!items.Exists(x => x.ItemId == inventoryItemRequired.ItemId && x.Count >= inventoryItemRequired.Count))
                {
                    return false;
                }
            }
            return true;
        }

        public static List<Item> GetAllReturnedInventoryItems(this CraftingRecipe recipe)
        {
            var items = new List<Item>();
            var allCraftingReturnItems = DefaultCraftingRecipes.GetReturnedCraftingItems();
            for(int i = 0; i < recipe.Inputs.Count; i++)
            {
                var itemReturned = allCraftingReturnItems.FirstOrDefault(x => x.Item.Id == recipe.Inputs[i]);
                if (itemReturned != null)
                {
                    for (int x = 0; x < recipe.InputQuantities[i]; x++)
                    {
                        items.Add(itemReturned.ItemReturned);
                    }
                }
            }
            return items;
        }
        public static CreateRecipeFunction ConvertToCreateRecipeFunction(this CraftingRecipe craftingRecipe)
        {
            return new CreateRecipeFunction()
            {
                Recipe = ConvertToCraftRecipeDTO(craftingRecipe)
            };
        }

        public static CraftingRecipeDTO ConvertToCraftRecipeDTO(this CraftingRecipe craftingRecipe)
        {
            return new CraftingRecipeDTO()
            {
                Exists = craftingRecipe.Exists,
                Inputs = craftingRecipe.Inputs,
                Output = craftingRecipe.Output.Id,
                OutputQuantity = craftingRecipe.OutputQuantity,
                Quantities = craftingRecipe.InputQuantities,
                Xp = craftingRecipe.Xp
            };
        }


        public static ContractDefinition.CraftRecipeFunction ConvertToLandCraftRecipeFunction(this CraftingRecipe craftingRecipe, BigInteger landId)
        {
            return new CraftRecipeFunction()
            {
                Output = craftingRecipe.Output.Id,
                LandId = landId
            };
        }
       
        public static List<CraftingRecipeDTO> ConvertToContractDTOs(this IList<CraftingRecipe> craftingRecipes)
        {
            return craftingRecipes.Select(x => x.ConvertToCraftRecipeDTO()).ToList();
        }
    }

}
