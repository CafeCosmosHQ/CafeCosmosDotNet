using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;

using VisionsContracts.Items.Model;
using VisionsContracts.Land.Model;
using VisionsContracts.Redistributor;


namespace VisionsContracts.Items
{

     public partial class DefaultItems
    {
        public const int UNKNOWNID = 1000000000;
        public static Item FindItemById(BigInteger id)
        {
            var allItems = GetAllItems();
            return allItems.FirstOrDefault(x => x.Id == id);
        }

        public static IEnumerable<Item> FindItemsByName(string name)
        {
            return GetAllItems().Where(x => x.Name.ToLower().Contains(name.ToLower()));
        }

        public static List<Item> GetAllSeedItems()
        {
            return new List<Item>
            {
                Tomato.TOMATO_SEED,
                Wheat.WHEAT_SEED,
                Lettuce.LETTUCE_SEED
            };
        }

        public static List<Item> GetAllRotatableItems()
        {
            return GetAllItems().Where(x => x.IsRotatable).ToList();
        }

        public static bool IsItemRotatable(BigInteger itemId)
        {
            return GetAllRotatableItems().Any(x => x.Id == itemId);
        }

        public static List<Item> GetAllInventoryItems()
        {
            return GetAllItems().Where(x => x.IsInventory).ToList();
        }

        public static List<Item> GetAllNonRemovableItems()
        {
            return GetAllItems().Where(x => !x.IsRemovable).ToList();
        }

        public static List<Item> GetAllNonPlaceableItems()
        {
            return GetAllItems().Where(x => !x.IsPlaceable).ToList();
        }

        public static List<Item> GetAllPlaceableItems()
        {
            return GetAllItems().Where(x => x.IsPlaceable).ToList();
        }

        public static List<Item> GetAllRedistributionRecipes()
        {
            return GetAllItems().Where(x => x.SubSection != null).ToList();
        }


        public static List<Item> GetDefaultLandTools()
        {
            return GetAllItems().Where(x => x.IsTool).ToList();
        }

        public static List<Item> GetTables()
        {
            var defaultTables =  new List<Item> { Furniture.PINK_TABLE, Furniture.GREEN_TABLE, Furniture.PURPLE_TABLE };
            return defaultTables.Concat(ThemeService.GetTables()).ToList();
        }

        public static bool IsCookingState(BigInteger id)
        {
            return GetAllCookingStateItems().Any(x => x.Id == id);
        }

        public static List<Item> GetAllCookingStateItems()
        {
            return GetAllItems().Where(x => x.IsCookingState == true).ToList();
        }

        public static bool IsChair(BigInteger id)
        {
            return GetChairs().Any(x => x.Id == id);
        }

        public static bool IsTable(BigInteger id)
        {
            return GetTables().Any(x => x.Id == id);
        }

        public static List<Item> GetCounters()
        {
            var defaultCounters = new List<Item> { Furniture.BAR_COUNTER};
            return defaultCounters.Concat(ThemeService.GetCounters()).ToList();
        }

        public static List<Item> GetFloors()
        {
            var defaultFloors = new List<Item> { Decorations.PINK_FLOOR, Decorations.PURPLE_FLOOR};
            return defaultFloors.Concat(ThemeService.GetFloors()).ToList();
        }
        public static List<Item> GetFloorStackableItems()
        {
            var defaultFloorStackableItems = new List<Item>
            {
                // Furniture
                Furniture.GREEN_CHAIR, Furniture.PINK_CHAIR, Furniture.PURPLE_TABLE, Furniture.PINK_TABLE, Furniture.GREEN_TABLE, Furniture.BAR_COUNTER,
                // Machines
                Machines.CHEESE_MAKER, Machines.FURNACE_SMELTER, Machines.ROBOT,
                // Cooking
                Cooking.BASIC_OVEN, Cooking.CRAZY_OVEN,
                // Decorations
                Decorations.PLANT
            };

            return defaultFloorStackableItems.Concat(ThemeService.GetAllFloorStackableItems()).ToList();
        }


        public static List<Item> GetCounterStackableItems()
        {
            var defaultCounterStackableItems = new List<Item>
            {
                // Machines
                Machines.MIXER, Machines.BUTTER_CHURNER, Machines.OLIVE_PRESS, Machines.PASTA_MACHINE,
                // Cooking
                Cooking.COFFEE_MACHINE, Cooking.CRAZY_COFFEE_MACHINE, Cooking.CUTTING_BOARD, Cooking.CRAZY_CUTTING_BOARD,
                Cooking.BLENDER, Cooking.CRAZY_BLENDER, Cooking.KEBAB_MAKER
            };

            return defaultCounterStackableItems.Concat(ThemeService.GetCounterStackableItems()).ToList();
        }


        public static List<Item> GetChairs()
        {
            var defaultChairs = new List<Item> { Furniture.PINK_CHAIR, Furniture.GREEN_CHAIR };
            return defaultChairs.Concat(ThemeService.GetChairs()).ToList();
        }

        public static bool IsFurnaceOrWaterWell(LandItem landItem)
        {
            int id = (int)landItem.ItemId;
            return
                id == DefaultItems.Machines.FURNACE_SMELTER.Id ||
                id == DefaultItems.Machines.FURNACE_SMELTING_BISMUTH.Id ||
                id == DefaultItems.Machines.WATER_WELL.Id ||
                id == DefaultItems.Machines.WATER_WELL_GIVING_WATER.Id;
        }

        public static IList<IItemsCategoryList> GetAllItemsCategories()
        {

            var items = new List<IItemsCategoryList>
            {
                Ingredients.Instance,
                RawMaterials.Instance,
                Misc.Instance,
                Recipes.Instance,
                Gardening.Instance,
                Lettuce.Instance,
                Wheat.Instance,
                Grass.Instance,
                Bushes.Instance,
                Tomato.Instance,
                Trees.Instance,
                Machines.Instance,
                Cooking.Instance,
                Furniture.Instance,
                Decorations.Instance,
                Animals.Instance,
                Buckets.Instance,
                Tools.Instance

            };
            return items;

        }


        public static List<Item> GetAllItems()
        {
            var list = new List<Item>();
            foreach (var category in GetAllItemsCategories())
            {
                list.AddRange(category.GetDefaultItems());
            }

            var themeItems = ThemeService.GetAllItems();
            return list.Concat(themeItems).ToList();
            
        }





