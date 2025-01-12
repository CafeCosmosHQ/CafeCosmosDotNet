using System.Linq;
using LBINT = System.Collections.Generic.List<System.Numerics.BigInteger>;
using LBINT2D = System.Collections.Generic.List<System.Collections.Generic.List<System.Numerics.BigInteger>>;
using RawMaterials = VisionsContracts.Items.DefaultItems.RawMaterials;
using VisionsContracts.Items;
using VisionsContracts.CraftingSystem.Model;
using System.Collections.Generic;
using VisionsContracts.Items.Model;
using static VisionsContracts.Items.DefaultItems;
using System.Numerics;
using VisionsContracts.Land.Systems.CraftingSystem.Model;

namespace VisionsContracts.Land.Systems.CraftingSystem
{

    public static class DefaultCraftingRecipes
    {
        public static List<ReturnedCraftingItem> GetReturnedCraftingItems()
        {
            return new List<ReturnedCraftingItem>()
            {
                new(DefaultItems.Buckets.BUCKET_MILK, DefaultItems.Buckets.BUCKET_EMPTY),
                new(DefaultItems.Buckets.BUCKET_WATER, DefaultItems.Buckets.BUCKET_EMPTY)
            };
        }

        public static LBINT2D ConvertToListBigInteger(this int[][] array2d)
        {
            var returnValue = new LBINT2D();
            foreach (var item in array2d)
            {
                returnValue.Add(item.Select(x => (BigInteger)x).ToList());
            }
            return returnValue;
        }


        public static IList<ICraftingCategoryList> GetCraftingCategories()
        {

            var craftingCategories = new List<ICraftingCategoryList>
            {
                Misc.Instance,
                Gardening.Instance,
                Lettuce.Instance,
                Wheat.Instance,
                Tomato.Instance,
                Machines.Instance,
                Cooking.Instance,
                Furniture.Instance,
                Decorations.Instance,
                Buckets.Instance,
                Tools.Instance,
                OvenRecipes.Instance,
                BlenderRecipes.Instance,
                ChoppingBoardRecipes.Instance,
                CoffeeMachineRecipes.Instance,
                KebabMakerRecipes.Instance,
            };
            return craftingCategories;
        }

        public static List<CraftingRecipe> FindAllPossibleCraftingRecipes(this List<InventoryItem> inventoryItems)
        {
            var allCraftingRecipes = GetAllCraftingRecipes();
            var foundRecipes = new List<CraftingRecipe>();
            foreach (var craftingRecipe in allCraftingRecipes)
            {
                if (craftingRecipe.HasGotInventoryItemsToCraftRecipe(inventoryItems))
                {
                    foundRecipes.Add(craftingRecipe);
                }
            }
            return foundRecipes;
        }

        public static List<CraftingRecipe> FindByOutput(int outputId)
        {
            var allCraftingRecipes = GetAllCraftingRecipes();
            return allCraftingRecipes.Where(x => x.Output.Id == outputId).ToList();
        }

        public static bool IsValidRecipe(int[][] recipe)
        {
            return IsValidRecipe(recipe.ConvertToListBigInteger());
        }

        public static bool IsValidRecipe(LBINT2D Recipe)
        {
            var craftingRecipes = GetAllCraftingRecipes();
            return craftingRecipes.Any(x => x.Recipe.IsRecipeTheSame(Recipe));
        }

        public static CraftingRecipe FindCraftingRecipe(int[][] recipe)
        {
            return FindCraftingRecipe(recipe.ConvertToListBigInteger());
        }

        public static CraftingRecipe FindCraftingRecipe(LBINT2D Recipe)
        {
            var craftingRecipes = GetAllCraftingRecipes();
            return craftingRecipes.FirstOrDefault(x => x.Recipe.IsRecipeTheSame(Recipe));
        }

        public static IList<CraftingRecipe> GetAllCraftingRecipes()
        {
            var list = new List<CraftingRecipe>();
            foreach (var category in GetCraftingCategories())
            {
                list.AddRange(category.GetAllCraftingRecipes());
            }
            return list;
        }



        public class Machines : CraftingCategoryList<Machines>
        {

            public static readonly CraftingRecipe OLIVE_PRESS = new(new()
            {
                new LBINT{ DefaultItems.Misc.GLASS.Id, DefaultItems.Misc.BLADE.Id, 0 },
                new LBINT{ DefaultItems.Misc.GLASS.Id, DefaultItems.Misc.WIRE.Id, 0 },
                new LBINT{ 0, RawMaterials.CRYSTAL.Id, 0 }
            }, DefaultItems.Machines.OLIVE_PRESS);

