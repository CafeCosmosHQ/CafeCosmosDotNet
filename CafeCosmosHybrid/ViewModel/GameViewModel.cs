
using Nethereum.UI;
using VisionsContracts.Land;
using VisionsContracts.LandLocalState;
using VisionsContracts;
using static VisionsContracts.TestScenarios.PlayerLocalStateTestScenarioFactory;
using VisionsContracts.TestScenarios;
using CafeCosmosBlazor.Services;
using VisionsContracts.Items.Model;
using VisionsContracts.Items;
using Nethereum.Util;
using System.Numerics;
using Newtonsoft.Json;
using VisionsContracts.Land.Systems.CraftingSystem.Model;
using VisionsContracts.Land.Systems.CraftingSystem;
using HttpUtil;
using VisionsContracts.Faucet;
using Nethereum.ABI.FunctionEncoding;
using Nethereum.Contracts;
using VisionsContracts.Land.Systems.LandItemInteractionSystem;
using VisionsContracts.Land.Model;
using VisionsContracts.Land.Systems.CatalogueSystem.Model;
using Nethereum.RPC.Eth.DTOs;
using VisionsContracts.Land.Systems.QuestsSystem.Model;
using VisionsContracts.Land.Systems.LandQuestsSystem.Model;
using VisionsContracts.PlayerBalancePurchasing;
using System.Text;
using VisionsContracts.LandNFTs.ContractDefinition;
using VisionsContracts.Land.Systems.MarketplaceSystem.Model;
using static MudBlazor.CategoryTypes;
using Item = VisionsContracts.Items.Model.Item;



namespace CafeCosmosBlazor.ViewModel
{
    public enum ItemEditingMode
    {
        PlaceItem,
        RemoveItem,
        RotateItem,
        ZoomToItem
    }
    public class GameViewModel
    {
        private const string FaucetUrl = "https://cafecosmosfaucet.app.nethereum.dev";
        //private const string FaucetUrl = "https://localhost:7285";
        
        PlayerService playerService;
        public PlayerLocalState PlayerLocalState { get; set; }
        public PlayerInfo PlayerInfo { get; set; } = new PlayerInfo();

        public BigInteger SelectedChainId { get; set; }

        public Item SelectedInventoryItem { get; set; } = DefaultItems.Tools.HAND;
        public ItemEditingMode ItemEditingMode { get; set; } = ItemEditingMode.PlaceItem;

        public SelectedEthereumHostProviderService SelectedHostProviderService { get; private set; }
        public IVisionsContractAddressesService VisionsContractAddressesService { get; }
        public IEthereumHostProvider SelectedHost { get; private set; }
        public bool NewError { get; set; }

        public string ErrorMessage { get; set; }

        public bool SavingPlayerLand = false;
        public bool LoadingPlayerLand = true;
        public int? SelectedLandId { get; set; } = 1;

        public event Func<Task> GameChanged;
        public event Action<BigInteger, BigInteger> ZoomToItemSelected;

        public List<LandMetadata> LandNames { get; set; }
        public List<MarketPlaceListing> MarketPlaceListings { get; set; }


        public GameViewModel(SelectedEthereumHostProviderService selectedHostProviderService, IVisionsContractAddressesService visionsContractAddressesService)
        {
            SelectedHostProviderService = selectedHostProviderService;
            VisionsContractAddressesService = visionsContractAddressesService;
            //metamask is set as the default so we are not changing the Selected Host 
            
            SelectedHost = selectedHostProviderService.SelectedHost;
            SelectedHost.SelectedAccountChanged += HostProvider_SelectedAccountChanged;
            SelectedHost.NetworkChanged += HostProvider_NetworkChanged;
            SelectedHost.EnabledChanged += HostProviderOnEnabledChanged;
            SelectedChainId = visionsContractAddressesService.GetChainId(); // ok until proven otherwise

        }

        public async Task ChangeToRequiredChain()
        {
            var requiredChainId = VisionsContractAddressesService.GetChainId();
            var addParameter = ChainsService.GetAddEthereumChainParameter((long)requiredChainId);
            var web3 = await SelectedHost.GetWeb3Async();
            await web3.Eth.HostWallet.AddEthereumChain.SendRequestAsync(addParameter);
        }

