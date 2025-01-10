using Nethereum.Mud.TableRepository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using VisionsContracts.Items;
using VisionsContracts.Items.Exceptions;
using VisionsContracts.Items.Model;
using VisionsContracts.Land;

using VisionsContracts.Land.Exceptions;
using VisionsContracts.Land.Extensions;
using VisionsContracts.Land.Model;
using VisionsContracts.Land.Systems.CatalogueSystem;
using VisionsContracts.Land.Systems.CatalogueSystem.Model;
using VisionsContracts.Land.Systems.CraftingSystem;

using VisionsContracts.Land.Systems.CraftingSystem.Exceptions;
using VisionsContracts.Land.Systems.CraftingSystem.Model;
using VisionsContracts.Land.Systems.LandItemInteractionSystem;
using VisionsContracts.Land.Systems.LandItemInteractionSystem.ContractDefinition;
using VisionsContracts.Land.Systems.LandQuestsSystem.Model;
using VisionsContracts.Land.Systems.QuestsSystem.Model;
using VisionsContracts.Transformations;
using VisionsContracts.Transformations.Model;
using LandItem = VisionsContracts.Land.Model.LandItem;


namespace VisionsContracts.LandLocalState
{

    public class LandQuestsLocalState
    {
        public List<QuestGroup> ActiveQuestGroups { get; set; }
        public List<LandQuestGroup> ActiveLandQuestGroups { get; set; }
        public List<LandQuestGroup> CompletedActiveLandQuestGroups { get; set; }
        public InMemoryTableRepository InMemoryTableRepository { get; set; }
    }

    public class LandItemNextTransformation
    {
        public LandItem LandItem { get; set; }
        public Transformation Transformation { get; set; }
    }

    public class MergedExpansionResult
    {
        public bool ChangesFoundInChain { get; set; }
        public PlayerLocalState NewOrMergedPlayerLocalState { get; set; }
    }

    public interface IGameAction
    {
        string Action { get; }
        void PerformAction(PlayerLocalState playerLocalState);
    }

    public class RotateAction : IGameAction
    {
        public string Action => "Rotate";
        public int X { get; set; }
        public int Y { get; set; }
        public int Index { get; set; }

        public void PerformAction(PlayerLocalState playerLocalState)
        {
            playerLocalState.ToggleRotation(X, Y, Index);
        }
    }

    public class PlaceAction : IGameAction
    {
        public string Action => "Place";
        public int X { get; set; }
        public int Y { get; set; }
        public int InventoryItemId { get; set; }

        public void PerformAction(PlayerLocalState playerLocalState)
        {
            playerLocalState.PlaceItem(X, Y, InventoryItemId);
        }
    }

    public class RemoveAction : IGameAction
    {
        public string Action => "Remove";
        public int X { get; set; }
        public int Y { get; set; }

        public void PerformAction(PlayerLocalState playerLocalState)
        {
            playerLocalState.RemoveItem(X, Y);
        }
    }

    public class CraftAction : IGameAction
    {
        public string Action => "Craft";
        public CraftingRecipe Recipe { get; set; }

        public void PerformAction(PlayerLocalState playerLocalState)
        {
            playerLocalState.CraftItem(Recipe);
        }
    }


    public class LandTablesAndChairs
    {
        public BigInteger X { get; set; }
        public BigInteger Y { get; set; }
        public List<BigInteger> ChairsOfTables { get; set; } = new List<BigInteger>(3);
        public List<BigInteger> TablesOfChairs { get; set; } = new List<BigInteger>(3);
    }


    public class PlayerLocalState
    {
        public InMemoryTableRepository InMemoryTableRepository { get; set; } = new InMemoryTableRepository();
        public List<ISystemCallMulticallInput> UpdateLandOperations { get; set; } = new List<ISystemCallMulticallInput>();
        public List<InventoryItem> UpdatedInventoryItems { get; private set; } = new List<InventoryItem>();
        public string LandName { get; set; }

        public List<LandItem> UpdatedLand { get; set; }