            public static readonly CraftingRecipe BUTTER_CHURNER = new(new()
            {
                new LBINT { RawMaterials.BISMUTH.Id, RawMaterials.BISMUTH.Id, 0 },
                new LBINT { RawMaterials.BISMUTH.Id, DefaultItems.Misc.BLADE.Id, 0 },
                new LBINT { 0, DefaultItems.Buckets.BUCKET_EMPTY.Id, RawMaterials.CRYSTAL.Id }
            }, DefaultItems.Machines.BUTTER_CHURNER, 3);


            public static readonly CraftingRecipe WATER_WELL = new(new()
            {
                new LBINT{ 0, RawMaterials.CRYSTAL.Id, 0 },
                new LBINT{ RawMaterials.BISMUTH.Id, DefaultItems.Buckets.BUCKET_EMPTY.Id, RawMaterials.BISMUTH.Id },
                new LBINT{ RawMaterials.CLAY.Id, RawMaterials.CLAY.Id, RawMaterials.CLAY.Id }
            }, DefaultItems.Machines.WATER_WELL, 3);

            public static readonly CraftingRecipe CHEESE_MAKER = new(new()
            {
                new LBINT{ 0, DefaultItems.Buckets.BUCKET_EMPTY.Id, 0 },
                new LBINT{ RawMaterials.BISMUTH.Id, DefaultItems.Misc.WIRE.Id, RawMaterials.BISMUTH.Id },
                new LBINT{ DefaultItems.Misc.WIRE.Id, RawMaterials.BISMUTH.Id, DefaultItems.Misc.WIRE.Id }
            }, DefaultItems.Machines.CHEESE_MAKER);

            public static readonly CraftingRecipe MIXER = new(new()
                     {
                          new LBINT{ RawMaterials.BISMUTH.Id, RawMaterials.BISMUTH.Id, 0 },
                          new LBINT{ RawMaterials.BISMUTH.Id, DefaultItems.Misc.BLADE.Id, 0 },
                          new LBINT{ DefaultItems.Misc.WIRE.Id, DefaultItems.Buckets.BUCKET_EMPTY.Id, 0 }
                     }, DefaultItems.Machines.MIXER, 3);


            public static readonly CraftingRecipe FURNACE_SMELTER = new(new()
            {
                new LBINT{ RawMaterials.CRYSTAL.Id, RawMaterials.BISMUTH.Id, RawMaterials.CRYSTAL.Id },
                new LBINT{ RawMaterials.BISMUTH.Id, 0, RawMaterials.BISMUTH.Id },
                new LBINT{ RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id }
            }, DefaultItems.Machines.FURNACE_SMELTER, 2);

            public static readonly CraftingRecipe ROBOT = new(new()
            {
                new LBINT { DefaultItems.Misc.WIRE.Id, DefaultItems.Misc.WIRE.Id,  DefaultItems.Misc.FLUX_CAPACITOR.Id },
                new LBINT { RawMaterials.BISMUTH_INGOT.Id, DefaultItems.Misc.FLUX_CAPACITOR.Id, 0 },
                new LBINT { RawMaterials.BISMUTH_INGOT.Id, RawMaterials.CRYSTAL.Id, 0 }
            }, DefaultItems.Machines.ROBOT, 3);

            public static readonly CraftingRecipe PASTA_MACHINE = new(new()
                     {
                          new LBINT{ DefaultItems.Misc.POLE.Id, DefaultItems.Misc.POLE.Id, DefaultItems.Misc.POLE.Id },
                          new LBINT{ RawMaterials.BISMUTH.Id, RawMaterials.BISMUTH.Id, 0 },
                          new LBINT{ 0, 0, 0 }
                     }, DefaultItems.Machines.PASTA_MACHINE, 2);


            public static readonly CraftingRecipe WATER_TANK = new(new()
                     {
                          new LBINT{ DefaultItems.Machines.WATER_WELL.Id, DefaultItems.Misc.WIRE.Id, RawMaterials.BLACK_TRAPEZOID.Id },
                          new LBINT{ RawMaterials.BLACK_TRAPEZOID.Id, 0, 0 },
                          new LBINT{ 0, 0, 0 }
                     }, DefaultItems.Machines.WATER_TANK);