        private async Task HostProviderOnEnabledChanged(bool enabled)
        {
            if (enabled)
            {
                Console.WriteLine("Calling Validate from HostProviderOnEnabledChanged");
                await ValidateCurrentChainAndLoadSelectedAccount();
            }
            else
            {
                PlayerInfo = new PlayerInfo();
                PlayerLocalState = null;
            }

        }

        public async Task ValidateCurrentChainAndLoadSelectedAccount()
        {
            if (!LoadingPlayerLand)
            {
                try
                {
                    LoadingPlayerLand = true;
                    await NotifyGameStateChange();
                    await GetSelectedChainId();
                    if (SelectedChainId == VisionsContractAddressesService.GetChainId())
                    {
                        await LoadPlayerInfoAndLandAsync();
                        if (!PlayerInfo.HasLand())
                        {
                            ResetGame();
                        }
                    }
                    else
                    {
                        await LoadPlayerInfoAsync();
                        ResetGame();
                    }
                }
            finally
            {
                LoadingPlayerLand = false;
                NotifyGameStateChange();
            }
        }
        }

        public void ResetGame()
        {
            PlayerLocalState = null;
            SelectedInventoryItem = DefaultItems.Tools.HAND;
            ItemEditingMode = ItemEditingMode.PlaceItem;
            NewError = false;
            ErrorMessage = null;
            SavingPlayerLand = false;
            LoadingPlayerLand = false;
        }

        public string GetLandAsJson()
        {
            return JsonConvert.SerializeObject(PlayerLocalState.UpdatedLand, Formatting.Indented)

                + GetLandAsInitialLandItem();
        }

      

        public string GetLandAsInitialLandItem()
        {
            var stringBuilder = new StringBuilder();
            foreach(var item in PlayerLocalState.UpdatedLand)
            {
                if(item.ItemId != 0)
                {
                    stringBuilder.AppendLine($"new InitialLandItem {{ ItemId = {DefaultItems.GetReflectionFieldString(DefaultItems.FindItemById(item.ItemId))}.Id, X = {item.X}, Y = {item.Y}, Z = {item.StackIndex}, Rotated = {item.IsRotated.ToString().ToLower()}}},");
                }
            }
            return stringBuilder.ToString();
        }

        public string GetInventoryAsJson()
        {
            return JsonConvert.SerializeObject(PlayerLocalState.UpdatedInventoryItems, Formatting.Indented);
        }

        public string GetPlayerLandInfoAsJson()
        {
            return JsonConvert.SerializeObject(PlayerLocalState.PlayerLandInfo, Formatting.Indented);
        }

        public string GetLandId()
        {
            return playerService.SelectedLandId.ToString();
        }

       
        private async Task GetSelectedChainId()
        {
            var web3 = await SelectedHost.GetWeb3Async();
            var chainId = await web3.Eth.ChainId.SendRequestAsync();
            SelectedChainId = chainId.Value;
           
        }

        public void ValidateSelectedItemAfterAction()
        {
            try
            {
                if (SelectedInventoryItem != null && !IsSelectedInventoryItemMenuTool() && !PlayerLocalState.ContainsInventoryItemInPlayerInventory(SelectedInventoryItem.Id))
                {
                    SelectedInventoryItem = DefaultItems.Tools.HAND;
                }
            }
            catch
            {
                SelectedInventoryItem = DefaultItems.Tools.HAND;
            }
               
        }

        public bool IsSelectedInventoryItemMenuTool()
        {
            return DefaultItems.Tools.Default.Any(x => x.Id == SelectedInventoryItem.Id);

        }

        private async Task HostProvider_SelectedAccountChanged(string account)
        {

            Console.WriteLine("Calling Validate from HostProvider_SelectedAccountChanged");
            await ValidateCurrentChainAndLoadSelectedAccount();
        }

        private async Task HostProvider_NetworkChanged(long chainId)
        {
            await ValidateCurrentChainAndLoadSelectedAccount();
        }

        public void InitialisePlayerLocalStateDemoLand(TestScenario testScenario)
        {
            var playerLocalState = PlayerLocalStateTestScenarioFactory.GetPlayerLocalState(testScenario);
            //playerLocalState.EnsureInitialised();
            PlayerLocalState = playerLocalState;
        }

