using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using VisionsContracts.Transformations.Model;
using VisionsContracts.Transformations;

namespace VisionsContracts.Land.Systems.QuestsSystem.Model
{
    public class TransformationCategory
    {
        public TransformationCategory()
        {
        }

        public BigInteger CategoryId { get; set; }
        public string CategoryName { get; set; }
    }

    public class DefaultTransformationCategories
    {
        public static readonly TransformationCategory Cooking = new TransformationCategory() { CategoryId = 1, CategoryName = "Cooking" };
        public static readonly TransformationCategory CookCroissant = new TransformationCategory() { CategoryId = 2, CategoryName = "Cook Croissant" };
        public static readonly TransformationCategory CookCupcake = new TransformationCategory() { CategoryId = 3, CategoryName = "Cook Cupcake" };
        public static readonly TransformationCategory CookBurger = new TransformationCategory() { CategoryId = 4, CategoryName = "Cook Burger" };
        public static readonly TransformationCategory CookPizza = new TransformationCategory() { CategoryId = 5, CategoryName = "Cook Pizza" };
        public static readonly TransformationCategory CookMacAndCheese = new TransformationCategory() { CategoryId = 6, CategoryName = "Cook Mac and Cheese" };
        public static readonly TransformationCategory ChopSalad = new TransformationCategory() { CategoryId = 7, CategoryName = "Chop Salad" };
        public static readonly TransformationCategory CookShawarma = new TransformationCategory() { CategoryId = 8, CategoryName = "Cook Shawarma" };
        public static readonly TransformationCategory BlendSmoothie = new TransformationCategory() { CategoryId = 9, CategoryName = "Blend Smoothie" };
        public static readonly TransformationCategory WaterTomatoPlant = new TransformationCategory() { CategoryId = 10, CategoryName = "Water Tomato Plant" };
        public static readonly TransformationCategory WaterLettucePlant = new TransformationCategory() { CategoryId = 11, CategoryName = "Water Lettuce Plant" };
        public static readonly TransformationCategory WaterWheatPlant = new TransformationCategory() { CategoryId = 12, CategoryName = "Water Wheat Plant" };

        public static List<TransformationCategory> GetAll()
        {
            return new List<TransformationCategory>()
            {
                Cooking,
                CookCroissant,
                CookCupcake,
                CookBurger,
                CookPizza,
                CookMacAndCheese,
                ChopSalad,
                CookShawarma,
                BlendSmoothie,
                WaterTomatoPlant,
                WaterLettucePlant,
                WaterWheatPlant
            };
        }

        public static TransformationCategory FindCategory(BigInteger categoryId)
        {
            return GetAll().FirstOrDefault(x => x.CategoryId == categoryId);
        }


    }

    public class DefaultTransformationsWithCategories
    {

        public class Watering
        {
            public static readonly TransformationWithCategories WateringTomatoAlmostTransformation_1 = new TransformationWithCategories(DefaultTransformations.TomatoTransformations.TomatoSmallTransformation_1, DefaultTransformationCategories.WaterTomatoPlant);
            public static readonly TransformationWithCategories WateringTomatoMediumTransformation_2 = new TransformationWithCategories(DefaultTransformations.TomatoTransformations.TomatoMediumTransformation_2, DefaultTransformationCategories.WaterTomatoPlant);
            public static readonly TransformationWithCategories WateringTomatoAlmostTransformation_3 = new TransformationWithCategories(DefaultTransformations.TomatoTransformations.TomatoAlmostTransformation_3, DefaultTransformationCategories.WaterTomatoPlant);
            public static readonly TransformationWithCategories WateringTomatoGrownTransformation_4 = new TransformationWithCategories(DefaultTransformations.TomatoTransformations.TomatoGrownTransformation_4, DefaultTransformationCategories.WaterTomatoPlant);

            public static readonly TransformationWithCategories WateringLettuceAlmostTransformation_1 = new TransformationWithCategories(DefaultTransformations.LettuceTransformations.LettuceSmallTransformation_1, DefaultTransformationCategories.WaterLettucePlant);
            public static readonly TransformationWithCategories WateringLettuceMediumTransformation_2 = new TransformationWithCategories(DefaultTransformations.LettuceTransformations.LettuceMediumTransformation_2, DefaultTransformationCategories.WaterLettucePlant);
            public static readonly TransformationWithCategories WateringLettuceAlmostTransformation_3 = new TransformationWithCategories(DefaultTransformations.LettuceTransformations.LettuceAlmostTransformation_3, DefaultTransformationCategories.WaterLettucePlant);
            public static readonly TransformationWithCategories WateringLettuceGrownTransformation_4 = new TransformationWithCategories(DefaultTransformations.LettuceTransformations.LettuceGrownTransformation_4, DefaultTransformationCategories.WaterLettucePlant);