            public override List<CraftingRecipe> GetAllCraftingRecipes()
            {
                return new List<CraftingRecipe>
                {
                   OLIVE_PRESS,
                   BUTTER_CHURNER,
                   WATER_WELL,
                   CHEESE_MAKER,
                   MIXER,
                   FURNACE_SMELTER,
                   ROBOT,
                   PASTA_MACHINE,
                   WATER_TANK


                };
            }
        }

        public class Gardening : CraftingCategoryList<Gardening>
        {
            public static readonly CraftingRecipe FERTILIZER = new(new()
            {
                new LBINT { Ingredients.DUST.Id, Ingredients.DUST.Id, Ingredients.DUST.Id },
                new LBINT { Ingredients.DUST.Id, Ingredients.DUST.Id, Ingredients.DUST.Id },
                new LBINT { Ingredients.DUST.Id, Ingredients.DUST.Id, Ingredients.DUST.Id }
            }, DefaultItems.Gardening.FERTILIZER, 2);

            public override List<CraftingRecipe> GetAllCraftingRecipes()
            {
                return new List<CraftingRecipe>
                {
                   FERTILIZER
                };
            }
        }

        public class Furniture : CraftingCategoryList<Furniture>
        {

            public static readonly CraftingRecipe GREEN_TABLE = new(new()
            {
                new LBINT{ RawMaterials.WOOD_PINK.Id, RawMaterials.WOOD_PINK.Id, RawMaterials.WOOD_PINK.Id },
                new LBINT{ RawMaterials.WOOD_PURPLE.Id, RawMaterials.WOOD_PURPLE.Id, RawMaterials.WOOD_PURPLE.Id },
                new LBINT{ 0, RawMaterials.CRYSTAL.Id, 0 }
            }, DefaultItems.Furniture.GREEN_TABLE, 3);

            public static readonly CraftingRecipe BAR_COUNTER = new(new()
            {
                new LBINT { RawMaterials.WOOD_PURPLE.Id, RawMaterials.WOOD_PURPLE.Id, RawMaterials.WOOD_PURPLE.Id },
                new LBINT { RawMaterials.WOOD_PINK.Id, RawMaterials.WOOD_PINK.Id, RawMaterials.WOOD_PINK.Id },
                new LBINT { RawMaterials.WOOD_PINK.Id, RawMaterials.WOOD_PINK.Id, RawMaterials.WOOD_PINK.Id }
            }, DefaultItems.Furniture.BAR_COUNTER, 2);

            public static readonly CraftingRecipe PURPLE_TABLE = new(new()
            {
                new LBINT { RawMaterials.WOOD_PURPLE.Id, RawMaterials.WOOD_PURPLE.Id, RawMaterials.WOOD_PURPLE.Id },
                new LBINT { 0, RawMaterials.WOOD_PURPLE.Id, 0 },
                new LBINT { 0, RawMaterials.WOOD_PURPLE.Id, 0 }
            }, DefaultItems.Furniture.PURPLE_TABLE, 2);

            public static readonly CraftingRecipe PINK_TABLE = new(new()
            {
                new LBINT{ 0, RawMaterials.WOOD_PINK.Id, 0 },
                new LBINT{ RawMaterials.WOOD_PINK.Id, 0, RawMaterials.WOOD_PINK.Id },
                new LBINT{ RawMaterials.WOOD_PINK.Id, 0, RawMaterials.WOOD_PINK.Id }
            }, DefaultItems.Furniture.PINK_TABLE, 2);


            public override List<CraftingRecipe> GetAllCraftingRecipes()
            {
                return new List<CraftingRecipe>
                {
                   BAR_COUNTER,
                   PINK_TABLE,
                   PURPLE_TABLE,
                   GREEN_TABLE

                };
            }
        }

        public class Tomato : CraftingCategoryList<Tomato>
        {
            public static readonly CraftingRecipe TOMATO_SEED = new(new()
            {
                new LBINT { 0, 0, 0 },
                new LBINT { 0, 0, 0 },
                new LBINT { 0, 0, Ingredients.TOMATO.Id }
            }, DefaultItems.Tomato.TOMATO_SEED);

            public override List<CraftingRecipe> GetAllCraftingRecipes()
            {
                return new List<CraftingRecipe>
                {
                    TOMATO_SEED,
                };
            }
        }


        public class Wheat : CraftingCategoryList<Wheat>
        {
            public static readonly CraftingRecipe WHEAT_SEED = new(new()
            {
                new LBINT { 0, 0, 0 },
                new LBINT { 0, 0, 0 },
                new LBINT { 0, 0, Ingredients.WHEAT.Id }
            }, DefaultItems.Wheat.WHEAT_SEED);

