# Getting Started with CafeCosmos Automation Example

This program demonstrates how to work with data on **CafeCosmos** using **Nethereum** and **MUD** integration. It provides a framework to interact with smart contracts, retrieve data from the blockchain, and store or query information in PostgreSQL using MUD concepts. It serves as a proof of concept for beginners to get started with Nethereum and MUD in this specific context.

## Overview

The program interacts with Ethereum-based smart contracts to:

1. Access player information and local state.
2. Interact directly with MUD systems on the blockchain.
3. Query blockchain tables for specific data.
4. Process blockchain events for insights.
5. Retrieve and manage data from a PostgreSQL database using repositories.

### Dependency on MUD Tables Log Processor

This program relies on the **MUD Tables Log Processor** to fetch and process log events from the blockchain and populate the PostgreSQL database (`storerecords` table). If the background processor is not running, you won't be able to run that sample :), so comment it out.

For detailed setup instructions and access to the code, refer to the [MUD Tables Log Processor Project Documentation](../VisionsContracts.LogProcessing.Postgres/Readme.md).

## Prerequisites

1. Clone the repository:
   ```sh
   git clone <repository-url>
   cd <repository-folder>
   ```

2. Restore and build the project:
   ```sh
   dotnet restore
   dotnet build
   ```

3. Run the program:
   ```sh
   dotnet run
   ```

Ensure that the MUD Tables Log Processor is running and populating the database with the required data before executing this program.

## Code Walkthrough

### 1. Player Service and Local State

The **PlayerService** provides a high-level API to interact with player-specific data and manage the local state. This includes accessing player lands and inventory.

#### Simple Example

```csharp
var playerService = new PlayerService(web3, contractAddresses, "0xaBFc86CfAA33777eC854877b5f5eBA4038Da40F4");
var lands = await playerService.GetAllLandsAsync();

playerService.SelectedLandId = 1;
var playerLocalState = await playerService.GetNewPlayerLocalStateAsync();
Console.WriteLine("---- Player Local State ----");
Console.WriteLine($"Land XP: {playerLocalState.PlayerLandInfo.CumulativeXp} Land Name: {playerLocalState.LandName}");

playerLocalState.PlaceItem(1, 1, DefaultItems.Furniture.GREEN_CHAIR.Id);
await playerService.SavePlayerStateAndWaitForReceiptAsync(playerLocalState);
```

#### Advanced Example

```csharp
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
await playerService.SavePlayerStateAndWaitForReceiptAsync(localState);

// Log the changes to track progression
Console.WriteLine("Advanced local state operations completed and saved.");
Console.WriteLine($"Previous Level: {previousLevel}, Current Level: {localState.PlayerLandInfo.LastLevelClaimed}");
```

### 2. System-Level Interactions

Access systems directly to fetch or manipulate data. For example, retrieving player earnings from the `LandView` system:

```csharp
var landNamespace = new LandNamespace(web3, worldAddress);
var totalEarned = await landNamespace.Systems.LandView.GetPlayerTotalEarnedAsync(1);
```

### 3. Interacting with Blockchain Tables

Query tables stored on the blockchain, such as the `PlayerTotalEarned` table:

```csharp
var playerTotalEarnedTableService = new PlayerTotalEarnedTableService(web3, worldAddress);
var allTotalEarned = await playerTotalEarnedTableService.GetRecordsFromRepository(mudPostgresStoreRecordsTableRepository);
foreach (var record in allTotalEarned)
{
    Console.WriteLine($"Player: {record.LandId} Total Earned: {Web3.Convert.FromWei(record.TotalEarned)}, Total Spent: {Web3.Convert.FromWei(record.TotalSpent)}");
}
```

### 4. Processing Blockchain Events

Retrieve and process blockchain events, such as land purchases or creations:

```csharp
var eventPurchase = web3.Eth.GetEvent<LandPurchaseEventDTO>();
var filterInput = eventPurchase.CreateFilterInput(new BlockParameter(12138750), null);
var allPurchases = await eventPurchase.GetAllChangesAsync(filterInput);

Console.WriteLine("---- Land purchases events ----");
foreach (var purchase in allPurchases)
{
    Console.WriteLine($"Player: {purchase.Event.LandId}, Area: {purchase.Event.Area}, Cost: {purchase.Event.Cost}");
}
```

### 5. Using the PostgreSQL Repository

Retrieve data stored in the PostgreSQL database, such as transformations:

```csharp
var transformations = new TransformationsTableService(web3, contractAddresses.LandAddress);
var allTransformations = await transformations.GetRecordsFromRepository(mudPostgresStoreRecordsTableRepository);
Console.WriteLine("---- Land transformations ----");
foreach (var record in allTransformations)
{
    Console.WriteLine($"Input: {record.Input} Yield: {record.Yield} UnlockTime: {record.UnlockTime}");
}
```

### Supporting Code Snippets

#### Contract Addresses

Define the smart contracts used in the project:

```csharp
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
```

#### Database Configuration

Set up the PostgreSQL context:

```csharp
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
```