        public class Ingredients : ItemsCategoryList<Ingredients> //note to add placeable in the grid and as a transformation
        {
            public static readonly Item AVOCADO = new(name: "Avocado", id: 1, category: ItemCategory.Ingredients, isTool: false, isPlaceable: false, isRotatable: false, isInventory: true, isRemovable: false);
            public static readonly Item BANANAS = new(name: "Bananas", id: 2, category: ItemCategory.Ingredients, isTool: false, isPlaceable: false, isRotatable: false, isInventory: true, isRemovable: false);
            public static readonly Item BUTTER = new("Butter", 3, ItemCategory.Ingredients, false, false, false, true, false);
            public static readonly Item CHEESE = new("Cheese", 4, ItemCategory.Ingredients, false, false, false, true, false);
            public static readonly Item DOUGH = new("Dough", 6, ItemCategory.Ingredients, false, false, false, true, false); //placeable as transformation
            public static readonly Item DUST = new("Dust", 7, ItemCategory.Ingredients, false, false, false, true, false); // outcome of many transformations timeout
            public static readonly Item EGG = new("Egg", 8, ItemCategory.Ingredients, false, false, false, true, false);
            public static readonly Item FLOUR = new("Flour", 9, ItemCategory.Ingredients, false, false, false, true, false); //placeable as transformation
            public static readonly Item HAM = new("Ham", 10, ItemCategory.Ingredients, false, false, false, true, false);
            public static readonly Item MEAT = new("Meat", 11, ItemCategory.Ingredients, false, false, false, true, false);
            public static readonly Item RASPBERRY = new("Raspberry", 12, ItemCategory.Ingredients, false, false, false, true, false);
            public static readonly Item SUGAR = new("Sugar", 13, ItemCategory.Ingredients, false, false, false, true, false);
            public static readonly Item TOMATO = new("Tomato", 14, ItemCategory.Ingredients, false, false, false, true, false);


            public static readonly Item OLIVES = new("Olives", 15, ItemCategory.Ingredients, false, false, false, true, false); //placeable as transformation
            public static readonly Item OLIVE_OIL = new("Olive Oil", 16, ItemCategory.Ingredients, false, false, false, true, false);

            public static readonly Item WHIPPED_CREAM = new("Whipped Cream", 17, ItemCategory.Ingredients, false, false, false, true, false); //placeable as transformation

            public static readonly Item WHEAT = new("Wheat", 18, ItemCategory.Ingredients, false, false, false, true, false); //placeable as transformation
            public static readonly Item COFFEE_BEAN = new("Coffee Bean", 128, ItemCategory.Ingredients, false, false, false, true, false);

            public static readonly Item LETTUCE = new("Lettuce", 129, ItemCategory.Ingredients, false, false, false, true, false);

            public static readonly Item PASTA = new(name: "Pasta", id: 983, category: ItemCategory.Ingredients, isTool: false, isPlaceable: false, isRotatable: false, isInventory: true, isRemovable: false); // cooking ingredient



            public static readonly List<Item> Default = new() {
                                                                    AVOCADO,
                                                                    BANANAS,
                                                                    BUTTER,
                                                                    CHEESE,
                                                                    DOUGH,
                                                                    DUST,
                                                                    EGG,
                                                                    FLOUR,
                                                                    HAM,
                                                                    MEAT,
                                                                    RASPBERRY,
                                                                    SUGAR,
                                                                    TOMATO,
                                                                    OLIVES,
                                                                    OLIVE_OIL,
                                                                    WHIPPED_CREAM,
                                                                    WHEAT,
                                                                    COFFEE_BEAN,
                                                                    LETTUCE,
                                                                    PASTA,

                                                                    };
            public override List<Item> GetDefaultItems()
            {
                return Default;
            }
        }



        public class RawMaterials : ItemsCategoryList<RawMaterials>
        {
            public static readonly Item BISMUTH = new("Bismuth", 19, ItemCategory.RawMaterials, false, false, false, true, false);
            public static readonly Item CRYSTAL = new(name: "Crystal", id: 20, category: ItemCategory.RawMaterials, isTool: false, isPlaceable: false, isRotatable: false, isInventory: true, isRemovable: false); //hand
            public static readonly Item BISMUTH_INGOT = new("Bismuth Ingot", 21, ItemCategory.RawMaterials, false, false, false, true, false);
            public static readonly Item CLAY = new("Clay", 22, ItemCategory.RawMaterials, false, false, false, true, false); //pickaxe
            public static readonly Item STICKS = new(name: "Sticks", id: 23, category: ItemCategory.RawMaterials, isTool: false, isPlaceable: false, isRotatable: false, isInventory: true, isRemovable: false); //hand
            public static readonly Item WOOD_PURPLE = new("Purple Wood", 24, ItemCategory.RawMaterials, false, false, false, true, false);
            public static readonly Item WOOD_PINK = new("Pink Wood", 25, ItemCategory.RawMaterials, false, false, false, true, false);
            public static readonly Item BLACK_TRAPEZOID = new("Black Trapezoid", 1022, ItemCategory.Misc, false, false, false, true, false);

            public static readonly List<Item> Default = new() {
                                                               BISMUTH,
                                                               CRYSTAL,
                                                               BISMUTH_INGOT,
                                                               CLAY,
                                                               STICKS,
                                                               WOOD_PURPLE,
                                                               WOOD_PINK,
                                                               BLACK_TRAPEZOID,

                                                        };
            public override List<Item> GetDefaultItems()
            {
                return Default;
            }

        }

        public class Misc : ItemsCategoryList<Misc>
        {
            public static readonly Item FLUX_CAPACITOR = new("Flux Capacitor", 26, ItemCategory.Misc, false, false, false, true, false);
            public static readonly Item GLASS = new("Glass", 27, ItemCategory.Misc, false, false, false, true, false);
            public static readonly Item WIRE = new("Wire", 28, ItemCategory.Misc, false, false, false, true, false);
            public static readonly Item BLADE = new("Blade", 29, ItemCategory.Misc, false, false, false, true, false);
            public static readonly Item POLE = new("Pole", 1007, ItemCategory.Misc, false, false, false, true, false);