            public override List<CraftingRecipe> GetAllCraftingRecipes()
            {
                return new List<CraftingRecipe>
                {
                    WHEAT_SEED,
                };
            }
        }

        public class Lettuce : CraftingCategoryList<Lettuce>
        {
            public static readonly CraftingRecipe LETTUCE_SEED = new(new()
            {
                new LBINT { 0, 0, 0 },
                new LBINT { 0, 0, 0 },
                new LBINT { 0, 0, Ingredients.LETTUCE.Id }
            }, DefaultItems.Lettuce.LETTUCE_SEED);

            public override List<CraftingRecipe> GetAllCraftingRecipes()
            {
                return new List<CraftingRecipe>
                {
                    LETTUCE_SEED,
                };
            }
        }

        public class Decorations : CraftingCategoryList<Decorations>
        {


            public static readonly CraftingRecipe PLANT = new(new()
            {
                new LBINT { 0, DefaultItems.Lettuce.LETTUCE_SEED.Id, 0 },
                new LBINT { RawMaterials.CLAY.Id, DefaultItems.Buckets.BUCKET_EMPTY.Id, RawMaterials.CLAY.Id },
                new LBINT { 0, RawMaterials.CLAY.Id, 0 }
            }, DefaultItems.Decorations.PLANT, 2);


            public static readonly CraftingRecipe PINK_CHAIR = new(new()
            {
                new LBINT{ 0, 0, 0 },
                new LBINT{ RawMaterials.WOOD_PINK.Id, RawMaterials.WOOD_PINK.Id, RawMaterials.WOOD_PINK.Id },
                new LBINT{ 0, RawMaterials.WOOD_PINK.Id, 0 }
            }, DefaultItems.Furniture.PINK_CHAIR, 2);

            public static readonly CraftingRecipe GREEN_CHAIR = new(new()
            {
                new LBINT { RawMaterials.WOOD_PURPLE.Id, RawMaterials.WOOD_PURPLE.Id, 0 },
                new LBINT { RawMaterials.WOOD_PINK.Id, RawMaterials.WOOD_PINK.Id, 0 },
                new LBINT { RawMaterials.CRYSTAL.Id, 0, 0 }
            }, DefaultItems.Furniture.GREEN_CHAIR, 3);


            public static readonly CraftingRecipe FENCE = new(new()
            {
                new LBINT{ RawMaterials.STICKS.Id, 0, RawMaterials.STICKS.Id },
                new LBINT{ RawMaterials.WOOD_PINK.Id, RawMaterials.STICKS.Id, RawMaterials.WOOD_PINK.Id },
                new LBINT{ 0, 0, RawMaterials.STICKS.Id }
            }, DefaultItems.Decorations.FENCE, 2);

            public static readonly CraftingRecipe PURPLE_FLOOR = new(new()
            {
                new LBINT { 0, 0, 0 },
                new LBINT { 0, 0, 0 },
                new LBINT { RawMaterials.WOOD_PURPLE.Id, RawMaterials.WOOD_PURPLE.Id, RawMaterials.WOOD_PURPLE.Id }
            }, DefaultItems.Decorations.PURPLE_FLOOR, 2);

            public static readonly CraftingRecipe PINK_FLOOR = new(new()
            {
                new LBINT { 0, 0, 0 },
                new LBINT { 0, 0, 0 },
                new LBINT { RawMaterials.WOOD_PINK.Id, RawMaterials.WOOD_PINK.Id, RawMaterials.WOOD_PINK.Id }
            }, DefaultItems.Decorations.PINK_FLOOR);

            
            public static readonly CraftingRecipe WALL = new(new()
            {
                new LBINT{ 0, 0, RawMaterials.WOOD_PINK.Id },
                new LBINT{ 0, 0, RawMaterials.WOOD_PINK.Id },
                new LBINT{ 0, 0, RawMaterials.WOOD_PURPLE.Id }
            }, DefaultItems.Decorations.WALL, 2);

            public static readonly CraftingRecipe WALL_MENU = new(new()
            {
                new LBINT{ RawMaterials.WOOD_PINK.Id, RawMaterials.WOOD_PINK.Id, 0 },
                new LBINT{ RawMaterials.WOOD_PURPLE.Id, RawMaterials.WOOD_PURPLE.Id, 0 },
                new LBINT{ RawMaterials.WOOD_PINK.Id, RawMaterials.WOOD_PINK.Id, 0 }
            }, DefaultItems.Decorations.WALL_MENU, 2);

