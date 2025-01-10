using System;
using System.Collections.Generic;
using System.Text;
using static VisionsContracts.Items.DefaultItems;
using VisionsContracts.Land.Systems.CatalogueSystem.Model;


namespace VisionsContracts.Items
{
    public class DefaultItemsCatalogue
    {
        public static readonly Catalogue CATALOGUE = new Catalogue() { CatalogueId = 0, Name = "Cafe Cosmos Items" };
        public static List<CatalogueItem> GetCatalogueItems()
        {
            return new List<CatalogueItem>()
            {
                // Items in the same order as the spreadsheet with row numbers as comments

                new CatalogueItem(Ingredients.AVOCADO, 5, CATALOGUE.CatalogueId), // Row 1
                new CatalogueItem(Tools.AXE, 2, CATALOGUE.CatalogueId), // Row 2
                new CatalogueItem(Ingredients.BANANAS, 5, CATALOGUE.CatalogueId), // Row 3
                new CatalogueItem(Furniture.BAR_COUNTER, 4, CATALOGUE.CatalogueId), // Row 4
                new CatalogueItem(RawMaterials.BISMUTH, 3, CATALOGUE.CatalogueId), // Row 5
                new CatalogueItem(RawMaterials.BISMUTH_INGOT, 4, CATALOGUE.CatalogueId), // Row 6
                new CatalogueItem(Misc.BLADE, 4, CATALOGUE.CatalogueId), // Row 7
                new CatalogueItem(Cooking.BLENDER, 10, CATALOGUE.CatalogueId), // Row 8
                new CatalogueItem(Buckets.BUCKET_WATER, 3, CATALOGUE.CatalogueId), // Row 9
                new CatalogueItem(Ingredients.BUTTER, 3, CATALOGUE.CatalogueId), // Row 10
                new CatalogueItem(Machines.BUTTER_CHURNER, 4, CATALOGUE.CatalogueId), // Row 11
                //new CatalogueItem(Ingredients.CACAO_POD, 3, CATALOGUE.CatalogueId), // Row 12
                new CatalogueItem(Ingredients.CHEESE, 3, CATALOGUE.CatalogueId), // Row 13
                new CatalogueItem(Animals.CHICKEN, 10, CATALOGUE.CatalogueId), // Row 14
                new CatalogueItem(Ingredients.COFFEE_BEAN, 5, CATALOGUE.CatalogueId), // Row 15
                //new CatalogueItem(Ingredients.CONDENSED_MILK, 7, CATALOGUE.CatalogueId), // Row 16
                new CatalogueItem(Animals.COW, 15, CATALOGUE.CatalogueId), // Row 17
                new CatalogueItem(Cooking.CRAZY_BLENDER, 15, CATALOGUE.CatalogueId), // Row 18
                new CatalogueItem(Cooking.CRAZY_CUTTING_BOARD, 20, CATALOGUE.CatalogueId), // Row 19
                new CatalogueItem(Cooking.CRAZY_COFFEE_MACHINE, 20, CATALOGUE.CatalogueId), // Row 20
                new CatalogueItem(Cooking.CRAZY_OVEN, 25, CATALOGUE.CatalogueId), // Row 21
                new CatalogueItem(RawMaterials.CRYSTAL, 2, CATALOGUE.CatalogueId), // Row 22
                new CatalogueItem(Cooking.CUTTING_BOARD, 8, CATALOGUE.CatalogueId), // Row 23
                new CatalogueItem(Ingredients.DOUGH, 5, CATALOGUE.CatalogueId), // Row 24
                new CatalogueItem(Ingredients.EGG, 3, CATALOGUE.CatalogueId), // Row 25
                new CatalogueItem(Cooking.COFFEE_MACHINE, 10, CATALOGUE.CatalogueId), // Row 26 (Espresso Machine mapped to Coffee Machine)
                new CatalogueItem(Decorations.FENCE, 3, CATALOGUE.CatalogueId), // Row 27
                new CatalogueItem(Ingredients.FLOUR, 4, CATALOGUE.CatalogueId), // Row 28
                new CatalogueItem(Misc.FLUX_CAPACITOR, 7, CATALOGUE.CatalogueId), // Row 29
                new CatalogueItem(Machines.FURNACE_SMELTER, 12, CATALOGUE.CatalogueId), // Row 30
                new CatalogueItem(Misc.GLASS, 7, CATALOGUE.CatalogueId), // Row 31
                new CatalogueItem(Furniture.GREEN_CHAIR, 7, CATALOGUE.CatalogueId), // Row 32
                new CatalogueItem(Furniture.GREEN_TABLE, 7, CATALOGUE.CatalogueId), // Row 33
                new CatalogueItem(Ingredients.HAM, 6, CATALOGUE.CatalogueId), // Row 34
                new CatalogueItem(Cooking.KEBAB_MAKER, 12, CATALOGUE.CatalogueId), // Row 35
                new CatalogueItem(Ingredients.LETTUCE, 6, CATALOGUE.CatalogueId), // Row 36
                new CatalogueItem(Lettuce.LETTUCE_SEED, 3, CATALOGUE.CatalogueId), // Row 37
                new CatalogueItem(Ingredients.MEAT, 6, CATALOGUE.CatalogueId), // Row 38
                new CatalogueItem(Buckets.BUCKET_MILK, 2, CATALOGUE.CatalogueId), // Row 39
                new CatalogueItem(Machines.MIXER, 8, CATALOGUE.CatalogueId), // Row 40
                new CatalogueItem(Machines.OLIVE_PRESS, 4, CATALOGUE.CatalogueId), // Row 41 (Oil Maker mapped to Olive Press)
                new CatalogueItem(Ingredients.OLIVE_OIL, 5, CATALOGUE.CatalogueId), // Row 42
                new CatalogueItem(Ingredients.OLIVES, 3, CATALOGUE.CatalogueId), // Row 43
                //new CatalogueItem(Ingredients.ORANGE, 3, CATALOGUE.CatalogueId), // Row 44
                new CatalogueItem(Cooking.BASIC_OVEN, 17, CATALOGUE.CatalogueId), // Row 45
                new CatalogueItem(Ingredients.PASTA, 4, CATALOGUE.CatalogueId), // Row 46
                new CatalogueItem(Machines.PASTA_MACHINE, 6, CATALOGUE.CatalogueId), // Row 47
                new CatalogueItem(Tools.PICKAXE, 2, CATALOGUE.CatalogueId), // Row 48
                new CatalogueItem(Furniture.PINK_CHAIR, 5, CATALOGUE.CatalogueId), // Row 49
                new CatalogueItem(Decorations.PINK_FLOOR, 5, CATALOGUE.CatalogueId), // Row 50
                new CatalogueItem(RawMaterials.WOOD_PINK, 3, CATALOGUE.CatalogueId), // Row 51
                new CatalogueItem(Decorations.SIGNBOARD, 6, CATALOGUE.CatalogueId), // Row 52 (Planet Sign)
                new CatalogueItem(Decorations.PLANT, 6, CATALOGUE.CatalogueId), // Row 53
                new CatalogueItem(Misc.POLE, 4, CATALOGUE.CatalogueId), // Row 54
                new CatalogueItem(Decorations.PURPLE_FLOOR, 5, CATALOGUE.CatalogueId), // Row 55
                new CatalogueItem(RawMaterials.WOOD_PURPLE, 3, CATALOGUE.CatalogueId), // Row 56
                new CatalogueItem(Ingredients.RASPBERRY, 3, CATALOGUE.CatalogueId), // Row 57
                //new CatalogueItem(Ingredients.RED_ROOSTER_EGG, 10, CATALOGUE.CatalogueId), // Row 58
                new CatalogueItem(Machines.ROBOT, 20, CATALOGUE.CatalogueId), // Row 59
                new CatalogueItem(Furniture.PURPLE_TABLE, 7, CATALOGUE.CatalogueId), // Row 60
                new CatalogueItem(Tools.SCYTHE, 2, CATALOGUE.CatalogueId), // Row 61
                new CatalogueItem(RawMaterials.STICKS, 1, CATALOGUE.CatalogueId), // Row 62
                new CatalogueItem(Ingredients.SUGAR, 3, CATALOGUE.CatalogueId), // Row 63
                new CatalogueItem(Ingredients.TOMATO, 6, CATALOGUE.CatalogueId), // Row 64
                new CatalogueItem(Tomato.TOMATO_SEED, 3, CATALOGUE.CatalogueId), // Row 65

                new CatalogueItem(Decorations.WALL, 5, CATALOGUE.CatalogueId), // Row 66
                new CatalogueItem(Decorations.WALL_MENU, 5, CATALOGUE.CatalogueId), // Row 67
                new CatalogueItem(Buckets.BUCKET_WATER, 3, CATALOGUE.CatalogueId), // Row 68
                new CatalogueItem(Machines.WATER_TANK, 10, CATALOGUE.CatalogueId), // Row 69
                new CatalogueItem(Machines.WATER_WELL, 8, CATALOGUE.CatalogueId), // Row 70
                new CatalogueItem(Tools.WATERING_CAN, 2, CATALOGUE.CatalogueId), // Row 71
                new CatalogueItem(Wheat.WHEAT_SEED, 3, CATALOGUE.CatalogueId), // Row 72

                new CatalogueItem(Ingredients.WHIPPED_CREAM, 6, CATALOGUE.CatalogueId), // Row 73
                new CatalogueItem(Decorations.WINDOW, 5, CATALOGUE.CatalogueId), // Row 74
                new CatalogueItem(Misc.WIRE, 7, CATALOGUE.CatalogueId), // Row 75
                new CatalogueItem(Ingredients.WHEAT, 6, CATALOGUE.CatalogueId) // Row 76
            };
        }

    }
}