            public static readonly List<Item> Default = new() {
                                                             FLUX_CAPACITOR,
                                                             GLASS,
                                                             WIRE,
                                                             BLADE,
                                                             POLE,


                                                        };
            public override List<Item> GetDefaultItems()
            {
                return Default;
            }
        }





        public class Recipes : ItemsCategoryList<Recipes>
        {

            public static readonly Item CROISSANT = new("Croissant", 30, ItemCategory.Recipes, false, false, false, true, false, false, DefaultRedistributionSections.DESSERTS);
            public static readonly Item CUPCAKE = new("Cupcake", 31, ItemCategory.Recipes, false, false, false, true, false, false, DefaultRedistributionSections.DESSERTS);
            public static readonly Item SMOOTHIE = new("Smoothie", 32, ItemCategory.Recipes, false, false, false, true, false, false, DefaultRedistributionSections.DRINKS);
            public static readonly Item BANANA_MILKSHAKE = new("Banana Milk", 982, ItemCategory.Recipes, false, false, false, true, false, false, DefaultRedistributionSections.DRINKS);
            public static readonly Item BURGER = new("Burger", 33, ItemCategory.Recipes, false, false, false, true, false, false, DefaultRedistributionSections.MAINS);
            public static readonly Item PIZZA = new("Pizza", 34, ItemCategory.Recipes, false, false, false, true, false, false, DefaultRedistributionSections.MAINS);
            public static readonly Item SALAD = new("Salad", 123, ItemCategory.Recipes, false, false, false, true, false, false, DefaultRedistributionSections.MAINS);
            public static readonly Item SHAWARMA = new(name: "Shawarma", id: 911, category: ItemCategory.Recipes, isTool: false, isPlaceable: false, isRotatable: false, isInventory: true, isRemovable: false, isCookingState: false, subSection: DefaultRedistributionSections.MAINS);
            public static readonly Item COFFEE = new("Coffee", 5, ItemCategory.Ingredients, false, false, false, true, false, false, DefaultRedistributionSections.DRINKS);
            public static readonly Item MAC_AND_CHEESE = new("Mac and Cheese", 984, ItemCategory.Ingredients, false, false, false, true, false, false, DefaultRedistributionSections.MAINS);


            public static readonly List<Item> Default = new() {

                                                             CROISSANT,
                                                             CUPCAKE,
                                                             SMOOTHIE,
                                                             BANANA_MILKSHAKE,
                                                             BURGER,
                                                             PIZZA,
                                                             SALAD,
                                                             SHAWARMA,
                                                             COFFEE,
                                                             MAC_AND_CHEESE

                                                        };
            public override List<Item> GetDefaultItems()
            {
                return Default;
            }
        }



        public class Gardening : ItemsCategoryList<Gardening>
        {

            public static readonly Item FERTILIZER = new("Fertilizer", 35, ItemCategory.Gardening, false, false, false, true, false);
            public static readonly Item TILLED_SOIL = new("Tilled Soil", 36, ItemCategory.Gardening, false, false, false, false, false);

            public static readonly List<Item> Default = new() {

                                                             FERTILIZER,
                                                             TILLED_SOIL,
                                                        };
            public override List<Item> GetDefaultItems()
            {
                return Default;
            }
        }




        public class Lettuce : ItemsCategoryList<Lettuce>
        {

            public static readonly Item LETTUCE_SEED = new("Lettuce Seed", 37, ItemCategory.Lettuce, false, false, false, true, false);
            public static readonly Item LETTUCE_SMALL = new("Lettuce Small", 38, ItemCategory.Lettuce, false, false, false, false, false);
            public static readonly Item LETTUCE_MEDIUM = new("Lettuce Medium", 39, ItemCategory.Lettuce, false, false, false, false, false);
            public static readonly Item LETTUCE_ALMOST = new("Lettuce Almost", 40, ItemCategory.Lettuce, false, false, false, false, false);
            public static readonly Item LETTUCE_GROWN = new("Lettuce Grown", 41, ItemCategory.Lettuce, false, false, false, false, false);
            public static readonly Item LETTUCE_SMALL_DEAD = new("Lettuce Small Dead", 42, ItemCategory.Lettuce, false, false, false, false, false);
            public static readonly Item LETTUCE_MEDIUM_DEAD = new("Lettuce Medium Dead", 130, ItemCategory.Lettuce, false, false, false, false, false);
            public static readonly Item LETTUCE_ALMOST_DEAD = new("Lettuce Almost Dead", 131, ItemCategory.Lettuce, false, false, false, false, false);


            public static readonly List<Item> Default = new() {

                                                        LETTUCE_SEED,
                                                        LETTUCE_SMALL,
                                                        LETTUCE_MEDIUM,
                                                        LETTUCE_ALMOST,
                                                        LETTUCE_GROWN,
                                                        LETTUCE_SMALL_DEAD,
                                                        LETTUCE_MEDIUM_DEAD,
                                                        LETTUCE_ALMOST_DEAD,

                                                        };
            public override List<Item> GetDefaultItems()
            {
                return Default;
            }
        }

        public class Wheat : ItemsCategoryList<Wheat>
        {

            public static readonly Item WHEAT_SEED = new("Wheat Seed", 49, ItemCategory.Wheat, false, false, false, true, false);
            public static readonly Item WHEAT_SMALL = new("Wheat Small", 50, ItemCategory.Wheat, false, false, false, false, false);
            public static readonly Item WHEAT_MEDIUM = new("Wheat Medium", 51, ItemCategory.Wheat, false, false, false, false, false);
            public static readonly Item WHEAT_ALMOST = new("Wheat Almost", 52, ItemCategory.Wheat, false, false, false, false, false);
            public static readonly Item WHEAT_GROWN = new("Wheat Grown", 53, ItemCategory.Wheat, false, false, false, false, false);
            public static readonly Item WHEAT_SMALL_DEAD = new("Wheat Small Dead", 54, ItemCategory.Wheat, false, false, false, false, false);
            public static readonly Item WHEAT_MEDIUM_DEAD = new("Wheat Medium Dead", 134, ItemCategory.Wheat, false, false, false, false, false);
            public static readonly Item WHEAT_ALMOST_DEAD = new("Wheat Almost Dead", 135, ItemCategory.Wheat, false, false, false, false, false);