            public static readonly CraftingRecipe WINDOW = new(new()
            {
                new LBINT { 0, 0, DefaultItems.Misc.GLASS.Id },
                new LBINT { 0, 0, DefaultItems.Misc.GLASS.Id },
                new LBINT { 0, 0, 0 }
            }, DefaultItems.Decorations.WINDOW, 2);

            public static readonly CraftingRecipe SIGNBOARD = new(new()
            {
                new LBINT{ 0, RawMaterials.WOOD_PURPLE.Id, RawMaterials.WOOD_PURPLE.Id },
                new LBINT{ 0, 0, 0 },
                new LBINT{ RawMaterials.WOOD_PINK.Id, RawMaterials.WOOD_PINK.Id, RawMaterials.WOOD_PINK.Id }
            }, DefaultItems.Decorations.SIGNBOARD, 2);

            public override List<CraftingRecipe> GetAllCraftingRecipes()
            {
                return new List<CraftingRecipe>
                {
                    PLANT,
                    PINK_CHAIR,
                    GREEN_CHAIR,
                    FENCE,
                    PURPLE_FLOOR,
                    PINK_FLOOR,
                    WALL,
                    WALL_MENU,
                    WINDOW,
                    SIGNBOARD
                };
            }
        }

        public class Buckets : CraftingCategoryList<Buckets>
        {
            public static readonly CraftingRecipe BUCKET_EMPTY = new(new()
            {
                new LBINT { 0, 0, 0 },
                new LBINT { RawMaterials.WOOD_PINK.Id, 0, RawMaterials.WOOD_PINK.Id },
                new LBINT { 0, RawMaterials.WOOD_PINK.Id, 0 }
            }, DefaultItems.Buckets.BUCKET_EMPTY);


            public override List<CraftingRecipe> GetAllCraftingRecipes()
            {
                return new List<CraftingRecipe>
                {
                    BUCKET_EMPTY,

                };
            }
        }

        public class Cooking : CraftingCategoryList<Cooking>
        {

            public static readonly CraftingRecipe CRAZY_OVEN = new(new()
            {
                new LBINT{ 0, DefaultItems.Misc.FLUX_CAPACITOR.Id, 0 },
                new LBINT{ RawMaterials.BISMUTH_INGOT.Id, DefaultItems.Cooking.BASIC_OVEN.Id, RawMaterials.BISMUTH_INGOT.Id },
                new LBINT{ RawMaterials.BISMUTH_INGOT.Id, RawMaterials.CRYSTAL.Id, DefaultItems.Misc.WIRE.Id }
            }, DefaultItems.Cooking.CRAZY_OVEN, 3);


            public static readonly CraftingRecipe CUTTING_BOARD = new(new()
            {
                new LBINT{ 0, 0, RawMaterials.STICKS.Id },
                new LBINT{ 0, 0, RawMaterials.CRYSTAL.Id },
                new LBINT{ RawMaterials.WOOD_PINK.Id, RawMaterials.WOOD_PINK.Id, RawMaterials.WOOD_PINK.Id }
            }, DefaultItems.Cooking.CUTTING_BOARD, 2);

            public static readonly CraftingRecipe CRAZY_COFFEE_MACHINE = new(new()
                     {
                          new LBINT{ 0, DefaultItems.Cooking.COFFEE_MACHINE.Id, 0 },
                          new LBINT{ DefaultItems.Misc.WIRE.Id, DefaultItems.Machines.ROBOT.Id, DefaultItems.Misc.WIRE.Id },
                          new LBINT{ 0, DefaultItems.Misc.WIRE.Id, 0 }
                     }, DefaultItems.Cooking.CRAZY_COFFEE_MACHINE);

            public static readonly CraftingRecipe CRAZY_CUTTING_BOARD = new(new()
                     {
                          new LBINT{ 0, 0, RawMaterials.STICKS.Id },
                          new LBINT{ 0, 0, RawMaterials.BLACK_TRAPEZOID.Id },
                          new LBINT{ RawMaterials.WOOD_PURPLE.Id, DefaultItems.Cooking.CUTTING_BOARD.Id, RawMaterials.WOOD_PURPLE.Id }
                     }, DefaultItems.Cooking.CRAZY_CUTTING_BOARD, 2);

