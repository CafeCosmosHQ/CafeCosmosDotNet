# CafeCosmos DotNet

The **CafeCosmos** VisionContracts solution is the core logic for the Unity3D interface of the game which is also reused in the CafeCosmos Blazor implementation, this can also be used to understand the internal mechanics of the game and create your own automations if wanted.

The heart of the solution is the VisionContracts project, which has the essential services, models, and contracts necessary to interact with and manipulate the game state. Several auxiliary projects expand the functionality, including REST APIs, data normalization services, and database processing components to extract / index the data from the smart contracts into a database. 

If you are interested on how to interact with the project, a good starting point is the [CafeCosmos automation example](CafeCosmos.AutomationExample/Readme.md). 

## Project Summary
* **Visions Contracts**. The central part of the solution, includes all the core logic.
* **Cafe Cosmos Blazor**. The game in an html / wasm / hybrid windows / macos version using Blazor.
  <details>
    <summary>Expand to see the screenshot</summary>
    
    ![image](https://github.com/user-attachments/assets/6abbbfcc-d65f-44b7-b17e-d4879f13adfa)
  
  </details>
* **CafeCosmos.AutomationExample** The best place to get started to programmatically interact with the game
* **VisionsContracts.LogProcessing.Postgres** Mud tables event changes indexer in postgres.
  <details>
    <summary>Expand to see the screenshot</summary>
    
    ![image](https://github.com/user-attachments/assets/4880451e-ea74-455f-9edb-9341808b1bcf)
  
  </details>
 
* **VisionContracts.Normarliser.Console** Normalizes the mud table into separate tables already decoded
   <details>
    <summary>Expand to see the screenshot</summary>
    
    ![image](https://github.com/user-attachments/assets/e6d05285-2bfb-4ef6-accb-d3025038ad24)
  
  </details>
 
* **VisionContracts.StoredRecordsRestApi** Rest service to query remotely the postgress database.

## VisionsContracts Project

The VisionContracts project is the central part of the solution.

NOTE THIS DOCUMENT IS WIP

### Components
### 1. PlayerService

#### Loading a New Land onto PlayerLocalState
- To load a new land into the `PlayerLocalState`, the `GetNewPlayerLocalStateAsync` method of `PlayerService` is used. This retrieves the latest player state, including the associated land.

#### What PlayerLocalState Contains
- The `PlayerLocalState` is a comprehensive representation of the player's game state. It includes:
  - **Land**: Data about the player's land, including all the items, positions and stack.
  - **Inventory**: A list of items the player has in her backpack, and not placed in the land.
  - **LandInfo**: Metadata about the land including the size, active tables, xp, etc

#### Interacting with PlayerLocalState
- Players interact with the `PlayerLocalState` to perform various operations, such as:
  - **Placing Items**:
    ```csharp
    playerLocalState.PlaceItem(0, 1, DefaultItems.Furniture.GREEN_CHAIR.Id);
    ```
    Every time you place an item is validated against the capability of the item to be placed in that position or the transformations rules that drive the behaviour of that item.

  - **Crafting Items**:
    ```csharp
    playerLocalState.CraftItem(DefaultItems.Cooking.BURGER_RECIPE);
    ```
    This crafts an item :). When calling this method it validates if you have the items in the inventory and if valid creates the new item.
 
#### Enhancing Logic for Offline Play
- The `PlayerLocalState` contains much of the smart contract logic to validate actions offline. Enhancements can be made to this logic to ensure consistency with on-chain validation.

### Default Transformations, Crafting Recipes, and Items

#### Default Transformations
- Transformations define how items evolve over time or actions. Examples include:
  - **Wheat Growth Cycle**:
    ```csharp
    new Transformation { Base = Wheat.WHEAT_SEED.Id, Input = Tools.WATERING_CAN_FULL.Id, Next = Wheat.WHEAT_SMALL.Id, UnlockTime = 120, Yield = Ingredients.WHEAT.Id };
    ```
  - **Robot Transformations**:
    ```csharp
    new Transformation { Base = DefaultItems.Machines.ROBOT.Id, Input = DefaultItems.Ingredients.RASPBERRY.Id, Next = DefaultItems.Machines.ROBOT_MAKING_MEAT.Id, Yield = DefaultItems.Ingredients.MEAT.Id };
    ```

#### Crafting Recipes
- Recipes define how to craft new items from inputs. Examples include:
  - **Burger Recipe**:
    ```csharp
    new CraftingRecipe { Inputs = { new LBINT { Ingredients.LETTUCE.Id, Ingredients.CHEESE.Id }, new LBINT { Ingredients.MEAT.Id, Ingredients.TOMATO.Id }, new LBINT { Ingredients.DOUGH.Id } }, Output = Recipes.BURGER, XP = 4 };
    ```
#### Items
- Items are organized into categories such as:
  - **Furniture**: Includes items like `GREEN_CHAIR` and `GREEN_TABLE`.
  - **Cooking Appliances**: Examples are `BASIC_OVEN` and `CRAZY_OVEN`.
  - **Raw Materials**: Used in crafting recipes, e.g., `BISMUTH_INGOT` and `WOOD_PINK`.
  - **Decorations**: Items like `WALL_MENU` and `WINDOW`.

     ```csharp
    public static readonly Item COFFEE_MACHINE = new(name: "Coffee Machine", id: 79, category: ItemCategory.Cooking, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);
   ```
#### Exceptions
- Common exceptions encountered while interacting with `PlayerLocalState`:
  - **CraftRecipeInvalidRecipeException**: Thrown when attempting to craft an invalid recipe.
  - **CraftRecipeNoEnoughItemsInInventoryException**: Raised if there aren't enough materials to craft an item.

### LandNamespace

The **LandNamespace** represents the namespace of the Mud World in the smart contracts and acts as a structured interface for managing land-related systems and tables. It organizes **SystemServices** and **TableServices**, which interact directly with blockchain systems and stored game data, respectively.

#### SystemServices
**SystemServices** are code-generated interfaces akin to Nethereum-generated smart contract wrappers but extended with business logic and models to manage dynamic behaviors of the game. Key services include:

1. **LandItemInteractionSystemService**
   - Handles placing, removing, and transforming items on land.
   - Example interaction:
     ```csharp
     await LandItemInteractionSystemService.PlaceItemAsync(landId, itemId, x, y);
     ```

2. **CraftingSystemService**
   - Enables crafting items using recipes.
     ```csharp
     public async Task<TransactionReceipt> CraftRecipeAsync(BigInteger landId, BigInteger recipeId, BigInteger quantity);
     ```

3. **TransformationsSystemService**
   - Manages item transformations based on specific actions or time-based events.

5. **MarketplaceSystemService**
   - Supports listing and buying items in the player marketplace.

6. **LandTokensSystemService**
   - Manages land-related tokens and balances.

7. **QuestsSystemService**
   - Tracks and manages quest progression and rewards.

#### TableServices
**TableServices** handle stored game data and provide query and update capabilities for various components.

1. **LandItemTableService**
   - Tracks item placements and statuses on land.
     ```csharp
     var items = await LandItemTableService.GetTableRecordsAsync(landId);
     ```

2. **LandInfoTableService**
   - Stores metadata about land configurations, expansions, and active tables.

3. **InventoryTableService**
   - Manages player inventory, including items and quantities.

4. **CraftingRecipeTableService**
   - Maintains crafting recipe data.

5. **TransformationsTableService**
   - Records active transformations and their progress.

6. **QuestTableService**
   - Tracks quest data, including progress and completion.

7. **CafeCosmosConfigTableService**
   - Stores global configuration parameters for items, crafting, and land management.











 
