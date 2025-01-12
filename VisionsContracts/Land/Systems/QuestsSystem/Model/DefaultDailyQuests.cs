using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using VisionsContracts.Land.Systems.CraftingSystem;
using VisionsContracts.Transformations;

namespace VisionsContracts.Land.Systems.QuestsSystem.Model
{

    public class DailyQuestsService
    {

        public static QuestCollection GetDailyQuestCollection()
        {
            return new QuestCollection()
            {
                QuestIds = GetAllDailyQuests().Select(x => x.Id).ToList(),
                QuestGroupType = (int)QuestGroupType.Daily

            };
        }

        public static RewardCollection GetDailyRewardCollection()
        {
            return new RewardCollection()
            {
                RewardIds = GetDailyRewards().Select(x => x.Id).ToList(),
                RewardType = (int)QuestGroupType.Daily
            };
        }

        public static List<Reward> GetDailyRewards()
        {
            return new List<Reward>()
            {
                DefaultRewards.RewardXP5,
                DefaultRewards.RewardXP65,
                DefaultRewards.RewardXP7,
            };
        }

        public static List<Quest> GetAllDailyQuests()
        {
            return DefaultDailyQuests.GetAll();
        }

    }


    public class DefaultDailyQuests
    {
        public static readonly Quest Craft3PinkFloors = new Quest(1, "Craft 3 Pink Floors", DefaultCraftingRecipes.Decorations.PINK_FLOOR, 3, DefaultRewards.RewardXP5);
        public static readonly Quest Craft3PurpleFloors = new Quest(2, "Craft 3 Purple Floors", DefaultCraftingRecipes.Decorations.PURPLE_FLOOR, 3, DefaultRewards.RewardXP5);
        public static readonly Quest Craft3Walls = new Quest(3, "Craft 3 Walls", DefaultCraftingRecipes.Decorations.WALL, 3, DefaultRewards.RewardXP5);
        public static readonly Quest Craft5PinkFloors = new Quest(4, "Craft 5 Pink Floors", DefaultCraftingRecipes.Decorations.PINK_FLOOR, 5, DefaultRewards.RewardXP5);
        public static readonly Quest Craft5PurpleFloors = new Quest(5, "Craft 5 Purple Floors", DefaultCraftingRecipes.Decorations.PURPLE_FLOOR, 5, DefaultRewards.RewardXP5);
        public static readonly Quest Craft5Walls = new Quest(6, "Craft 5 Walls", DefaultCraftingRecipes.Decorations.WALL, 5, DefaultRewards.RewardXP5);

        public static readonly Quest Craft7PinkFloors = new Quest(7, "Craft 7 Pink Floors", DefaultCraftingRecipes.Decorations.PINK_FLOOR, 7, DefaultRewards.RewardXP5);
        public static readonly Quest Craft7PurpleFloors = new Quest(8, "Craft 7 Purple Floors", DefaultCraftingRecipes.Decorations.PURPLE_FLOOR, 7, DefaultRewards.RewardXP5);
        public static readonly Quest Craft7Walls = new Quest(9, "Craft 7 Walls", DefaultCraftingRecipes.Decorations.WALL, 7, DefaultRewards.RewardXP5);

        public static readonly Quest Craft10PinkFloors = new Quest(10, "Craft 10 Pink Floors", DefaultCraftingRecipes.Decorations.PINK_FLOOR, 10, DefaultRewards.RewardXP5);
        public static readonly Quest Craft10PurpleFloors = new Quest(11, "Craft 10 Purple Floors", DefaultCraftingRecipes.Decorations.PURPLE_FLOOR, 10, DefaultRewards.RewardXP5);
        public static readonly Quest Craft10Walls = new Quest(12, "Craft 10 Walls", DefaultCraftingRecipes.Decorations.WALL, 10, DefaultRewards.RewardXP5);