            public static readonly CraftingRecipe BLENDER = new(new()
            {
                new LBINT { DefaultItems.Misc.GLASS.Id, 0, DefaultItems.Misc.GLASS.Id },
                new LBINT { 0, DefaultItems.Misc.BLADE.Id, 0 },
                new LBINT { 0, DefaultItems.Misc.WIRE.Id, 0 }
            }, DefaultItems.Cooking.BLENDER, 3);


            public static readonly CraftingRecipe FLUX_CAPACITOR = new(new()
            {
                new LBINT{ DefaultItems.Misc.WIRE.Id, 0, 0 },
                new LBINT{ RawMaterials.BISMUTH_INGOT.Id, RawMaterials.BISMUTH_INGOT.Id, RawMaterials.BISMUTH_INGOT.Id },
                new LBINT{  RawMaterials.BISMUTH.Id, RawMaterials.BISMUTH.Id, RawMaterials.BISMUTH.Id }
            }, DefaultItems.Misc.FLUX_CAPACITOR, 3);

            public static readonly CraftingRecipe COFFEE_MACHINE = new(new()
                     {
                          new LBINT{ DefaultItems.Misc.GLASS.Id, RawMaterials.BISMUTH.Id, DefaultItems.Misc.WIRE.Id },
                          new LBINT{ RawMaterials.BISMUTH.Id, DefaultItems.Buckets.BUCKET_MILK.Id, RawMaterials.BISMUTH.Id },
                          new LBINT{ 0, DefaultItems.Misc.FLUX_CAPACITOR.Id, 0 }
                     }, DefaultItems.Cooking.COFFEE_MACHINE);

            public static readonly CraftingRecipe KEBAB_MAKER = new(new()
            {
                new LBINT { 0, RawMaterials.BISMUTH_INGOT.Id, 0 },
                new LBINT { 0, RawMaterials.BISMUTH_INGOT.Id, 0 },
                new LBINT { RawMaterials.BISMUTH_INGOT.Id, DefaultItems.Misc.FLUX_CAPACITOR.Id, RawMaterials.BISMUTH_INGOT.Id }
            }, DefaultItems.Cooking.KEBAB_MAKER);

            public static readonly CraftingRecipe BASIC_OVEN = new(new()
            {
                new LBINT { RawMaterials.BISMUTH.Id, RawMaterials.CRYSTAL.Id, RawMaterials.BISMUTH.Id },
                new LBINT { RawMaterials.BISMUTH.Id, DefaultItems.Misc.GLASS.Id, RawMaterials.BISMUTH.Id },
                new LBINT { RawMaterials.BISMUTH.Id, DefaultItems.Misc.WIRE.Id, RawMaterials.BISMUTH.Id }
            }, DefaultItems.Cooking.BASIC_OVEN);

            public static readonly CraftingRecipe CRAZY_BLENDER = new(new()
                     {
                          new LBINT{ 0, DefaultItems.Misc.FLUX_CAPACITOR.Id, 0 },
                          new LBINT{ 0, DefaultItems.Cooking.BLENDER.Id, 0 },
                          new LBINT{ RawMaterials.BISMUTH_INGOT.Id, RawMaterials.BISMUTH_INGOT.Id, RawMaterials.BISMUTH_INGOT.Id }
                     }, DefaultItems.Cooking.CRAZY_BLENDER, 3);

            public override List<CraftingRecipe> GetAllCraftingRecipes()
            {
                return new List<CraftingRecipe>
                {
                    CRAZY_OVEN,
                    CUTTING_BOARD,
                    BLENDER,
                    FLUX_CAPACITOR,
                    COFFEE_MACHINE,
                    CRAZY_COFFEE_MACHINE,
                    CRAZY_CUTTING_BOARD,
                    KEBAB_MAKER,
                    BASIC_OVEN,
                    CRAZY_BLENDER
                };
            }
        }

        public class BlenderRecipes : CraftingCategoryList<BlenderRecipes>
        {
            public static readonly CraftingRecipe SMOOTHIE = new(new()
                     {
                          new LBINT{ Ingredients.BANANAS.Id, 0, 0 },
                          new LBINT{ 0, Ingredients.RASPBERRY.Id, 0 },
                          new LBINT{ 0, 0, DefaultItems.Buckets.BUCKET_MILK.Id }
                     }, Recipes.SMOOTHIE, 3);