            public static readonly TransformationWithCategories WateringWheatAlmostTransformation_1 = new TransformationWithCategories(DefaultTransformations.WheatTransformations.WheatSmallTransformation_1, DefaultTransformationCategories.WaterWheatPlant);
            public static readonly TransformationWithCategories WateringWheatMediumTransformation_2 = new TransformationWithCategories(DefaultTransformations.WheatTransformations.WheatMediumTransformation_2, DefaultTransformationCategories.WaterWheatPlant);
            public static readonly TransformationWithCategories WateringWheatAlmostTransformation_3 = new TransformationWithCategories(DefaultTransformations.WheatTransformations.WheatAlmostTransformation_3, DefaultTransformationCategories.WaterWheatPlant);
            public static readonly TransformationWithCategories WateringWheatGrownTransformation_4 = new TransformationWithCategories(DefaultTransformations.WheatTransformations.WheatGrownTransformation_4, DefaultTransformationCategories.WaterWheatPlant);

            public static List<TransformationWithCategories> GetAll()
            {
                return new List<TransformationWithCategories>()
                {
                    WateringTomatoAlmostTransformation_1,
                    WateringTomatoMediumTransformation_2,
                    WateringTomatoAlmostTransformation_3,
                    WateringTomatoGrownTransformation_4,
                    WateringLettuceAlmostTransformation_1,
                    WateringLettuceMediumTransformation_2,
                    WateringLettuceAlmostTransformation_3,
                    WateringLettuceGrownTransformation_4,
                    WateringWheatAlmostTransformation_1,
                    WateringWheatMediumTransformation_2,
                    WateringWheatAlmostTransformation_3,
                    WateringWheatGrownTransformation_4
                };
            }

        }