            public static readonly List<Item> Default = new() {

                                                         WHEAT_SEED,
                                                         WHEAT_SMALL,
                                                         WHEAT_MEDIUM,
                                                         WHEAT_ALMOST,
                                                         WHEAT_GROWN,
                                                         WHEAT_SMALL_DEAD,
                                                         WHEAT_MEDIUM_DEAD,
                                                         WHEAT_ALMOST_DEAD,

                                                        };
            public override List<Item> GetDefaultItems()
            {
                return Default;
            }
        }


        public class Grass : ItemsCategoryList<Grass>
        {
            public static readonly Item GRASS_SALAD = new(name: "Grass Lettuce", id: 55, category: ItemCategory.Grass, isTool: false, isPlaceable: false, isRotatable: false, isInventory: false, isRemovable: false);
            public static readonly Item GRASS_TOMATO = new("Grass Tomato", 113, ItemCategory.Grass, false, false, false, false, false);
            public static readonly Item GRASS_WHEAT = new("Grass Wheat", 114, ItemCategory.Grass, false, false, false, false, false);

            public static readonly List<Item> Default = new()
                                            {
                                                GRASS_SALAD,
                                                GRASS_TOMATO,
                                                GRASS_WHEAT,
                                            };

            public override List<Item> GetDefaultItems()
            {
                return Default;
            }
        }






        public class Bushes : ItemsCategoryList<Bushes>
        {
            public static readonly Item RASPBERRY_BUSH = new(name: "Raspberry Bush", id: 56, category: ItemCategory.Bushes, isTool: false, isPlaceable: false, isRotatable: false, isInventory: false, isRemovable: false);
            public static readonly Item COFFEE_BUSH = new("Coffee Bush", 57, ItemCategory.Bushes, false, false, false, false, false);
            public static readonly Item RASPBERRY_BUSH_EMPTY = new("Raspberry Bush Empty", 58, ItemCategory.Bushes, false, false, false, false, false);
            public static readonly Item COFFEE_BUSH_EMPTY = new("Coffee Bush Empty", 59, ItemCategory.Bushes, false, false, false, false, false);

            public static readonly List<Item> Default = new()
            {
                RASPBERRY_BUSH,
                COFFEE_BUSH,
                RASPBERRY_BUSH_EMPTY,
                COFFEE_BUSH_EMPTY,
            };

            public override List<Item> GetDefaultItems()
            {
                return Default;
            }
        }



        public class Tomato : ItemsCategoryList<Tomato>
        {
            public static readonly Item TOMATO_SEED = new("Tomato Seed", 43, ItemCategory.Tomato, false, false, false, true, false);
            public static readonly Item TOMATO_SMALL = new("Tomato Small", 44, ItemCategory.Tomato, false, false, false, false, false);
            public static readonly Item TOMATO_MEDIUM = new("Tomato Medium", 45, ItemCategory.Tomato, false, false, false, false, false);
            public static readonly Item TOMATO_ALMOST = new("Tomato Almost", 46, ItemCategory.Tomato, false, false, false, false, false);
            public static readonly Item TOMATO_GROWN = new("Tomato Grown", 47, ItemCategory.Tomato, false, false, false, false, false);
            public static readonly Item TOMATO_SMALL_DEAD = new("Tomato Small Dead", 48, ItemCategory.Tomato, false, false, false, false, false);
            public static readonly Item TOMATO_MEDIUM_DEAD = new("Tomato Medium Dead", 132, ItemCategory.Tomato, false, false, false, false, false);
            public static readonly Item TOMATO_ALMOST_DEAD = new("Tomato Almost Dead", 133, ItemCategory.Tomato, false, false, false, false, false);

            public static readonly List<Item> Default = new()
            {
                TOMATO_SEED,
                TOMATO_SMALL,
                TOMATO_MEDIUM,
                TOMATO_ALMOST,
                TOMATO_GROWN,
                TOMATO_SMALL_DEAD,
                TOMATO_MEDIUM_DEAD,
                TOMATO_ALMOST_DEAD,
            };

            public override List<Item> GetDefaultItems()
            {
                return Default;
            }
        }




        public class Trees : ItemsCategoryList<Trees>
        {
            public static readonly Item AVOCADO_TREE = new(name: "Avocado Tree", id: 60, category: ItemCategory.Trees, isTool: false, isPlaceable: false, isRotatable: false, isInventory: false, isRemovable: false);
            public static readonly Item BANANA_TREE = new(name: "Banana Tree", id: 61, category: ItemCategory.Trees, isTool: false, isPlaceable: false, isRotatable: false, isInventory: false, isRemovable: false);
            public static readonly Item OLIVE_TREE = new(name: "Olive Tree", id: 62, category: ItemCategory.Trees, isTool: false, isPlaceable: false, isRotatable: false, isInventory: false, isRemovable: false);
            public static readonly Item SUGAR_TREE = new(name: "Sugar Tree", id: 63, category: ItemCategory.Trees, isTool: false, isPlaceable: false, isRotatable: false, isInventory: false, isRemovable: false);
            public static readonly Item SIMPLE_TREE = new(name: "Simple Tree", id: 115, category: ItemCategory.Trees, isTool: false, isPlaceable: false, isRotatable: false, isInventory: false, isRemovable: false);
            public static readonly Item BIG_TREE = new(name: "Big Tree", id: 1009, category: ItemCategory.Trees, isTool: false, isPlaceable: false, isRotatable: false, isInventory: false, isRemovable: false);
            public static readonly Item AVOCADO_TREE_EMPTY = new(name: "Avocado Tree Empty", id: 64, category: ItemCategory.Trees, isTool: false, isPlaceable: false, isRotatable: false, isInventory: false, isRemovable: false);
            public static readonly Item BANANA_TREE_EMPTY = new(name: "Banana Tree Empty", id: 65, category: ItemCategory.Trees, isTool: false, isPlaceable: false, isRotatable: false, isInventory: false, isRemovable: false);
            public static readonly Item OLIVE_TREE_EMPTY = new(name: "Olive Tree Empty", id: 66, category: ItemCategory.Trees, isTool: false, isPlaceable: false, isRotatable: false, isInventory: false, isRemovable: false);
            public static readonly Item SUGAR_TREE_EMPTY = new(name: "Sugar Tree Empty", id: 67, category: ItemCategory.Trees, isTool: false, isPlaceable: false, isRotatable: false, isInventory: false, isRemovable: false);

