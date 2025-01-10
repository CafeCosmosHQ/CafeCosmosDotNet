using Tomato = VisionsContracts.Items.DefaultItems.Tomato;
using Lettuce = VisionsContracts.Items.DefaultItems.Lettuce;
using Wheat = VisionsContracts.Items.DefaultItems.Wheat;
using Tools = VisionsContracts.Items.DefaultItems.Tools;
using Ingredients = VisionsContracts.Items.DefaultItems.Ingredients;
using System.Collections.Generic;
using System.Linq;
using VisionsContracts.Transformations.Model;
using static VisionsContracts.Items.DefaultItems;
using VisionsContracts.Items;
using VisionsContracts.LandLocalState;
using System.Numerics;

namespace VisionsContracts.Transformations
{

    public class DefaultTransformations
    {
        public const int INITIAL_ITEMS_YIELD_MULTIPLIER = 4;
        public const int INITIAL_BISMUTH_FURNANCE_MULTIPLIER = 3;
        public static IList<ITransformationCategoryList> GetTransformationCategories()
        {

            var transformationCategories = new List<ITransformationCategoryList>
            {
                WallTransformations.Instance,
                TomatoTransformations.Instance,
                LettuceTransformations.Instance,
                WheatTransformations.Instance,
                ToolsTransformations.Instance,
                MachinesTransformations.Instance,
                TreesTransformations.Instance,
                AnimalsTransformations.Instance,
                BlenderTransformations.Instance,
                KebabMakerTransformations.Instance,
                OvenTransformations.Instance,
                CoffeeMachineTransformations.Instance,
                CuttingBoardTransformations.Instance,
                RobotTransformations.Instance,
                PastaMachineTransformations.Instance,
                WaterTankTransformations.Instance
            };
            return transformationCategories;
        }

        public static IList<Transformation> GetAllTransformations()
        {
            var list = new List<Transformation>();
            foreach (var category in GetTransformationCategories())
            {
                list.AddRange(category.GetAllTransformations());
            }
            list.AddRange(ThemeService.GetTransformations());
            return list;

        }

        public static IList<Transformation> GetAllTransformationsThatRequireUnlocking()
        {
            var transformations = GetAllTransformations();
            return transformations.Where(x => x.UnlockTime > 0).ToList();
        }

        public static IList<Transformation> GetTransformationsByYield(BigInteger yieldId)
        {
            var transformations = GetAllTransformations();
            return transformations.Where(x => x.Yield == yieldId).ToList();
        }

        public static BigInteger GetTransformationsInputByYield(BigInteger yieldId)
        {
            var transformationTree = GetTransformationTreeByYield(yieldId);
            if (transformationTree.Count == 0)
            {
                return 0;
            }

            if (transformationTree.Count == 1)
            {
                return transformationTree[0].Input;
            }

            if(transformationTree.Count == 2) 
            {
                var firstTransformation = transformationTree[0];
                var secondTransformation = transformationTree[1];
                if(secondTransformation.Yield == yieldId)
                {
                    return firstTransformation.Input;
                }
                else
                {
                    return secondTransformation.Input;
                }
            }

            return transformationTree[0].Input;
        }


        public static IList<Transformation> GetTransformationTreeByYield(BigInteger yieldId)
        {
            var transformations = GetAllTransformations();
            var yieldTransformation = transformations.FirstOrDefault(x => x.Yield == yieldId);
            var returnTransformations = new List<Transformation>();

            if (yieldTransformation != null)
            {
                returnTransformations.Add(yieldTransformation);
                if(yieldTransformation.Input == 0)
                {
                    var potentialPreviousStage = transformations.FirstOrDefault(x => x.Next == yieldTransformation.Base);
                    if (potentialPreviousStage != null)
                    {
                        returnTransformations.Add(potentialPreviousStage);
                    }
                }
            }
            return returnTransformations;
        }


        public static Transformation FindTransformation(int baseItemId, int inputItemId)
        {
            return GetAllTransformations().FirstOrDefault(x => x.Base == baseItemId && x.Input == inputItemId);
        }

        public static Transformation FindTransformation(int baseItemId)
        {
            return GetAllTransformations().FirstOrDefault(x => x.Base == baseItemId);
        }

        public class WallTransformations : TransformationCategoryList<WallTransformations>
        {
            public static readonly Transformation WallMenuTransformation = new()
            {
                Base = DefaultItems.Decorations.WALL.Id,
                Input = DefaultItems.Decorations.WALL_MENU.Id,
                Next = DefaultItems.Decorations.WALL_WITH_MENU.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,
            };

            public static readonly Transformation WallSignboardTransformation = new()
            {
                Base = DefaultItems.Decorations.WALL.Id,
                Input = DefaultItems.Decorations.SIGNBOARD.Id,
                Next = DefaultItems.Decorations.WALL_WITH_SIGNBOARD.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,
            };

            public static readonly Transformation WallWindowTransformation = new()
            {
                Base = DefaultItems.Decorations.WALL.Id,
                Input = DefaultItems.Decorations.WINDOW.Id,
                Next = DefaultItems.Decorations.WALL_WITH_WINDOW.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,
            };


            public static readonly Transformation WallWithWindowPickAxeTransformation = new()
            {
                Base = DefaultItems.Decorations.WALL_WITH_WINDOW.Id,
                Input = DefaultItems.Tools.PICKAXE.Id,
                Next = DefaultItems.Decorations.WALL.Id,
                Yield = DefaultItems.Decorations.WINDOW.Id,
                YieldQuantity = 1 ,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,

                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,
            };

            public static readonly Transformation WallWithSignboardPickAxeTransformation = new()
            {
                Base = DefaultItems.Decorations.WALL_WITH_SIGNBOARD.Id,
                Input = DefaultItems.Tools.PICKAXE.Id,
                Next = DefaultItems.Decorations.WALL.Id,
                Yield = DefaultItems.Decorations.SIGNBOARD.Id,
                YieldQuantity = 1 ,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,

                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,
            };

            public static readonly Transformation WallWithMenuPickAxeTransformation = new()
            {
                Base = DefaultItems.Decorations.WALL_WITH_MENU.Id,
                Input = DefaultItems.Tools.PICKAXE.Id,
                Next = DefaultItems.Decorations.WALL.Id,
                Yield = DefaultItems.Decorations.WALL_MENU.Id,
                YieldQuantity = 1 ,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,
            };


            public override List<Transformation> GetAllTransformations()
            {
                return new List<Transformation> {
                                                   WallMenuTransformation,
                                                   WallSignboardTransformation,
                                                   WallWindowTransformation,
                                                   WallWithMenuPickAxeTransformation,
                                                   WallWithSignboardPickAxeTransformation,
                                                   WallWithWindowPickAxeTransformation,


                                                };
            }

        }


        public class RobotTransformations : TransformationCategoryList<RobotTransformations>
        {
            public static readonly Transformation RobotOlivesTransformation = new()
            {
                Base = DefaultItems.Machines.ROBOT.Id,
                Input = DefaultItems.Ingredients.RASPBERRY.Id,
                Next = DefaultItems.Machines.ROBOT_MAKING_MEAT.Id,
                Yield = 0,
                YieldQuantity = 0 , 
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,
                Xp = 2 
            };

            public static readonly Transformation RobotMakingMeatClickTransformation = new()
            {
                Base = DefaultItems.Machines.ROBOT_MAKING_MEAT.Id,
                Input = 0,
                Next = DefaultItems.Machines.ROBOT.Id,
                Yield = DefaultItems.Ingredients.MEAT.Id,
                YieldQuantity = 1 ,
                UnlockTime = 104,
                Timeout = 0,
                TimeoutNext = 0,

                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,
            };


            public static readonly Transformation RobotTomatoTransformation = new()
            {
                Base = DefaultItems.Machines.ROBOT.Id,
                Input = DefaultItems.Ingredients.AVOCADO.Id,
                Next = DefaultItems.Machines.ROBOT_MAKING_HAM.Id,
                Yield = 0,
                YieldQuantity = 0 ,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,
            };

            public static readonly Transformation RobotMakingHamClickTransformation = new()
            {
                Base = DefaultItems.Machines.ROBOT_MAKING_HAM.Id,
                Input = 0,
                Next = DefaultItems.Machines.ROBOT.Id,
                Yield = DefaultItems.Ingredients.HAM.Id,
                YieldQuantity = 1 ,
                UnlockTime = 104,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,
            };

            public override List<Transformation> GetAllTransformations()
            {
                return new List<Transformation> {
                                                   RobotOlivesTransformation,
                                                   RobotMakingMeatClickTransformation,
                                                   RobotTomatoTransformation,
                                                   RobotMakingHamClickTransformation
                                                };
            }
        }


        public class CuttingBoardTransformations : TransformationCategoryList<CuttingBoardTransformations>
        {

            public static readonly Transformation CuttingBoardSaladTransformation_1 = new()
            {
                Base = DefaultItems.Cooking.CUTTING_BOARD.Id,
                Input = DefaultItems.Recipes.SALAD.Id,
                Next = DefaultItems.Cooking.CUTTING_BOARD_CHOPPING_SALAD.Id,
                Yield = 0,
                YieldQuantity = 0 ,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = true,
                Exists = true,
            };

            public static readonly Transformation CuttingBoardChoppingSaladClickTransformation_2 = new()
            {
                Base = DefaultItems.Cooking.CUTTING_BOARD_CHOPPING_SALAD.Id,
                Input = 0,
                Next = DefaultItems.Cooking.CUTTING_BOARD.Id,
                Yield = 0,
                YieldQuantity = 0 ,
                UnlockTime = 270, // preparation time
                Timeout = 10000, // all this time to collect it
                TimeoutNext = DefaultItems.Cooking.CUTTING_BOARD.Id,
                TimeoutYield = DefaultItems.Ingredients.DUST.Id,
                TimeoutYieldQuantity = 1,
                IsRecipe = false,
                Exists = true,
            };

