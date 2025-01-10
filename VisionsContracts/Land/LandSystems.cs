using Nethereum.Web3;
using VisionsContracts.Land.Systems.LandConfigSystem;
using VisionsContracts.Land.Systems.LandCreationSystem;
using VisionsContracts.Land.Systems.LandItemInteractionSystem;
using VisionsContracts.Land.Systems.LandScenarioUserTestingSystem;
using VisionsContracts.Land.Systems.WaterControllerSystem;
using VisionsContracts.Land.Systems.LandViewSystem;
using VisionsContracts.Land.Systems.LandTokensSystem;
using System.Collections.Generic;
using VisionsContracts.Land.Systems.LandItemsSystem;
using Nethereum.Mud.Contracts.Core.Systems;
using VisionsContracts.Land.Systems.CraftingSystem;
using VisionsContracts.Land.Systems.LandERC1155HolderSystem;
using VisionsContracts.Land.Systems.TransformationsSystem;
using VisionsContracts.Land.Systems.LevelingSystem;
using VisionsContracts.Land.Systems.QuestsSystem;
using VisionsContracts.Land.Systems.LandQuestsSystem;
using VisionsContracts.Land.Systems.QuestsDTOSystem;
using VisionsContracts.Land.Systems.CatalogueSystem;
using VisionsContracts.Land.Systems.MarketplaceSystem;
using VisionsContracts.Land.Systems.GuildSystem;
using VisionsContracts.Land.Systems.VrgdaSystem;

namespace VisionsContracts.Land
{
    public class LandSystems : SystemsServices
    {
        public CraftingSystemService Crafting { get; private set; }
        public LandConfigSystemService LandConfig { get; private set; }
        public LandCreationSystemService LandCreation { get; private set; }
        public LandItemInteractionSystemService LandItemInteraction { get; private set; }
        public LandScenarioUserTestingSystemService LandScenarioTesting { get; private set; }
        public LandERC1155HolderSystemService LandERC1155Holder { get; private set; }
        public LandViewSystemService LandView { get; private set; }
        public WaterControllerSystemService WaterController { get; private set; }
        public LandItemsSystemService LandItems { get; private set; }
        public LandTokensSystemService LandTokens { get; private set; }
        public TransformationsSystemService Transformations { get; private set; }
        public LevelingSystemService Leveling { get; private set; }
        public QuestsSystemService Quests { get; private set; }
        public LandQuestsSystemService LandQuests { get; private set; }
        public QuestsDTOSystemService QuestsDTOs { get; private set; }

        public CatalogueSystemService Catalogue { get; private set; }

        public MarketplaceSystemService Marketplace { get; private set; }

        public GuildSystemService Guild { get; private set; }

        public VrgdaSystemService Vrgda { get; private set; }

        public bool Testnet { get; private set; }

        public LandSystems(IWeb3 web3, string contractAddress, bool testnet = true) : base(web3, contractAddress)
        {
            Testnet = testnet;

            Crafting = new CraftingSystemService(web3, contractAddress);
            LandConfig = new LandConfigSystemService(web3, contractAddress);
            LandCreation = new LandCreationSystemService(web3, contractAddress);
            LandItemInteraction = new LandItemInteractionSystemService(web3, contractAddress);
            LandScenarioTesting = new LandScenarioUserTestingSystemService(web3, contractAddress);
            LandView = new LandViewSystemService(web3, contractAddress);
            WaterController = new WaterControllerSystemService(web3, contractAddress);
            LandItems = new LandItemsSystemService(web3, contractAddress);
            LandTokens = new LandTokensSystemService(web3, contractAddress);
            LandERC1155Holder = new LandERC1155HolderSystemService(web3, contractAddress);
            Transformations = new TransformationsSystemService(web3, contractAddress);
            Leveling = new LevelingSystemService(web3, contractAddress);
            Quests = new QuestsSystemService(web3, contractAddress);
            LandQuests = new LandQuestsSystemService(web3, contractAddress);
            QuestsDTOs = new QuestsDTOSystemService(web3, contractAddress);
            Catalogue = new CatalogueSystemService(web3, contractAddress);
            Marketplace = new MarketplaceSystemService(web3, contractAddress);
            Guild = new GuildSystemService(web3, contractAddress);
            Vrgda = new VrgdaSystemService(web3, contractAddress);

            SystemServices = new List<ISystemService>
            {
                Crafting,
                LandConfig,
                LandCreation,
                LandItemInteraction,
                LandView,
                WaterController,
                LandItems,
                LandTokens,
                LandERC1155Holder,
                Transformations,
                Leveling,
                Quests,
                LandQuests,
                QuestsDTOs,
                Marketplace,
                Guild,
                Vrgda
            };

            if (Testnet)
            {
                SystemServices.Add(LandScenarioTesting);
                SystemServices.Add(Catalogue);  
            }
        }
    }

}

   