        public List<LandItem> OriginalLand { get; private set; } // this is going to be removed don't use only for testing and merging
        /// <summary>
        /// Obsolete only used for testing
        /// </summary>
        public List<InventoryItem> OriginalInventoryItems { get; private set; } = new List<InventoryItem>(); // only for testing

        public LandQuestsLocalState LandQuestsLocalState { get; set; }
        public LandInfo PlayerLandInfo { get; private set; }

        public List<LandTablesAndChairs> LandTablesAndChairs { get; set; } = new List<LandTablesAndChairs>();

        public List<Item> Tools = DefaultItems.GetDefaultLandTools();
        public List<IGameAction> PostSaveGameActions { get; set; } = new List<IGameAction>();
        public bool IsSaving { get; set; } = false;

        public bool PrioritySavedRequired { get; set; } = false;
        public DateTime LastTimeSaved { get; set; } = DateTime.Now;
        public bool IsItRequiredToSave()
        {
            return PrioritySavedRequired || UpdateLandOperations.Count > 10
                || (UpdateLandOperations.Count > 0 && (DateTime.Now - LastTimeSaved).TotalSeconds > 60);
        }
        public IUnlockTimeoutValidator UnlockTimeoutValidator { get; set; } = new UnlockTimeoutValidator();
        public int LandId { get; set; }

        public PlayerLocalState(LandInfo playerLandInfo, List<InventoryItem> inventoryItems, List<LandItem> land)
        {
            Initialise(playerLandInfo, inventoryItems, land);
        }

        public void Initialise(LandInfo playerLandInfo, List<InventoryItem> inventoryItems, List<LandItem> land)
        {
            Reset();
            InitLand(land);
            InitInventory(inventoryItems);
            PlayerLandInfo = playerLandInfo;
            PrioritySavedRequired = false;
            LastTimeSaved = DateTime.Now;
            UpdateLandOperations ??= new List<ISystemCallMulticallInput>();
            this.ReCheckAllTablesAndChairs();
        }


        public void InitInventory(List<InventoryItem> inventoryItems)
        {
            OriginalInventoryItems = inventoryItems;
            var clonedArray = inventoryItems.Select(x => (InventoryItem)x.Clone());
            UpdatedInventoryItems = new List<InventoryItem>(clonedArray);
        }

        private void InitLand(List<LandItem> land)
        {
            OriginalLand = land;
            var clonedArray = land.Select(x => (LandItem)x.Clone());
            UpdatedLand = new List<LandItem>(clonedArray);
        }

        public void AddPostSaveActions(IGameAction action)
        {
            if (PostSaveGameActions.Contains(action))
                return;

            PostSaveGameActions.Add(action);
        }

        public void ProcessPostSaveActions()
        {
            bool error = false;
            var actionsToRemove = new List<IGameAction>();

            foreach (var action in PostSaveGameActions)
            {
                try
                {
                    action.PerformAction(this);
                }
                catch (Exception e)
                {
                  
                    error = true;
                }

                actionsToRemove.Add(action);
            }

            foreach (var action in actionsToRemove)
            {
                PostSaveGameActions.Remove(action);
            }

            if (error)
                ProcessPostSaveActions();
        }

        public List<Catalogue> GetCatalogues()
        {
            return DefaultCatalogue.GetAllCatalogues();
        }

        public List<CatalogueItem> GetCatalogueItemsByCatalogueId(BigInteger catalogueId)
        {
            return DefaultCatalogue.GetCatalogueItemsByCatalogueId(catalogueId);
        }

        public List<CatalogueItem> GetAllCatalogueItems()
        {
            return DefaultCatalogue.GetAllCatalogueItems();
        }

        public TotalPurchaseCostBalance CalculateTotalPurchaseCostAndBalance(List<CatalogueItemPurchase> catalogueItemPurchases)
        {
            return DefaultCatalogue.CalculateTotalPurchaseCostAndBalance(this.PlayerLandInfo.TokenBalance, catalogueItemPurchases);
        }

        public TotalPurchaseCostBalance CalculateTotalPurchaseCostAndBalance(BigInteger itemId, BigInteger quantity)
        {
            return DefaultCatalogue.CalculateTotalPurchaseCostAndBalance(this.PlayerLandInfo.TokenBalance, itemId, quantity);
        }