        private async Task<PlayerService> GetPlayerServiceAsync()
        {
            var web3 = await SelectedHostProviderService.SelectedHost.GetWeb3Async();
            web3.TransactionManager.UseLegacyAsDefault = true;
            var address = SelectedHostProviderService.SelectedHost.SelectedAccount;
            if (address != null && address.IsValidEthereumAddressHexFormat())
            {
                
                playerService = new PlayerService(web3, await VisionsContractAddressesService.GetContractAddresses(), address);
                //edit to see other lands
                //playerService.SelectedLandId = 5;
                //
                await playerService.EnsureInitialisedSelectedLandIdToFirstLandIfNotSetAsync();
                
                return playerService;
            }
            return null;
        }

        public async Task<GuildsAndPlayersEarnings> GetGuildsAndPlayersEarningsAsync()
        {
            var playerService = await GetPlayerServiceAsync();
            return await playerService.GetGuildsAndPlayersEarningsAsync();
        }

        public async Task<List<LeaderBoardViewModel>> GetLeaderBoardOfTotalEarnedInOrderAsync()
        {
           var guildsAndPlayersEarnings = await GetGuildsAndPlayersEarningsAsync();
           var lands = await GetAllLandsAsync(); 
           var earningsInOrder = guildsAndPlayersEarnings.GetPlayersEarningsInOrder();
           var returnList = new List<LeaderBoardViewModel>();
            foreach (var player in earningsInOrder)
            {
                var land = lands.FirstOrDefault(x => x.LandId == player.LandId);
                if (land != null)
                {
                    Console.WriteLine("Player: " + player.LandId + " " + player.TotalEarned);
                    var leaderBoardViewModel = new LeaderBoardViewModel
                    {
                        LandId = player.LandId,
                        TotalEarned = player.TokenEarnedToMainUnit(),
                        LandName = land.Name
                    };

                    returnList.Add(leaderBoardViewModel);
                }
            }
            return returnList;
        }

        public async Task RefreshLeaderBoardAsync()
        {
            LeaderBoard = await GetLeaderBoardOfTotalEarnedInOrderAsync();
        }

        public List<LeaderBoardViewModel> LeaderBoard { get; set; }

        public async Task<List<LandMetadata>> GetAllLandsAsync()
        {
            var playerService = await GetPlayerServiceAsync();
            return await playerService.GetAllLandsAsync();
        }


        public async Task<PlayerInfo> LoadPlayerInfoAsync()
        {
            if(PlayerInfo == null) PlayerInfo = new PlayerInfo();

            if (PlayerLocalState != null && PlayerInfo != null && PlayerInfo.HasLand())
            {
                this.PlayerInfo.PlayerLandInfo = this.PlayerLocalState.PlayerLandInfo;
            }
            else
            {
                var playerService = await GetPlayerServiceAsync();
                PlayerInfo = await playerService.GetPlayerInfoAsync();
            }
            
            return PlayerInfo;

        }

        public async Task LoadPlayerInfoAndLandAsync()
        {
            await LoadPlayerInfoAsync();
            Console.WriteLine("PlayerInfo Loaded");
           // Console.WriteLine(JsonConvert.SerializeObject(PlayerInfo));
            if (PlayerInfo.HasLand())
            {
                await LoadPlayerLocalStateAsync();
            }
           
        }

        public async Task<PlayerLocalState> LoadPlayerLocalStateAsync()
        {
            Console.WriteLine("test...");
            var playerService = await GetPlayerServiceAsync();
            if (playerService != null)
            {
                PlayerLocalState = await playerService.GetNewPlayerLocalStateAsync();
                Console.WriteLine("test..." + PlayerLocalState.UpdatedLand);
                return PlayerLocalState;
            }
            PlayerLocalState = null;
            return null;
          
        }

        public async Task<BigInteger> CalculateLandCostQueryAsync(int x, int y)
        {
            var playerService = await GetPlayerServiceAsync();
            return await playerService.CalculateLandCostQueryAsync(x, y);
        }

