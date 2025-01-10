using System.Collections.Generic;
using static VisionsContracts.Items.DefaultItems;
using VisionsContracts.Items;
using VisionsContracts.Land.Model;

namespace VisionsContracts.TestScenarios
{
    public static class LandScenarios
    {

        public static List<LandItem> GetDefaultStartUpLand()
        {
            var landItems = new List<LandItem>();
            var raw1 = new List<int> { 0, 0, RawMaterials.CRYSTAL.Id, Bushes.RASPBERRY_BUSH.Id, 0, Trees.AVOCADO_TREE.Id, RawMaterials.CRYSTAL.Id, Animals.COW.Id, Grass.GRASS_TOMATO.Id, 0 };
            var raw2 = new List<int> { 0, Grass.GRASS_SALAD.Id, RawMaterials.BISMUTH.Id, Bushes.RASPBERRY_BUSH.Id, 0, RawMaterials.STICKS.Id, 0, 0, 0, RawMaterials.STICKS.Id };
            var raw3 = new List<int> { Trees.AVOCADO_TREE.Id, 0, 0, 0, Animals.COW.Id, 0, 0, Bushes.RASPBERRY_BUSH.Id, Grass.GRASS_WHEAT.Id, RawMaterials.STICKS.Id };
            var raw4 = new List<int> { 0, 0, 0, 0, 0, Trees.AVOCADO_TREE.Id, RawMaterials.STICKS.Id, Grass.GRASS_WHEAT.Id, RawMaterials.CLAY.Id, RawMaterials.CRYSTAL.Id };
            var raw5 = new List<int> { 0, Trees.SUGAR_TREE.Id, Grass.GRASS_WHEAT.Id, Bushes.COFFEE_BUSH.Id, 0, 0, Trees.SUGAR_TREE.Id, RawMaterials.STICKS.Id, 0, RawMaterials.CRYSTAL.Id };
            var raw6 = new List<int> { 0, 0, 0, Grass.GRASS_WHEAT.Id, Bushes.RASPBERRY_BUSH.Id, 0, 0, RawMaterials.CLAY.Id, 0, RawMaterials.BISMUTH.Id };
            var raw7 = new List<int> { Grass.GRASS_WHEAT.Id, Grass.GRASS_WHEAT.Id, 0, Bushes.COFFEE_BUSH.Id, 0, 0, 0, 0, 0, RawMaterials.BISMUTH.Id };
            var raw8 = new List<int> { 0, Bushes.RASPBERRY_BUSH.Id, 0, Grass.GRASS_TOMATO.Id, 0, Grass.GRASS_WHEAT.Id, 0, 0, 0, Grass.GRASS_WHEAT.Id };
            var raw9 = new List<int> { Trees.BANANA_TREE.Id, RawMaterials.CLAY.Id, 0, 0, Trees.OLIVE_TREE.Id, Grass.GRASS_TOMATO.Id, Animals.CHICKEN.Id, RawMaterials.CRYSTAL.Id, Trees.AVOCADO_TREE.Id, Trees.SUGAR_TREE.Id };
            var raw10 = new List<int> { 0, Trees.SIMPLE_TREE.Id, Animals.COW.Id, RawMaterials.STICKS.Id, Trees.SIMPLE_TREE.Id, Grass.GRASS_TOMATO.Id, Grass.GRASS_WHEAT.Id, 0, Grass.GRASS_SALAD.Id, Trees.SIMPLE_TREE.Id };

            AddItems(raw1, 0, landItems);
            AddItems(raw2, 1, landItems);
            AddItems(raw3, 2, landItems);
            AddItems(raw4, 3, landItems);
            AddItems(raw5, 4, landItems);
            AddItems(raw6, 5, landItems);
            AddItems(raw7, 6, landItems);
            AddItems(raw8, 7, landItems);
            AddItems(raw9, 8, landItems);
            AddItems(raw10, 9, landItems);

            return landItems;
        }