        //TODO with new state by merging the table repository
        public bool MergeAfterExpandingPreservingUpdatedChanges(LandInfo playerLandInfo, List<LandItem> expandedLand)
        {
            var newItems = new List<LandItem>();

            foreach (var expandedLandItem in expandedLand)
            {
                var currentItem = this.OriginalLand.FirstOrDefault(x => x.X == expandedLandItem.X && x.Y == expandedLandItem.Y && x.StackIndex == expandedLandItem.StackIndex);

                if (currentItem != null)
                {
                    if (currentItem.ItemId == -1)
                    {
                        if (expandedLandItem.ItemId != -1)
                        {
                            this.OriginalLand.Remove(currentItem);
                            this.UpdatedLand.Remove(this.UpdatedLand.FirstOrDefault(x => x.X == currentItem.X && x.Y == currentItem.Y && x.StackIndex == currentItem.StackIndex));
                            newItems.Add(expandedLandItem);
                        }

                    }
                    else
                    {
                        if (!currentItem.Equals(expandedLandItem))
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    newItems.Add(expandedLandItem);
                }
            }

            this.PlayerLandInfo = playerLandInfo;

            this.OriginalLand.AddRange(newItems);
            this.UpdatedLand.AddRange(newItems.Select(x => (LandItem)x.Clone()));
            return true;
        }

        public List<LandItemNextTransformation> GetAllNextTransformationsThatRequireUnlocking()
        {
            var nextTransformations = new List<LandItemNextTransformation>();
            var allTransformationsThatRequiredUnlocking = DefaultTransformations.GetAllTransformationsThatRequireUnlocking();
            foreach (var transformation in allTransformationsThatRequiredUnlocking)
            {
                foreach (var landItem in UpdatedLand)
                {
                    if (landItem.ItemId == transformation.Base)
                    {
                        nextTransformations.Add(new LandItemNextTransformation()
                        {
                            Transformation = transformation,
                            LandItem = landItem,
                        });
                    }
                }
            }

            var landItemsWithDynamicUnlock = this.UpdatedLand.Where(x => x.DynamicUnlockTime > 0);
            foreach (var landItem in landItemsWithDynamicUnlock)
            {
                var transformation = DefaultTransformations.FindTransformation((int)landItem.ItemId);
                if (transformation != null)
                {
                    nextTransformations.Add(new LandItemNextTransformation()
                    {
                        Transformation = transformation,
                        LandItem = landItem,
                    });
                }

            }
            return nextTransformations;
        }

        public List<LandItemNextTransformation> GetAllNextTransformationsThatRequireUnlockingWithEnoughInventory()
        {
            var nextTransformations = GetAllNextTransformationsThatRequireUnlocking();
            return nextTransformations.Where(x => ContainsInventoryItemInPlayerInventory((int)x.Transformation.Input)).ToList();

        }

        public IList<Transformation> GetAllTransformations()
        {
            return DefaultTransformations.GetAllTransformations();
        }

        public void CraftItem(int[][] recipe)
        {
            var craftingRecipe = DefaultCraftingRecipes.FindCraftingRecipe(recipe.ConvertToListBigInteger());
            if (craftingRecipe == null) throw new CraftRecipeInvalidRecipeException();
            CraftItem(craftingRecipe);
        }

        public bool CraftItemRecipeIsValidWithCurrentInventoryItems(CraftingRecipe craftingRecipe)
        {
            if (DefaultCraftingRecipes.IsValidRecipe(craftingRecipe.Recipe))
            {
                if (craftingRecipe.HasGotInventoryItemsToCraftRecipe(this.UpdatedInventoryItems))
                {
                    return true;
                }
            }
            return false;
        }

        public List<CraftingRecipe> GetCraftingRecipesThatCanBeCreatedWithCurrentInventoryItems()
        {
            var craftingRecipes = DefaultCraftingRecipes.GetAllCraftingRecipes();
            return craftingRecipes.Where(x => x.HasGotInventoryItemsToCraftRecipe(this.UpdatedInventoryItems)).ToList();
        }

        public bool CraftItemRecipeIsValidWithCurrentInventoryItems(int[][] recipe)
        {
            var craftingRecipe = DefaultCraftingRecipes.FindCraftingRecipe(recipe.ConvertToListBigInteger());
            if (craftingRecipe == null) return false;
            return CraftItemRecipeIsValidWithCurrentInventoryItems(craftingRecipe);
        }

        public void CraftItem(CraftingRecipe craftingRecipe)
        {
            if (DefaultCraftingRecipes.IsValidRecipe(craftingRecipe.Recipe))
            {
                if (craftingRecipe.HasGotInventoryItemsToCraftRecipe(this.UpdatedInventoryItems))
                {
                    var inventoryItemsRequired = craftingRecipe.ConvertToInventoryItemsRequired();
                    RemoveUpdatedInventoryItems(inventoryItemsRequired);

                    var inventoryOutput = UpdatedInventoryItems.FirstOrDefault(x => x.ItemId == craftingRecipe.Output.Id);
                    if (inventoryOutput != null)
                    {
                        inventoryOutput.Count = inventoryOutput.Count + 1;
                    }
                    else
                    {
                        UpdatedInventoryItems.Add(new InventoryItem() { ItemId = craftingRecipe.Output.Id, Count = 1 });
                    }

                    var craftRecipeFunction = craftingRecipe.ConvertToLandCraftRecipeFunction(LandId);

                    UpdateLandOperations.Add(new SystemCallMulticallInput<Land.Systems.CraftingSystem.ContractDefinition.CraftRecipeFunction, CraftingSystemServiceResource>(craftRecipeFunction, null));

                    var returnedItems = craftingRecipe.GetAllReturnedInventoryItems();
                    foreach (var returnedItem in returnedItems)
                    {
                        AddUpdatedInventoryItem(returnedItem.Id, 1);
                    }
                    if (IsSaving)
                    {
                        AddPostSaveActions(new CraftAction() { Recipe = craftingRecipe });
                    }
                }
                else
                {
                    throw new CraftRecipeNoEnoughItemsInInventoryException();
                }
            }
            else
            {
                throw new CraftRecipeNotFoundException();
            }


        }

        private void RemoveUpdatedInventoryItems(List<InventoryItem> inventoryItemsToRemove)
        {
            foreach (var inventoryItemToRemove in inventoryItemsToRemove)
            {
                var inventoryItem = UpdatedInventoryItems.FirstOrDefault(x => x.ItemId == inventoryItemToRemove.ItemId);
                if (inventoryItem != null && inventoryItem.Count >= inventoryItemToRemove.Count)
                {
                    inventoryItem.Count = inventoryItem.Count - inventoryItemToRemove.Count;
                }
                else
                {
                    throw new InventoryItemNotFoundException();
                }
            }
        }

        public void PlaceItem(int x, int y, int inventoryItemId, bool validateOnly = false)
        {
            CheckBoundaries(x, y);

            var landItem = new LandItem() { ItemId = 0, X = x, Y = y };
            var landItems = UpdatedLand.Where(item => item.X == x && item.Y == y).ToList();
            if (landItems.Count > 0)
            {
                landItem = landItems.OrderBy(x => x.StackIndex).Last();
            }
            else
            {
                UpdatedLand.Add(landItem);
            }

            if (landItem.ItemId == 0 && inventoryItemId == 0) return;

            var transformation = DefaultTransformations.FindTransformation((int)landItem.ItemId, inventoryItemId);
            if (landItem.ItemId == 0 && transformation == null)
            {
                if (DefaultItems.GetAllNonPlaceableItems().Any(x => x.Id == inventoryItemId))
                {
                    throw new LandPlaceItemOnEmptyLandNonPlaceableException();
                }
                PlaceItemFromInventory(inventoryItemId, landItem, validateOnly);
            }
            else if (transformation != null)
            {
                PlaceItemTransformation(landItem, inventoryItemId, transformation, validateOnly);
            }
            else if (DefaultStackings.IsStackable(landItem.ItemId, inventoryItemId))
            {
                var newLandItem = new LandItem()
                {
                    X = landItem.X,
                    Y = landItem.Y,
                    StackIndex = landItem.StackIndex + 1,
                    ItemId = inventoryItemId,
                    PlacementTime = -1
                };


                PlaceItemFromInventory(inventoryItemId, newLandItem, validateOnly);

                if (!validateOnly)
                {
                    UpdatedLand.Add(newLandItem);
                }
            }
            else
            {
                throw new LandPlaceItemInvalidItemException();
            }

            if (!validateOnly && IsSaving)
            {
                AddPostSaveActions(new PlaceAction() { InventoryItemId = inventoryItemId, X = x, Y = y });
            }
        }

        private void CheckBoundaries(int x, int y)
        {
            if (x < 0 || y < 0) throw new LandOutOfBoundsException();

            if (x >= this.PlayerLandInfo.LimitX ||
               y >= this.PlayerLandInfo.LimitY ||
               x >= this.PlayerLandInfo.YBound[y]
            ) throw new LandOutOfBoundsException();
        }

        private void PlaceToolItemTransformation(int inventoryItemId, LandItem landItem, Transformation transformation, bool validate)
        {
            if (!IsToolItem(inventoryItemId)) throw new LandPlaceItemToolInvalidToolException(inventoryItemId);
            if (!validate)
            {
                AddUpdatedInventoryItem(transformation.Yield, transformation.YieldQuantity);
                AddNextInputItemToInventory(transformation.InputNext);
                SetUpdatedLandItemItemId(landItem, transformation.Next);
                var message = new PlaceItemFunction()
                {
                    X = landItem.X,
                    Y = landItem.Y,
                    LandId = LandId,
                    ItemId = inventoryItemId
                };

                UpdateLandOperations.Add(new SystemCallMulticallInput<PlaceItemFunction, LandItemInteractionSystemServiceResource>(message, null));
            }
        }

        private bool IsToolItem(int inventoryItemId)
        {
            return Tools.Any(x => x.Id == inventoryItemId) || inventoryItemId == 0;
        }

        private void PlaceItemFromInventory(int inventoryItemId, LandItem landItem, bool validateOnly, BigInteger? nextItem = null, BigInteger? nextInputItem = null)
        {
            bool isItemInPlayerInventory = ContainsInventoryItemInPlayerInventory(inventoryItemId);
            if (!isItemInPlayerInventory) throw new LandPlaceItemFromInventoryNotFoundException();

            if (!validateOnly)
            {

                var message = new PlaceItemFunction()
                {
                    X = landItem.X,
                    Y = landItem.Y,
                    LandId = LandId,
                    ItemId = inventoryItemId
                };

                this.CheckPlaceTableOrChair((uint)inventoryItemId, (uint)landItem.X, (uint)landItem.Y);

                UpdateLandOperations.Add(new SystemCallMulticallInput<PlaceItemFunction, LandItemInteractionSystemServiceResource>(message, null));

                var inventoryItem = UpdatedInventoryItems.FirstOrDefault(x => x.ItemId == inventoryItemId);
                if (inventoryItem != null)
                {
                    inventoryItem.Count = inventoryItem.Count - 1;
                }

                AddNextInputItemToInventory(nextInputItem);
                if (nextItem == null) nextItem = inventoryItemId;
                SetUpdatedLandItemItemId(landItem, nextItem);
            }
        }

        private void AddNextInputItemToInventory(BigInteger? nextInputItem)
        {
            if (nextInputItem != null && nextInputItem != 0)
            {
                var nextInputInventoryItem = UpdatedInventoryItems.FirstOrDefault(x => x.ItemId == nextInputItem);
                if (nextInputInventoryItem != null)
                {
                    nextInputInventoryItem.Count = nextInputInventoryItem.Count + 1;
                }
                else
                {
                    UpdatedInventoryItems.Add(new InventoryItem() { Count = 1, ItemId = nextInputItem.Value });
                }
            }
        }

        private static void SetUpdatedLandItemItemId(LandItem landItem, BigInteger? nextItem)
        {
            landItem.ItemId = nextItem.Value;
            landItem.PlacementTime = -1;
        }

        private void AddUpdatedInventoryItem(BigInteger itemId, BigInteger count)
        {
            var inventoryItem = UpdatedInventoryItems.FirstOrDefault(x => x.ItemId == itemId);
            if (inventoryItem != null)
            {
                inventoryItem.Count = inventoryItem.Count + count;
            }
            else
            {
                UpdatedInventoryItems.Add(new InventoryItem() { ItemId = itemId, Count = count });
            }
        }

        public bool IsAnyItemCookingInLand()
        {
            foreach (var landItem in UpdatedLand)
            {
                if (DefaultItems.IsCookingState(landItem.ItemId)) return true;
            }
            return false;
        }

        public bool CanItemBeRemovedFromLand(int x, int y)
        {
            var landItem = UpdatedLand.OrderByDescending(x => x.StackIndex).FirstOrDefault(item => item.X == x && item.Y == y);
            if (landItem.ItemId == 0) return false;

            if (DefaultItems.IsChair(landItem.ItemId) || DefaultItems.IsTable(landItem.ItemId))
            {
                if (IsAnyItemCookingInLand())
                    throw new LandRemoveTableOrChairWhileCookingException();
            }

            if (DefaultItems.IsFurnaceOrWaterWell(landItem))
            {
                throw new LandRemoveItemNonRemovableException();
            }

            if (DefaultItems.GetAllNonRemovableItems().Any(x => x.Id == landItem.ItemId))
            {
                throw new LandRemoveUsingCookingDeviceException();
            }

            return true;

        }

        public void RemoveItem(int x, int y, bool validateOnly = false)
        {
            CheckBoundaries(x, y);
            var landStackedItems = UpdatedLand.Where(item => item.X == x && item.Y == y).OrderByDescending(x => x.StackIndex);
            var landItem = landStackedItems.FirstOrDefault();

            try
            {
                if (CanItemBeRemovedFromLand(x, y))
                {
                    if (!validateOnly)
                    {
                        //TODO CHECK non inventory item / removable etc / perlin / tables
                        AddUpdatedInventoryItem(landItem.ItemId, 1);

                        if (landStackedItems.Count() > 1)
                        {
                            UpdatedLand.Remove(landItem);
                        }
                        else
                        {
                            landItem.ItemId = 0;
                            landItem.PlacementTime = -1;
                        }

                        var message = new RemoveItemFunction()
                        {
                            LandId = LandId,
                            X = landItem.X,
                            Y = landItem.Y
                        };

                        UpdateLandOperations.Add(new SystemCallMulticallInput<RemoveItemFunction, LandItemInteractionSystemServiceResource>(message, null));
                        this.CheckRemoveTableOrChair((uint)landItem.ItemId, (uint)landItem.X, (uint)landItem.Y);
                        if (IsSaving && !validateOnly)
                        {
                            AddPostSaveActions(new RemoveAction() { X = x, Y = y });
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void PlaceItemTransformation(LandItem landItem, int inventoryItemId, Transformation transformation, bool validateOnly)
        {
            if (transformation == null) throw new ArgumentNullException(nameof(transformation));
            if (landItem.PlacementTime < 0) // Not updated
            {
                if (transformation.UnlockTime > 0)
                {
                    throw new LandPlaceItemNeedsSavingForTransformationException(transformation);
                }
            }

            if (transformation.UnlockTime > 0)
            {
                //needs unlocking
                if (landItem.PlacementTime > 0 && UnlockTimeoutValidator.HasLockedDurationFinished(landItem, transformation))
                {
                    if (!validateOnly)
                    {

                        if (IsToolItem(inventoryItemId))
                        {
                            PlaceToolItemTransformation(inventoryItemId, landItem, transformation, validateOnly);
                        }
                        else
                        {
                            PlaceItemFromInventory(inventoryItemId, landItem, validateOnly, transformation.Next, transformation.InputNext);
                        }

                        if (UnlockTimeoutValidator.HasLockedDurationFinished(landItem, transformation) && transformation.Timeout > 0)
                        {
                            //Only here to prevent players from loose plants from not saving in time
                            //But that is causing an error with the new auto-saving, when watering multiple plants
                            //PrioritySavedRequired = true;
                        }

                        if (transformation.IsRecipe)
                        {
                            PrioritySavedRequired = true;
                        }

                        //var message = new PlaceItemFunction()
                        //{
                        //    LandId = LandId,
                        //    X = landItem.X,
                        //    Y = landItem.Y,
                        //    ItemId = inventoryItemId
                        //};

                        //UpdateLandOperations.Add(new SystemCallMulticallInput<PlaceItemFunction, LandItemInteractionSystemServiceResource>(message, null));

                        landItem.PlacementTime = -1;

                    }
                }
                else
                {
                    throw new LandPlaceItemUnlockTimeHasNotElapsed(transformation, landItem);
                }
            }
            else
            {

                if (IsToolItem(inventoryItemId))
                {
                    PlaceToolItemTransformation(inventoryItemId, landItem, transformation, validateOnly);
                }
                else
                {

                    if (transformation.IsRecipe)
                    {
                        //Shouldn't be active chairs instead of active tables?
                        if ((this.PlayerLandInfo.ActiveTables == 0))
                        {
                            throw new LandPlaceItemRecipeNoActiveTableException();
                        }
                    }

                    PlaceItemFromInventory(inventoryItemId, landItem, validateOnly, transformation.Next, transformation.InputNext);
                    if (!validateOnly)
                    {
                        if (transformation.IsRecipe)
                        {
                            PrioritySavedRequired = true;
                        }
                    }
                }
            }
        }

        public bool CanItemBeRotated(int x, int y, int index)
        {
            var landItem = UpdatedLand.FirstOrDefault(item => item.X == x && item.Y == y && item.StackIndex == index);
            if (landItem != null)
            {
                return DefaultItems.IsItemRotatable(landItem.ItemId);
            }
            throw new LandRotateItemNotFoundAtPositionException();
        }

        public bool IsItemRotated(int x, int y, int index)
        {
            var landItem = UpdatedLand.FirstOrDefault(item => item.X == x && item.Y == y && item.StackIndex == index);
            if (landItem != null)
            {
                return landItem.IsRotated;
            }
            throw new LandRotateItemNotFoundAtPositionException();
        }

        public void ToggleRotation(int x, int y, int index, bool validateOnly = false)
        {
            CheckBoundaries(x, y);

            var landItem = UpdatedLand.FirstOrDefault(item => item.X == x && item.Y == y && item.StackIndex == index);
            if (landItem != null)
            {
                if (DefaultItems.IsItemRotatable(landItem.ItemId))
                {
                    if (!validateOnly)
                    {
                        landItem.IsRotated = !landItem.IsRotated;
                        var message = new ToggleRotationFunction()
                        {
                            LandId = LandId,
                            X = landItem.X,
                            Y = landItem.Y,
                            Z = index
                        };

                        UpdateLandOperations.Add(new SystemCallMulticallInput<ToggleRotationFunction, LandItemInteractionSystemServiceResource>(message, null));
                        if (IsSaving && !validateOnly)
                        {
                            AddPostSaveActions(new RotateAction() { X = x, Y = y, Index = x });
                        }
                    }
                    return;

                }
                else
                {
                    throw new LandRotateItemNonRotatableException();
                }

            }
            else
            {
                throw new LandRotateItemNotFoundAtPositionException();
            }

        }

        public bool ContainsInventoryItemInPlayerInventory(int inventoryItemId)
        {
            return inventoryItemId == 0
                               || Tools.Any(x => x.Id == inventoryItemId)
                               || UpdatedInventoryItems.Any(x => x.ItemId == inventoryItemId && x.Count > 0);
        }

        public void PlaceItem(LandItem landItem, int inventoryItemId, bool validate = false)
        {
            var transformation = DefaultTransformations.FindTransformation((int)landItem.ItemId, inventoryItemId);
            if (transformation == null) throw new LandPlaceItemTransformationNotFoundException();
            PlaceItemTransformation(landItem, inventoryItemId, transformation, validate);
        }

        private void Reset()
        {
            this.UpdateLandOperations.Clear();
            this.UpdatedInventoryItems = null;
            //this.OriginalInventoryItems = null;
            this.OriginalLand = null;
            this.UpdatedLand = null;
        }
    }
}