            public static readonly CraftingRecipe BANANA_MILKSHAKE = new(new()
                     {
                          new LBINT{ 0, Ingredients.BANANAS.Id, 0 },
                          new LBINT{ 0, Ingredients.BANANAS.Id, 0 },
                          new LBINT{ 0, DefaultItems.Buckets.BUCKET_MILK.Id, 0 }
                     }, Recipes.BANANA_MILKSHAKE, 2);
            public override List<CraftingRecipe> GetAllCraftingRecipes()
            {
                return new List<CraftingRecipe>
                {
                    SMOOTHIE,
                    BANANA_MILKSHAKE,
                };
            }
        }

        public class CoffeeMachineRecipes : CraftingCategoryList<CoffeeMachineRecipes>
        {

            public static readonly CraftingRecipe COFFEE = new(new()
                     {
                          new LBINT{ 0, 0, 0 },
                          new LBINT{ 0, 0, 0 },
                          new LBINT{ 0, Ingredients.COFFEE_BEAN.Id, 0 }
                     }, Recipes.COFFEE, 2);

            public override List<CraftingRecipe> GetAllCraftingRecipes()
            {
                return new List<CraftingRecipe>
                {
                    COFFEE
                };
            }
        }

        public class OvenRecipes : CraftingCategoryList<OvenRecipes>
        {
            public static readonly CraftingRecipe BURGER = new(new()
                     {
                          new LBINT{ 0, Ingredients.LETTUCE.Id, Ingredients.CHEESE.Id },
                          new LBINT{ 0, Ingredients.MEAT.Id, Ingredients.TOMATO.Id },
                          new LBINT{ 0, Ingredients.DOUGH.Id, 0 }
                     }, Recipes.BURGER, 4);

            public static readonly CraftingRecipe PIZZA = new(new()
                     {
                          new LBINT{ Ingredients.OLIVES.Id, Ingredients.HAM.Id, Ingredients.TOMATO.Id },
                          new LBINT{ 0, Ingredients.CHEESE.Id, 0 },
                          new LBINT{ 0, Ingredients.DOUGH.Id, 0 }
                     }, Recipes.PIZZA, 4);

            public static readonly CraftingRecipe CUPCAKE = new(new()
                     {
                          new LBINT{ 0, 0, 0 },
                          new LBINT{ Ingredients.BUTTER.Id, Ingredients.SUGAR.Id, Ingredients.DOUGH.Id },
                          new LBINT{ Ingredients.WHIPPED_CREAM.Id, Ingredients.RASPBERRY.Id, Ingredients.EGG.Id }
                     }, Recipes.CUPCAKE, 4);

            public static readonly CraftingRecipe MAC_AND_CHEESE = new(new()
                     {
                          new LBINT{ 0, DefaultItems.Buckets.BUCKET_MILK.Id, 0 },
                          new LBINT{ 0, Ingredients.CHEESE.Id, 0},
                          new LBINT{0, Ingredients.PASTA.Id, 0 }
                     }, Recipes.MAC_AND_CHEESE, 3);

            public static readonly CraftingRecipe CROISSANT = new(new()
                     {
                          new LBINT{ Ingredients.EGG.Id, 0, Ingredients.SUGAR.Id },
                          new LBINT{0, DefaultItems.Buckets.BUCKET_WATER.Id, 0},
                          new LBINT{0, Ingredients.DOUGH.Id, 0 }
                     }, Recipes.CROISSANT, 4);



            public override List<CraftingRecipe> GetAllCraftingRecipes()
            {
                return new List<CraftingRecipe>
                {
                    BURGER,
                    PIZZA,
                    CUPCAKE,
                    CROISSANT,
                    MAC_AND_CHEESE
                };
            }
        }

        public class KebabMakerRecipes : CraftingCategoryList<KebabMakerRecipes>
        {
            public static readonly CraftingRecipe SHAWARMA = new(new()
                     {
                          new LBINT{ Ingredients.MEAT.Id, Ingredients.TOMATO.Id, Ingredients.DOUGH.Id},
                          new LBINT{ Ingredients.LETTUCE.Id, 0, 0 },
                          new LBINT{ 0, 0, 0 }
                     }, Recipes.SHAWARMA, 4);

            public override List<CraftingRecipe> GetAllCraftingRecipes()
            {
                return new List<CraftingRecipe>
                {
                    SHAWARMA
                };
            }

        }

        public class ChoppingBoardRecipes : CraftingCategoryList<ChoppingBoardRecipes>
        {
            public static readonly CraftingRecipe SALAD = new(new()
                     {
                          new LBINT{ 0, 0, 0 },
                          new LBINT{ 0, Ingredients.OLIVE_OIL.Id, 0 },
                          new LBINT{ Ingredients.TOMATO.Id, Ingredients.LETTUCE.Id, 0 }
                     }, Recipes.SALAD, 3);