        public static List<LandItem> GetGrassLand()
        {
            var landItems = new List<LandItem>();
            var raw1 = new List<int> { 0, 0, 0 , 0, 0, 0, 0, 0, 0, 0};
            var raw2 = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var raw3 = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var raw4 = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var raw5 = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var raw6 = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var raw7 = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var raw8 = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var raw9 = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var raw10 = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            AddItems(raw1, 0, landItems);
            AddItems(raw2, 1, landItems);
            AddItems(raw3, 2, landItems);
            AddItems(raw4, 3, landItems);
            AddItems(raw5, 4, landItems);
            AddItems(raw6, 5, landItems);
            AddItems(raw7, 6, landItems);
            AddItems(raw8, 7, landItems);
            AddItems(raw9, 8, landItems);
            AddItems(raw10, 9, landItems);

            return landItems;
        }



        public static List<LandItem> GetCrystalLand()
        {
            var landItems = new List<LandItem>();
            var raw1 = new List<int> { RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id };
            var raw2 = new List<int> { RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id };
            var raw3 = new List<int> { RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id };
            var raw4 = new List<int> { RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id };
            var raw5 = new List<int> { RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id };
            var raw6 = new List<int> { RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id };
            var raw7 = new List<int> { RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id };
            var raw8 = new List<int> { RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id };
            var raw9 = new List<int> { RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id };
            var raw10 = new List<int> { RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id };

            AddItems(raw1, 0, landItems);
            AddItems(raw2, 1, landItems);
            AddItems(raw3, 2, landItems);
            AddItems(raw4, 3, landItems);
            AddItems(raw5, 4, landItems);
            AddItems(raw6, 5, landItems);
            AddItems(raw7, 6, landItems);
            AddItems(raw8, 7, landItems);
            AddItems(raw9, 8, landItems);
            AddItems(raw10, 9, landItems);

            return landItems;
        }

        public static List<LandItem> GetPlantGrownLand()
        {
            var landItems = new List<LandItem>();
            var raw1 = new List<int> { Tomato.TOMATO_GROWN.Id, Tomato.TOMATO_GROWN.Id, Tomato.TOMATO_GROWN.Id, Tomato.TOMATO_GROWN.Id, Tomato.TOMATO_GROWN.Id, Tomato.TOMATO_GROWN.Id, Tomato.TOMATO_GROWN.Id, Tomato.TOMATO_GROWN.Id, Tomato.TOMATO_GROWN.Id, Tomato.TOMATO_GROWN.Id };
            var raw2 = new List<int> { Lettuce.LETTUCE_GROWN.Id, Lettuce.LETTUCE_GROWN.Id, Lettuce.LETTUCE_GROWN.Id, Lettuce.LETTUCE_GROWN.Id, Lettuce.LETTUCE_GROWN.Id, Lettuce.LETTUCE_GROWN.Id, Lettuce.LETTUCE_GROWN.Id, Lettuce.LETTUCE_GROWN.Id, Lettuce.LETTUCE_GROWN.Id, Lettuce.LETTUCE_GROWN.Id };
            var raw3 = new List<int> { Wheat.WHEAT_GROWN.Id, Wheat.WHEAT_GROWN.Id,  Wheat.WHEAT_GROWN.Id,  Wheat.WHEAT_GROWN.Id,  Wheat.WHEAT_GROWN.Id,  Wheat.WHEAT_GROWN.Id,  Wheat.WHEAT_GROWN.Id,  Wheat.WHEAT_GROWN.Id,  Wheat.WHEAT_GROWN.Id,  Wheat.WHEAT_GROWN.Id };
            var raw4 = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var raw5 = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var raw6 = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var raw7 = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var raw8 = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var raw9 = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var raw10 = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            AddItems(raw1, 0, landItems);
            AddItems(raw2, 1, landItems);
            AddItems(raw3, 2, landItems);
            AddItems(raw4, 3, landItems);
            AddItems(raw5, 4, landItems);
            AddItems(raw6, 5, landItems);
            AddItems(raw7, 6, landItems);
            AddItems(raw8, 7, landItems);
            AddItems(raw9, 8, landItems);
            AddItems(raw10, 9, landItems);

            return landItems;
        }