        public static readonly Quest Craft3GreenChairs = new Quest(13, "Craft 3 Green Chairs", DefaultCraftingRecipes.Decorations.GREEN_CHAIR, 3, DefaultRewards.RewardXP5);
        public static readonly Quest Craft5GreenChairs = new Quest(14, "Craft 5 Green Chairs", DefaultCraftingRecipes.Decorations.GREEN_CHAIR, 5, DefaultRewards.RewardXP5);
        public static readonly Quest Craft7GreenChairs = new Quest(15, "Craft 7 Green Chairs", DefaultCraftingRecipes.Decorations.GREEN_CHAIR, 7, DefaultRewards.RewardXP5);
        public static readonly Quest Craft10GreenChairs = new Quest(16, "Craft 10 Green Chairs", DefaultCraftingRecipes.Decorations.GREEN_CHAIR, 10, DefaultRewards.RewardXP5);

        public static readonly Quest Craft3PinkChairs = new Quest(17, "Craft 3 Pink Chairs", DefaultCraftingRecipes.Decorations.PINK_CHAIR, 3, DefaultRewards.RewardXP5);
        public static readonly Quest Craft5PinkChairs = new Quest(18, "Craft 5 Pink Chairs", DefaultCraftingRecipes.Decorations.PINK_CHAIR, 5, DefaultRewards.RewardXP5);
        public static readonly Quest Craft7PinkChairs = new Quest(19, "Craft 7 Pink Chairs", DefaultCraftingRecipes.Decorations.PINK_CHAIR, 7, DefaultRewards.RewardXP5);
        public static readonly Quest Craft10PinkChairs = new Quest(20, "Craft 10 Pink Chairs", DefaultCraftingRecipes.Decorations.PINK_CHAIR, 10, DefaultRewards.RewardXP5);

        public static readonly Quest Craft3RoundPinkTable = new Quest(21, "Craft 3 Round Pink Table", DefaultCraftingRecipes.Furniture.PINK_TABLE, 3, DefaultRewards.RewardXP5);
        public static readonly Quest Craft5RoundPinkTable = new Quest(22, "Craft 5 Round Pink Table", DefaultCraftingRecipes.Furniture.PINK_TABLE, 5, DefaultRewards.RewardXP5);
        public static readonly Quest Craft7RoundPinkTable = new Quest(23, "Craft 7 Round Pink Table", DefaultCraftingRecipes.Furniture.PINK_TABLE, 7, DefaultRewards.RewardXP5);
        public static readonly Quest Craft10RoundPinkTable = new Quest(24, "Craft 10 Round Pink Table", DefaultCraftingRecipes.Furniture.PINK_TABLE, 10, DefaultRewards.RewardXP5);

        public static readonly Quest Craft3RoundPurpleTable = new Quest(25, "Craft 3 Round Purple Table", DefaultCraftingRecipes.Furniture.PURPLE_TABLE, 3, DefaultRewards.RewardXP5);
        public static readonly Quest Craft5RoundPurpleTable = new Quest(26, "Craft 5 Round Purple Table", DefaultCraftingRecipes.Furniture.PURPLE_TABLE, 5, DefaultRewards.RewardXP5);
        public static readonly Quest Craft7RoundPurpleTable = new Quest(27, "Craft 7 Round Purple Table", DefaultCraftingRecipes.Furniture.PURPLE_TABLE, 7, DefaultRewards.RewardXP5);
        public static readonly Quest Craft10RoundPurpleTable = new Quest(28, "Craft 10 Round Purple Table", DefaultCraftingRecipes.Furniture.PURPLE_TABLE, 10, DefaultRewards.RewardXP5);