            public override List<CraftingRecipe> GetAllCraftingRecipes()
            {
                return new List<CraftingRecipe>
                {
                    SALAD
                };
            }
        }

        public class Misc : CraftingCategoryList<Misc>
        {
            public static readonly CraftingRecipe BLADE = new(new()
            {
                new LBINT{ 0, RawMaterials.BISMUTH.Id, 0 },
                new LBINT{ RawMaterials.BISMUTH.Id, RawMaterials.CRYSTAL.Id, RawMaterials.BISMUTH.Id },
                new LBINT{ 0, RawMaterials.BISMUTH.Id, 0 }
            }, DefaultItems.Misc.BLADE, 2);


            public static readonly CraftingRecipe WIRE = new(new()
            {
                new LBINT { 0, 0, 0 },
                new LBINT { 0, 0, 0 },
                new LBINT { 0, RawMaterials.BISMUTH_INGOT.Id, RawMaterials.BISMUTH.Id }
            }, DefaultItems.Misc.WIRE, 2);

            public static readonly CraftingRecipe GLASS = new(new()
            {
                new LBINT { 0, 0, 0 },
                new LBINT { 0, RawMaterials.CRYSTAL.Id, 0 },
                new LBINT { 0, 0, 0 }
            }, DefaultItems.Misc.GLASS, 2);

            public static readonly CraftingRecipe POLE = new(new()
            {
                new LBINT { 0, RawMaterials.STICKS.Id, 0 },
                new LBINT { 0, RawMaterials.STICKS.Id, 0 },
                new LBINT { 0, RawMaterials.STICKS.Id, 0 }
            }, DefaultItems.Misc.POLE, 2);

            public override List<CraftingRecipe> GetAllCraftingRecipes()
            {
                return new List<CraftingRecipe>
                {
                    BLADE,
                    WIRE,
                    GLASS,
                    POLE
                };
            }
        }

        public class Tools : CraftingCategoryList<Tools>
        {
            public static readonly CraftingRecipe AXE = new(new()
            {
                new LBINT { 0, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id },
                new LBINT { 0, RawMaterials.STICKS.Id, RawMaterials.CRYSTAL.Id },
                new LBINT { 0, RawMaterials.STICKS.Id, 0 }
            }, DefaultItems.Tools.AXE);

            public static readonly CraftingRecipe SCYTHE = new(new()
            {
                new LBINT { RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, 0 },
                new LBINT { 0, RawMaterials.STICKS.Id, 0 },
                new LBINT { 0, RawMaterials.STICKS.Id, 0 }
            }, DefaultItems.Tools.SCYTHE);

            public static readonly CraftingRecipe HOE = new(new()
            {
                new LBINT { 0, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id },
                new LBINT { 0, RawMaterials.STICKS.Id, 0 },
                new LBINT { 0, RawMaterials.STICKS.Id, 0 }
            }, DefaultItems.Tools.HOE);

            public static readonly CraftingRecipe PICKAXE = new(new()
            {
                new LBINT { RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id, RawMaterials.CRYSTAL.Id },
                new LBINT { 0, RawMaterials.STICKS.Id, 0 },
                new LBINT { 0, RawMaterials.STICKS.Id, 0 }
            }, DefaultItems.Tools.PICKAXE);

            public static readonly CraftingRecipe WATERING_CAN_FULL = new(new()
            {
                new LBINT { 0, 0, 0 },
                new LBINT { RawMaterials.CRYSTAL.Id, 0, RawMaterials.CRYSTAL.Id },
                new LBINT { 0, RawMaterials.CRYSTAL.Id, 0 }
            }, DefaultItems.Tools.WATERING_CAN_FULL);

            //public static readonly CraftingRecipe WATERING_CAN_FULL = new(new()
            //{
            //    new LBINT { 0, 0, 0 },
            //    new LBINT { DefaultItems.Tools.WATERING_CAN.Id, 0, DefaultItems.Buckets.BUCKET_WATER.Id},
            //    new LBINT { 0, 0, 0 }
            //}, DefaultItems.Tools.WATERING_CAN_FULL);

            public override List<CraftingRecipe> GetAllCraftingRecipes()
            {
                return new List<CraftingRecipe>
                {
                    AXE,
                    SCYTHE,
                    HOE,
                    PICKAXE,
                    WATERING_CAN_FULL
                };
            }
        }

    }
}