        public async Task InitialisePlayerInitialFreeTestLandRequestAndWaitForReceiptAsync()
        {
            try
            {
                

                var playerService = await GetPlayerServiceAsync();
                SavingPlayerLand = true;
                
                await NotifyGameStateChange();
                var faucetService = new FaucetApiClientService(FaucetUrl, new HttpHelper(new HttpClient()));
                Console.WriteLine("Checking if funds can be requested");
                Console.WriteLine("Player Address: " + playerService.PlayerAddress);
                var canRequest = await faucetService.CanRequestFundsAsync(playerService.PlayerAddress);
                if(canRequest)
                {
                    var response = await faucetService.RequestFundsAsync(playerService.PlayerAddress);
                    Console.WriteLine("Funds requested: " + response.TransactionHash);
                }
                else
                {
                    Console.WriteLine("Funds not requested, already funded");
                }

                
                await playerService.PurchaseNewLandAndWaitForReceiptAsync();
                PlayerInfo = await playerService.GetPlayerInfoAsync();
                await Task.Delay(1000);
                await MergeAfterExpandingPlayerLocalStateAsync();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                SetErrorMessage(ex.Message + " The land has been reset to the last time was saved");
                await playerService.ReloadPlayerLocalStateAsync(this.PlayerLocalState);

            }
            finally
            {
                SavingPlayerLand = false;
                ValidateSelectedItemAfterAction();
                await NotifyGameStateChange();
            }
        }

        public async Task ExpandLandAndWaitForReceiptAsync(int x=1, int y=0)
        {
            try
            {
                SavingPlayerLand = true;
                await NotifyGameStateChange();
                var playerService = await GetPlayerServiceAsync();
                await playerService.ExpandPlayerLandRevealingAllChunksAndWaitForReceiptAsync(x, y, this.PlayerLocalState);
                PlayerInfo.PlayerLandInfo =  this.PlayerLocalState.PlayerLandInfo;
                //await Task.Delay(1000);
                //await MergeAfterExpandingPlayerLocalStateAsync();

            }
            catch (Exception ex)
            {
                SetErrorMessage(ex.Message + " The land has been reset to the last time was saved");
                await playerService.ReloadPlayerLocalStateAsync(this.PlayerLocalState);
              
            }
            finally
            {
                SavingPlayerLand = false;
                ValidateSelectedItemAfterAction();
                await NotifyGameStateChange();
            }
        }

        public async Task RevealAndGenerateChunkAndWaitForReceiptAsync()
        {
            try
            {
                SavingPlayerLand = true;
                await NotifyGameStateChange();
                var playerService = await GetPlayerServiceAsync();
                await playerService.RevealAndGenerateChunkAndWaitForReceiptAsync(this.PlayerLocalState);
                //await Task.Delay(1000);
                //await MergeAfterExpandingPlayerLocalStateAsync();

            }
            catch (Exception ex)
            {
                SetErrorMessage(ex.Message + " The land has been reset to the last time was saved");
                await playerService.ReloadPlayerLocalStateAsync(this.PlayerLocalState);

            }
            finally
            {
                SavingPlayerLand = false;
                ValidateSelectedItemAfterAction();
                await NotifyGameStateChange();
            }
        }

        private async Task NotifyGameStateChange()
        {
            if (GameChanged != null) await GameChanged();
        }

        

        public async Task RefreshStateAsync()
        {
            if (PlayerLocalState != null)
            {
                await LoadPlayerInfoAsync();
                await playerService.ReloadPlayerLocalStateAsync(this.PlayerLocalState);
            }
            else
            {
                await LoadPlayerInfoAndLandAsync();
            }
        }

        public async Task MergeAfterExpandingPlayerLocalStateAsync()
        {
            if (PlayerLocalState != null)
            {
                await LoadPlayerInfoAsync();
                var result =  await playerService.MergeAfterExpandingPlayerLocalStateAsync(this.PlayerLocalState);
                if (result.ChangesFoundInChain)
                {
                    SetErrorMessage("Expansion succeeded, but current land did not match the one in the chain, so all the changes have been reverted");
                }
            }
            else
            {
                await LoadPlayerInfoAndLandAsync();
            }
        }