            public static readonly List<Item> Default = new()
            {
                AVOCADO_TREE,
                BANANA_TREE,
                OLIVE_TREE,
                SUGAR_TREE,
                AVOCADO_TREE_EMPTY,
                BANANA_TREE_EMPTY,
                OLIVE_TREE_EMPTY,
                SUGAR_TREE_EMPTY,
                SIMPLE_TREE,
                BIG_TREE,
            };

            public override List<Item> GetDefaultItems()
            {
                return Default;
            }
        }



        public class Machines : ItemsCategoryList<Machines>
        {
            public static readonly Item MIXER = new("Mixer", 68, ItemCategory.Machines, false, false, true, true, true);
            public static readonly Item BUTTER_CHURNER = new("Butter Churner", 72, ItemCategory.Machines, false, false, true, true, true);
            public static readonly Item OLIVE_PRESS = new("Oil Maker", 74, ItemCategory.Machines, false, false, true, true, true);
            public static readonly Item CHEESE_MAKER = new("Cheese Maker", 76, ItemCategory.Machines, false, true, true, true, true);
            public static readonly Item FURNACE_SMELTER = new(name: "Furnace", id: 987, category: ItemCategory.Machines, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: false);
            public static readonly Item WATER_WELL = new(name: "Water Well", id: 78, category: ItemCategory.Machines, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: false);
            public static readonly Item ROBOT = new("Robot", 136, ItemCategory.Machines, false, true, true, true, true);
            public static readonly Item PASTA_MACHINE = new("Pasta machine", 991, ItemCategory.Machines, false, false, true, true, true);
            public static readonly Item WATER_TANK = new(name: "Water tank Empty", id: 1011, category: ItemCategory.Machines, isTool: false, isPlaceable: true, isRotatable: false, isInventory: true, isRemovable: true);

            public static readonly Item WATER_TANK_1_BUCKET_WATER = new(name: "Water tank 1 Bucket Water", id: 1012, category: ItemCategory.Machines, isTool: false, isPlaceable: false, isRotatable: false, isInventory: false, isRemovable: false);
            public static readonly Item WATER_TANK_2_BUCKET_WATER = new(name: "Water tank 2 Bucket Water", id: 1013, category: ItemCategory.Machines, isTool: false, isPlaceable: false, isRotatable: false, isInventory: false, isRemovable: false);
            public static readonly Item WATER_TANK_3_BUCKET_WATER = new(name: "Water tank 3 Bucket Water", id: 1014, category: ItemCategory.Machines, isTool: false, isPlaceable: false, isRotatable: false, isInventory: false, isRemovable: false);
            public static readonly Item WATER_TANK_4_BUCKET_WATER = new(name: "Water tank 4 Bucket Water", id: 1015, category: ItemCategory.Machines, isTool: false, isPlaceable: false, isRotatable: false, isInventory: false, isRemovable: false);
            public static readonly Item WATER_TANK_5_BUCKET_WATER = new(name: "Water tank 5 Bucket Water", id: 1016, category: ItemCategory.Machines, isTool: false, isPlaceable: false, isRotatable: false, isInventory: false, isRemovable: false);
            public static readonly Item WATER_TANK_6_BUCKET_WATER = new(name: "Water tank 6 Bucket Water", id: 1017, category: ItemCategory.Machines, isTool: false, isPlaceable: false, isRotatable: false, isInventory: false, isRemovable: false);
            public static readonly Item WATER_TANK_7_BUCKET_WATER = new(name: "Water tank 7 Bucket Water", id: 1018, category: ItemCategory.Machines, isTool: false, isPlaceable: false, isRotatable: false, isInventory: false, isRemovable: false);
            public static readonly Item WATER_TANK_8_BUCKET_WATER = new(name: "Water tank 8 Bucket Water", id: 1019, category: ItemCategory.Machines, isTool: false, isPlaceable: false, isRotatable: false, isInventory: false, isRemovable: false);
            public static readonly Item WATER_TANK_9_BUCKET_WATER = new(name: "Water tank 9 Bucket Water", id: 1020, category: ItemCategory.Machines, isTool: false, isPlaceable: false, isRotatable: false, isInventory: false, isRemovable: false);
            public static readonly Item WATER_TANK_10_BUCKET_WATER = new(name: "Water tank 10 Bucket Water", id: 1021, category: ItemCategory.Machines, isTool: false, isPlaceable: false, isRotatable: false, isInventory: false, isRemovable: false);

            public static readonly Item MIXER_MIXING_FLOUR = new(name: "Mixer Mixing Flour", id: 69, category: ItemCategory.Machines, isTool: false, isPlaceable: false, isRotatable: false, isInventory: false, isRemovable: false);
            public static readonly Item MIXER_MIXING_WHEAT = new(name: "Mixer Mixing Wheat", id: 985, category: ItemCategory.Machines, isTool: false, isPlaceable: false, isRotatable: false, isInventory: false, isRemovable: false);
            public static readonly Item MIXER_MIXING_MILK = new(name: "Mixer Mixing Milk", id: 1005, category: ItemCategory.Machines, isTool: false, isPlaceable: false, isRotatable: false, isInventory: false, isRemovable: false);