            public static readonly Transformation CrazyCuttingBoardSaladTransformation_1 = new()
            {
                Base = DefaultItems.Cooking.CRAZY_CUTTING_BOARD.Id,
                Input = DefaultItems.Recipes.SALAD.Id,
                Next = DefaultItems.Cooking.CRAZY_CUTTING_BOARD_CHOPPING_SALAD.Id,
                Yield = 0,
                YieldQuantity = 0 ,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = true,
                Exists = true,
            };

            public static readonly Transformation CrazyCuttingBoardChoppingSaladClickTransformation_2 = new()
            {
                Base = DefaultItems.Cooking.CRAZY_CUTTING_BOARD_CHOPPING_SALAD.Id,
                Input = 0,
                Next = DefaultItems.Cooking.CRAZY_CUTTING_BOARD.Id,
                Yield = 0,
                YieldQuantity = 0 ,
                UnlockTime = 270,
                Timeout = 10000,
                TimeoutNext = DefaultItems.Cooking.CRAZY_CUTTING_BOARD.Id,
                TimeoutYield = DefaultItems.Ingredients.DUST.Id,
                TimeoutYieldQuantity = 1,
                IsRecipe = false,
                Exists = true,
            };



            public override List<Transformation> GetAllTransformations()
            {
                return new List<Transformation> {
                                                   CuttingBoardSaladTransformation_1,
                                                   CuttingBoardChoppingSaladClickTransformation_2,

                                                   CrazyCuttingBoardSaladTransformation_1,
                                                   CrazyCuttingBoardChoppingSaladClickTransformation_2
                                                };
            }
        }


        public class CoffeeMachineTransformations : TransformationCategoryList<CoffeeMachineTransformations>
        {
            public static readonly Transformation CoffeeMachineCoffeeTransformation_1 = new()
            {
                Base = DefaultItems.Cooking.COFFEE_MACHINE.Id,
                Input = DefaultItems.Recipes.COFFEE.Id,
                Next = DefaultItems.Cooking.COFFEE_MACHINE_BREWING.Id,
                Yield = 0,
                YieldQuantity = 0 ,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = true,
                Exists = true,
            };

            public static readonly Transformation CoffeeMachineBrewingClickTransformation_2 = new()
            {
                Base = DefaultItems.Cooking.COFFEE_MACHINE_BREWING.Id,
                Input = 0,
                Next = DefaultItems.Cooking.COFFEE_MACHINE.Id,
                Yield = 0,
                YieldQuantity = 0 ,
                UnlockTime = 120,
                Timeout = 500,
                TimeoutNext = DefaultItems.Cooking.COFFEE_MACHINE.Id,
                TimeoutYield = DefaultItems.Ingredients.DUST.Id,
                TimeoutYieldQuantity = 1,
                IsRecipe = false,
                Exists = true,
            };

            public static readonly Transformation CrazyCoffeeMachineCoffeeTransformation_1 = new()
            {
                Base = DefaultItems.Cooking.CRAZY_COFFEE_MACHINE.Id,
                Input = DefaultItems.Recipes.COFFEE.Id,
                Next = DefaultItems.Cooking.CRAZY_COFFEE_MACHINE_BREWING.Id,
                Yield = 0,
                YieldQuantity = 0 ,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = true,
                Exists = true,
            };

            public static readonly Transformation CrazyCoffeeMachineBrewingClickTransformation_2 = new()
            {
                Base = DefaultItems.Cooking.CRAZY_COFFEE_MACHINE_BREWING.Id,
                Input = 0,
                Next = DefaultItems.Cooking.CRAZY_COFFEE_MACHINE.Id,
                Yield = 0,
                YieldQuantity = 0 ,
                UnlockTime = 120,
                Timeout = 500,
                TimeoutNext = DefaultItems.Cooking.CRAZY_COFFEE_MACHINE.Id,
                TimeoutYield = DefaultItems.Ingredients.DUST.Id,
                TimeoutYieldQuantity = 1,
                IsRecipe = false,
                Exists = true,
            };

            public override List<Transformation> GetAllTransformations()
            {
                return new List<Transformation> {
                                                    CoffeeMachineCoffeeTransformation_1,
                                                    CoffeeMachineBrewingClickTransformation_2,

                                                    CrazyCoffeeMachineCoffeeTransformation_1,
                                                    CrazyCoffeeMachineBrewingClickTransformation_2
                                                };
            }
        }

        public class KebabMakerTransformations : TransformationCategoryList<KebabMakerTransformations>
        {
            public static readonly Transformation KebabMakerKebabTransformation_1 = new()
            {
                Base = DefaultItems.Cooking.KEBAB_MAKER.Id,
                Input = DefaultItems.Recipes.SHAWARMA.Id,
                Next = DefaultItems.Cooking.KEBAB_MAKER_COOKING_KEBAB.Id,
                Yield = 0,
                YieldQuantity = 0 ,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = true,
                Exists = true,
            };

            public static readonly Transformation KebabMakerCookingKebabClickTransformation_2 = new()
            {
                Base = DefaultItems.Cooking.KEBAB_MAKER_COOKING_KEBAB.Id,
                Input = 0,
                Next = DefaultItems.Cooking.KEBAB_MAKER.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 500,
                Timeout = 10000,
                TimeoutNext = DefaultItems.Cooking.KEBAB_MAKER.Id,
                TimeoutYield = DefaultItems.Ingredients.DUST.Id,
                TimeoutYieldQuantity = 1,
                IsRecipe = false,
                Exists = true,
            };

            public override List<Transformation> GetAllTransformations()
            {
                return new List<Transformation> {
                                                    KebabMakerKebabTransformation_1,
                                                    KebabMakerCookingKebabClickTransformation_2,
                                                };
            }
        }

        public class PastaMachineTransformations : TransformationCategoryList<PastaMachineTransformations>
        {
            public static readonly Transformation PastaMachineDoughTransformation = new()
            {
                Base = DefaultItems.Machines.PASTA_MACHINE.Id,
                Input = DefaultItems.Ingredients.DOUGH.Id,
                Next = DefaultItems.Machines.PASTA_MACHINE_MAKING_PASTA.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,
            };


            public static readonly Transformation PastaMachineMakingPastaTransformation = new()
            {
                Base = DefaultItems.Machines.PASTA_MACHINE_MAKING_PASTA.Id,
                Input = 0,
                Next = DefaultItems.Machines.PASTA_MACHINE.Id,
                Yield = DefaultItems.Ingredients.PASTA.Id,
                YieldQuantity = 1,
                UnlockTime = 244,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,
                Xp = 3
            };
            public override List<Transformation> GetAllTransformations()
            {
                return new List<Transformation> {
                                                   PastaMachineDoughTransformation,
                                                   PastaMachineMakingPastaTransformation
                                                };
            }
        }


        public class BlenderTransformations : TransformationCategoryList<BlenderTransformations>
        {
            public static readonly Transformation BlenderSmoothieTransformation_1 = new()
            {
                Base = DefaultItems.Cooking.BLENDER.Id,
                Input = DefaultItems.Recipes.SMOOTHIE.Id,
                Next = DefaultItems.Cooking.BLENDER_BLENDING_SMOOTHIE.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = true,
                Exists = true,
            };

            public static readonly Transformation BlenderBlendingSmoothieClickTransformation_2 = new()
            {
                Base = DefaultItems.Cooking.BLENDER_BLENDING_SMOOTHIE.Id,
                Input = 0,
                Next = DefaultItems.Cooking.BLENDER.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 290,
                Timeout = 10000,
                TimeoutNext = DefaultItems.Cooking.BLENDER.Id,
                TimeoutYield = DefaultItems.Ingredients.DUST.Id,
                TimeoutYieldQuantity = 1,
                IsRecipe = false,
                Exists = true,
            };




            public static readonly Transformation BlenderBananaMilkshakeTransformation_1 = new()
            {
                Base = DefaultItems.Cooking.BLENDER.Id,
                Input = DefaultItems.Recipes.BANANA_MILKSHAKE.Id,
                Next = DefaultItems.Cooking.BLENDER_BLENDING_BANANA_MILKSHAKE.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = true,
                Exists = true,
            };

            public static readonly Transformation BlenderBlendingBananaMilkshakeClickTransformation_2 = new()
            {
                Base = DefaultItems.Cooking.BLENDER_BLENDING_BANANA_MILKSHAKE.Id,
                Input = 0,
                Next = DefaultItems.Cooking.BLENDER.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 310,
                Timeout = 10000,
                TimeoutNext = DefaultItems.Cooking.BLENDER.Id,
                TimeoutYield = DefaultItems.Ingredients.DUST.Id,
                TimeoutYieldQuantity = 1,
                IsRecipe = false,
                Exists = true,
            };




            public static readonly Transformation CrazyBlenderSmoothieTransformation_1 = new()
            {
                Base = DefaultItems.Cooking.CRAZY_BLENDER.Id,
                Input = DefaultItems.Recipes.SMOOTHIE.Id,
                Next = DefaultItems.Cooking.CRAZY_BLENDER_BLENDING_SMOOTHIE.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = true,
                Exists = true,
            };