        public async Task<string> SavePlayerStateToChainAndWaitForReceiptAsync()
        {
            try
            {
                SavingPlayerLand = true;
                await NotifyGameStateChange();
                var playerService = await GetPlayerServiceAsync();
                //TODO check there is something to save! // update timings etc this might be passed back to the frontend unity to start timers
                var txn = await playerService.SavePlayerStateAndWaitForReceiptAsync(PlayerLocalState);
               // Console.WriteLine(JsonConvert.SerializeObject(txn));
                await Task.Delay(1000); // using the blocknumber and delay to ensure sync
                //await RefreshStateAsync();


                return txn.TransactionHash;
            }
            
            catch(Exception ex)
            {

                if(ex is SmartContractRevertException)
                {
                    var revert = ex as SmartContractRevertException;
                   
                    SetErrorMessage("Custom error:" + revert.Message);
                }
                else if (ex is SmartContractCustomErrorRevertException)
                {
                    var errors = this.playerService.LandNamespace.Systems.LandItemInteraction.GetAllErrorTypes();
                    var customError = ex as SmartContractCustomErrorRevertException;
                    foreach (var error in errors)
                    {
                        if(customError.IsCustomErrorFor(error))
                        {
                            SetErrorMessage(error.ToString() + " " + customError.Message);
                        }
                    }
                }
                else
                {
                    SetErrorMessage(ex.Message + " The land has been reset to the last time was saved");
                }
                
                //SetErrorMessage(ex.Message + " The land has been reset to the last time was saved");
                await playerService.ReloadPlayerLocalStateAsync(this.PlayerLocalState);
                return null;
            }
            finally
            {
                ValidateSelectedItemAfterAction();
                await LoadPlayerInfoAsync();
                SavingPlayerLand = false;
                await NotifyGameStateChange();
            }
        }

        public void SetErrorMessage(string message)
        {
            NewError = true;
            ErrorMessage = message;
            Console.WriteLine("Error: " + message);
        }

       

        public bool IsPlayerInitialised()
        {
            if (PlayerLocalState == null) throw new System.Exception("PlayerLocalState not loaded");
            return PlayerLocalState.PlayerLandInfo.IsInitialized;
        }

        public bool IsLoaded()
        {
            return PlayerInfo != null && !LoadingPlayerLand;
                
        }

        public bool HasLand()
        {
            return IsLoaded() && PlayerInfo.HasLand();
        }

        public List<InventoryItem> GetInventoryItemsFromPlayerLocalState()
        {
            return PlayerLocalState.UpdatedInventoryItems;
        }

        public List<List<List<LandItem>>> GetLandItemsFromPlayerLocalState()
        {
           
            return LandNamespace.ConvertTo3dArray(LandNamespace.PadLandItems(PlayerLocalState.UpdatedLand));

        }


        public string GetInventoryBatchData()
        {
            if (PlayerLocalState != null) {
                return GetInventoryItemsFromPlayerLocalState().Sum(x => (int)x.Count).ToString();
            }
            else
            {
                return String.Empty;
            }
        }

        public void PerformActionLandItem(LandItem landItem)
        {
            try
            {
                ErrorMessage = null;
                switch (ItemEditingMode)
                {
                    case ItemEditingMode.PlaceItem:
                        PlaceItemIntoLocalState(landItem);
                        break;
                    case ItemEditingMode.RemoveItem:
                        RemoveItemFromLocalState(landItem);
                        break;
                    case ItemEditingMode.RotateItem:
                        ToggleRotationLocalState(landItem);
                        break;
                    case ItemEditingMode.ZoomToItem:
                        if(ZoomToItemSelected!= null)
                        {
                            ZoomToItemSelected(landItem.X, landItem.Y);
                        }
                        break;
                }

               
            }
            catch(Exception e)
            {
                SetErrorMessage(e.Message);
            }
            finally
            {
                ValidateSelectedItemAfterAction();
            }
        }

        public void PlaceItemIntoLocalState(LandItem landItem)
        {
            try
            {
                PlaceItemIntoLocalState((int)landItem.X, (int)landItem.Y, SelectedInventoryItem.Id);
            }
            catch(Exception e)
            {
                SetErrorMessage(e.GetType().ToString() + ": " + e.Message);
            }
        }

        public void PlaceItemIntoLocalState(int x, int y)
        {
            PlaceItemIntoLocalState(x, y, SelectedInventoryItem.Id);
        }

        public void PlaceItemIntoLocalState(int x, int y, int inventoryId)
        {
            if (inventoryId == DefaultItems.Tools.HAND.Id) inventoryId = 0;
            PlayerLocalState.PlaceItem(x, y, inventoryId, false);
        }