            public static readonly Item BUTTER_CHURNER_CHURNING = new(name: "Butter Churner Churning", id: 73, category: ItemCategory.Machines, isTool: false, isPlaceable: false, isRotatable: false, isInventory: false, isRemovable: false);
            public static readonly Item OLIVE_PRESS_PRESSING = new(name: "Oil Maker Pressing olives", id: 75, category: ItemCategory.Machines, isTool: false, isPlaceable: false, isRotatable: false, isInventory: false, isRemovable: false);
            public static readonly Item CHEESE_MAKER_MAKING_CHEESE = new(name: "Cheese Maker Making Cheese", id: 986, category: ItemCategory.Machines, isTool: false, isPlaceable: false, isRotatable: false, isInventory: false, isRemovable: false);
            public static readonly Item FURNACE_SMELTING_BISMUTH = new(name: "Furnace Smelting Bismuth", id: 77, category: ItemCategory.Machines, isTool: false, isPlaceable: false, isRotatable: false, isInventory: false, isRemovable: false);
            public static readonly Item WATER_WELL_GIVING_WATER = new(name: "Water Well Giving Water", id: 988, category: ItemCategory.Machines, isTool: false, isPlaceable: false, isRotatable: false, isInventory: false, isRemovable: false);
            public static readonly Item ROBOT_MAKING_HAM = new(name: "Robot making ham", id: 989, category: ItemCategory.Machines, isTool: false, isPlaceable: false, isRotatable: false, isInventory: false, isRemovable: false);
            public static readonly Item ROBOT_MAKING_MEAT = new(name: "Robot making meat", id: 990, category: ItemCategory.Machines, isTool: false, isPlaceable: false, isRotatable: false, isInventory: false, isRemovable: false);
            public static readonly Item PASTA_MACHINE_MAKING_PASTA = new(name: "Pasta machine making pasta", id: 992, category: ItemCategory.Machines, isTool: false, isPlaceable: false, isRotatable: false, isInventory: false, isRemovable: false);



            public static readonly List<Item> Default = new() {

                                                       MIXER,
                                                       MIXER_MIXING_FLOUR,
                                                       MIXER_MIXING_WHEAT,
                                                       MIXER_MIXING_MILK,
                                                       BUTTER_CHURNER,
                                                       BUTTER_CHURNER_CHURNING,
                                                       OLIVE_PRESS,
                                                       OLIVE_PRESS_PRESSING,
                                                       CHEESE_MAKER,
                                                       CHEESE_MAKER_MAKING_CHEESE,
                                                       FURNACE_SMELTER,
                                                       FURNACE_SMELTING_BISMUTH,
                                                       WATER_WELL,
                                                       WATER_WELL_GIVING_WATER,
                                                       ROBOT,
                                                       ROBOT_MAKING_HAM,
                                                       ROBOT_MAKING_MEAT,
                                                       PASTA_MACHINE,
                                                       PASTA_MACHINE_MAKING_PASTA,
                                                       WATER_TANK,
                                                       WATER_TANK_1_BUCKET_WATER,
                                                       WATER_TANK_2_BUCKET_WATER,
                                                       WATER_TANK_3_BUCKET_WATER,
                                                       WATER_TANK_4_BUCKET_WATER,
                                                       WATER_TANK_5_BUCKET_WATER,
                                                       WATER_TANK_6_BUCKET_WATER,
                                                       WATER_TANK_7_BUCKET_WATER,
                                                       WATER_TANK_8_BUCKET_WATER,
                                                       WATER_TANK_9_BUCKET_WATER,
                                                       WATER_TANK_10_BUCKET_WATER,

            };
            public override List<Item> GetDefaultItems()
            {
                return Default;
            }
        }

        public class Cooking : ItemsCategoryList<Cooking>
        {

            public static readonly Item COFFEE_MACHINE = new(name: "Coffee Machine", id: 79, category: ItemCategory.Cooking, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true); //stackable on bar table 
            public static readonly Item CRAZY_COFFEE_MACHINE = new(name: "Crazy Coffee Machine", id: 993, category: ItemCategory.Cooking, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true); //stackable on bar table 

            public static readonly Item BASIC_OVEN = new(name: "Oven", id: 80, category: ItemCategory.Cooking, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true); //stackable on the floor
            public static readonly Item CRAZY_OVEN = new(name: "Crazy Oven", id: 81, category: ItemCategory.Cooking, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true); //stackable on the floor
            public static readonly Item CUTTING_BOARD = new("Cutting Board", 82, ItemCategory.Cooking, false, false, true, true, true); // stackable bar table
            public static readonly Item CRAZY_CUTTING_BOARD = new("Crazy Cutting Board", 995, ItemCategory.Cooking, false, false, true, true, true); // stackable bar table
            public static readonly Item BLENDER = new("Blender", 83, ItemCategory.Cooking, false, false, true, true, true); // stackable bar table
            public static readonly Item CRAZY_BLENDER = new("Crazy Blender", 996, ItemCategory.Cooking, false, false, true, true, true); // stackable bar table


            public static readonly Item COFFEE_MACHINE_BREWING = new("Coffee Machine Brewing", 84, ItemCategory.Cooking, false, false, false, false, false, true);
            public static readonly Item CRAZY_COFFEE_MACHINE_BREWING = new("Crazy Coffee Machine Brewing", 994, ItemCategory.Cooking, false, false, false, false, false, true);


            public static readonly Item BASIC_OVEN_COOKING_BURGER = new("Oven Cooking Burger", 977, ItemCategory.Cooking, false, false, false, false, false, true);
            public static readonly Item BASIC_OVEN_COOKING_CROISSANT = new("Oven Cooking Croissant", 976, ItemCategory.Cooking, false, false, false, false, false, true);
            public static readonly Item BASIC_OVEN_COOKING_PIZZA = new("Oven Cooking Pizza", 975, ItemCategory.Cooking, false, false, false, false, false, true);
            public static readonly Item BASIC_OVEN_COOKING_CUPCAKE = new("Oven Cooking Cupcake", 974, ItemCategory.Cooking, false, false, false, false, false, true);
            public static readonly Item BASIC_OVEN_COOKING_MAC_AND_CHEESE = new("Oven Cooking Mac and Cheese", 1006, ItemCategory.Cooking, false, false, false, false, false, true);


            public static readonly Item CRAZY_OVEN_COOKING_BURGER = new("Crazy Oven Cooking Burger", 997, ItemCategory.Cooking, false, false, false, false, false, true);
            public static readonly Item CRAZY_OVEN_COOKING_CROISSANT = new("Crazy Oven Cooking Croissant", 998, ItemCategory.Cooking, false, false, false, false, false, true);
            public static readonly Item CRAZY_OVEN_COOKING_PIZZA = new("Crazy Oven Cooking Pizza", 999, ItemCategory.Cooking, false, false, false, false, false, true);
            public static readonly Item CRAZY_OVEN_COOKING_CUPCAKE = new(name: "Crazy Oven Cooking Cupcake", id: 1000, category: ItemCategory.Cooking, isTool: false, isPlaceable: false, isRotatable: false, isInventory: false, isRemovable: false, isCookingState: true);
            public static readonly Item CRAZY_OVEN_COOKING_MAC_AND_CHEESE = new("Crazy Oven Cooking Mac and Cheese", 1001, ItemCategory.Cooking, false, false, false, false, false, true);