            public static readonly Transformation CrazyBlenderBlendingSmoothieClickTransformation_2 = new()
            {
                Base = DefaultItems.Cooking.CRAZY_BLENDER_BLENDING_SMOOTHIE.Id,
                Input = 0,
                Next = DefaultItems.Cooking.CRAZY_BLENDER.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 290,
                Timeout = 10000,
                TimeoutNext = DefaultItems.Cooking.CRAZY_BLENDER.Id,
                TimeoutYield = DefaultItems.Ingredients.DUST.Id,
                TimeoutYieldQuantity = 1,
                IsRecipe = false,
                Exists = true,
            };




            public static readonly Transformation CrazyBlenderBananaMilkshakeTransformation_1 = new()
            {
                Base = DefaultItems.Cooking.CRAZY_BLENDER.Id,
                Input = DefaultItems.Recipes.BANANA_MILKSHAKE.Id,
                Next = DefaultItems.Cooking.CRAZY_BLENDER_BLENDING_BANANA_MILKSHAKE.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = true,
                Exists = true,
            };

            public static readonly Transformation CrazyBlenderBlendingBananaMilkshakeClickTransformation_2 = new()
            {
                Base = DefaultItems.Cooking.CRAZY_BLENDER_BLENDING_BANANA_MILKSHAKE.Id,
                Input = 0,
                Next = DefaultItems.Cooking.CRAZY_BLENDER.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 310,
                Timeout = 10000,
                TimeoutNext = DefaultItems.Cooking.CRAZY_BLENDER.Id,
                TimeoutYield = DefaultItems.Ingredients.DUST.Id,
                TimeoutYieldQuantity = 1,
                IsRecipe = false,
                Exists = true,
            };


            public override List<Transformation> GetAllTransformations()
            {
                return new List<Transformation> {
                                                    BlenderSmoothieTransformation_1,
                                                    BlenderBlendingSmoothieClickTransformation_2,

                                                    BlenderBananaMilkshakeTransformation_1,
                                                    BlenderBlendingBananaMilkshakeClickTransformation_2,

                                                    CrazyBlenderSmoothieTransformation_1,
                                                    CrazyBlenderBlendingSmoothieClickTransformation_2,

                                                    CrazyBlenderBananaMilkshakeTransformation_1,
                                                    CrazyBlenderBlendingBananaMilkshakeClickTransformation_2
                                                };
            }
        }


        public class OvenTransformations : TransformationCategoryList<OvenTransformations>
        {
            public static readonly Transformation BasicOvenBurgerTransformation_1 = new()
            {
                Base = DefaultItems.Cooking.BASIC_OVEN.Id,
                Input = DefaultItems.Recipes.BURGER.Id,
                Next = DefaultItems.Cooking.BASIC_OVEN_COOKING_BURGER.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = true,
                Exists = true,
            };

            public static readonly Transformation BasicOvenCookingBurgerClickTransformation_2 = new()
            {
                Base = DefaultItems.Cooking.BASIC_OVEN_COOKING_BURGER.Id,
                Input = 0,
                Next = DefaultItems.Cooking.BASIC_OVEN.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 350,
                Timeout = 10000,
                TimeoutNext = DefaultItems.Cooking.BASIC_OVEN.Id,
                TimeoutYield = DefaultItems.Ingredients.DUST.Id,
                TimeoutYieldQuantity = 1,
                IsRecipe = false,
                Exists = true,
            };

            public static readonly Transformation BasicOvenCroissantTransformation_1 = new()
            {
                Base = DefaultItems.Cooking.BASIC_OVEN.Id,
                Input = DefaultItems.Recipes.CROISSANT.Id,
                Next = DefaultItems.Cooking.BASIC_OVEN_COOKING_CROISSANT.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = true,
                Exists = true,
            };

            public static readonly Transformation BasicOvenCookingCroissantClickTransformation_2 = new()
            {
                Base = DefaultItems.Cooking.BASIC_OVEN_COOKING_CROISSANT.Id,
                Input = 0,
                Next = DefaultItems.Cooking.BASIC_OVEN.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 480,
                Timeout = 10000,
                TimeoutNext = DefaultItems.Cooking.BASIC_OVEN.Id,
                TimeoutYield = DefaultItems.Ingredients.DUST.Id,
                TimeoutYieldQuantity = 1,
                IsRecipe = false,
                Exists = true,
            };

            public static readonly Transformation BasicOvenPizzaTransformation_1 = new()
            {
                Base = DefaultItems.Cooking.BASIC_OVEN.Id,
                Input = DefaultItems.Recipes.PIZZA.Id,
                Next = DefaultItems.Cooking.BASIC_OVEN_COOKING_PIZZA.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = true,
                Exists = true,
            };


            public static readonly Transformation BasicOvenCookingPizzaClickTransformation_2 = new()
            {
                Base = DefaultItems.Cooking.BASIC_OVEN_COOKING_PIZZA.Id,
                Input = 0,
                Next = DefaultItems.Cooking.BASIC_OVEN.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 470,
                Timeout = 10000,
                TimeoutNext = DefaultItems.Cooking.BASIC_OVEN.Id,
                TimeoutYield = DefaultItems.Ingredients.DUST.Id,
                TimeoutYieldQuantity = 1,
                IsRecipe = false,
                Exists = true,
            };


            public static readonly Transformation BasicOvenCupcakeTransformation_1 = new()
            {
                Base = DefaultItems.Cooking.BASIC_OVEN.Id,
                Input = DefaultItems.Recipes.CUPCAKE.Id,
                Next = DefaultItems.Cooking.BASIC_OVEN_COOKING_CUPCAKE.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = true,
                Exists = true,
            };


            public static readonly Transformation BasicOvenCookingCupcakeClickTransformation_2 = new()
            {
                Base = DefaultItems.Cooking.BASIC_OVEN_COOKING_CUPCAKE.Id,
                Input = 0,
                Next = DefaultItems.Cooking.BASIC_OVEN.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 360,
                Timeout = 10000,
                TimeoutNext = DefaultItems.Cooking.BASIC_OVEN.Id,
                TimeoutYield = DefaultItems.Ingredients.DUST.Id,
                TimeoutYieldQuantity = 1,
                IsRecipe = false,
                Exists = true,
            };

            public static readonly Transformation BasicOvenMacAndCheeseTransformation_1 = new()
            {
                Base = DefaultItems.Cooking.BASIC_OVEN.Id,
                Input = DefaultItems.Recipes.MAC_AND_CHEESE.Id,
                Next = DefaultItems.Cooking.BASIC_OVEN_COOKING_MAC_AND_CHEESE.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = true,
                Exists = true,
            };


            public static readonly Transformation BasicOvenCookingMacAndCheeseClickTransformation_2 = new()
            {
                Base = DefaultItems.Cooking.BASIC_OVEN_COOKING_MAC_AND_CHEESE.Id,
                Input = 0,
                Next = DefaultItems.Cooking.BASIC_OVEN.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 360,
                Timeout = 10000,
                TimeoutNext = DefaultItems.Cooking.BASIC_OVEN.Id,
                TimeoutYield = DefaultItems.Ingredients.DUST.Id,
                TimeoutYieldQuantity = 1,
                IsRecipe = false,
                Exists = true,
            };



            public static readonly Transformation CrazyOvenBurgerTransformation_1 = new()
            {
                Base = DefaultItems.Cooking.CRAZY_OVEN.Id,
                Input = DefaultItems.Recipes.BURGER.Id,
                Next = DefaultItems.Cooking.CRAZY_OVEN_COOKING_BURGER.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = true,
                Exists = true,
            };

            public static readonly Transformation CrazyOvenCookingBurgerClickTransformation_2 = new()
            {
                Base = DefaultItems.Cooking.CRAZY_OVEN_COOKING_BURGER.Id,
                Input = 0,
                Next = DefaultItems.Cooking.CRAZY_OVEN.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 350,
                Timeout = 10000,
                TimeoutNext = DefaultItems.Cooking.CRAZY_OVEN.Id,
                TimeoutYield = DefaultItems.Ingredients.DUST.Id,
                TimeoutYieldQuantity = 1,
                IsRecipe = false,
                Exists = true,
            };

            public static readonly Transformation CrazyOvenCroissantTransformation_1 = new()
            {
                Base = DefaultItems.Cooking.CRAZY_OVEN.Id,
                Input = DefaultItems.Recipes.CROISSANT.Id,
                Next = DefaultItems.Cooking.CRAZY_OVEN_COOKING_CROISSANT.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = true,
                Exists = true,
            };

            public static readonly Transformation CrazyOvenCookingCroissantClickTransformation_2 = new()
            {
                Base = DefaultItems.Cooking.CRAZY_OVEN_COOKING_CROISSANT.Id,
                Input = 0,
                Next = DefaultItems.Cooking.CRAZY_OVEN.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 480,
                Timeout = 10000,
                TimeoutNext = DefaultItems.Cooking.CRAZY_OVEN.Id,
                TimeoutYield = DefaultItems.Ingredients.DUST.Id,
                TimeoutYieldQuantity = 1,
                IsRecipe = false,
                Exists = true,
            };

            public static readonly Transformation CrazyOvenPizzaTransformation_1 = new()
            {
                Base = DefaultItems.Cooking.CRAZY_OVEN.Id,
                Input = DefaultItems.Recipes.PIZZA.Id,
                Next = DefaultItems.Cooking.CRAZY_OVEN_COOKING_PIZZA.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = true,
                Exists = true,
            };


