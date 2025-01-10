using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using VisionsContracts.Items.Model;
using LBINT2D = System.Collections.Generic.List<System.Collections.Generic.List<System.Numerics.BigInteger>>;


namespace VisionsContracts.Land.Systems.CraftingSystem.Model
{
    public class CraftingRecipe
    {
        public CraftingRecipe(LBINT2D recipe, Item output, int xp = 1, int outputQuantity = 1)
        {
            Recipe = recipe;
            Output = output;
            OutputQuantity = outputQuantity;
            Xp = xp;
            InitItemsFromFixedRecipe(recipe);
        }

        public CraftingRecipe(List<BigInteger> inputs, List<BigInteger> inputsQuantities, Item output, int xp, int outputQuantity)
        {
            Output = output;
            Xp = xp;
            OutputQuantity = outputQuantity;
            Inputs = inputs;
            InputQuantities = inputsQuantities;
        }

        private void InitItemsFromFixedRecipe(LBINT2D recipe)
        {
            Inputs = new List<BigInteger>();
            InputQuantities = new List<BigInteger>();
            foreach (var row in recipe)
            {
                foreach (var item in row)
                {
                    if (item != 0)
                    {
                        if (!Inputs.Contains(item))
                        {
                            Inputs.Add(item);
                            InputQuantities.Add(1);
                        }
                        else
                        {
                            InputQuantities[Inputs.IndexOf(item)]++;
                        }
                    }
                }
            }
        }

        public LBINT2D Recipe { get; init; }
        public Item Output { get; init; }
        public int Xp { get; init; }

        public List<BigInteger> Inputs { get; private set; }
        public List<BigInteger> InputQuantities { get; private set; }

        public int OutputQuantity { get; init; }
        public bool Exists { get; set; } = true;

        public List<InventoryItem> GetAllRecipeRequiredInventoryItems()
        {
            var inventoryItems = new List<InventoryItem>();
            for(int i = 0; i < Inputs.Count; i++) { 
                inventoryItems.Add(new InventoryItem() { ItemId = Inputs[i], Count = InputQuantities[i] });
            }
            return inventoryItems;
        }

    }

}
