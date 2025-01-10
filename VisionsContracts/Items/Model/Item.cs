
using System;
using System.Collections.Generic;
using VisionsContracts.Land.Systems.CraftingSystem.Model;
using VisionsContracts.Redistributor.Model;
using VisionsContracts.Transformations.Model;

namespace VisionsContracts.Items.Model
{
    public class ItemCreationNotSpecified : ItemCreation
    {
        public ItemCreationNotSpecified(Item item) : base(item, null, null, false)
        {
            NotSpecified = true;    
        }

    }

    public class ItemCreation
    {
        public Item Item { get; protected set; }
        public List<Transformation> Transformations { get; protected set; }   = new List<Transformation>();
        public List<CraftingRecipe> CraftingRecipesOutput { get; protected set; } = new List<CraftingRecipe> { };

        public bool LandCreation { get; protected set; } = false;

        public bool NotSpecified { get; protected set; } = false;

        public ItemCreation(Item item, Transformation[] transformations, CraftingRecipe[] craftingRecipes, bool landCreation = false)
        {
            Item = item;
            LandCreation = landCreation;
            
            if(Transformations != null)
            {
                Transformations = new List<Transformation>(transformations);
            }

            if(craftingRecipes != null)
            {
                CraftingRecipesOutput = new List<CraftingRecipe>(craftingRecipes);
            }
            
        }

        public ItemCreation(Item item, bool landCreation):this(item, null, null, landCreation)
        {
         

        }

        public ItemCreation(Item item, params Transformation[] transformations) :this(item, transformations, null)
        {
         
        }

        public ItemCreation(Item item, bool landCreation, params Transformation[] transformations) : this(item, transformations, null, landCreation)
        {

        }

        public ItemCreation(Item item, params CraftingRecipe[] craftingRecipes) : this(item, null, craftingRecipes)
        {

        }

        public void ValidateTransformationsAndCrafting()
        {

            if (Transformations != null)
            {
                foreach (var transformation in Transformations)
                {

                    if (transformation.Yield != this.Item.Id) throw new Exception($"Invalid yield for Transformation, Item:{this.Item.Name}");
                }
            }

            if (CraftingRecipesOutput != null)
            {
                foreach (var craftingRecipe in CraftingRecipesOutput)
                {

                    if (craftingRecipe.Output != this.Item) throw new Exception($"Invalid output for Crafting Recipe, Item:{this.Item.Name}");
                }

            }
        }
    }

    public class Item
    {

        public Item(string name,
                    int id,
                    ItemCategory category,
                    bool isTool,
                    bool isPlaceable,
                    bool isRotatable,
                    bool isInventory,
                    bool isRemovable,
                    bool isCookingState = false,
                    SubSection subSection = null
            )
        {
                 this.Name = name;
                this.Id = id;
                this.Category = category;
                IsTool = isTool;
                IsPlaceable = isPlaceable;
                IsRotatable = isRotatable;
                IsInventory = isInventory;
                IsRemovable = isRemovable;
                IsCookingState = isCookingState;
                SubSection = subSection;
        }

        public string Name { get; }
        public int Id { get; }
        public ItemCategory Category { get; }
        public bool IsTool { get; }
        public bool IsPlaceable { get; }
        public bool IsRotatable { get; }
        public bool IsInventory { get; }
        public bool IsRemovable { get; }
        public bool IsCookingState { get; }
        public SubSection SubSection { get; }
    }
    
}


namespace System.Runtime.CompilerServices
{
    internal static class IsExternalInit { }
}