        public void ToggleRotationLocalState(LandItem landItem)
        {
            PlayerLocalState.ToggleRotation((int)landItem.X, (int)landItem.Y, (int)landItem.StackIndex);
        }

        public void ToggleRotationLocalState(int x, int y, int index)
        {
            PlayerLocalState.ToggleRotation(x, y, index);
        }

        public void RemoveItemFromLocalState(LandItem landItem)
        {
            PlayerLocalState.RemoveItem((int)landItem.X, (int)landItem.Y);
        }

        public void RemoveItemFromLocalState(int x, int y)
        {
            PlayerLocalState.RemoveItem(x, y);
        }

        public async Task<PlayerBalances> LoadPlayerBalancesAsync()
        {
            var playerService = await GetPlayerServiceAsync();
            return await playerService.GetPlayerBalancesAsync();
        }

        public void CraftRecipeIntoLocalState(int[][] recipe)
        {
            PlayerLocalState.CraftItem(recipe);
        }

        public void CraftRecipeIntoLocalState(CraftingRecipe recipe)
        {
            PlayerLocalState.CraftItem(recipe);
        }

        public bool IsCraftingRecipeValidWithCurrentInventoryItems(int[][] recipe)
        {
            return PlayerLocalState.CraftItemRecipeIsValidWithCurrentInventoryItems(recipe);
        }

        public bool IsCraftingRecipeValidWithCurrentInventoryItems(CraftingRecipe recipe)
        {
            return PlayerLocalState.CraftItemRecipeIsValidWithCurrentInventoryItems(recipe);
        }
        public List<CraftingRecipe> GetCraftingRecipesThatCanBeCreatedWithCurrentInventoryItems()
        {
            return PlayerLocalState.GetCraftingRecipesThatCanBeCreatedWithCurrentInventoryItems();
        }





        public bool CraftRecipeIsValid(CraftingRecipe recipe)
        {
            return DefaultCraftingRecipes.IsValidRecipe(recipe.Recipe);
        }

        public bool CraftRecipeIsValid(int[][] recipe)
        {
            return DefaultCraftingRecipes.IsValidRecipe(recipe);
        }

        public CraftingRecipe FindCraftingRecipe(int[][] recipe)
        {
            return DefaultCraftingRecipes.FindCraftingRecipe(recipe);
        }

      

        public bool CanItemBeRotatedInLocalState(int x, int y, int index)
        {
            return PlayerLocalState.CanItemBeRotated(x, y, index);
        }

        public bool IsItemRotatedInLocalState(int x, int y, int index)
        {
            return PlayerLocalState.IsItemRotated(x, y, index);
        }

        //Catalogue
        public List<CatalogueItem> GetCatalogueItems()
        {
            return PlayerLocalState.GetAllCatalogueItems();
        }

        public List<Catalogue> GetCatalogues()
        {
            return PlayerLocalState.GetCatalogues();
        }

        public List<CatalogueItem> GetCatalogueItemsByCatalogueId(int catalogueId)
        {
            return PlayerLocalState.GetCatalogueItemsByCatalogueId(catalogueId);
        }

        public Catalogue GetCatalogueById(BigInteger itemId)
        {
            return PlayerLocalState.GetCatalogues().First(x => x.CatalogueId == itemId);
        }

        public TotalPurchaseCostBalance CalculateTotalPurchaseCostAndBalance(BigInteger itemId, int quantity)
        {
            return PlayerLocalState.CalculateTotalPurchaseCostAndBalance(itemId, quantity);
        }

        public TotalPurchaseCostBalance CalculateTotalPurchaseCostAndBalance(List<CatalogueItemPurchase> catalogueItemPurchases)
        {
            return PlayerLocalState.CalculateTotalPurchaseCostAndBalance(catalogueItemPurchases);
        }

        public async Task<TransactionReceipt> PurchaseCatalogueItemAsync(BigInteger itemId, BigInteger quantity)
        {
            var playerService = await GetPlayerServiceAsync();
            var receipt = await playerService.PurchaseItemFromCatalogueAndWaitForReceiptAsync(itemId, quantity, PlayerLocalState);
            await LoadPlayerInfoAsync();
            await NotifyGameStateChange();
            return receipt;
        }

