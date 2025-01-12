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

        public Item GetHandItem()
        {
            return new("Hand", 0, ItemCategory.Tools, false, false, false, false, false);
        }

        bool smoothie = false;
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
            if (smoothie)
            {
                CraftItemAndCookIfPossible(playerLocalState, DefaultCraftingRecipes.BlenderRecipes.SMOOTHIE, DefaultItems.Cooking.BLENDER);
                smoothie = false;
            }
            else
            {
                CraftItemAndCookIfPossible(playerLocalState, DefaultCraftingRecipes.BlenderRecipes.BANANA_MILKSHAKE, DefaultItems.Cooking.BLENDER);
                smoothie = true;
            }
            CraftItemAndCookIfPossible(playerLocalState, DefaultCraftingRecipes.BlenderRecipes.BANANA_MILKSHAKE, DefaultItems.Cooking.BLENDER);
            CraftItemAndCookIfPossible(playerLocalState, DefaultCraftingRecipes.BlenderRecipes.SMOOTHIE, DefaultItems.Cooking.BLENDER);
            CraftItemAndCookIfPossible(playerLocalState, DefaultCraftingRecipes.ChoppingBoardRecipes.SALAD, DefaultItems.Cooking.CUTTING_BOARD);

            PlaceItemOnAnother(playerLocalState, DefaultItems.Ingredients.FLOUR, DefaultItems.Machines.MIXER);
            PlaceItemOnAnother(playerLocalState, DefaultItems.Ingredients.WHEAT, DefaultItems.Machines.MIXER);

            for (int i = 0; i < 10; i++)
            {
                PlaceItemOnAnother(playerLocalState, DefaultItems.Wheat.WHEAT_SEED, DefaultItems.Gardening.TILLED_SOIL);
                PlaceItemOnAnother(playerLocalState, DefaultItems.Lettuce.LETTUCE_SEED, DefaultItems.Gardening.TILLED_SOIL);
                PlaceItemOnAnother(playerLocalState, DefaultItems.Tomato.TOMATO_SEED, DefaultItems.Gardening.TILLED_SOIL);
                PlaceItemOnAnother(playerLocalState, DefaultItems.Tools.WATERING_CAN, DefaultItems.Wheat.WHEAT_SEED);
                PlaceItemOnAnother(playerLocalState, DefaultItems.Tools.WATERING_CAN, DefaultItems.Lettuce.LETTUCE_SEED);
                PlaceItemOnAnother(playerLocalState, DefaultItems.Tools.WATERING_CAN, DefaultItems.Tomato.TOMATO_SEED);
            }


            //PlaceItemOnAnother(playerLocalState, DefaultItems.Buckets.BUCKET_EMPTY, DefaultItems.Machines.WATER_WELL);
            PlaceItemOnAnother(playerLocalState, GetHandItem(), DefaultItems.Machines.WATER_WELL_GIVING_WATER);

            CraftItemAndCookIfPossible(playerLocalState, DefaultCraftingRecipes.OvenRecipes.CROISSANT, DefaultItems.Cooking.BASIC_OVEN);

            CraftItemAndCookIfPossible(playerLocalState, DefaultCraftingRecipes.OvenRecipes.MAC_AND_CHEESE, DefaultItems.Cooking.BASIC_OVEN);

            PlaceItemOnAnother(playerLocalState, DefaultItems.Ingredients.OLIVES, DefaultItems.Machines.OLIVE_PRESS);







            if (playerLocalState.UpdateLandOperations.Count > 0)
            {
                await playerService.SavePlayerStateAndWaitForReceiptAsync(playerLocalState);
            }

        }

        private static void PlaceItemOnAnother(PlayerLocalState playerLocalState, Item item, Item appliance)
        {
            var applianceLandItem = playerLocalState.UpdatedLand.FirstOrDefault(x => x.ItemId == appliance.Id);
            if (applianceLandItem != null)
            {
                try
                {
                    playerLocalState.PlaceItem((int)applianceLandItem.X, (int)applianceLandItem.Y, item.Id, false);
                    Console.WriteLine($"Placing item {item.Name} on another item {appliance.Name}");
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex.Message);
                }
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
                        // if (transformation.Transformation.Base != DefaultItems.Animals.COW.Id) {
                        playerLocalState.PlaceItem((int)item.X, (int)item.Y, (int)transformation.Transformation.Input, false);
                        var inputname = "hand";
                        var input = DefaultItems.FindItemById(transformation.Transformation.Input);
                        if (input != null) inputname = input.Name;


                        Console.WriteLine($"Unlocking {DefaultItems.FindItemById(transformation.LandItem.ItemId).Name} with {inputname}");
                        //}

                    }
                    catch { }
                }
            }

            var allTransformations = playerLocalState.GetAllTransformations();


            foreach (var item in landItemsTopOfStack)
            {

                try
                {
                    var transformation = allTransformations.FirstOrDefault(x => x.Base == item.ItemId);
                    if (transformation != null && transformation.Input == 0)
                    {
                        playerLocalState.PlaceItem((int)item.X, (int)item.Y, (int)transformation.Input, false);

                        Console.WriteLine($"Collecting {DefaultItems.FindItemById(item.ItemId).Name}");
                    }
                }
                catch { }

            }
        }


    }




}