        public static readonly Quest Craft3GreenTable = new Quest(29, "Craft 3 Green Table", DefaultCraftingRecipes.Furniture.GREEN_TABLE, 3, DefaultRewards.RewardXP5);
        public static readonly Quest Craft5GreenTable = new Quest(30, "Craft 5 Green Table", DefaultCraftingRecipes.Furniture.GREEN_TABLE, 5, DefaultRewards.RewardXP5);
        public static readonly Quest Craft7GreenTable = new Quest(31, "Craft 7 Green Table", DefaultCraftingRecipes.Furniture.GREEN_TABLE, 7, DefaultRewards.RewardXP5);
        public static readonly Quest Craft10GreenTable = new Quest(32, "Craft 10 Green Table", DefaultCraftingRecipes.Furniture.GREEN_TABLE, 10, DefaultRewards.RewardXP5);

        public static readonly Quest Craft5Menus = new Quest(33, "Craft 5 Menus", DefaultCraftingRecipes.Decorations.WALL_MENU, 5, DefaultRewards.RewardXP5);
        public static readonly Quest Craft7Menus = new Quest(34, "Craft 7 Menus", DefaultCraftingRecipes.Decorations.WALL_MENU, 7, DefaultRewards.RewardXP5);
        
        public static readonly Quest Craft5PlanetSigns = new Quest(35, "Craft 5 Planet Signs", DefaultCraftingRecipes.Decorations.SIGNBOARD, 5, DefaultRewards.RewardXP5);
        public static readonly Quest Craft7PlanetSigns = new Quest(36, "Craft 7 Planet Signs", DefaultCraftingRecipes.Decorations.SIGNBOARD, 7, DefaultRewards.RewardXP5);

        public static readonly Quest Craft4Fences = new Quest(37, "Craft 4 Fences", DefaultCraftingRecipes.Decorations.FENCE, 4, DefaultRewards.RewardXP5);
        public static readonly Quest Craft8Fences = new Quest(38, "Craft 8 Fences", DefaultCraftingRecipes.Decorations.FENCE, 8, DefaultRewards.RewardXP5);
        public static readonly Quest Craft3Window = new Quest(39, "Craft 3 Window", DefaultCraftingRecipes.Decorations.WINDOW, 3, DefaultRewards.RewardXP5);
        public static readonly Quest Craft5Window = new Quest(40, "Craft 5 Window", DefaultCraftingRecipes.Decorations.WINDOW, 5, DefaultRewards.RewardXP5);

        // Croissant Quests
        public static readonly Quest Cook1Croissant = new Quest(41, "Cook 1 Croissant", DefaultTransformationCategories.CookCroissant, 1, DefaultRewards.RewardXP5);
        public static readonly Quest Cook3Croissant = new Quest(42, "Cook 3 Croissants", DefaultTransformationCategories.CookCroissant, 3, DefaultRewards.RewardXP5);
        public static readonly Quest Cook5Croissant = new Quest(43, "Cook 5 Croissants", DefaultTransformationCategories.CookCroissant, 5, DefaultRewards.RewardXP5);

        // Cupcake Quests
        public static readonly Quest Cook1Cupcake = new Quest(44, "Cook 1 Cupcake", DefaultTransformationCategories.CookCupcake, 1, DefaultRewards.RewardXP5);
        public static readonly Quest Cook3Cupcake = new Quest(45, "Cook 3 Cupcakes", DefaultTransformationCategories.CookCupcake, 3, DefaultRewards.RewardXP5);
        public static readonly Quest Cook5Cupcake = new Quest(46, "Cook 5 Cupcakes", DefaultTransformationCategories.CookCupcake, 5, DefaultRewards.RewardXP5);

        // Burger Quests
        public static readonly Quest Cook1Burger = new Quest(47, "Cook 1 Burger", DefaultTransformationCategories.CookBurger, 1, DefaultRewards.RewardXP5);
        public static readonly Quest Cook3Burger = new Quest(48, "Cook 3 Burgers", DefaultTransformationCategories.CookBurger, 3, DefaultRewards.RewardXP5);
        public static readonly Quest Cook5Burger = new Quest(49, "Cook 5 Burgers", DefaultTransformationCategories.CookBurger, 5, DefaultRewards.RewardXP5);

