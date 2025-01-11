using Nethereum.Web3;
using VisionsContracts;
using VisionsContracts.Items;
using VisionsContracts.Land.Systems.CraftingSystem;
using VisionsContracts.LandLocalState;
using VisionsContracts.Land.Systems.CraftingSystem.Model;
using VisionsContracts.Items.Model;

namespace CafeCosmos.AutomationExample
{
   
        //This requires that you have already crafted and placed the coffee machine and blender on your land
        public class ContinuousHarvestingCollectingAndCookingSimpleAppliancesStrategy
        {

            public async Task ExecuteAsync(Web3 web3, VisionsContractAddresses contractAddresses)
            {
                var playerService = new PlayerService(web3, contractAddresses, web3.TransactionManager.Account.Address);
                await playerService.EnsureInitialisedSelectedLandIdToFirstLandIfNotSetAsync();
                var playerLocalState = await playerService.GetNewPlayerLocalStateAsync();

                CollectAllItemsReadyToCollect(playerLocalState);

                if (playerLocalState.UpdateLandOperations.Count > 0)
                {
                    await playerService.SavePlayerStateAndWaitForReceiptAsync(playerLocalState);
                }
                CraftItemAndCookIfPossible(playerLocalState, DefaultCraftingRecipes.CoffeeMachineRecipes.COFFEE, DefaultItems.Cooking.COFFEE_MACHINE);
                CraftItemAndCookIfPossible(playerLocalState, DefaultCraftingRecipes.BlenderRecipes.SMOOTHIE, DefaultItems.Cooking.BLENDER);
                CraftItemAndCookIfPossible(playerLocalState, DefaultCraftingRecipes.BlenderRecipes.BANANA_MILKSHAKE, DefaultItems.Cooking.BLENDER);

                if (playerLocalState.UpdateLandOperations.Count > 0)
                {
                    await playerService.SavePlayerStateAndWaitForReceiptAsync(playerLocalState);
                }

        }


            private static void CraftItemAndCookIfPossible(PlayerLocalState playerLocalState, CraftingRecipe recipe, Item appliance)
            {
                if (playerLocalState.CraftItemRecipeIsValidWithCurrentInventoryItems(recipe) && !playerLocalState.ContainsInventoryItemInPlayerInventory(recipe.Output.Id))
                {
                    playerLocalState.CraftItem(recipe);
                    Console.WriteLine($"Crafting {DefaultItems.FindItemById(recipe.Output.Id).Name}");
                }
                var applianceLandItem = playerLocalState.UpdatedLand.FirstOrDefault(x => x.ItemId == appliance.Id);
                if (applianceLandItem != null)
                {
                    try
                    {
                        playerLocalState.PlaceItem((int)applianceLandItem.X, (int)applianceLandItem.Y, recipe.Output.Id, false);
                        Console.WriteLine($"Cooking {DefaultItems.FindItemById(recipe.Output.Id).Name}");
                    }
                    catch
                    {
                    }
                }
            }

            private static void CollectAllItemsReadyToCollect(PlayerLocalState playerLocalState)
            {
                var updatedLandItems = playerLocalState.UpdatedLand;


                var landItemsTopOfStack = playerLocalState.UpdatedLand.Where(x => !playerLocalState.UpdatedLand.Any(y => x.Y == y.Y && x.X == y.X && y.StackIndex > x.StackIndex));

                // where it does not exist any item at x any where the stack index is bigger than x.stackindex
                var transformationsThatRequireUnlocking = playerLocalState.GetAllNextTransformationsThatRequireUnlocking();


                foreach (var item in landItemsTopOfStack)
                {
                    var transformation = transformationsThatRequireUnlocking.FirstOrDefault(x => x.LandItem == item);
                    if (transformation != null)
                    {
                        try
                        {
                            playerLocalState.PlaceItem((int)item.X, (int)item.Y, (int)transformation.Transformation.Input, false);
                            Console.WriteLine($"Unlocking {DefaultItems.FindItemById(transformation.LandItem.ItemId).Name} with {DefaultItems.FindItemById(transformation.Transformation.Input)?.Name}");

                        }
                        catch { }
                    }
                }
            }


        }



    
}