            public static readonly Item CUTTING_BOARD_CHOPPING_SALAD = new("Cutting Board Chopping Salad", 981, ItemCategory.Cooking, false, false, false, false, false, true);
            public static readonly Item CRAZY_CUTTING_BOARD_CHOPPING_SALAD = new("Crazy Cutting Board Chopping Salad", 1002, ItemCategory.Cooking, false, false, false, false, false, true);

            public static readonly Item BLENDER_BLENDING_SMOOTHIE = new("Blender Blending Smoothie", 979, ItemCategory.Cooking, false, false, false, false, false, true);
            public static readonly Item BLENDER_BLENDING_BANANA_MILKSHAKE = new("Blender Blending Banana Milk", 980, ItemCategory.Cooking, false, false, false, false, false, true);

            public static readonly Item CRAZY_BLENDER_BLENDING_SMOOTHIE = new("Crazy Blender Blending Smoothie", 1003, ItemCategory.Cooking, false, false, false, false, false, true);
            public static readonly Item CRAZY_BLENDER_BLENDING_BANANA_MILKSHAKE = new("Crazy Blender Blending Banana Milk", 1004, ItemCategory.Cooking, false, false, false, false, false, true);

            public static readonly Item KEBAB_MAKER = new(name: "Kebab Machine", id: 963, category: ItemCategory.Cooking, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true); //stackable on the bar table
            public static readonly Item KEBAB_MAKER_COOKING_KEBAB = new("Kebab Machine Cooking Shawarma", 978, ItemCategory.Cooking, false, false, false, false, false, true);

            public static readonly List<Item> Default = new() {

                                             COFFEE_MACHINE,
                                             CRAZY_COFFEE_MACHINE,
                                             COFFEE_MACHINE_BREWING,
                                             CRAZY_COFFEE_MACHINE_BREWING,

                                             BASIC_OVEN,
                                             CRAZY_OVEN,
                                             CUTTING_BOARD,
                                             CRAZY_CUTTING_BOARD,
                                             BLENDER,
                                             CRAZY_BLENDER,


                                             BASIC_OVEN_COOKING_BURGER,
                                             BASIC_OVEN_COOKING_CROISSANT,
                                             BASIC_OVEN_COOKING_PIZZA,
                                             BASIC_OVEN_COOKING_CUPCAKE,
                                             BASIC_OVEN_COOKING_MAC_AND_CHEESE,


                                             CRAZY_OVEN_COOKING_BURGER,
                                             CRAZY_OVEN_COOKING_CROISSANT,
                                             CRAZY_OVEN_COOKING_PIZZA,
                                             CRAZY_OVEN_COOKING_CUPCAKE,
                                             CRAZY_OVEN_COOKING_MAC_AND_CHEESE,

                                             CUTTING_BOARD_CHOPPING_SALAD,
                                             CRAZY_CUTTING_BOARD_CHOPPING_SALAD,

                                             BLENDER_BLENDING_SMOOTHIE,
                                             BLENDER_BLENDING_BANANA_MILKSHAKE,

                                             CRAZY_BLENDER_BLENDING_SMOOTHIE,
                                             CRAZY_BLENDER_BLENDING_BANANA_MILKSHAKE,

                                             KEBAB_MAKER,
                                             KEBAB_MAKER_COOKING_KEBAB

            };
            public override List<Item> GetDefaultItems()
            {
                return Default;
            }
        }

        public class Furniture : ItemsCategoryList<Furniture>
        {

            public static readonly Item GREEN_CHAIR = new(name: "Green Chair", id: 89, category: ItemCategory.Furniture, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true); // stackable on the floor
            public static readonly Item PINK_CHAIR = new("Pink Chair", 90, ItemCategory.Furniture, false, false, true, true, true); // stackable on the floor

            public static readonly Item GREEN_TABLE = new("Green Table", 92, ItemCategory.Furniture, false, false, true, true, true); // stackable on the floor
            public static readonly Item PURPLE_TABLE = new("Purple Table", 93, ItemCategory.Furniture, false, false, true, true, true); // stackable on the floor
            public static readonly Item PINK_TABLE = new("Pink Table", 94, ItemCategory.Furniture, false, false, true, true, true); // stackable on the floor
            public static readonly Item BAR_COUNTER = new("Bar Counter", 116, ItemCategory.Furniture, false, false, true, true, true); // stackable on the floor


            public static readonly List<Item> Default = new() {
                                                            GREEN_CHAIR,
                                                            PINK_CHAIR,
                                                            GREEN_TABLE,
                                                            PURPLE_TABLE,
                                                            PINK_TABLE,
                                                            BAR_COUNTER,

                        };
            public override List<Item> GetDefaultItems()
            {
                return Default;
            }
        }

        public class Decorations : ItemsCategoryList<Decorations>
        {

            public static readonly Item PLANT = new(name: "Plant", id: 95, category: ItemCategory.Decorations, isTool: false, isPlaceable: false, isRotatable: true, isInventory: true, isRemovable: true);  //stackable on the floor
            public static readonly Item FENCE = new(name: "Fence", id: 96, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true);
            public static readonly Item PINK_FLOOR = new(name: "Pink Floor", id: 97, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: false, isInventory: true, isRemovable: true);
            public static readonly Item PURPLE_FLOOR = new(name: "Purple Floor", id: 98, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: false, isInventory: true, isRemovable: true);
            public static readonly Item WALL = new(name: "Wall", id: 99, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: true, isRemovable: true); //stackable on the floor also
            public static readonly Item WALL_WITH_SIGNBOARD = new(name: "Wall With Planet Sign", id: 100, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: false, isRemovable: false); //stackable on the floor also //transformation to be added that picks the signboard using the pickaxe
            public static readonly Item WALL_WITH_WINDOW = new(name: "Wall With Window", id: 101, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: false, isRemovable: false); //stackable on the floor also //transformation to be added that picks the window using the pickaxe
            public static readonly Item WALL_WITH_MENU = new(name: "Wall With Menu", id: 102, category: ItemCategory.Decorations, isTool: false, isPlaceable: true, isRotatable: true, isInventory: false, isRemovable: false); // stackable on the floor also transformation to be added that picks the window using the pickaxe
            public static readonly Item SIGNBOARD = new("Planet Sign", 124, ItemCategory.Decorations, false, false, true, true, true); // transformation to put in the wall
            public static readonly Item WINDOW = new("Window", 125, ItemCategory.Decorations, false, false, true, true, true); // transformation to put in the wall
            public static readonly Item WALL_MENU = new("Wall Menu", 126, ItemCategory.Decorations, false, false, true, true, true); // transformation to put in the wall



