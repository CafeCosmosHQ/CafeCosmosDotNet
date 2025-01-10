using System.Collections.Generic;
using VisionsContracts.CraftingSystem.Model;
using VisionsContracts.Land.Systems.CraftingSystem.ContractDefinition;


namespace VisionsContracts.Land.Systems.CraftingSystem.Model
{
    public abstract class CraftingCategoryList<T> : ICraftingCategoryList where T : CraftingCategoryList<T>, new()
    {
        public static T Instance { get; private set; } = new T();

        public abstract List<CraftingRecipe> GetAllCraftingRecipes();
    }

}