        public static List<LandItem> GetDefaultStartUpLandWithFloorBarTableAndUtensils()
        {
            var landItems = new List<LandItem>();
            var raw1 = new List<int> { 0, 0, RawMaterials.CRYSTAL.Id, Bushes.RASPBERRY_BUSH.Id, 0, Trees.AVOCADO_TREE.Id, RawMaterials.CRYSTAL.Id, Animals.COW.Id, Grass.GRASS_TOMATO.Id, 0 };
            var raw2 = new List<int> { 0, Grass.GRASS_SALAD.Id, RawMaterials.BISMUTH.Id, Bushes.RASPBERRY_BUSH.Id, 0, RawMaterials.STICKS.Id, 0, 0, 0, RawMaterials.STICKS.Id };
            var raw3 = new List<int> { Trees.AVOCADO_TREE.Id, 0, 0, 0, Animals.COW.Id, 0, 0, Bushes.RASPBERRY_BUSH.Id, Grass.GRASS_WHEAT.Id, RawMaterials.STICKS.Id };
            var raw4 = new List<int> { 0, 0, 0, 0, 0, Trees.AVOCADO_TREE.Id, RawMaterials.STICKS.Id, Grass.GRASS_WHEAT.Id, RawMaterials.CLAY.Id, RawMaterials.CRYSTAL.Id };
            var raw5 = new List<int> { 0, Trees.SUGAR_TREE.Id, Grass.GRASS_WHEAT.Id, Bushes.COFFEE_BUSH.Id, Decorations.PINK_FLOOR.Id, Decorations.PINK_FLOOR.Id, Decorations.PINK_FLOOR.Id, Decorations.PINK_FLOOR.Id, Decorations.PINK_FLOOR.Id, Decorations.PINK_FLOOR.Id };
            var raw6 = new List<int> { 0, 0, 0, Grass.GRASS_WHEAT.Id, Bushes.RASPBERRY_BUSH.Id, Decorations.PINK_FLOOR.Id, Decorations.PINK_FLOOR.Id, Decorations.PINK_FLOOR.Id, Decorations.PINK_FLOOR.Id, Decorations.PINK_FLOOR.Id };
            var raw7 = new List<int> { Grass.GRASS_WHEAT.Id, Grass.GRASS_WHEAT.Id, 0, Bushes.COFFEE_BUSH.Id, Decorations.PINK_FLOOR.Id, Decorations.PINK_FLOOR.Id, Decorations.PINK_FLOOR.Id, Decorations.PINK_FLOOR.Id, Decorations.PINK_FLOOR.Id, Decorations.PINK_FLOOR.Id };
            var raw8 = new List<int> { 0, Bushes.RASPBERRY_BUSH.Id, 0, Grass.GRASS_TOMATO.Id, 0, Decorations.PINK_FLOOR.Id, Decorations.PINK_FLOOR.Id, Decorations.PINK_FLOOR.Id, Decorations.PINK_FLOOR.Id, Decorations.PINK_FLOOR.Id };
            var raw9 = new List<int> { Trees.BANANA_TREE.Id, RawMaterials.CLAY.Id, 0, 0, Trees.OLIVE_TREE.Id, Grass.GRASS_TOMATO.Id, Animals.CHICKEN.Id, RawMaterials.CRYSTAL.Id, Trees.AVOCADO_TREE.Id, Trees.SUGAR_TREE.Id };
            var raw10 = new List<int> { 0, Trees.SIMPLE_TREE.Id, Animals.COW.Id, RawMaterials.STICKS.Id, 0, Grass.GRASS_TOMATO.Id, Grass.GRASS_WHEAT.Id, 0, Grass.GRASS_SALAD.Id, 0 };

            AddItems(raw1, 0, landItems);
            AddItems(raw2, 1, landItems);
            AddItems(raw3, 2, landItems);
            AddItems(raw4, 3, landItems);
            AddItems(raw5, 4, landItems);
            AddItems(raw6, 5, landItems);
            AddItems(raw7, 6, landItems);
            AddItems(raw8, 7, landItems);
            AddItems(raw9, 8, landItems);
            AddItems(raw10, 9, landItems);

            //landItems.Add(new LandItem() { ItemId = Furniture.BAR_TABLE.Id, StackIndex = 1, X = 7, Y = 5 });
            //landItems.Add(new LandItem() { ItemId = Furniture.BAR_TABLE.Id, StackIndex = 1, X = 7, Y = 6 });
            //landItems.Add(new LandItem() { ItemId = Furniture.BAR_TABLE.Id, StackIndex = 1, X = 7, Y = 7 });
            //landItems.Add(new LandItem() { ItemId = Furniture.BAR_TABLE.Id, StackIndex = 1, X = 7, Y = 8 });


            //landItems.Add(new LandItem() { ItemId = Cooking.COFFEE_MACHINE.Id, StackIndex = 2, X = 7, Y = 5 });
            //landItems.Add(new LandItem() { ItemId = Cooking.BLENDER.Id, StackIndex = 2, X = 7, Y = 6 });
            //landItems.Add(new LandItem() { ItemId = Cooking.CUTTING_BOARD.Id, StackIndex = 2, X = 7, Y = 7 });


            return landItems;
        }


