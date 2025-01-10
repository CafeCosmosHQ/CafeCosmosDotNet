using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Nethereum.Mud.Repositories.Postgres;
using Nethereum.Web3;
using VisionsContracts.Land.Tables;
using System;
using VisionsContracts.Land;
using VisionsContracts;
using Nethereum.Contracts;
using VisionsContracts.Land.Systems.LandCreationSystem.ContractDefinition;
using Nethereum.RPC.Eth.DTOs;
using VisionsContracts.Items;
using VisionsContracts.Land.Systems.CraftingSystem;

namespace CafeCosmos.AutomationExample
{
    internal class Program
    {
        // Contract addresses setup
        static VisionsContractAddresses contractAddresses = new VisionsContractAddresses
        {
            ChainId = 690,
            RedistributorAddress = "0xd8a94218936c2ceb6182e53f0db35edf263edce5",
            TokenAddress = "0x31212186ffe0a354335cbfb2dff837900f145f46",
            ItemsAddress = "0x7df5da1bdcc7a890efd8c8d5ece1a38e2968795a",
            LandAddress = "0xBA24a3E1980D25E3A23A0d62dDA9a49917D811D6",
            VestingAddress = "0x3f3663714e22bc1ff1df0ece6e9b06ce08ff0f32",
            LandNFTAddress = "0x678063e4171e5dd2a11d380115e986c8faed8974"
        };

        static async Task Main(string[] args)
        {
            var web3 = new Web3("https://rpc.redstonechain.com");
            var worldAddress = contractAddresses.LandAddress;
            

            // 1. Player Service and Local State
            await HandlePlayerServiceAndLocalState(web3);

            // 2. Advanced Player Local State Interaction
            //await HandleAdvancedPlayerLocalStateInteraction(web3);

            // 3. System-Level Interactions
            await HandleSystemInteractions(web3, worldAddress);

            // 4. Interacting with Blockchain Tables
            await HandleBlockchainTableInteractions(web3, worldAddress);

            // 5. Processing Blockchain Events
            await HandleBlockchainEvents(web3, worldAddress);

            // 6. PostgreSQL Repository Interactions
            //If you are not running a local Postgres instance, you can comment out these line
            var databaseContext = GetContext();
            var repository = new MudPostgresStoreRecordsTableRepository(databaseContext);
            await HandlePostgresRepositoryInteractions(web3, repository);
        }

       

        private static async Task HandlePlayerServiceAndLocalState(Web3 web3)
        {
            var playerService = new PlayerService(web3, contractAddresses, "0xaBFc86CfAA33777eC854877b5f5eBA4038Da40F4");
            var lands = await playerService.GetAllLandsAsync();

            playerService.SelectedLandId = 1;
            var playerLocalState = await playerService.GetNewPlayerLocalStateAsync();
            Console.WriteLine("---- Player Local State ----");
            Console.WriteLine($"Land XP: {playerLocalState.PlayerLandInfo.CumulativeXp}, Land Name: {playerLocalState.LandName}");

            playerLocalState.PlaceItem(1, 1, DefaultItems.Furniture.GREEN_CHAIR.Id);
            // Uncomment the line below to save the changes and interact with the blockchain
            //await playerService.SavePlayerStateAndWaitForReceiptAsync(playerLocalState);
        }

        // Advanced Player Local State Interaction
        private static async Task HandleAdvancedPlayerLocalStateInteraction(Web3 web3)
        {
            var playerService = new PlayerService(web3, contractAddresses, "0xaBFc86CfAA33777eC854877b5f5eBA4038Da40F4");
            playerService.SelectedLandId = 1;
            var localState = await playerService.GetNewPlayerLocalStateAsync();

            // Record the player's last level before any operations
            var previousLevel = localState.PlayerLandInfo.LastLevelClaimed;

            // Craft multiple items to populate the land inventory
            localState.CraftItem(DefaultCraftingRecipes.Decorations.PINK_FLOOR);
            localState.CraftItem(DefaultCraftingRecipes.Decorations.PINK_FLOOR);
            localState.CraftItem(DefaultCraftingRecipes.Decorations.PINK_FLOOR);
            localState.CraftItem(DefaultCraftingRecipes.Decorations.PURPLE_FLOOR);
            localState.CraftItem(DefaultCraftingRecipes.Decorations.PURPLE_FLOOR);
            localState.CraftItem(DefaultCraftingRecipes.Decorations.PURPLE_FLOOR);

            // Find an existing tree in the land and chop it to gain resources
            var treeItem = localState.UpdatedLand.FirstOrDefault(x => x.ItemId == DefaultItems.Trees.SIMPLE_TREE.Id);
            if (treeItem != null)
            {
                localState.PlaceItem(treeItem, DefaultItems.Tools.AXE.Id); // Chop the tree
                Console.WriteLine("Chopped a tree for resources.");
            }

            // Locate avocado trees and chop each for additional XP
            var avocadoTrees = localState.UpdatedLand.Where(x => x.ItemId == DefaultItems.Trees.AVOCADO_TREE.Id);
            foreach (var avocadoTree in avocadoTrees)
            {
                localState.PlaceItem(avocadoTree, DefaultItems.Tools.AXE.Id);
                Console.WriteLine("Chopped an avocado tree for XP.");
            }

            // Craft high-level furniture to gain experience and resources
            localState.CraftItem(DefaultCraftingRecipes.Furniture.PINK_TABLE);
            localState.CraftItem(DefaultCraftingRecipes.Furniture.PINK_TABLE);
            localState.CraftItem(DefaultCraftingRecipes.Furniture.PINK_TABLE);

            // Save the updated state and synchronize it with the blockchain
            // Uncomment the line below to save the changes and interact with the blockchain
            //await playerService.SavePlayerStateAndWaitForReceiptAsync(localState);

            // Log the changes to track progression
            Console.WriteLine("Advanced local state operations completed and saved.");
            Console.WriteLine($"Previous Level: {previousLevel}, Current Level: {localState.PlayerLandInfo.LastLevelClaimed}");
        }