        // Pizza Quests
        public static readonly Quest Cook1Pizza = new Quest(50, "Cook 1 Pizza", DefaultTransformationCategories.CookPizza, 1, DefaultRewards.RewardXP5);
        public static readonly Quest Cook3Pizza = new Quest(51, "Cook 3 Pizzas", DefaultTransformationCategories.CookPizza, 3, DefaultRewards.RewardXP5);
        public static readonly Quest Cook5Pizza = new Quest(52, "Cook 5 Pizzas", DefaultTransformationCategories.CookPizza, 5, DefaultRewards.RewardXP5);

        // Mac 'n Cheese Quests
        public static readonly Quest Cook1MacAndCheese = new Quest(53, "Cook 1 Mac 'n Cheese", DefaultTransformationCategories.CookMacAndCheese, 1, DefaultRewards.RewardXP5);
        public static readonly Quest Cook3MacAndCheese = new Quest(54, "Cook 3 Mac 'n Cheeses", DefaultTransformationCategories.CookMacAndCheese, 3, DefaultRewards.RewardXP5);
        public static readonly Quest Cook5MacAndCheese = new Quest(55, "Cook 5 Mac 'n Cheeses", DefaultTransformationCategories.CookMacAndCheese, 5, DefaultRewards.RewardXP5);

        // Salad Quests
        public static readonly Quest Make1Salad = new Quest(56, "Chop 1 Salad", DefaultTransformationCategories.ChopSalad, 1, DefaultRewards.RewardXP5);
        public static readonly Quest Make3Salad = new Quest(57, "Chop 3 Salads", DefaultTransformationCategories.ChopSalad, 3, DefaultRewards.RewardXP5);
        public static readonly Quest Make5Salad = new Quest(58, "Chop 5 Salads", DefaultTransformationCategories.ChopSalad, 5, DefaultRewards.RewardXP5);

        // Shawarma Quests
        public static readonly Quest Cook1Shawarma = new Quest(59, "Cook 1 Shawarma", DefaultTransformationCategories.CookShawarma, 1, DefaultRewards.RewardXP5);
        public static readonly Quest Cook3Shawarma = new Quest(60, "Cook 3 Shawarmas", DefaultTransformationCategories.CookShawarma, 3, DefaultRewards.RewardXP5);
        public static readonly Quest Cook5Shawarma = new Quest(61, "Cook 5 Shawarmas", DefaultTransformationCategories.CookShawarma, 5, DefaultRewards.RewardXP5);

        // Smoothie Quests
        public static readonly Quest Blend1Smoothie = new Quest(62, "Blend 1 Smoothie", DefaultTransformationCategories.BlendSmoothie, 1, DefaultRewards.RewardXP5);
        public static readonly Quest Blend3Smoothie = new Quest(63, "Blend 3 Smoothies", DefaultTransformationCategories.BlendSmoothie, 3, DefaultRewards.RewardXP5);
        public static readonly Quest Blend5Smoothie = new Quest(64, "Blend 5 Smoothies", DefaultTransformationCategories.BlendSmoothie, 5, DefaultRewards.RewardXP5);