        public static List<LandItem> Get1CellLand()
        {
            var landItems = new List<LandItem>();
            var raw1 = new List<int> { 0 };

            AddItems(raw1, 0, landItems);
            
            return landItems;
        }


        public static List<LandItem> GetBlankLand()
        {
            var landItems = new List<LandItem>();
            var raw1 = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var raw2 = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var raw3 = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var raw4 = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var raw5 = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var raw6 = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var raw7 = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var raw8 = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var raw9 = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var raw10 = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            AddItems(raw1, 0, landItems);
            AddItems(raw2, 1, landItems);
            AddItems(raw3, 2, landItems);
            AddItems(raw4, 3, landItems);
            AddItems(raw5, 4, landItems);
            AddItems(raw6, 5, landItems);
            AddItems(raw7, 6, landItems);
            AddItems(raw8, 7, landItems);
            AddItems(raw9, 8, landItems);
            AddItems(raw10, 9, landItems);

            return landItems;
        }
        
        public static List<LandItem> GetFloorland()
        {
            var landItems = new List<LandItem>();
            var raw1 = new List<int> {  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id };
            var raw2 = new List<int> {  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id };
            var raw3 = new List<int> {  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id };
            var raw4 = new List<int> {  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id };
            var raw5 = new List<int> {  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id };
            var raw6 = new List<int> {  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id };
            var raw7 = new List<int> {  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id };
            var raw8 = new List<int> {  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id };
            var raw9 = new List<int> {  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id };
            var raw10 = new List<int> {  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id,  DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id };

            AddItems(raw1, 0, landItems);
            AddItems(raw2, 1, landItems);
            AddItems(raw3, 2, landItems);
            AddItems(raw4, 3, landItems);
            AddItems(raw5, 4, landItems);
            AddItems(raw6, 5, landItems);
            AddItems(raw7, 6, landItems);
            AddItems(raw8, 7, landItems);
            AddItems(raw9, 8, landItems);
            AddItems(raw10, 9, landItems);

            return landItems;
        }


