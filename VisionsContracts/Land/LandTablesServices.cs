using Nethereum.Web3;
using System.Collections.Generic;
using Nethereum.Mud.Contracts.Core.Tables;
using VisionsContracts.Land.Tables;
using Org.BouncyCastle.Asn1.Mozilla;

namespace VisionsContracts.Land
{
    public class LandTablesServices : TablesServices
    {
     
        public ActiveStovesTableService ActiveStoves { get; private set; }
        public LandItemCookingStateTableService LandItemCookingState { get; private set; }
        public LandItemTableService LandItem { get; private set; }
        public ItemInfoTableService Item { get; private set; }
        public LandCellTableService LandCell { get; private set; }
        public LandInfoTableService LandInfo { get; private set; }
        public LandTablesAndChairsTableService LandTablesAndChairs { get; private set; }
        public CafeCosmosConfigTableService CafeCosmosConfig { get; private set; }
        public WaterControllerTableService WaterController { get; private set; }
        public InventoryTableService Inventory { get; private set; }
        public LandPermissionsTableService LandPermissions { get; private set; }
        public StackableItemTableService StackableItem { get; private set; }
        public TransformationsTableService Transformations { get; private set; }
        public LevelRewardTableService LevelRewards { get; private set; }
        public ClaimedLevelsTableService ClaimedLevels { get; private set; }
        public RewardCollectionTableService RewardsCollection { get; private set; }
        public RewardTableService Reward { get; private set; }
        public QuestsTableService Quests { get; private set; }
        public QuestGroupTableService QuestGroups { get; private set; }
        public QuestTableService Quest { get; private set; }

  
        public CraftingRecipeTableService CraftingRecipe { get; private set; }
        public ConfigAddressesTableService CafeCosmosConfigAddresses { get; private set; }
        public QuestTaskTableService QuestTask { get; private set; }
        public QuestCollectionTableService QuestCollection { get; private set; }
        public LandQuestGroupsTableService LandQuestGroups { get; private set; }
        public LandQuestTaskProgressTableService LandQuestTaskProgress { get; private set; }
        public LandQuestGroupTableService LandQuestGroup { get; private set; }
        public LandQuestTableService LandQuest { get; private set; }

        public TransformationCategoriesTableService TransformationCategories { get; private set; }

        public CatalogueItemTableService CatalogueItems { get; private set; }

        public GuildsTableService Guilds { get; private set; }

        public GuildTableService Guild { get; private set; }

        public GuildUniqueNameTableService GuildUniqueName { get; private set; }

        public LandGuildTableService LandGuild { get; private set; }

        public GuildInvitationTableService GuildInvitation { get; private set; }

       

        public MarketplaceListingsTableService MarketplaceListings { get; private set; }

        public MarketplaceNonceTableService MarketplaceNonce { get; private set; }

       

        public PlayerTotalEarnedTableService PlayerTotalEarned { get; private set; }

        public VrgdaTableService Vrgda { get; private set; }

        public LandTablesServices(IWeb3 web3, string contractAddress) : base(web3, contractAddress)
        {
           
            CafeCosmosConfig = new CafeCosmosConfigTableService(web3, contractAddress);
            WaterController = new WaterControllerTableService(web3, contractAddress);
            ActiveStoves = new ActiveStovesTableService(web3, contractAddress);
            LandItemCookingState = new LandItemCookingStateTableService(web3, contractAddress);
            LandItem = new LandItemTableService(web3, contractAddress);
            Item = new ItemInfoTableService(web3, contractAddress);
            LandCell = new LandCellTableService(web3, contractAddress);
            LandInfo = new LandInfoTableService(web3, contractAddress);
            LandTablesAndChairs = new LandTablesAndChairsTableService(web3, contractAddress);
            Inventory = new InventoryTableService(web3, contractAddress);
            LandPermissions = new LandPermissionsTableService(web3, contractAddress);
            StackableItem = new StackableItemTableService(web3, contractAddress);
            Transformations = new TransformationsTableService(web3, contractAddress);
            LevelRewards = new LevelRewardTableService(web3, contractAddress);
            ClaimedLevels = new ClaimedLevelsTableService(web3, contractAddress);
            RewardsCollection = new RewardCollectionTableService(web3, contractAddress);
            Reward = new RewardTableService(web3, contractAddress);
            Quests = new QuestsTableService(web3, contractAddress);
            QuestGroups = new QuestGroupTableService(web3, contractAddress);
            Quest = new QuestTableService(web3, contractAddress);
            CraftingRecipe = new CraftingRecipeTableService(web3, contractAddress);
            CafeCosmosConfigAddresses = new ConfigAddressesTableService(web3, contractAddress);
            QuestTask = new QuestTaskTableService(web3, contractAddress);
            QuestCollection = new QuestCollectionTableService(web3, contractAddress);
            LandQuestGroups = new LandQuestGroupsTableService(web3, contractAddress);
            LandQuestTaskProgress = new LandQuestTaskProgressTableService(web3, contractAddress);
            LandQuestGroup = new LandQuestGroupTableService(web3, contractAddress);
            LandQuest = new LandQuestTableService(web3, contractAddress);
            TransformationCategories = new TransformationCategoriesTableService(web3, contractAddress);
            CatalogueItems = new CatalogueItemTableService(web3, contractAddress);
            Guilds = new GuildsTableService(web3, contractAddress);
            GuildInvitation = new GuildInvitationTableService(web3, contractAddress);
            Guild = new GuildTableService(web3, contractAddress);
            MarketplaceListings = new MarketplaceListingsTableService(web3, contractAddress);
            MarketplaceNonce = new MarketplaceNonceTableService(web3, contractAddress);
            LandGuild = new LandGuildTableService(web3, contractAddress);
            GuildUniqueName = new GuildUniqueNameTableService(web3, contractAddress);
            PlayerTotalEarned = new PlayerTotalEarnedTableService(web3, contractAddress);
            Vrgda = new VrgdaTableService(web3, contractAddress);



            TableServices = new List<ITableServiceBase>
            {
                CafeCosmosConfig,
                WaterController,
                ActiveStoves,
                LandItemCookingState,
                LandItem,
                Item,
                LandCell,
                LandInfo,
                LandTablesAndChairs,
                Inventory,
                LandPermissions,
                StackableItem,
                Transformations,
                LevelRewards,
                ClaimedLevels,
                RewardsCollection,
                Reward,
                Quests,
                QuestGroups,
                Quest,
                CraftingRecipe,
                CafeCosmosConfigAddresses,
                QuestTask,
                QuestCollection,
                LandQuestGroups,
                LandQuestTaskProgress,
                LandQuestGroup,
                LandQuest,
                TransformationCategories,
                CatalogueItems,
                Guilds,
                Guild,
                LandGuild,
                GuildUniqueName,
                GuildInvitation,
                
                MarketplaceListings,
                MarketplaceNonce,
                
                PlayerTotalEarned,
                Vrgda
            };
        }
    }
}