        // Plant quests
        public static readonly Quest Plant3Tomatoes = new Quest(65, "Plant 3 Tomatoes", DefaultStackings.SoilTomatoSeedStacking, 3, DefaultRewards.RewardXP5);
        public static readonly Quest Plant5Tomatoes = new Quest(66, "Plant 5 Tomatoes", DefaultStackings.SoilTomatoSeedStacking, 5, DefaultRewards.RewardXP5);
        public static readonly Quest Plant7Tomatoes = new Quest(67, "Plant 7 Tomatoes", DefaultStackings.SoilTomatoSeedStacking, 7, DefaultRewards.RewardXP5);
        public static readonly Quest Plant10Tomatoes = new Quest(68, "Plant 10 Tomatoes", DefaultStackings.SoilTomatoSeedStacking, 10, DefaultRewards.RewardXP5);

        
        public static readonly Quest Plant3Lettuce = new Quest(69, "Plant 3 Lettuce", DefaultStackings.SoilLettuceSeedStacking, 3, DefaultRewards.RewardXP5);
        public static readonly Quest Plant5Lettuce = new Quest(70, "Plant 5 Lettuce", DefaultStackings.SoilLettuceSeedStacking, 5, DefaultRewards.RewardXP5);
        public static readonly Quest Plant7Lettuce = new Quest(71, "Plant 7 Lettuce", DefaultStackings.SoilLettuceSeedStacking, 7, DefaultRewards.RewardXP5);
        public static readonly Quest Plant10Lettuce = new Quest(72, "Plant 10 Lettuce", DefaultStackings.SoilLettuceSeedStacking, 10, DefaultRewards.RewardXP5);

        
        public static readonly Quest Plant3Wheat = new Quest(73, "Plant 3 Wheat", DefaultStackings.SoilWheatSeedStacking, 3, DefaultRewards.RewardXP5);
        public static readonly Quest Plant5Wheat = new Quest(74, "Plant 5 Wheat", DefaultStackings.SoilWheatSeedStacking, 5, DefaultRewards.RewardXP5);
        public static readonly Quest Plant7Wheat = new Quest(75, "Plant 7 Wheat", DefaultStackings.SoilWheatSeedStacking, 7, DefaultRewards.RewardXP5);
        public static readonly Quest Plant10Wheat = new Quest(76, "Plant 10 Wheat", DefaultStackings.SoilWheatSeedStacking, 10, DefaultRewards.RewardXP5);

        // Water Quests
       


        public static readonly Quest Water3Lettuce = new Quest(77, "Water 3 Lettuce Plants", DefaultTransformationCategories.WaterLettucePlant, 3, DefaultRewards.RewardXP5);
        public static readonly Quest Water5Lettuce = new Quest(78, "Water 5 Lettuce Plants", DefaultTransformationCategories.WaterLettucePlant, 5, DefaultRewards.RewardXP5);
        public static readonly Quest Water7Lettuce = new Quest(79, "Water 7 Lettuce Plants", DefaultTransformationCategories.WaterLettucePlant, 7, DefaultRewards.RewardXP5);
        public static readonly Quest Water10Lettuce = new Quest(80, "Water 10 Lettuce Plants", DefaultTransformationCategories.WaterLettucePlant, 10, DefaultRewards.RewardXP5);

        public static readonly Quest Water3Wheat = new Quest(81, "Water 3 Wheat Plants", DefaultTransformationCategories.WaterWheatPlant, 3, DefaultRewards.RewardXP5);
        public static readonly Quest Water5Wheat = new Quest(82, "Water 5 Wheat Plants", DefaultTransformationCategories.WaterWheatPlant, 5, DefaultRewards.RewardXP5);
        public static readonly Quest Water7Wheat = new Quest(83, "Water 7 Wheat Plants", DefaultTransformationCategories.WaterWheatPlant, 7, DefaultRewards.RewardXP5);
        public static readonly Quest Water10Wheat = new Quest(84, "Water 10 Wheat Plants", DefaultTransformationCategories.WaterWheatPlant, 10, DefaultRewards.RewardXP5);

        public static readonly Quest Water3Tomatoes = new Quest(85, "Water 3 Tomato Plants", DefaultTransformationCategories.WaterTomatoPlant, 3, DefaultRewards.RewardXP5);
        public static readonly Quest Water5Tomatoes = new Quest(86, "Water 5 Tomato Plants", DefaultTransformationCategories.WaterTomatoPlant, 5, DefaultRewards.RewardXP5);
        public static readonly Quest Water7Tomatoes = new Quest(87, "Water 7 Tomato Plants", DefaultTransformationCategories.WaterTomatoPlant, 7, DefaultRewards.RewardXP5);
        public static readonly Quest Water10Tomatoes = new Quest(88, "Water 10 Tomato Plants", DefaultTransformationCategories.WaterTomatoPlant, 10, DefaultRewards.RewardXP5);