        public async Task<TransactionReceipt> PurchaseCatalogueItemsAsync(List<CatalogueItemPurchase> catalogueItemPurchases)
        {
            var playerService = await GetPlayerServiceAsync();
            var receipt = await playerService.PurchaseItemsFromCatalogueAndWaitForReceiptAsync(catalogueItemPurchases, PlayerLocalState);
            await LoadPlayerInfoAsync();
            await NotifyGameStateChange();
            return receipt;
        }

        //Quests

        public List<QuestGroup> GetActiveQuestGroupsFromLocalState()
        {
            return PlayerLocalState.LandQuestsLocalState.ActiveQuestGroups;
        }

        public List<LandQuestGroup> GetCompletedActiveLandQuestGroupsFromLocalState()
        {
            return PlayerLocalState.LandQuestsLocalState.CompletedActiveLandQuestGroups;
        }

        public List<LandQuestGroup> GetActiveLandQuestGroupsFromLocalState()
        {
            return PlayerLocalState.LandQuestsLocalState.ActiveLandQuestGroups;
        }


        //Marketplace
        public async Task<List<MarketPlaceListing>> GetMarketPlaceListingsAsync()
        {
            var playerService = await GetPlayerServiceAsync();
            var marketplaceService = playerService.GetPlayerMarketPlaceService();
            return await marketplaceService.GetMarketPlaceListingsAsync();
        }

        public async Task EditMarketPlaceListingAsync(BigInteger listingId, decimal unitPriceInMainUnit, BigInteger quantity)
        {
            var playerService = await GetPlayerServiceAsync();
            var marketplaceService = playerService.GetPlayerMarketPlaceService();
            await marketplaceService.EditListingAndWaitForReceiptAsync(listingId, unitPriceInMainUnit, quantity, PlayerLocalState);
        }

        public async Task CancelMarketPlaceListingAsync(BigInteger listingId)
        {
            var playerService = await GetPlayerServiceAsync();
            var marketplaceService = playerService.GetPlayerMarketPlaceService();
            await marketplaceService.CancelListingAndWaitForReceiptAsync(listingId, PlayerLocalState);
        }

        public async Task<TransactionReceipt> CreateMarketPlaceListingAsync(BigInteger itemId, BigInteger quantity, decimal unitPriceInMainUnit)
        {
            var playerService = await GetPlayerServiceAsync();
            var marketplaceService = playerService.GetPlayerMarketPlaceService();
            var receipt = await marketplaceService.ListMarketplaceItemAndWaitForReceiptAsync(itemId, unitPriceInMainUnit, quantity, PlayerLocalState);
            await LoadPlayerInfoAsync();
            await NotifyGameStateChange();
            return receipt;
        }

        public async Task RefreshMarketPlaceListingsAsync()
        {
            if (LandNames == null)
            {
                LandNames = await GetAllLandsAsync();
            }

            MarketPlaceListings = await GetMarketPlaceListingsAsync();
        }

        public async Task PurchaseMarketplaceListing(BigInteger listingId, BigInteger quantity)
        {
            var playerService = await GetPlayerServiceAsync();
            var marketplaceService = playerService.GetPlayerMarketPlaceService();
            var receipt = await marketplaceService.BuyFromMarketplaceValidateAndApproveItemRequestAndWaitForReceiptAsync(listingId, quantity, PlayerLocalState);
            await LoadPlayerInfoAsync();
            await NotifyGameStateChange();
        }

       


        /// <summary>
        /// Use these items with VisionsContracts.LandLocalState.UnlockTimeoutValidator to validate if an item can be unlocked, timed out etc
        /// </summary>
        /// <returns></returns>
        public List<LandItemNextTransformation> GetAllNextTransformationsThatRequireUnlockingWithEnoughInventoryFromLocalState()
        {
            return PlayerLocalState.GetAllNextTransformationsThatRequireUnlockingWithEnoughInventory();
        }

        public bool EnablePerformActionFromCell { get; set; } = true;

        //This is a singleton so we are not disposing.. keeping this in case we add other hosts etc
        public void Dispose()
        {
            if (SelectedHost != null)
            {
                SelectedHost.SelectedAccountChanged -= HostProvider_SelectedAccountChanged;
                SelectedHost.NetworkChanged -= HostProvider_NetworkChanged;
                SelectedHost.EnabledChanged -= HostProviderOnEnabledChanged;
            }
        }
    }
}