        public static List<LandItem> GetCookingland()
        {
            var landItems = new List<LandItem>();
            var raw1 = new List<int> { DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id };
            var raw2 = new List<int> { DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id };
            var raw3 = new List<int> { DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id };
            var raw4 = new List<int> { DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id };
            var raw5 = new List<int> { DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id };
            var raw6 = new List<int> { DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id };
            var raw7 = new List<int> { DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id };
            var raw8 = new List<int> { DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id };
            var raw9 = new List<int> { DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id };
            var raw10 = new List<int> { DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id, DefaultItems.Decorations.PINK_FLOOR.Id };

            AddItems(raw1, 0, landItems);
            AddItems(raw2, 1, landItems);
            AddItems(raw3, 2, landItems);
            AddItems(raw4, 3, landItems);
            AddItems(raw5, 4, landItems);
            AddItems(raw6, 5, landItems);
            AddItems(raw7, 6, landItems);
            AddItems(raw8, 7, landItems);
            AddItems(raw9, 8, landItems);
            AddItems(raw10, 9, landItems);

            landItems.Add(new LandItem() { ItemId = Cooking.BASIC_OVEN.Id, StackIndex = 1, X = 0, Y = 0 });
            landItems.Add(new LandItem() { ItemId = Cooking.CRAZY_OVEN.Id, StackIndex = 1, X = 1, Y = 0 });
            landItems.Add(new LandItem() { ItemId = Furniture.BAR_COUNTER.Id, StackIndex = 1, X = 2, Y = 0 });
            landItems.Add(new LandItem() { ItemId = Furniture.BAR_COUNTER.Id, StackIndex = 1, X = 3, Y = 0 });
            landItems.Add(new LandItem() { ItemId = Furniture.BAR_COUNTER.Id, StackIndex = 1, X = 4, Y = 0 });
            landItems.Add(new LandItem() { ItemId = Furniture.BAR_COUNTER.Id, StackIndex = 1, X = 5, Y = 0 });
            landItems.Add(new LandItem() { ItemId = Furniture.BAR_COUNTER.Id, StackIndex = 1, X = 6, Y = 0 });
            landItems.Add(new LandItem() { ItemId = Furniture.BAR_COUNTER.Id, StackIndex = 1, X = 7, Y = 0 });
            landItems.Add(new LandItem() { ItemId = Furniture.BAR_COUNTER.Id, StackIndex = 1, X = 8, Y = 0 });
            landItems.Add(new LandItem() { ItemId = Furniture.BAR_COUNTER.Id, StackIndex = 1, X = 9, Y = 0 });

            landItems.Add(new LandItem() { ItemId = Cooking.BLENDER.Id, StackIndex = 2, X = 2, Y = 0 });
            landItems.Add(new LandItem() { ItemId = Cooking.COFFEE_MACHINE.Id, StackIndex = 2, X = 3, Y = 0 });
            landItems.Add(new LandItem() { ItemId = Cooking.CRAZY_BLENDER.Id, StackIndex = 2, X = 4, Y = 0 });
            landItems.Add(new LandItem() { ItemId = Cooking.CRAZY_COFFEE_MACHINE.Id, StackIndex = 2, X = 5, Y = 0 });
            landItems.Add(new LandItem() { ItemId = Cooking.CRAZY_CUTTING_BOARD.Id, StackIndex = 2, X = 6, Y = 0 });
            landItems.Add(new LandItem() { ItemId = Cooking.CUTTING_BOARD.Id, StackIndex = 2, X = 7, Y = 0 });
            landItems.Add(new LandItem() { ItemId = Cooking.KEBAB_MAKER.Id, StackIndex = 2, X = 8, Y = 0 });


            landItems.Add(new LandItem() { ItemId = Furniture.GREEN_CHAIR.Id, StackIndex = 1, X = 2, Y = 2 });
            landItems.Add(new LandItem() { ItemId = Furniture.GREEN_TABLE.Id, StackIndex = 1, X = 2, Y = 3 });
            
            return landItems;
        }

        private static void AddItems(List<int> items, int rawNumber, List<LandItem> landItems)
        {
            for (int y = 0; y < items.Count; y++)
            {
                landItems.Add(new() { ItemId = items[y], X = rawNumber, Y = y });
            }
        }
    }
}