        public class Cooking
        {
            public static readonly TransformationWithCategories BasicOvenCookingCroissantClickTransformation_2 = new TransformationWithCategories(DefaultTransformations.OvenTransformations.BasicOvenCookingCroissantClickTransformation_2, DefaultTransformationCategories.CookCroissant);
            public static readonly TransformationWithCategories CrazyOvenCookingCroissantClickTransformation_2 = new TransformationWithCategories(DefaultTransformations.OvenTransformations.CrazyOvenCookingCroissantClickTransformation_2, DefaultTransformationCategories.CookCroissant);
            public static readonly TransformationWithCategories BasicOvenCookingCupcakeClickTransformation_2 = new TransformationWithCategories(DefaultTransformations.OvenTransformations.BasicOvenCookingCupcakeClickTransformation_2, DefaultTransformationCategories.CookCupcake);
            public static readonly TransformationWithCategories CrazyOvenCookingCupcakeClickTransformation_2 = new TransformationWithCategories(DefaultTransformations.OvenTransformations.CrazyOvenCookingCupcakeClickTransformation_2, DefaultTransformationCategories.CookCupcake);
            public static readonly TransformationWithCategories BasicOvenCookingBurgerClickTransformation_2 = new TransformationWithCategories(DefaultTransformations.OvenTransformations.BasicOvenCookingBurgerClickTransformation_2, DefaultTransformationCategories.CookBurger);
            public static readonly TransformationWithCategories CrazyOvenCookingBurgerClickTransformation_2 = new TransformationWithCategories(DefaultTransformations.OvenTransformations.CrazyOvenCookingBurgerClickTransformation_2, DefaultTransformationCategories.CookBurger);
            public static readonly TransformationWithCategories BasicOvenCookingPizzaClickTransformation_2 = new TransformationWithCategories(DefaultTransformations.OvenTransformations.BasicOvenCookingPizzaClickTransformation_2, DefaultTransformationCategories.CookPizza);
            public static readonly TransformationWithCategories CrazyOvenCookingPizzaClickTransformation_2 = new TransformationWithCategories(DefaultTransformations.OvenTransformations.CrazyOvenCookingPizzaClickTransformation_2, DefaultTransformationCategories.CookPizza);
            public static readonly TransformationWithCategories BasicOvenCookingMacAndCheeseClickTransformation_2 = new TransformationWithCategories(DefaultTransformations.OvenTransformations.BasicOvenCookingMacAndCheeseClickTransformation_2, DefaultTransformationCategories.CookMacAndCheese);
            public static readonly TransformationWithCategories CrazyOvenCookingMacAndCheeseClickTransformation_2 = new TransformationWithCategories(DefaultTransformations.OvenTransformations.CrazyOvenCookingMacAndCheeseClickTransformation_2, DefaultTransformationCategories.CookMacAndCheese);
            public static readonly TransformationWithCategories CuttingBoardChoppingSaladClickTransformation_2 = new TransformationWithCategories(DefaultTransformations.CuttingBoardTransformations.CuttingBoardChoppingSaladClickTransformation_2, DefaultTransformationCategories.ChopSalad);
            public static readonly TransformationWithCategories CrazyCuttingBoardChoppingSaladClickTransformation_2 = new TransformationWithCategories(DefaultTransformations.CuttingBoardTransformations.CrazyCuttingBoardChoppingSaladClickTransformation_2, DefaultTransformationCategories.ChopSalad);
            public static readonly TransformationWithCategories KebabMakerCookingKebabClickTransformation_2 = new TransformationWithCategories(DefaultTransformations.KebabMakerTransformations.KebabMakerCookingKebabClickTransformation_2, DefaultTransformationCategories.CookShawarma);
            public static readonly TransformationWithCategories BlenderBlendingSmoothieClickTransformation_2 = new TransformationWithCategories(DefaultTransformations.BlenderTransformations.BlenderBlendingSmoothieClickTransformation_2, DefaultTransformationCategories.BlendSmoothie);
            public static readonly TransformationWithCategories CrazyBlenderBlendingSmoothieClickTransformation_2 = new TransformationWithCategories(DefaultTransformations.BlenderTransformations.CrazyBlenderBlendingSmoothieClickTransformation_2, DefaultTransformationCategories.BlendSmoothie);

            public static List<TransformationWithCategories> GetAll()
            {
                return new List<TransformationWithCategories>()
                {
                    BasicOvenCookingCroissantClickTransformation_2,
                    CrazyOvenCookingCroissantClickTransformation_2,
                    BasicOvenCookingCupcakeClickTransformation_2,
                    CrazyOvenCookingCupcakeClickTransformation_2,
                    BasicOvenCookingBurgerClickTransformation_2,
                    CrazyOvenCookingBurgerClickTransformation_2,
                    BasicOvenCookingPizzaClickTransformation_2,
                    CrazyOvenCookingPizzaClickTransformation_2,
                    BasicOvenCookingMacAndCheeseClickTransformation_2,
                    CrazyOvenCookingMacAndCheeseClickTransformation_2,
                    CuttingBoardChoppingSaladClickTransformation_2,
                    CrazyCuttingBoardChoppingSaladClickTransformation_2,
                    KebabMakerCookingKebabClickTransformation_2,
                    BlenderBlendingSmoothieClickTransformation_2,
                    CrazyBlenderBlendingSmoothieClickTransformation_2
                };
            }

        }

        public static List<TransformationWithCategories> GetAll()
        {
            return Watering.GetAll().Concat(Cooking.GetAll()).ToList();
        }

        public static TransformationWithCategories FindTransformationWithCategories(BigInteger baseId, BigInteger inputId)
        {
            return GetAll().FirstOrDefault(x => x.Base == baseId && x.Input == inputId);
        }

        public static TransformationWithCategories FindTransformationWithCategories(BigInteger categoryId)
        {
            return GetAll().FirstOrDefault(x => x.CategoryIds.Contains(categoryId));
        }

    }

    public class TransformationWithCategories
    {
        public TransformationWithCategories(Transformation transformation, params TransformationCategory[] categories)
        {
            this.Input = transformation.Input;
            this.Base = transformation.Base;
            this.CategoryIds = categories.Select(x => x.CategoryId).ToList();
        }

        public BigInteger Input { get; set; }
        public BigInteger Base { get; set; }
        public List<BigInteger> CategoryIds { get; set; } = new List<BigInteger>();

    }
}