            public static readonly List<Item> Default = new() {

                                                        PLANT,
                                                        FENCE,
                                                        PINK_FLOOR,
                                                        PURPLE_FLOOR,
                                                        WALL,
                                                        WALL_WITH_SIGNBOARD,
                                                        WALL_WITH_WINDOW,
                                                        WALL_WITH_MENU,

                                                        SIGNBOARD,
                                                        WINDOW,
                                                        WALL_MENU,


            };
            public override List<Item> GetDefaultItems()
            {
                return Default;
            }

        }

        public class Animals : ItemsCategoryList<Animals>
        {

            public static readonly Item COW = new(name: "Cow", id: 103, category: ItemCategory.Animals, isTool: false, isPlaceable: true, isRotatable: false, isInventory: true, isRemovable: true); //to move just go to the inventory
            public static readonly Item COW_GIVING_MILK = new(name: "Cow giving milk", id: 1008, category: ItemCategory.Animals, isTool: false, isPlaceable: false, isRotatable: false, isInventory: false, isRemovable: false); //to move just go to the inventory
            public static readonly Item CHICKEN = new(name: "Chicken", id: 104, category: ItemCategory.Animals, isTool: false, isPlaceable: true, isRotatable: false, isInventory: true, isRemovable: true); //to move just to go to the inventory

            public static readonly List<Item> Default = new() {

                                                        COW,
                                                        COW_GIVING_MILK,
                                                        CHICKEN,
            };
            public override List<Item> GetDefaultItems()
            {
                return Default;
            }
        }

        public class Buckets : ItemsCategoryList<Buckets>
        {

            public static readonly Item BUCKET_MILK = new(name: "Milk", id: 105, category: ItemCategory.Buckets, isTool: false, isPlaceable: false, isRotatable: false, isInventory: true, isRemovable: false); //placeable as transformation (making cheese)
            public static readonly Item BUCKET_WATER = new("Water", 106, ItemCategory.Buckets, false, false, false, true, false); //placeable as transformation 
            public static readonly Item BUCKET_EMPTY = new(name: "Empty Bucket", id: 107, category: ItemCategory.Buckets, isTool: false, isPlaceable: false, isRotatable: false, isInventory: true, isRemovable: false); //placeable as transformation to collect water and milk

            public static readonly List<Item> Default = new() {

                                                        BUCKET_MILK,
                                                        BUCKET_WATER,
                                                        BUCKET_EMPTY,
            };
            public override List<Item> GetDefaultItems()
            {
                return Default;
            }
        }

        public class Tools : ItemsCategoryList<Tools>
        {

            public static readonly Item SCYTHE = new(name: "Scythe", id: 108, category: ItemCategory.Tools, isTool: true, isPlaceable: false, isRotatable: false, isInventory: true, isRemovable: false); // crafted
            public static readonly Item WATERING_CAN = new("Watering Can", 109, ItemCategory.Tools, false, false, false, true, false); // crafted This is not a TOOL anymore behaves like a bucket (a transformation should not destroyed this)
            public static readonly Item WATERING_CAN_FULL = new(name: "Watering Can Full", id: 1010, category: ItemCategory.Tools, isTool: true, isPlaceable: false, isRotatable: false, isInventory: true, isRemovable: false); // crafted This is not a TOOL anymore behaves like a bucket full, BUT TEMPORARILY IT IS
            public static readonly Item PICKAXE = new("Pickaxe", 110, ItemCategory.Tools, true, false, false, true, false); // crafted
            public static readonly Item AXE = new(name: "Axe", id: 111, category: ItemCategory.Tools, isTool: true, isPlaceable: false, isRotatable: false, isInventory: true, isRemovable: false); // crafted
            public static readonly Item HOE = new("Hoe", 112, ItemCategory.Tools, true, false, false, true, false); // crafted
            public static readonly Item HAND = new("Hand", 127, ItemCategory.Tools, true, false, false, false, false);

            public static readonly List<Item> Default = new() {
                                                        SCYTHE,
                                                        WATERING_CAN,
                                                        WATERING_CAN_FULL,
                                                        PICKAXE,
                                                        AXE,
                                                        HOE,
                                                        HAND,
            };
            public override List<Item> GetDefaultItems()
            {
                return Default;
            }

        }


        public static CategoryTypeItemField GetCategoryTypeItemField(Item item)
        {
            if (item == null) return null;
            if (item.Id == 0) return null;
            var categories = typeof(DefaultItems).GetNestedTypes();
            foreach (var category in categories)
            {
                var items = category.GetFields();
                foreach (var innerItem in items)
                {
                    var value = innerItem.GetValue(null);
                    if (value is Item innerItemValue)
                    {
                        if (innerItemValue.Category == item.Category && innerItemValue.Id == item.Id && innerItemValue.Name == innerItemValue.Name)
                        {
                            return new CategoryTypeItemField()
                            {
                                CategoryType = category,
                                ItemField = innerItem
                            };
                        }
                    }
                }
            }

            return null;
        }


        public static string GetIdReflectionString(Item item)
        {
            var found = GetCategoryTypeItemField(item);
            if (found == null) return "0";
            return "DefaultItems." + found.CategoryType.Name + "." + found.ItemField.Name + ".Id";
        }

        public static string GetReflectionFieldString(Item item)
        {
            var found = GetCategoryTypeItemField(item);
            if (found == null) throw new Exception("Not found");
            return "DefaultItems." + found.CategoryType.Name + "." + found.ItemField.Name;
        }


    }

    public class CategoryTypeItemField
    {
        public Type CategoryType { get; set; }
        public FieldInfo ItemField { get; set; }
    }

}
