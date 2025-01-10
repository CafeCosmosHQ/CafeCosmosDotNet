using Nethereum.RPC.Eth.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using VisionsContracts.Land.Systems.CraftingSystem.Model;

namespace VisionsContracts.Land.Systems.CraftingSystem
{
    public partial class CraftingSystemService
    {
        public Task<string> SetDefaultCraftingRecipesRequestAsync()
        {
            var recipes = DefaultCraftingRecipes.GetAllCraftingRecipes();
            return CreateRecipesRequestAsync(recipes.ConvertToContractDTOs());
        }

        public Task<TransactionReceipt> SetDefaultCraftingRecipesRequestAndWaitForReceiptAsync()
        {
            var recipes = DefaultCraftingRecipes.GetAllCraftingRecipes();
            return CreateRecipesRequestAndWaitForReceiptAsync(recipes.ConvertToContractDTOs());

        }

        public Task<TransactionReceipt> CreateRecipeAndWaitForReceiptAsync(CraftingRecipe craftingRecipe)
        {
            return CreateRecipeRequestAndWaitForReceiptAsync(craftingRecipe.ConvertToCraftRecipeDTO());
        }

        public async Task<TransactionReceipt> UpdateRecipeAndWaitForReceiptAsync(CraftingRecipe craftingRecipe)
        {
            await RemoveRecipeRequestAndWaitForReceiptAsync(craftingRecipe.ConvertToCraftRecipeDTO()); 
            // we use the output as the id so it we can upsert it now also we need to wait for the transaction as the state is not updated (some how)..
            return await CreateRecipeAndWaitForReceiptAsync(craftingRecipe);
        }
      
        public async Task InitialiseCraftingServiceRequestAsync()
        {
            await SetDefaultCraftingRecipesRequestAsync();
        }
    }
}
