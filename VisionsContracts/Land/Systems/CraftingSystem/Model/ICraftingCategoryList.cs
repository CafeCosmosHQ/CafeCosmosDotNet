using System.Collections.Generic;
using VisionsContracts.Land.Systems.CraftingSystem.ContractDefinition;
using VisionsContracts.Land.Systems.CraftingSystem.Model;


namespace VisionsContracts.Land.Systems.CraftingSystem.Model
{
    public interface ICraftingCategoryList
    {
        List<CraftingRecipe> GetAllCraftingRecipes();
    }

}