        private static async Task HandleSystemInteractions(Web3 web3, string worldAddress)
        {
            var landNamespace = new LandNamespace(web3, worldAddress);
            var totalEarned = await landNamespace.Systems.LandView.GetPlayerTotalEarnedAsync(1);
            Console.WriteLine($"Total Earned for Player LandId 1: {Web3.Convert.FromWei(totalEarned.TotalEarned)}");
            Console.WriteLine($"Total Spent for Player LandId 1: {Web3.Convert.FromWei(totalEarned.TotalSpent)}");
        }

        private static async Task HandleBlockchainTableInteractions(Web3 web3, string worldAddress)
        {
            var playerTotalEarnedTableService = new PlayerTotalEarnedTableService(web3, worldAddress);

            var playerTotalEarned = await playerTotalEarnedTableService.GetTableRecordAsync(1);
            Console.WriteLine("---- Player Total Earned ----");
            var record = playerTotalEarned;
            Console.WriteLine($"Player: {record.LandId}, Total Earned: {Web3.Convert.FromWei(record.TotalEarned)}, Total Spent: {Web3.Convert.FromWei(record.TotalSpent)}");
            
        }

        private static async Task HandleBlockchainEvents(Web3 web3, string worldAddress)
        {
            var eventPurchase = web3.Eth.GetEvent<LandPurchaseEventDTO>();
            var filterInput = eventPurchase.CreateFilterInput(new BlockParameter(12138750), null);
            var allPurchases = await eventPurchase.GetAllChangesAsync(filterInput);

            Console.WriteLine("---- Land Purchase Events ----");
            foreach (var purchase in allPurchases)
            {
                Console.WriteLine($"Player: {purchase.Event.LandId}, Area: {purchase.Event.Area}, Cost: {purchase.Event.Cost}");
            }
        }

        private static async Task HandlePostgresRepositoryInteractions(Web3 web3, MudPostgresStoreRecordsTableRepository repository)
        {
            var worldAddress = contractAddresses.LandAddress;
            var playerTotalEarnedTableService = new PlayerTotalEarnedTableService(web3, worldAddress);

            var allTotalEarned = await playerTotalEarnedTableService.GetRecordsFromRepository(repository);
            Console.WriteLine("---- All Player Total Earned ----");
            foreach (var record in allTotalEarned)
            {
                Console.WriteLine($"Player: {record.LandId}, Total Earned: {Web3.Convert.FromWei(record.TotalEarned)}, Total Spent: {Web3.Convert.FromWei(record.TotalSpent)}");
            }


            // Retrieve records with a filter predicate
            var predicate = playerTotalEarnedTableService.CreateTablePredicateBuilder();
            var expandedPredicate = predicate.Equals(x => x.LandId, 1).AndEqual(x => x.LandId, 2).Expand();
            var filteredRecords = await playerTotalEarnedTableService.GetRecordsFromRepositoryAsync(expandedPredicate, repository);

            Console.WriteLine("---- Filtered Player Total Earned ----");
            foreach (var record in filteredRecords)
            {
                Console.WriteLine($"Player: {record.LandId}, Total Earned: {Web3.Convert.FromWei(record.TotalEarned)}, Total Spent: {Web3.Convert.FromWei(record.TotalSpent)}");
            }

            var transformations = new TransformationsTableService(web3, worldAddress);
            var allTransformations = await transformations.GetRecordsFromRepository(repository);

            Console.WriteLine("---- Land Transformations ----");
            foreach (var record in allTransformations)
            {
                Console.WriteLine($"Input: {record.Input}, Yield: {record.Yield}, UnlockTime: {record.UnlockTime}");
            }
        }

        public static MudPostgresStoreRecordsDbContext GetContext()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<MudPostgresStoreRecordsDbContext>();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("PostgresConnection"))
                          .UseLowerCaseNamingConvention();
            return new MudPostgresStoreRecordsDbContext(optionsBuilder.Options);
        }
    }
}