            public static readonly Transformation CrazyOvenCookingPizzaClickTransformation_2 = new()
            {
                Base = DefaultItems.Cooking.CRAZY_OVEN_COOKING_PIZZA.Id,
                Input = 0,
                Next = DefaultItems.Cooking.CRAZY_OVEN.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 470,
                Timeout = 10000,
                TimeoutNext = DefaultItems.Cooking.CRAZY_OVEN.Id,
                TimeoutYield = DefaultItems.Ingredients.DUST.Id,
                TimeoutYieldQuantity = 1,
                IsRecipe = false,
                Exists = true,
            };


            public static readonly Transformation CrazyOvenCupcakeTransformation_1 = new()
            {
                Base = DefaultItems.Cooking.CRAZY_OVEN.Id,
                Input = DefaultItems.Recipes.CUPCAKE.Id,
                Next = DefaultItems.Cooking.CRAZY_OVEN_COOKING_CUPCAKE.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = true,
                Exists = true,
            };


            public static readonly Transformation CrazyOvenCookingCupcakeClickTransformation_2 = new()
            {
                Base = DefaultItems.Cooking.CRAZY_OVEN_COOKING_CUPCAKE.Id,
                Input = 0,
                Next = DefaultItems.Cooking.CRAZY_OVEN.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 360,
                Timeout = 10000,
                TimeoutNext = DefaultItems.Cooking.CRAZY_OVEN.Id,
                TimeoutYield = DefaultItems.Ingredients.DUST.Id,
                TimeoutYieldQuantity = 1,
                IsRecipe = false,
                Exists = true,
            };


            public static readonly Transformation CrazyOvenMacAndCheeseTransformation_1 = new()
            {
                Base = DefaultItems.Cooking.CRAZY_OVEN.Id,
                Input = DefaultItems.Recipes.MAC_AND_CHEESE.Id,
                Next = DefaultItems.Cooking.CRAZY_OVEN_COOKING_MAC_AND_CHEESE.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = true,
                Exists = true,
            };


            public static readonly Transformation CrazyOvenCookingMacAndCheeseClickTransformation_2 = new()
            {
                Base = DefaultItems.Cooking.CRAZY_OVEN_COOKING_MAC_AND_CHEESE.Id,
                Input = 0,
                Next = DefaultItems.Cooking.CRAZY_OVEN.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 360,
                Timeout = 10000,
                TimeoutNext = DefaultItems.Cooking.CRAZY_OVEN.Id,
                TimeoutYield = DefaultItems.Ingredients.DUST.Id,
                TimeoutYieldQuantity = 1,
                IsRecipe = false,
                Exists = true,
            };


            public override List<Transformation> GetAllTransformations()
            {
                return new List<Transformation> {
                                                    BasicOvenBurgerTransformation_1,
                                                    BasicOvenCookingBurgerClickTransformation_2,

                                                    BasicOvenCroissantTransformation_1,
                                                    BasicOvenCookingCroissantClickTransformation_2,

                                                    BasicOvenPizzaTransformation_1,
                                                    BasicOvenCookingPizzaClickTransformation_2,

                                                    BasicOvenCupcakeTransformation_1,
                                                    BasicOvenCookingCupcakeClickTransformation_2,

                                                    BasicOvenMacAndCheeseTransformation_1,
                                                    BasicOvenCookingMacAndCheeseClickTransformation_2,

                                                    CrazyOvenBurgerTransformation_1,
                                                    CrazyOvenCookingBurgerClickTransformation_2,

                                                    CrazyOvenCroissantTransformation_1,
                                                    CrazyOvenCookingCroissantClickTransformation_2,

                                                    CrazyOvenPizzaTransformation_1,
                                                    CrazyOvenCookingPizzaClickTransformation_2,

                                                    CrazyOvenCupcakeTransformation_1,
                                                    CrazyOvenCookingCupcakeClickTransformation_2,

                                                    CrazyOvenMacAndCheeseTransformation_1,
                                                    CrazyOvenCookingMacAndCheeseClickTransformation_2
                                                };
            }
        }



        public class AnimalsTransformations : TransformationCategoryList<AnimalsTransformations>
        {
            public static readonly Transformation CowBucketEmptyTransformation = new()
            {
                Base = DefaultItems.Animals.COW.Id,
                Input = DefaultItems.Buckets.BUCKET_EMPTY.Id,
                Next = DefaultItems.Animals.COW.Id,
                Yield = DefaultItems.Buckets.BUCKET_MILK.Id,
                YieldQuantity = 1,
                UnlockTime = 240,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,
            };

            public static readonly Transformation CowGivingMilkClickTransformation = new()
            {
                Base = DefaultItems.Animals.COW_GIVING_MILK.Id,
                Input = DefaultItems.Buckets.BUCKET_EMPTY.Id,
                Next = DefaultItems.Animals.COW.Id,
                Yield = DefaultItems.Buckets.BUCKET_MILK.Id,
                YieldQuantity = 1,
                UnlockTime = 240,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,
            };

            public static readonly Transformation ChickenClickTransformation = new()
            {
                Base = DefaultItems.Animals.CHICKEN.Id,
                Input = 0,
                Next = DefaultItems.Animals.CHICKEN.Id,
                Yield = DefaultItems.Ingredients.EGG.Id,
                YieldQuantity = 1,
                UnlockTime = 120,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,
                Xp = 1
            };

            public override List<Transformation> GetAllTransformations()
            {
                return new List<Transformation> {
                                                    CowBucketEmptyTransformation,
                                                    CowGivingMilkClickTransformation,
                                                    ChickenClickTransformation
                                                };
            }
        }


        public class TreesTransformations : TransformationCategoryList<TreesTransformations>
        {
            public static readonly Transformation AvocadoTreeClickTransformation = new()
            {
                Base = DefaultItems.Trees.AVOCADO_TREE.Id,
                Input = 0,
                Next = DefaultItems.Trees.AVOCADO_TREE.Id,
                Yield = DefaultItems.Ingredients.AVOCADO.Id,
                YieldQuantity = 1,
                UnlockTime = 120,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,
                Xp = 1,
            };

            public static readonly Transformation BananaTreeClickTransformation = new()
            {
                Base = DefaultItems.Trees.BANANA_TREE.Id,
                Input = 0,
                Next = DefaultItems.Trees.BANANA_TREE.Id,
                Yield = DefaultItems.Ingredients.BANANAS.Id,
                YieldQuantity = 3,
                UnlockTime = 300,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,
                Xp = 1
            };

            public static readonly Transformation OliveTreeClickTransformation = new()
            {
                Base = DefaultItems.Trees.OLIVE_TREE.Id,
                Input = 0,
                Next = DefaultItems.Trees.OLIVE_TREE.Id,
                Yield = DefaultItems.Ingredients.OLIVES.Id,
                YieldQuantity = 1,
                UnlockTime = 240,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,
                Xp = 1
            };


            public static readonly Transformation RaspberryBushClickTransformation = new()
            {
                Base = DefaultItems.Bushes.RASPBERRY_BUSH.Id,
                Input = 0,
                Next = DefaultItems.Bushes.RASPBERRY_BUSH.Id,
                Yield = DefaultItems.Ingredients.RASPBERRY.Id,
                YieldQuantity = 3,
                UnlockTime = 270,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,
                Xp = 1
            };


            public static readonly Transformation SugarTreeClickTransformation = new()
            {
                Base = DefaultItems.Trees.SUGAR_TREE.Id,
                Input = 0,
                Next = DefaultItems.Trees.SUGAR_TREE.Id,
                Yield = DefaultItems.Ingredients.SUGAR.Id,
                YieldQuantity = 3,
                UnlockTime = 300,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,
                Xp = 1
            };

            public static readonly Transformation CoffeeBushClickTransformation = new()
            {
                Base = DefaultItems.Bushes.COFFEE_BUSH.Id,
                Input = 0,
                Next = DefaultItems.Bushes.COFFEE_BUSH.Id,
                Yield = DefaultItems.Ingredients.COFFEE_BEAN.Id,
                YieldQuantity = 3,
                UnlockTime = 270,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,
                Xp = 1
            };

            public override List<Transformation> GetAllTransformations()
            {
                return new List<Transformation> {
                                                    AvocadoTreeClickTransformation,
                                                    RaspberryBushClickTransformation,
                                                    SugarTreeClickTransformation,
                                                    CoffeeBushClickTransformation,
                                                    BananaTreeClickTransformation,
                                                    OliveTreeClickTransformation
                                                };
            }
        }

        public class ToolsTransformations : TransformationCategoryList<ToolsTransformations>
        {
            public static readonly Transformation CrystalClickTransformation = new()
            {
                Base = RawMaterials.CRYSTAL.Id,
                Input = 0,
                Next = 0,
                Yield = RawMaterials.CRYSTAL.Id,
                YieldQuantity = 3 * INITIAL_ITEMS_YIELD_MULTIPLIER,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,
            };

            public static readonly Transformation SticksClickTransformation = new()
            {
                Base = RawMaterials.STICKS.Id,
                Input = 0,
                Next = 0,
                Yield = RawMaterials.STICKS.Id,
                YieldQuantity = 1 * INITIAL_ITEMS_YIELD_MULTIPLIER,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,
            };