        public static readonly Quest Collect3Lettuce = new Quest(89, "Collect 3 Lettuce", DefaultTransformations.LettuceTransformations.LettuceTransformation_5, 3, DefaultRewards.RewardXP5);
        public static readonly Quest Collect5Lettuce = new Quest(90, "Collect 5 Lettuce", DefaultTransformations.LettuceTransformations.LettuceTransformation_5, 5, DefaultRewards.RewardXP5);
        public static readonly Quest Collect7Lettuce = new Quest(91, "Collect 7 Lettuce", DefaultTransformations.LettuceTransformations.LettuceTransformation_5, 7, DefaultRewards.RewardXP5);
        public static readonly Quest Collect10Lettuce = new Quest(92, "Collect 10 Lettuce", DefaultTransformations.LettuceTransformations.LettuceTransformation_5, 10, DefaultRewards.RewardXP5);

        public static readonly Quest Collect3Tomatoes = new Quest(93, "Collect 3 Tomatoes", DefaultTransformations.TomatoTransformations.TomatoTransformation_5, 3, DefaultRewards.RewardXP5);
        public static readonly Quest Collect5Tomatoes = new Quest(94, "Collect 5 Tomatoes", DefaultTransformations.TomatoTransformations.TomatoTransformation_5, 5, DefaultRewards.RewardXP5);
        public static readonly Quest Collect7Tomatoes = new Quest(95, "Collect 7 Tomatoes", DefaultTransformations.TomatoTransformations.TomatoTransformation_5, 7, DefaultRewards.RewardXP5);
        public static readonly Quest Collect10Tomatoes = new Quest(96, "Collect 10 Tomatoes", DefaultTransformations.TomatoTransformations.TomatoTransformation_5, 10, DefaultRewards.RewardXP5);
       
        public static readonly Quest Collect3Wheat = new Quest(97, "Collect 3 Wheat", DefaultTransformations.WheatTransformations.WheatTransformation_5, 3, DefaultRewards.RewardXP5);
        public static readonly Quest Collect5Wheat = new Quest(98, "Collect 5 Wheat", DefaultTransformations.WheatTransformations.WheatTransformation_5, 5, DefaultRewards.RewardXP5);
        public static readonly Quest Collect7Wheat = new Quest(99, "Collect 7 Wheat", DefaultTransformations.WheatTransformations.WheatTransformation_5, 7, DefaultRewards.RewardXP5);
        public static readonly Quest Collect10Wheat = new Quest(100, "Collect 10 Wheat", DefaultTransformations.WheatTransformations.WheatTransformation_5, 10, DefaultRewards.RewardXP5);

        public static readonly Quest Collect3Crystals = new Quest(101, "Collect 3 Crystals", DefaultTransformations.ToolsTransformations.CrystalClickTransformation, 3, DefaultRewards.RewardXP5);
        public static readonly Quest Collect5Crystals = new Quest(102, "Collect 5 Crystals", DefaultTransformations.ToolsTransformations.CrystalClickTransformation, 5, DefaultRewards.RewardXP5);
        public static readonly Quest Collect7Crystals = new Quest(103, "Collect 7 Crystals", DefaultTransformations.ToolsTransformations.CrystalClickTransformation, 7, DefaultRewards.RewardXP5);


