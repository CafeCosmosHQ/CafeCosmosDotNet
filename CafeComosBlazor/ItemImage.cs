using VisionsContracts.Items.Model;
using static VisionsContracts.Items.DefaultItems;

namespace CafeCosmosBlazor
{
    public record ItemImage(Item Item, string Image);

    public class ItemImages
    {
        public static List<ItemImage> AllImages = new()
        {
            new ItemImage(Ingredients.AVOCADO, "avocado.png"),  //ok
            new ItemImage(Ingredients.BANANAS, "bananas.png"), //ok
            new ItemImage(Ingredients.BUTTER, "butter.png"), //ok
            new ItemImage(Ingredients.CHEESE, "cheese.png"), //ok
            new ItemImage(Ingredients.DOUGH, "dough.png"), //ok
            new ItemImage(Ingredients.DUST, "dust.png"), //ok
            new ItemImage(Ingredients.EGG, "egg.png"),  //ok
            new ItemImage(Ingredients.FLOUR, "flour.png"), //ok
            new ItemImage(Ingredients.HAM, "ham.png"), //ok
            new ItemImage(Ingredients.MEAT, "meat.png"), //ok
            new ItemImage(Ingredients.RASPBERRY, "raspberry.png"), //ok
            new ItemImage(Ingredients.SUGAR, "sugar.png"), //ok
            new ItemImage(Ingredients.TOMATO, "tomato.png"), //ok
            new ItemImage(Ingredients.OLIVES, "olives.png"), //ok
            new ItemImage(Ingredients.OLIVE_OIL, "olive_oil.png"),
            new ItemImage(Ingredients.WHIPPED_CREAM, "whipped_cream.png"),
            new ItemImage(Ingredients.WHEAT, "wheat.png"),
            new ItemImage(Ingredients.COFFEE_BEAN, "coffee_seed.png"),
            new ItemImage(Ingredients.LETTUCE, "lettuce.png"),
            new ItemImage(Ingredients.PASTA, "pasta.png"),

            new ItemImage(RawMaterials.BISMUTH, "bismuth.png"),
            new ItemImage(RawMaterials.CRYSTAL, "crystal.png"),
            new ItemImage(RawMaterials.BISMUTH_INGOT, "bismuth_ingot.png"),
            new ItemImage(RawMaterials.CLAY, "clay.png"),
            new ItemImage(RawMaterials.STICKS, "sticks.png"),
            new ItemImage(RawMaterials.WOOD_PURPLE, "wood_purple.png"),
            new ItemImage(RawMaterials.WOOD_PINK, "wood_pink.png"),
            new ItemImage(RawMaterials.BLACK_TRAPEZOID, "trapezoid_black.png"),


            new ItemImage(Misc.FLUX_CAPACITOR, "flux_capacitor.png"),
            new ItemImage(Misc.GLASS, "glass.png"),
            new ItemImage(Misc.WIRE, "wire.png"),
            new ItemImage(Misc.BLADE, "blade.png"),
            new ItemImage(Misc.POLE, "pole.png"),
    
            // Recipes items
            new ItemImage(Recipes.CROISSANT, "croissant.png"),
            new ItemImage(Recipes.CUPCAKE, "cupcake.png"),
            new ItemImage(Recipes.SMOOTHIE, "smoothie.png"),
            new ItemImage(Recipes.BANANA_MILKSHAKE, "banana_milkshake.png"),
            new ItemImage(Recipes.BURGER, "burger.png"),
            new ItemImage(Recipes.PIZZA, "pizza.png"),
            new ItemImage(Recipes.SALAD, "salad.png"),
            new ItemImage(Recipes.SHAWARMA, "shawarma_kebab.png"),
            new ItemImage(Recipes.COFFEE, "coffee.png"),
            new ItemImage(Recipes.MAC_AND_CHEESE, "mac_and_cheese.png"),

            
            // Gardening items
            new ItemImage(Gardening.FERTILIZER, "fertilizer.png"),
            new ItemImage(Gardening.TILLED_SOIL, "tilled_soil.png"),
    
            // lettuce items
            new ItemImage(Lettuce.LETTUCE_SEED, "lettuce_seed.png"),
            new ItemImage(Lettuce.LETTUCE_SMALL, "lettuce_small.png"),
            new ItemImage(Lettuce.LETTUCE_MEDIUM, "lettuce_medium.png"),
            new ItemImage(Lettuce.LETTUCE_ALMOST, "lettuce_almost.png"),
            new ItemImage(Lettuce.LETTUCE_GROWN, "lettuce_grown.png"),
            new ItemImage(Lettuce.LETTUCE_SMALL_DEAD, "lettuce_small_dead.png"),
            new ItemImage(Lettuce.LETTUCE_MEDIUM_DEAD, "lettuce_medium_dead.png"),
            new ItemImage(Lettuce.LETTUCE_ALMOST_DEAD, "lettuce_almost_dead.png"),
    
            // Wheat items
            new ItemImage(Wheat.WHEAT_SEED, "wheat_seed.png"),
            new ItemImage(Wheat.WHEAT_SMALL, "wheat_small.png"),
            new ItemImage(Wheat.WHEAT_MEDIUM, "wheat_medium.png"),
            new ItemImage(Wheat.WHEAT_ALMOST, "wheat_almost.png"),
            new ItemImage(Wheat.WHEAT_GROWN, "wheat_grown.png"),
            new ItemImage(Wheat.WHEAT_SMALL_DEAD, "wheat_small_dead.png"),
            new ItemImage(Wheat.WHEAT_MEDIUM_DEAD, "wheat_medium_dead.png"),
            new ItemImage(Wheat.WHEAT_ALMOST_DEAD, "wheat_almost_dead.png"),

            // Grass Class
            new ItemImage(Grass.GRASS_SALAD, "grass.png"),
            new ItemImage(Grass.GRASS_TOMATO, "grass.png"),
            new ItemImage(Grass.GRASS_WHEAT, "grass.png"),

            // Bushes Class
            new ItemImage(Bushes.RASPBERRY_BUSH, "raspberry_bush.png"),
            new ItemImage(Bushes.COFFEE_BUSH, "coffee_bush.png"),
            new ItemImage(Bushes.RASPBERRY_BUSH_EMPTY, "raspberry_bush_empty.png"),
            new ItemImage(Bushes.COFFEE_BUSH_EMPTY, "coffee_bush_empty.png"),

            // Tomato Class
            new ItemImage(Tomato.TOMATO_SEED, "tomato_seed.png"),
            new ItemImage(Tomato.TOMATO_SMALL, "tomato_small.png"),
            new ItemImage(Tomato.TOMATO_MEDIUM, "tomato_medium.png"),
            new ItemImage(Tomato.TOMATO_ALMOST, "tomato_almost.png"),
            new ItemImage(Tomato.TOMATO_GROWN, "tomato_grown.png"),
            new ItemImage(Tomato.TOMATO_SMALL_DEAD, "tomato_small_dead.png"),
            new ItemImage(Tomato.TOMATO_MEDIUM_DEAD, "tomato_medium_dead.png"),
            new ItemImage(Tomato.TOMATO_ALMOST_DEAD, "tomato_almost_dead.png"),

            // Trees Class
            new ItemImage(Trees.AVOCADO_TREE, "avocado_tree.png"),
            new ItemImage(Trees.BANANA_TREE, "banana_tree.png"),
            new ItemImage(Trees.OLIVE_TREE, "olive_tree.png"),
            new ItemImage(Trees.SUGAR_TREE, "sugar_tree.png"),
            new ItemImage(Trees.SIMPLE_TREE, "simple_tree.png"),
            new ItemImage(Trees.BIG_TREE, "simple_tree.png"),
            new ItemImage(Trees.AVOCADO_TREE_EMPTY, "avocado_tree_empty.png"),
            new ItemImage(Trees.BANANA_TREE_EMPTY, "banana_tree_empty.png"),
            new ItemImage(Trees.OLIVE_TREE_EMPTY, "olive_tree_empty.png"),
            new ItemImage(Trees.SUGAR_TREE_EMPTY, "sugar_tree_empty.png"),

            // Machines Class
            new ItemImage(Machines.MIXER, "mixer.png"),
            new ItemImage(Machines.BUTTER_CHURNER, "butter_churner.png"),
            new ItemImage(Machines.OLIVE_PRESS, "olive_press.png"),
            new ItemImage(Machines.CHEESE_MAKER, "cheese_maker.png"),
            new ItemImage(Machines.FURNACE_SMELTER, "furnace_smelter.png"),
            new ItemImage(Machines.WATER_WELL, "water_well.png"),
            new ItemImage(Machines.ROBOT, "robot.png"),
            new ItemImage(Machines.PASTA_MACHINE, "pasta_machine.png"),


            new ItemImage(Machines.WATER_TANK, "watertank_empty.png"),
            new ItemImage(Machines.WATER_TANK_1_BUCKET_WATER, "watertank_1_bucket.png"),
            new ItemImage(Machines.WATER_TANK_2_BUCKET_WATER, "watertank_2_bucket.png"),
            new ItemImage(Machines.WATER_TANK_3_BUCKET_WATER, "watertank_3_bucket.png"),
            new ItemImage(Machines.WATER_TANK_4_BUCKET_WATER, "watertank_4_bucket.png"),
            new ItemImage(Machines.WATER_TANK_5_BUCKET_WATER, "watertank_5_bucket.png"),
            new ItemImage(Machines.WATER_TANK_6_BUCKET_WATER, "watertank_6_bucket.png"),
            new ItemImage(Machines.WATER_TANK_7_BUCKET_WATER, "watertank_7_bucket.png"),
            new ItemImage(Machines.WATER_TANK_8_BUCKET_WATER, "watertank_8_bucket.png"),
            new ItemImage(Machines.WATER_TANK_9_BUCKET_WATER, "watertank_9_bucket.png"),
            new ItemImage(Machines.WATER_TANK_10_BUCKET_WATER, "watertank_10_bucket.png"),


            new ItemImage(Machines.MIXER_MIXING_FLOUR, "mixer_mixing.png"),
            new ItemImage(Machines.MIXER_MIXING_WHEAT, "mixer_mixing.png"),
            new ItemImage(Machines.MIXER_MIXING_MILK, "mixer_mixing.png"),
            new ItemImage(Machines.BUTTER_CHURNER_CHURNING, "butter_churner_churning.png"),
            new ItemImage(Machines.OLIVE_PRESS_PRESSING, "olive_press_pressing.png"),
            new ItemImage(Machines.CHEESE_MAKER_MAKING_CHEESE, "cheese_maker_making_cheese.png"),
            new ItemImage(Machines.FURNACE_SMELTING_BISMUTH, "furnace_smelting_bismuth.png"),
            new ItemImage(Machines.WATER_WELL_GIVING_WATER, "water_well_giving_water.png"),
            new ItemImage(Machines.ROBOT_MAKING_HAM, "robot_making_ham.png"),
            new ItemImage(Machines.ROBOT_MAKING_MEAT, "robot_making_meat.png"),
            new ItemImage(Machines.PASTA_MACHINE_MAKING_PASTA, "pasta_machine_making_pasta.png"),

       


        //Cooking
            new ItemImage(Cooking.COFFEE_MACHINE, "coffee_machine.png"),
            new ItemImage(Cooking.CRAZY_COFFEE_MACHINE, "crazy_coffee_machine.png"),
            new ItemImage(Cooking.BASIC_OVEN, "basic_oven.png"),
            new ItemImage(Cooking.CRAZY_OVEN, "crazy_oven.png"),
            new ItemImage(Cooking.CUTTING_BOARD, "cutting_board.png"),
            new ItemImage(Cooking.CRAZY_CUTTING_BOARD, "crazy_cutting_board.png"),
            new ItemImage(Cooking.BLENDER, "blender.png"),
            new ItemImage(Cooking.CRAZY_BLENDER, "crazy_blender.png"),
            new ItemImage(Cooking.KEBAB_MAKER, "kebab_maker.png"),

            new ItemImage(Cooking.COFFEE_MACHINE_BREWING, "coffee_machine_brewing.png"),
            new ItemImage(Cooking.CRAZY_COFFEE_MACHINE_BREWING, "crazy_coffee_machine_brewing.png"),
            new ItemImage(Cooking.BASIC_OVEN_COOKING_BURGER, "basic_oven_cooking_burger.png"),
            new ItemImage(Cooking.BASIC_OVEN_COOKING_CROISSANT, "basic_oven_cooking_croissant.png"),
            new ItemImage(Cooking.BASIC_OVEN_COOKING_PIZZA, "basic_oven_cooking_pizza.png"),
            new ItemImage(Cooking.BASIC_OVEN_COOKING_CUPCAKE, "basic_oven_cooking_cupcake.png"),
            new ItemImage(Cooking.BASIC_OVEN_COOKING_MAC_AND_CHEESE, "basic_oven_cooking_mac_and_cheese.png"),
            new ItemImage(Cooking.CRAZY_OVEN_COOKING_BURGER, "crazy_oven_cooking_burger.png"),
            new ItemImage(Cooking.CRAZY_OVEN_COOKING_CROISSANT, "crazy_oven_cooking_croissant.png"),
            new ItemImage(Cooking.CRAZY_OVEN_COOKING_PIZZA, "crazy_oven_cooking_pizza.png"),
            new ItemImage(Cooking.CRAZY_OVEN_COOKING_CUPCAKE, "crazy_oven_cooking_cupcake.png"),
            new ItemImage(Cooking.CRAZY_OVEN_COOKING_MAC_AND_CHEESE, "crazy_oven_cooking_mac_and_cheese.png"),
            new ItemImage(Cooking.CUTTING_BOARD_CHOPPING_SALAD, "cutting_board_chopping_salad.png"),
            new ItemImage(Cooking.CRAZY_CUTTING_BOARD_CHOPPING_SALAD, "crazy_cutting_board_chopping_salad.png"),
            new ItemImage(Cooking.BLENDER_BLENDING_SMOOTHIE, "blender_blending_smoothie.png"),
            new ItemImage(Cooking.BLENDER_BLENDING_BANANA_MILKSHAKE, "blender_blending_banana_milkshake.png"),
            new ItemImage(Cooking.CRAZY_BLENDER_BLENDING_SMOOTHIE, "crazy_blender_blending_smoothie.png"),
            new ItemImage(Cooking.CRAZY_BLENDER_BLENDING_BANANA_MILKSHAKE, "crazy_blender_blending_banana_milkshake.png"),
            new ItemImage(Cooking.KEBAB_MAKER, "kebab_maker.png"),
            new ItemImage(Cooking.KEBAB_MAKER_COOKING_KEBAB, "kebab_maker_cooking_kebab.png"),

            new ItemImage(Furniture.GREEN_CHAIR, "green_chair.png"),
            new ItemImage(Furniture.PINK_CHAIR, "pink_chair.png"),
            new ItemImage(Furniture.GREEN_TABLE, "green_table.png"),
            new ItemImage(Furniture.PURPLE_TABLE, "purple_table.png"),
            new ItemImage(Furniture.PINK_TABLE, "pink_table.png"),
            new ItemImage(Furniture.BAR_COUNTER, "bar_table.png"),

             // Decorations Class
            new ItemImage(Decorations.PLANT, "plant.png"),
            new ItemImage(Decorations.FENCE, "fence.png"),
            new ItemImage(Decorations.PINK_FLOOR, "pink_floor.png"),
            new ItemImage(Decorations.PURPLE_FLOOR, "purple_floor.png"),
            new ItemImage(Decorations.WALL, "wall.png"),
            new ItemImage(Decorations.WALL_WITH_SIGNBOARD, "wall_with_signboard.png"),
            new ItemImage(Decorations.WALL_WITH_WINDOW, "wall_with_window.png"),
            new ItemImage(Decorations.WALL_WITH_MENU, "wall_with_menu.png"),
            new ItemImage(Decorations.SIGNBOARD, "signboard.png"),
            new ItemImage(Decorations.WINDOW, "window.png"),
            new ItemImage(Decorations.WALL_MENU, "menu.png"),

            // Animals Class
            new ItemImage(Animals.COW, "cow.png"),
            new ItemImage(Animals.COW_GIVING_MILK, "cow_giving_milk.png"),
            new ItemImage(Animals.CHICKEN, "chicken.png"),

            new ItemImage(Buckets.BUCKET_MILK, "bucket_milk.png"),
            new ItemImage(Buckets.BUCKET_WATER, "bucket_water.png"),
            new ItemImage(Buckets.BUCKET_EMPTY, "bucket_empty.png"),

            new ItemImage(Tools.SCYTHE, "scythe.png"),
            new ItemImage(Tools.WATERING_CAN, "watering_can.png"),
            new ItemImage(Tools.WATERING_CAN_FULL, "watering_can_full.png"),
            new ItemImage(Tools.PICKAXE, "pickaxe.png"),
            new ItemImage(Tools.AXE, "axe.png"),
            new ItemImage(Tools.HOE, "hoe.png"),
            new ItemImage(Tools.HAND, "hand.png")

        };
    }
    
}