            public static readonly Transformation BismuthPickAxeTransformation = new()
            {
                Base = RawMaterials.BISMUTH.Id,
                Input = Tools.PICKAXE.Id,
                Next = 0,
                Yield = RawMaterials.BISMUTH.Id,
                YieldQuantity = 1 * INITIAL_ITEMS_YIELD_MULTIPLIER,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation TrapezoidBlackPickAxeTransformation = new()
            {
                Base = RawMaterials.BLACK_TRAPEZOID.Id,
                Input = Tools.PICKAXE.Id,
                Next = 0,
                Yield = RawMaterials.BLACK_TRAPEZOID.Id,
                YieldQuantity = 1 * INITIAL_ITEMS_YIELD_MULTIPLIER,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation ClayHoeTransformation = new()
            {
                Base = RawMaterials.CLAY.Id,
                Input = Tools.HOE.Id,
                Next = 0,
                Yield = RawMaterials.CLAY.Id,
                YieldQuantity = 1 * INITIAL_ITEMS_YIELD_MULTIPLIER,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };



            public static readonly Transformation AvocadoTreeAxeTransformation = new()
            {
                Base = Trees.AVOCADO_TREE.Id,
                Input = Tools.AXE.Id,
                Next = 0,
                Yield = RawMaterials.WOOD_PURPLE.Id,
                YieldQuantity = 3 * INITIAL_ITEMS_YIELD_MULTIPLIER,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation OliveTreeAxeTransformation = new()
            {
                Base = Trees.OLIVE_TREE.Id,
                Input = Tools.AXE.Id,
                Next = 0,
                Yield = RawMaterials.WOOD_PURPLE.Id,
                YieldQuantity = 3 * INITIAL_ITEMS_YIELD_MULTIPLIER,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation BananaTreeAxeTransformation = new()
            {
                Base = Trees.BANANA_TREE.Id,
                Input = Tools.AXE.Id,
                Next = 0,
                Yield = RawMaterials.WOOD_PINK.Id,
                YieldQuantity = 3 * INITIAL_ITEMS_YIELD_MULTIPLIER,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation SugarTreeAxeTransformation = new()
            {
                Base = Trees.SUGAR_TREE.Id,
                Input = Tools.AXE.Id,
                Next = 0,
                Yield = RawMaterials.WOOD_PINK.Id,
                YieldQuantity = 3 * INITIAL_ITEMS_YIELD_MULTIPLIER,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation SimpleTreeAxeTransformation = new()
            {
                Base = Trees.SIMPLE_TREE.Id,
                Input = Tools.AXE.Id,
                Next = 0,
                Yield = RawMaterials.WOOD_PINK.Id,
                YieldQuantity = 4 * INITIAL_ITEMS_YIELD_MULTIPLIER,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation BigTreeAxeTransformation = new()
            {
                Base = Trees.BIG_TREE.Id,
                Input = Tools.AXE.Id,
                Next = 0,
                Yield = RawMaterials.WOOD_PINK.Id,
                YieldQuantity = 7 * INITIAL_ITEMS_YIELD_MULTIPLIER,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };


            public static readonly Transformation RaspberryBushAxeTransformation = new()
            {
                Base = Bushes.RASPBERRY_BUSH.Id,
                Input = Tools.AXE.Id,
                Next = 0,
                Yield = RawMaterials.STICKS.Id,
                YieldQuantity = 3 * INITIAL_ITEMS_YIELD_MULTIPLIER,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };


            public static readonly Transformation CoffeeBushAxeTransformation = new()
            {
                Base = Bushes.COFFEE_BUSH.Id,
                Input = Tools.AXE.Id,
                Next = 0,
                Yield = RawMaterials.STICKS.Id,
                YieldQuantity = 3 * INITIAL_ITEMS_YIELD_MULTIPLIER,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation TomatoGrassScytheTransformation = new()
            {
                Base = Grass.GRASS_TOMATO.Id,
                Input = Tools.SCYTHE.Id,
                Next = 0,
                Yield = Tomato.TOMATO_SEED.Id,
                YieldQuantity = 2 * INITIAL_ITEMS_YIELD_MULTIPLIER,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation TomatoSmallAxeTransformation = new()
            {
                Base = Tomato.TOMATO_SMALL.Id,
                Input = Tools.SCYTHE.Id,
                Next = 0,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation TomatoMediumAxeTransformation = new()
            {
                Base = Tomato.TOMATO_MEDIUM.Id,
                Input = Tools.SCYTHE.Id,
                Next = 0,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation TomatoAlmostAxeTransformation = new()
            {
                Base = Tomato.TOMATO_ALMOST.Id,
                Input = Tools.SCYTHE.Id,
                Next = 0,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation TomatoGrownAxeTransformation = new()
            {
                Base = Tomato.TOMATO_GROWN.Id,
                Input = Tools.SCYTHE.Id,
                Next = 0,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };


            public static readonly Transformation TomatoSmallDeadAxeTransformation = new()
            {
                Base = Tomato.TOMATO_SMALL_DEAD.Id,
                Input = Tools.SCYTHE.Id,
                Next = 0,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation TomatoMediumDeadAxeTransformation = new()
            {
                Base = Tomato.TOMATO_MEDIUM_DEAD.Id,
                Input = Tools.SCYTHE.Id,
                Next = 0,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation TomatoAlmostDeadAxeTransformation = new()
            {
                Base = Tomato.TOMATO_ALMOST_DEAD.Id,
                Input = Tools.SCYTHE.Id,
                Next = 0,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };




            public static readonly Transformation WheatGrassScytheTransformation = new()
            {
                Base = Grass.GRASS_WHEAT.Id,
                Input = Tools.SCYTHE.Id,
                Next = 0,
                Yield = Wheat.WHEAT_SEED.Id,
                YieldQuantity = 2 * INITIAL_ITEMS_YIELD_MULTIPLIER,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation WheatSmallAxeTransformation = new()
            {
                Base = Wheat.WHEAT_SMALL.Id,
                Input = Tools.SCYTHE.Id,
                Next = 0,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation WheatMediumAxeTransformation = new()
            {
                Base = Wheat.WHEAT_MEDIUM.Id,
                Input = Tools.SCYTHE.Id,
                Next = 0,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation WheatAlmostAxeTransformation = new()
            {
                Base = Wheat.WHEAT_ALMOST.Id,
                Input = Tools.SCYTHE.Id,
                Next = 0,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation WheatGrownAxeTransformation = new()
            {
                Base = Wheat.WHEAT_GROWN.Id,
                Input = Tools.SCYTHE.Id,
                Next = 0,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation WheatSmallDeadAxeTransformation = new()
            {
                Base = Wheat.WHEAT_SMALL_DEAD.Id,
                Input = Tools.SCYTHE.Id,
                Next = 0,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation WheatMediumDeadAxeTransformation = new()
            {
                Base = Wheat.WHEAT_MEDIUM_DEAD.Id,
                Input = Tools.SCYTHE.Id,
                Next = 0,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation WheatAlmostDeadAxeTransformation = new()
            {
                Base = Wheat.WHEAT_ALMOST_DEAD.Id,
                Input = Tools.SCYTHE.Id,
                Next = 0,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation LettuceGrassScytheTransformation = new()
            {
                Base = Grass.GRASS_SALAD.Id,
                Input = Tools.SCYTHE.Id,
                Next = 0,
                Yield = Lettuce.LETTUCE_SEED.Id,
                YieldQuantity = 2 * INITIAL_ITEMS_YIELD_MULTIPLIER,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation LettuceSmallAxeTransformation = new()
            {
                Base = Lettuce.LETTUCE_SMALL.Id,
                Input = Tools.SCYTHE.Id,
                Next = 0,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation LettuceMediumAxeTransformation = new()
            {
                Base = Lettuce.LETTUCE_MEDIUM.Id,
                Input = Tools.SCYTHE.Id,
                Next = 0,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation LettuceAlmostAxeTransformation = new()
            {
                Base = Lettuce.LETTUCE_ALMOST.Id,
                Input = Tools.SCYTHE.Id,
                Next = 0,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation LettuceGrownAxeTransformation = new()
            {
                Base = Lettuce.LETTUCE_GROWN.Id,
                Input = Tools.SCYTHE.Id,
                Next = 0,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };


            public static readonly Transformation LettuceSmallDeadAxeTransformation = new()
            {
                Base = Lettuce.LETTUCE_SMALL_DEAD.Id,
                Input = Tools.SCYTHE.Id,
                Next = 0,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation LettuceMediumDeadAxeTransformation = new()
            {
                Base = Lettuce.LETTUCE_MEDIUM_DEAD.Id,
                Input = Tools.SCYTHE.Id,
                Next = 0,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation LettuceAlmostDeadAxeTransformation = new()
            {
                Base = Lettuce.LETTUCE_ALMOST_DEAD.Id,
                Input = Tools.SCYTHE.Id,
                Next = 0,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation GroundHoeTransformation = new()
            {
                Base = 0,
                Input = Tools.HOE.Id,
                Next = Gardening.TILLED_SOIL.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation SoilPickAxeTransformation = new()
            {
                Base = Gardening.TILLED_SOIL.Id,
                Input = Tools.PICKAXE.Id,
                Next = 0,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            




            public override List<Transformation> GetAllTransformations()
            {
                return new List<Transformation> {CrystalClickTransformation,
                                                 BismuthPickAxeTransformation,
                                                 ClayHoeTransformation,
                                                 SticksClickTransformation,

                                                 AvocadoTreeAxeTransformation,
                                                 OliveTreeAxeTransformation,
                                                 BananaTreeAxeTransformation,
                                                 SugarTreeAxeTransformation,
                                                 SimpleTreeAxeTransformation,
                                                 BigTreeAxeTransformation,
                                                 RaspberryBushAxeTransformation,
                                                 CoffeeBushAxeTransformation,

                                                 TomatoGrassScytheTransformation,
                                                 TomatoSmallAxeTransformation,
                                                 TomatoMediumAxeTransformation,
                                                 TomatoAlmostAxeTransformation,
                                                 TomatoGrownAxeTransformation,
                                                 TomatoAlmostDeadAxeTransformation,
                                                 TomatoMediumDeadAxeTransformation,
                                                 TomatoSmallDeadAxeTransformation,

                                                 WheatGrassScytheTransformation,
                                                 WheatSmallAxeTransformation,
                                                 WheatMediumAxeTransformation,
                                                 WheatAlmostAxeTransformation,
                                                 WheatGrownAxeTransformation,
                                                 WheatAlmostDeadAxeTransformation,
                                                 WheatMediumDeadAxeTransformation,
                                                 WheatSmallDeadAxeTransformation,

                                                 LettuceGrassScytheTransformation,
                                                 LettuceSmallAxeTransformation,
                                                 LettuceMediumAxeTransformation,
                                                 LettuceAlmostAxeTransformation,
                                                 LettuceGrownAxeTransformation,
                                                 LettuceAlmostDeadAxeTransformation,
                                                 LettuceMediumDeadAxeTransformation,
                                                 LettuceSmallDeadAxeTransformation,

                                                 GroundHoeTransformation,
                                                 SoilPickAxeTransformation,                                    
                                                 TrapezoidBlackPickAxeTransformation
                                                };
            }


        }

        public class MachinesTransformations : TransformationCategoryList<MachinesTransformations>
        {
            public static readonly Transformation WaterWellBucketTransformation = new()
            {
                Base = Machines.WATER_WELL.Id,
                Input = Buckets.BUCKET_EMPTY.Id,
                Next = Machines.WATER_WELL_GIVING_WATER.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                IsWaterCollection = true,
                Exists = true,

            };


            public static readonly Transformation WaterWellGivingWaterClickTransformation = new()
            {
                Base = Machines.WATER_WELL_GIVING_WATER.Id,
                Input = 0,
                Next = Machines.WATER_WELL.Id,
                Yield = Buckets.BUCKET_WATER.Id,
                YieldQuantity = 1,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation CheeseMakerBucketMilkTransformation = new()
            {
                Base = Machines.CHEESE_MAKER.Id,
                Input = Buckets.BUCKET_MILK.Id,
                Next = Machines.CHEESE_MAKER_MAKING_CHEESE.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };


            public static readonly Transformation CheeseMakerMakingCheeseBucketMilkTransformation = new()
            {
                Base = Machines.CHEESE_MAKER_MAKING_CHEESE.Id,
                Input = 0,
                Next = Machines.CHEESE_MAKER.Id,
                Yield = Ingredients.CHEESE.Id,
                YieldQuantity = 1,
                UnlockTime = 90,
                Timeout = 0,
                TimeoutNext = Machines.CHEESE_MAKER.Id,
                TimeoutYield = Ingredients.DUST.Id,
                TimeoutYieldQuantity = 1,
                IsRecipe = false,
                Exists = true,
                Xp = 2

            };

            public static readonly Transformation OlivePressOlivesTransformation = new()
            {
                Base = Machines.OLIVE_PRESS.Id,
                Input = Ingredients.OLIVES.Id,
                Next = Machines.OLIVE_PRESS_PRESSING.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation OlivePressPressingClickTransformation = new()
            {
                Base = Machines.OLIVE_PRESS_PRESSING.Id,
                Input = 0,
                Next = Machines.OLIVE_PRESS.Id,
                Yield = Ingredients.OLIVE_OIL.Id,
                YieldQuantity = 1,
                UnlockTime = 104,
                Timeout = 0,
                TimeoutNext = Machines.OLIVE_PRESS.Id,
                TimeoutYield = Ingredients.DUST.Id,
                TimeoutYieldQuantity = 1,
                IsRecipe = false,
                Exists = true,
                Xp = 2

            };

            public static readonly Transformation MixerBucketMilkTransformation = new()
            {
                Base = DefaultItems.Machines.MIXER.Id,
                Input = DefaultItems.Buckets.BUCKET_MILK.Id,
                Next = DefaultItems.Machines.MIXER_MIXING_MILK.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,
            };

            public static readonly Transformation MixerMixingMilkClickTransformation = new()
            {
                Base = DefaultItems.Machines.MIXER_MIXING_MILK.Id,
                Input = 0,
                Next = DefaultItems.Machines.MIXER.Id,
                Yield = DefaultItems.Ingredients.WHIPPED_CREAM.Id,
                YieldQuantity = 1,
                UnlockTime = 104,
                Timeout = 0,
                TimeoutNext = Machines.MIXER.Id,
                TimeoutYield = DefaultItems.Ingredients.DUST.Id,
                TimeoutYieldQuantity = 1,
                IsRecipe = false,
                Exists = true,
                Xp = 2
            };

            public static readonly Transformation MixerWheatTransformation = new()
            {
                Base = DefaultItems.Machines.MIXER.Id,
                Input = DefaultItems.Ingredients.WHEAT.Id,
                Next = DefaultItems.Machines.MIXER_MIXING_WHEAT.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,
            };

            public static readonly Transformation MixerMixingWheatClickTransformation = new()
            {
                Base = DefaultItems.Machines.MIXER_MIXING_WHEAT.Id,
                Input = 0,
                Next = DefaultItems.Machines.MIXER.Id,
                Yield = DefaultItems.Ingredients.FLOUR.Id,
                YieldQuantity = 1,
                UnlockTime = 140,
                Timeout = 0,
                TimeoutNext = Machines.MIXER.Id,
                TimeoutYield = DefaultItems.Ingredients.DUST.Id,
                TimeoutYieldQuantity = 1,
                IsRecipe = false,
                Exists = true,
                Xp = 2
            };


            public static readonly Transformation MixerFlourTransformation = new()
            {
                Base = DefaultItems.Machines.MIXER.Id,
                Input = DefaultItems.Ingredients.FLOUR.Id,
                Next = DefaultItems.Machines.MIXER_MIXING_FLOUR.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,
            };


            public static readonly Transformation MixerMixingFlourClickTransformation = new()
            {
                Base = DefaultItems.Machines.MIXER_MIXING_FLOUR.Id,
                Input = 0,
                Next = DefaultItems.Machines.MIXER.Id,
                Yield = DefaultItems.Ingredients.DOUGH.Id,
                YieldQuantity = 1,
                UnlockTime = 240,
                Timeout = 0,
                TimeoutNext = Machines.MIXER.Id,
                TimeoutYield = DefaultItems.Ingredients.DUST.Id,
                TimeoutYieldQuantity = 1,
                IsRecipe = false,
                Exists = true,
                Xp = 3
            };



            public static readonly Transformation ButterChurnerBucketMilkTransformation = new()
            {
                Base = DefaultItems.Machines.BUTTER_CHURNER.Id,
                Input = DefaultItems.Buckets.BUCKET_MILK.Id,
                Next = DefaultItems.Machines.BUTTER_CHURNER_CHURNING.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,
            };

            public static readonly Transformation ButterChurnerChurningClickTransformation = new()
            {
                Base = DefaultItems.Machines.BUTTER_CHURNER_CHURNING.Id,
                Input = 0,
                Next = DefaultItems.Machines.BUTTER_CHURNER.Id,
                Yield = DefaultItems.Ingredients.BUTTER.Id,
                YieldQuantity = 1,
                UnlockTime = 104,
                Timeout = 0,
                TimeoutNext = Machines.BUTTER_CHURNER.Id,
                TimeoutYield = DefaultItems.Ingredients.DUST.Id,
                TimeoutYieldQuantity = 1,
                IsRecipe = false,
                Exists = true,
                Xp =2
            };


            public static readonly Transformation FurnaceSmelterBismuthTransformation = new()
            {
                Base = DefaultItems.Machines.FURNACE_SMELTER.Id,
                Input = DefaultItems.RawMaterials.BISMUTH.Id,
                Next = DefaultItems.Machines.FURNACE_SMELTING_BISMUTH.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,
            };

            public static readonly Transformation FurnaceSmeltingBismuthClickTransformation = new()
            {
                Base = DefaultItems.Machines.FURNACE_SMELTING_BISMUTH.Id,
                Input = 0,
                Next = DefaultItems.Machines.FURNACE_SMELTER.Id,
                Yield = DefaultItems.RawMaterials.BISMUTH_INGOT.Id,
                YieldQuantity = 1 * INITIAL_BISMUTH_FURNANCE_MULTIPLIER,
                UnlockTime = 95,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,
                Xp = 2
            };

            public override List<Transformation> GetAllTransformations()
            {
                return new List<Transformation> { WaterWellBucketTransformation,
                                                  WaterWellGivingWaterClickTransformation,
                                                  CheeseMakerBucketMilkTransformation,
                                                  CheeseMakerMakingCheeseBucketMilkTransformation,
                                                  OlivePressOlivesTransformation,
                                                  OlivePressPressingClickTransformation,
                                                  MixerFlourTransformation,
                                                  MixerMixingFlourClickTransformation,
                                                  MixerBucketMilkTransformation,
                                                  MixerMixingMilkClickTransformation,
                                                  MixerWheatTransformation,
                                                  MixerMixingWheatClickTransformation,
                                                  ButterChurnerBucketMilkTransformation,
                                                  ButterChurnerChurningClickTransformation,
                                                  FurnaceSmelterBismuthTransformation,
                                                  FurnaceSmeltingBismuthClickTransformation};
            }
        }


        public class WaterTankTransformations : TransformationCategoryList<WaterTankTransformations>
        {
            public static readonly Transformation WaterTank1BucketWaterTransformation = new()
            {
                Base = Machines.WATER_TANK.Id,
                Input = Buckets.BUCKET_WATER.Id,
                Next = Machines.WATER_TANK_1_BUCKET_WATER.Id,
                InputNext = Buckets.BUCKET_EMPTY.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation WaterTank2BucketWaterTransformation = new()
            {
                Base = Machines.WATER_TANK_1_BUCKET_WATER.Id,
                Input = Buckets.BUCKET_WATER.Id,
                Next = Machines.WATER_TANK_2_BUCKET_WATER.Id,
                InputNext = Buckets.BUCKET_EMPTY.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation WaterTank3BucketWaterTransformation = new()
            {
                Base = Machines.WATER_TANK_2_BUCKET_WATER.Id,
                Input = Buckets.BUCKET_WATER.Id,
                Next = Machines.WATER_TANK_3_BUCKET_WATER.Id,
                InputNext = Buckets.BUCKET_EMPTY.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation WaterTank4BucketWaterTransformation = new()
            {
                Base = Machines.WATER_TANK_3_BUCKET_WATER.Id,
                Input = Buckets.BUCKET_WATER.Id,
                Next = Machines.WATER_TANK_4_BUCKET_WATER.Id,
                InputNext = Buckets.BUCKET_EMPTY.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation WaterTank5BucketWaterTransformation = new()
            {
                Base = Machines.WATER_TANK_4_BUCKET_WATER.Id,
                Input = Buckets.BUCKET_WATER.Id,
                Next = Machines.WATER_TANK_5_BUCKET_WATER.Id,
                InputNext = Buckets.BUCKET_EMPTY.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation WaterTank6BucketWaterTransformation = new()
            {
                Base = Machines.WATER_TANK_5_BUCKET_WATER.Id,
                Input = Buckets.BUCKET_WATER.Id,
                Next = Machines.WATER_TANK_6_BUCKET_WATER.Id,
                InputNext = Buckets.BUCKET_EMPTY.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation WaterTank7BucketWaterTransformation = new()
            {
                Base = Machines.WATER_TANK_6_BUCKET_WATER.Id,
                Input = Buckets.BUCKET_WATER.Id,
                Next = Machines.WATER_TANK_7_BUCKET_WATER.Id,
                InputNext = Buckets.BUCKET_EMPTY.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation WaterTank8BucketWaterTransformation = new()
            {
                Base = Machines.WATER_TANK_7_BUCKET_WATER.Id,
                Input = Buckets.BUCKET_WATER.Id,
                Next = Machines.WATER_TANK_8_BUCKET_WATER.Id,
                InputNext = Buckets.BUCKET_EMPTY.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation WaterTank9BucketWaterTransformation = new()
            {
                Base = Machines.WATER_TANK_8_BUCKET_WATER.Id,
                Input = Buckets.BUCKET_WATER.Id,
                Next = Machines.WATER_TANK_9_BUCKET_WATER.Id,
                InputNext = Buckets.BUCKET_EMPTY.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation WaterTank10BucketWaterTransformation = new()
            {
                Base = Machines.WATER_TANK_9_BUCKET_WATER.Id,
                Input = Buckets.BUCKET_WATER.Id,
                Next = Machines.WATER_TANK_10_BUCKET_WATER.Id,
                InputNext = Buckets.BUCKET_EMPTY.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,
            };







            public static readonly Transformation WaterTankEmptyBucketEmptyTransformation = new()
            {
                Base = Machines.WATER_TANK_1_BUCKET_WATER.Id,
                Input = Buckets.BUCKET_EMPTY.Id,
                Next = Machines.WATER_TANK.Id,
                InputNext = Buckets.BUCKET_WATER.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation WaterTank1BucketEmptyTransformation = new()
            {
                Base = Machines.WATER_TANK_2_BUCKET_WATER.Id,
                Input = Buckets.BUCKET_EMPTY.Id,
                Next = Machines.WATER_TANK_1_BUCKET_WATER.Id,
                InputNext = Buckets.BUCKET_WATER.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };


            public static readonly Transformation WaterTank2BucketEmptyTransformation = new()
            {
                Base = Machines.WATER_TANK_3_BUCKET_WATER.Id,
                Input = Buckets.BUCKET_EMPTY.Id,
                Next = Machines.WATER_TANK_2_BUCKET_WATER.Id,
                InputNext = Buckets.BUCKET_WATER.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation WaterTank3BucketEmptyTransformation = new()
            {
                Base = Machines.WATER_TANK_4_BUCKET_WATER.Id,
                Input = Buckets.BUCKET_EMPTY.Id,
                Next = Machines.WATER_TANK_3_BUCKET_WATER.Id,
                InputNext = Buckets.BUCKET_WATER.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation WaterTank4BucketEmptyTransformation = new()
            {
                Base = Machines.WATER_TANK_5_BUCKET_WATER.Id,
                Input = Buckets.BUCKET_EMPTY.Id,
                Next = Machines.WATER_TANK_4_BUCKET_WATER.Id,
                InputNext = Buckets.BUCKET_WATER.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation WaterTank5BucketEmptyTransformation = new()
            {
                Base = Machines.WATER_TANK_6_BUCKET_WATER.Id,
                Input = Buckets.BUCKET_EMPTY.Id,
                Next = Machines.WATER_TANK_5_BUCKET_WATER.Id,
                InputNext = Buckets.BUCKET_WATER.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation WaterTank6BucketEmptyTransformation = new()
            {
                Base = Machines.WATER_TANK_7_BUCKET_WATER.Id,
                Input = Buckets.BUCKET_EMPTY.Id,
                Next = Machines.WATER_TANK_6_BUCKET_WATER.Id,
                InputNext = Buckets.BUCKET_WATER.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation WaterTank7BucketEmptyTransformation = new()
            {
                Base = Machines.WATER_TANK_8_BUCKET_WATER.Id,
                Input = Buckets.BUCKET_EMPTY.Id,
                Next = Machines.WATER_TANK_7_BUCKET_WATER.Id,
                InputNext = Buckets.BUCKET_WATER.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation WaterTank8BucketEmptyTransformation = new()
            {
                Base = Machines.WATER_TANK_9_BUCKET_WATER.Id,
                Input = Buckets.BUCKET_EMPTY.Id,
                Next = Machines.WATER_TANK_8_BUCKET_WATER.Id,
                InputNext = Buckets.BUCKET_WATER.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation WaterTank9BucketEmptyTransformation = new()
            {
                Base = Machines.WATER_TANK_10_BUCKET_WATER.Id,
                Input = Buckets.BUCKET_EMPTY.Id,
                Next = Machines.WATER_TANK_9_BUCKET_WATER.Id,
                InputNext = Buckets.BUCKET_WATER.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,
            };

            public static readonly Transformation WaterTankEmptyWateringCanTransformation = new()
            {
                Base = Machines.WATER_TANK_1_BUCKET_WATER.Id,
                Input = Tools.WATERING_CAN.Id,
                Next = Machines.WATER_TANK.Id,
                InputNext = Tools.WATERING_CAN_FULL.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };


            public static readonly Transformation WaterTank1WateringCanTransformation = new()
            {
                Base = Machines.WATER_TANK_2_BUCKET_WATER.Id,
                Input = Tools.WATERING_CAN.Id,
                Next = Machines.WATER_TANK_1_BUCKET_WATER.Id,
                InputNext = Tools.WATERING_CAN_FULL.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };


            public static readonly Transformation WaterTank2WateringCanTransformation = new()
            {
                Base = Machines.WATER_TANK_3_BUCKET_WATER.Id,
                Input = Tools.WATERING_CAN.Id,
                Next = Machines.WATER_TANK_2_BUCKET_WATER.Id,
                InputNext = Tools.WATERING_CAN_FULL.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation WaterTank3WateringCanTransformation = new()
            {
                Base = Machines.WATER_TANK_4_BUCKET_WATER.Id,
                Input = Tools.WATERING_CAN.Id,
                Next = Machines.WATER_TANK_3_BUCKET_WATER.Id,
                InputNext = Tools.WATERING_CAN_FULL.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation WaterTank4WateringCanTransformation = new()
            {
                Base = Machines.WATER_TANK_5_BUCKET_WATER.Id,
                Input = Tools.WATERING_CAN.Id,
                Next = Machines.WATER_TANK_4_BUCKET_WATER.Id,
                InputNext = Tools.WATERING_CAN_FULL.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation WaterTank5WateringCanTransformation = new()
            {
                Base = Machines.WATER_TANK_6_BUCKET_WATER.Id,
                Input = Tools.WATERING_CAN.Id,
                Next = Machines.WATER_TANK_5_BUCKET_WATER.Id,
                InputNext = Tools.WATERING_CAN_FULL.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation WaterTank6WateringCanTransformation = new()
            {
                Base = Machines.WATER_TANK_7_BUCKET_WATER.Id,
                Input = Tools.WATERING_CAN.Id,
                Next = Machines.WATER_TANK_6_BUCKET_WATER.Id,
                InputNext = Tools.WATERING_CAN_FULL.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation WaterTank7WateringCanTransformation = new()
            {
                Base = Machines.WATER_TANK_8_BUCKET_WATER.Id,
                Input = Tools.WATERING_CAN.Id,
                Next = Machines.WATER_TANK_7_BUCKET_WATER.Id,
                InputNext = Tools.WATERING_CAN_FULL.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation WaterTank8WateringCanTransformation = new()
            {
                Base = Machines.WATER_TANK_9_BUCKET_WATER.Id,
                Input = Tools.WATERING_CAN.Id,
                Next = Machines.WATER_TANK_8_BUCKET_WATER.Id,
                InputNext = Tools.WATERING_CAN_FULL.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation WaterTank9WateringCanTransformation = new()
            {
                Base = Machines.WATER_TANK_10_BUCKET_WATER.Id,
                Input = Tools.WATERING_CAN.Id,
                Next = Machines.WATER_TANK_9_BUCKET_WATER.Id,
                InputNext = Tools.WATERING_CAN_FULL.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,
            };


            public override List<Transformation> GetAllTransformations()
            {
                return new List<Transformation> { WaterTank1BucketWaterTransformation,
                                                  WaterTank2BucketWaterTransformation,
                                                  WaterTank3BucketWaterTransformation,
                                                  WaterTank4BucketWaterTransformation,
                                                  WaterTank5BucketWaterTransformation,
                                                  WaterTank6BucketWaterTransformation,
                                                  WaterTank7BucketWaterTransformation,
                                                  WaterTank8BucketWaterTransformation,
                                                  WaterTank9BucketWaterTransformation,
                                                  WaterTank10BucketWaterTransformation,

                                                  WaterTankEmptyBucketEmptyTransformation,
                                                  WaterTank1BucketEmptyTransformation,
                                                  WaterTank2BucketEmptyTransformation,
                                                  WaterTank3BucketEmptyTransformation,
                                                  WaterTank4BucketEmptyTransformation,
                                                  WaterTank5BucketEmptyTransformation,
                                                  WaterTank6BucketEmptyTransformation,
                                                  WaterTank7BucketEmptyTransformation,
                                                  WaterTank8BucketEmptyTransformation,
                                                  WaterTank9BucketEmptyTransformation,

                                                  WaterTankEmptyWateringCanTransformation,
                                                  WaterTank1WateringCanTransformation,
                                                  WaterTank2WateringCanTransformation,
                                                  WaterTank3WateringCanTransformation,
                                                  WaterTank4WateringCanTransformation,
                                                  WaterTank5WateringCanTransformation,
                                                  WaterTank6WateringCanTransformation,
                                                  WaterTank7WateringCanTransformation,
                                                  WaterTank8WateringCanTransformation,
                                                  WaterTank9WateringCanTransformation,

                                                };
            }

        }


        public class TomatoTransformations : TransformationCategoryList<TomatoTransformations>
        {
            public static readonly Transformation TomatoSmallTransformation_1 = new()
            {
                Base = Tomato.TOMATO_SEED.Id,
                Input = Tools.WATERING_CAN_FULL.Id,
                // InputNext = Tools.WATERING_CAN.Id,
                Next = Tomato.TOMATO_SMALL.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation TomatoMediumTransformation_2 = new()
            {
                Base = Tomato.TOMATO_SMALL.Id,
                Input = Tools.WATERING_CAN_FULL.Id,
                // InputNext = Tools.WATERING_CAN.Id,
                Next = Tomato.TOMATO_MEDIUM.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 120,
                Timeout = 360,
                TimeoutNext = Tomato.TOMATO_SMALL_DEAD.Id,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,
            };

            public static readonly Transformation TomatoAlmostTransformation_3 = new()
            {
                Base = Tomato.TOMATO_MEDIUM.Id,
                Input = Tools.WATERING_CAN_FULL.Id,
                // InputNext = Tools.WATERING_CAN.Id,
                Next = Tomato.TOMATO_ALMOST.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 120,
                Timeout = 360,
                TimeoutNext = Tomato.TOMATO_MEDIUM_DEAD.Id,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,
            };

            public static readonly Transformation TomatoGrownTransformation_4 = new()
            {
                Base = Tomato.TOMATO_ALMOST.Id,
                Input = Tools.WATERING_CAN_FULL.Id,
                // InputNext = Tools.WATERING_CAN.Id,
                Next = Tomato.TOMATO_GROWN.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 120,
                Timeout = 360,
                TimeoutNext = Tomato.TOMATO_ALMOST_DEAD.Id,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,
            };

            public static readonly Transformation TomatoTransformation_5 = new()
            {
                Base = Tomato.TOMATO_GROWN.Id,
                Input = 0,
                Next = 0,
                Yield = Ingredients.TOMATO.Id,
                YieldQuantity = 3,
                UnlockTime = 0,
                Timeout = 360,
                TimeoutNext = Tomato.TOMATO_ALMOST_DEAD.Id,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,
            };

            public override List<Transformation> GetAllTransformations()
            {
                return new List<Transformation> { TomatoSmallTransformation_1, TomatoMediumTransformation_2, TomatoAlmostTransformation_3, TomatoGrownTransformation_4, TomatoTransformation_5 };
            }
        }

        public class LettuceTransformations : TransformationCategoryList<LettuceTransformations>
        {
            public static readonly Transformation LettuceSmallTransformation_1 = new()
            {
                Base = Lettuce.LETTUCE_SEED.Id,
                Input = Tools.WATERING_CAN_FULL.Id,
                // InputNext = Tools.WATERING_CAN.Id,
                Next = Lettuce.LETTUCE_SMALL.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation LettuceMediumTransformation_2 = new()
            {
                Base = Lettuce.LETTUCE_SMALL.Id,
                Input = Tools.WATERING_CAN_FULL.Id,
                // InputNext = Tools.WATERING_CAN.Id,
                Next = Lettuce.LETTUCE_MEDIUM.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 120,
                Timeout = 360,
                TimeoutNext = Lettuce.LETTUCE_SMALL_DEAD.Id,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,
            };

            public static readonly Transformation LettuceAlmostTransformation_3 = new()
            {
                Base = Lettuce.LETTUCE_MEDIUM.Id,
                Input = Tools.WATERING_CAN_FULL.Id,
                // InputNext = Tools.WATERING_CAN.Id,
                Next = Lettuce.LETTUCE_ALMOST.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 120,
                Timeout = 360,
                TimeoutNext = Lettuce.LETTUCE_MEDIUM_DEAD.Id,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,
            };

            public static readonly Transformation LettuceGrownTransformation_4 = new()
            {
                Base = Lettuce.LETTUCE_ALMOST.Id,
                Input = Tools.WATERING_CAN_FULL.Id,
                // InputNext = Tools.WATERING_CAN.Id,
                Next = Lettuce.LETTUCE_GROWN.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 120,
                Timeout = 360,
                TimeoutNext = Lettuce.LETTUCE_ALMOST_DEAD.Id,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,
            };

            public static readonly Transformation LettuceTransformation_5 = new()
            {
                Base = Lettuce.LETTUCE_GROWN.Id,
                Input = 0,
                Next = 0,
                Yield = Ingredients.LETTUCE.Id,
                YieldQuantity = 1,
                UnlockTime = 0,
                Timeout = 360,
                TimeoutNext = Lettuce.LETTUCE_ALMOST_DEAD.Id,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,
            };

            public override List<Transformation> GetAllTransformations()
            {
                return new List<Transformation> { LettuceSmallTransformation_1, LettuceMediumTransformation_2, LettuceAlmostTransformation_3, LettuceGrownTransformation_4, LettuceTransformation_5 };
            }

        }

        public class WheatTransformations : TransformationCategoryList<WheatTransformations>
        {
            public static readonly Transformation WheatSmallTransformation_1 = new()
            {
                Base = Wheat.WHEAT_SEED.Id,
                Input = Tools.WATERING_CAN_FULL.Id,
                // InputNext = Tools.WATERING_CAN.Id,
                Next = Wheat.WHEAT_SMALL.Id, //HACK no Wheat seedling,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 0,
                Timeout = 0,
                TimeoutNext = 0,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,

            };

            public static readonly Transformation WheatMediumTransformation_2 = new()
            {
                Base = Wheat.WHEAT_SMALL.Id,
                Input = Tools.WATERING_CAN_FULL.Id,
                // InputNext = Tools.WATERING_CAN.Id,
                Next = Wheat.WHEAT_MEDIUM.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 120,
                Timeout = 360,
                TimeoutNext = Wheat.WHEAT_SMALL_DEAD.Id,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,
            };

            public static readonly Transformation WheatAlmostTransformation_3 = new()
            {
                Base = Wheat.WHEAT_MEDIUM.Id,
                Input = Tools.WATERING_CAN_FULL.Id,
                // InputNext = Tools.WATERING_CAN.Id,
                Next = Wheat.WHEAT_ALMOST.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 120,
                Timeout = 360,
                TimeoutNext = Wheat.WHEAT_MEDIUM_DEAD.Id,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,
            };

            public static readonly Transformation WheatGrownTransformation_4 = new()
            {
                Base = Wheat.WHEAT_ALMOST.Id,
                Input = Tools.WATERING_CAN_FULL.Id,
                // InputNext = Tools.WATERING_CAN.Id,
                Next = Wheat.WHEAT_GROWN.Id,
                Yield = 0,
                YieldQuantity = 0,
                UnlockTime = 120,
                Timeout = 360,
                TimeoutNext = Wheat.WHEAT_ALMOST_DEAD.Id,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,
            };

            public static readonly Transformation WheatTransformation_5 = new()
            {
                Base = Wheat.WHEAT_GROWN.Id,
                Input = 0,
                Next = 0,
                Yield = Ingredients.WHEAT.Id,
                YieldQuantity = 1,
                UnlockTime = 0,
                Timeout = 360,
                TimeoutNext = Wheat.WHEAT_ALMOST_DEAD.Id,
                TimeoutYield = 0,
                TimeoutYieldQuantity = 0,
                IsRecipe = false,
                Exists = true,
            };

            public override List<Transformation> GetAllTransformations()
            {
                return new List<Transformation> { WheatSmallTransformation_1, WheatMediumTransformation_2, WheatAlmostTransformation_3, WheatGrownTransformation_4, WheatTransformation_5 };
            }

        }

    }

}