        public static readonly Quest Collect3BismuthIngot = new Quest(104, "Collect 3 Bismuth Ingot", DefaultTransformations.MachinesTransformations.FurnaceSmeltingBismuthClickTransformation, 3, DefaultRewards.RewardXP5);
        public static readonly Quest Collect5BismuthIngot = new Quest(105, "Collect 5 Bismuth Ingot", DefaultTransformations.MachinesTransformations.FurnaceSmeltingBismuthClickTransformation, 5, DefaultRewards.RewardXP5);
        public static readonly Quest Collect7BismuthIngot = new Quest(106, "Collect 7 Bismuth Ingot", DefaultTransformations.MachinesTransformations.FurnaceSmeltingBismuthClickTransformation, 7, DefaultRewards.RewardXP5);

        
        public static List<Quest> GetAll()
        {
            return new List<Quest>
            {
                Craft3PinkFloors,
                Craft3PurpleFloors,
                Craft3Walls,
                Craft5PinkFloors,
                Craft5PurpleFloors,
                Craft5Walls,
                Craft7PinkFloors,
                Craft7PurpleFloors,
                Craft7Walls,
                Craft10PinkFloors,
                Craft10PurpleFloors,
                Craft10Walls,
                Craft3GreenChairs,
                Craft5GreenChairs,
                Craft7GreenChairs,
                Craft10GreenChairs,
                Craft3PinkChairs,
                Craft5PinkChairs,
                Craft7PinkChairs,
                Craft10PinkChairs,
                Craft3RoundPinkTable,
                Craft5RoundPinkTable,
                Craft7RoundPinkTable,
                Craft10RoundPinkTable,
                Craft3RoundPurpleTable,
                Craft5RoundPurpleTable,
                Craft7RoundPurpleTable,
                Craft10RoundPurpleTable,
                Craft3GreenTable,
                Craft5GreenTable,
                Craft7GreenTable,
                Craft10GreenTable,
                Craft5Menus,
                Craft7Menus,
                Craft5PlanetSigns,
                Craft7PlanetSigns,
                Craft4Fences,
                Craft8Fences,
                Craft3Window,
                Craft5Window,
                Cook1Croissant,
                Cook3Croissant,
                Cook5Croissant,
                Cook1Cupcake,
                Cook3Cupcake,
                Cook5Cupcake,
                Cook1Burger,
                Cook3Burger,
                Cook5Burger,
                Cook1Pizza,
                Cook3Pizza,
                Cook5Pizza,
                Cook1MacAndCheese,
                Cook3MacAndCheese,
                Cook5MacAndCheese,
                Make1Salad,
                Make3Salad,
                Make5Salad,
                Cook1Shawarma,
                Cook3Shawarma,
                Cook5Shawarma,
                Blend1Smoothie,
                Blend3Smoothie,
                Blend5Smoothie,
                Plant3Tomatoes,
                Plant5Tomatoes,
                Plant7Tomatoes,
                Plant10Tomatoes,
                Plant3Lettuce,
                Plant5Lettuce,
                Plant7Lettuce,
                Plant10Lettuce,
                Plant3Wheat,
                Plant5Wheat,
                Plant7Wheat,
                Plant10Wheat,
                Water3Tomatoes,
                Water5Tomatoes,
                Water7Tomatoes,
                Water10Tomatoes,
                Water3Lettuce,
                Water5Lettuce,
                Water7Lettuce,
                Water10Lettuce,
                Water3Wheat,
                Water5Wheat,
                Water7Wheat,
                Water10Wheat,
                Collect3Lettuce,
                Collect5Lettuce,
                Collect7Lettuce,
                Collect10Lettuce,
                Collect3Tomatoes,
                Collect5Tomatoes,
                Collect7Tomatoes,
                Collect10Tomatoes,
                Collect3Wheat,
                Collect5Wheat,
                Collect7Wheat,
                Collect10Wheat,
                Collect3Crystals,
                Collect5Crystals,
                Collect7Crystals,
                Collect3BismuthIngot,
                Collect5BismuthIngot,
                Collect7BismuthIngot
            };
        }
    }
}



