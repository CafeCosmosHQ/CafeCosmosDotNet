using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using VisionsContracts.Land.Systems.LandCreationSystem.ContractDefinition;
using VisionsContracts.Items;
using System;

namespace VisionsContracts.Land.Systems.LandCreationSystem
{
    public class InitialLandService
    {
        public class InitialItem
        {
            public int ItemId { get; set; }
            public int Quantity { get; set; }
        }

        public static List<InitialItem> GetInitialItems()
        {
            return new[] {
                new InitialItem()
                {
                    ItemId = DefaultItems.Trees.BANANA_TREE.Id,
                    Quantity = 1,
                },
                new InitialItem()
                {
                    ItemId = DefaultItems.Trees.SUGAR_TREE.Id,
                    Quantity = 1,
                },
                new InitialItem()
                {
                    ItemId = DefaultItems.Trees.SIMPLE_TREE.Id,
                    Quantity = 1,
                },
                new InitialItem()
                {
                    ItemId = DefaultItems.Trees.OLIVE_TREE.Id,
                    Quantity = 1,
                },
                new InitialItem()
                {
                    ItemId = DefaultItems.Trees.AVOCADO_TREE.Id,
                    Quantity = 1,
                },
                new InitialItem()
                {
                    ItemId = DefaultItems.Bushes.RASPBERRY_BUSH.Id,
                    Quantity = 1,
                },
                new InitialItem()
                {
                    ItemId = DefaultItems.Bushes.COFFEE_BUSH.Id,
                    Quantity = 1,
                },
                new InitialItem()
                {
                    ItemId = DefaultItems.Grass.GRASS_SALAD.Id,
                    Quantity = 2,
                },
                new InitialItem()
                {
                    ItemId = DefaultItems.Grass.GRASS_TOMATO.Id,
                    Quantity = 2,
                },
                new InitialItem()
                {
                    ItemId = DefaultItems.Grass.GRASS_WHEAT.Id,
                    Quantity = 2,
                },
                new InitialItem()
                {
                    ItemId = DefaultItems.Animals.COW.Id,
                    Quantity = 1,
                },
                new InitialItem()
                {
                    ItemId = DefaultItems.Animals.CHICKEN.Id,
                    Quantity = 1,
                },
                new InitialItem()
                {
                    ItemId = DefaultItems.RawMaterials.CRYSTAL.Id,
                    Quantity = 4,
                },
                new InitialItem()
                {
                    ItemId = DefaultItems.RawMaterials.STICKS.Id,
                    Quantity = 4,
                },
                new InitialItem()
                {
                    ItemId = DefaultItems.RawMaterials.BISMUTH.Id,
                    Quantity = 4,
                },
                new InitialItem()
                {
                    ItemId = DefaultItems.RawMaterials.CLAY.Id,
                    Quantity = 4,
                },
                new InitialItem()
                {
                    ItemId =  0,
                    Quantity = 4,
                },

            }.ToList();
        }

        public static List<List<InitialLandItem>> GetRandomInitialLandItems(int numberOfLands, int maxSizeX, int maxSizeY)
        {
            var initialLandItems = new List<List<InitialLandItem>>();
            for (int i = 0; i < numberOfLands; i++)
            {
                initialLandItems.Add(GetRandomItemsOnGridWithCafeOnTop(maxSizeX, maxSizeY));
            }
            return initialLandItems;
        }

        public static List<InitialLandItem> GetRandomItemsOnGridWithCafeOnTop(int maxSizeX, int maxSizeY)
        {
            var initialItems = GetInitialCafe();
            var occupiedPositions = new HashSet<(int, int)>();
            foreach(var item in initialItems)
            {
                (int x, int y) position = ((int)item.X, (int)item.Y);
                occupiedPositions.Add(position);
            }

            initialItems.AddRange(GetRandomItemsOnGrid(maxSizeX, maxSizeY, occupiedPositions));
            return initialItems;

        }

        public static List<InitialLandItem> GetInitialCafe()
        {
            var gridItems = new List<InitialLandItem>
            {
                new InitialLandItem { ItemId = 0, X = 0, Y = 0, Z = 0, Rotated = false},
                new InitialLandItem { ItemId = 0, X = 0, Y = 1, Z = 0, Rotated = false},
                new InitialLandItem { ItemId = 0, X = 0, Y = 2, Z = 0, Rotated = false},
                new InitialLandItem { ItemId = 0, X = 0, Y = 4, Z = 0, Rotated = false},
                new InitialLandItem { ItemId = 0, X = 1, Y = 5, Z = 0, Rotated = false},
                new InitialLandItem { ItemId = 0, X = 2, Y = 5, Z = 0, Rotated = false},
                new InitialLandItem { ItemId = 0, X = 3, Y = 5, Z = 0, Rotated = false},
                new InitialLandItem { ItemId = 0, X = 4, Y = 5, Z = 0, Rotated = false},
                new InitialLandItem { ItemId = 0, X = 1, Y = 0, Z = 0, Rotated = false},
                new InitialLandItem { ItemId = 0, X = 2, Y = 0, Z = 0, Rotated = false},
                new InitialLandItem { ItemId = 0, X = 3, Y = 0, Z = 0, Rotated = false},
                new InitialLandItem { ItemId = 0, X = 4, Y = 0, Z = 0, Rotated = false},
                new InitialLandItem { ItemId = 0, X = 5, Y = 0, Z = 0, Rotated = false},
                new InitialLandItem { ItemId = 0, X = 5, Y = 1, Z = 0, Rotated = false},
                new InitialLandItem { ItemId = 0, X = 5, Y = 2, Z = 0, Rotated = false},
                new InitialLandItem { ItemId = 0, X = 5, Y = 4, Z = 0, Rotated = false},

                new InitialLandItem { ItemId = DefaultItems.Bushes.COFFEE_BUSH.Id, X = 0, Y = 3, Z = 0, Rotated = false},
                new InitialLandItem { ItemId = DefaultItems.Decorations.PINK_FLOOR.Id, X = 1, Y = 1, Z = 0, Rotated = false},
                new InitialLandItem { ItemId = DefaultItems.Decorations.PURPLE_FLOOR.Id, X = 1, Y = 2, Z = 0, Rotated = false},
                new InitialLandItem { ItemId = DefaultItems.Decorations.PINK_FLOOR.Id, X = 1, Y = 3, Z = 0, Rotated = false},
                new InitialLandItem { ItemId = DefaultItems.Decorations.WALL_WITH_WINDOW.Id, X = 1, Y = 4, Z = 0, Rotated = false},
                new InitialLandItem { ItemId = DefaultItems.Decorations.PURPLE_FLOOR.Id, X = 2, Y = 1, Z = 0, Rotated = false},
                new InitialLandItem { ItemId = DefaultItems.Decorations.PINK_FLOOR.Id, X = 2, Y = 2, Z = 0, Rotated = false},
                new InitialLandItem { ItemId = DefaultItems.Decorations.PURPLE_FLOOR.Id, X = 2, Y = 3, Z = 0, Rotated = false},
                new InitialLandItem { ItemId = DefaultItems.Decorations.WALL_WITH_MENU.Id, X = 2, Y = 4, Z = 0, Rotated = false},
                new InitialLandItem { ItemId = DefaultItems.Decorations.PINK_FLOOR.Id, X = 3, Y = 1, Z = 0, Rotated = false},
                new InitialLandItem { ItemId = DefaultItems.Decorations.PURPLE_FLOOR.Id, X = 3, Y = 2, Z = 0, Rotated = false},
                new InitialLandItem { ItemId = DefaultItems.Decorations.PINK_FLOOR.Id, X = 3, Y = 3, Z = 0, Rotated = false},
                new InitialLandItem { ItemId = DefaultItems.Decorations.WALL.Id, X = 3, Y = 4, Z = 0, Rotated = false},
                new InitialLandItem { ItemId = DefaultItems.Decorations.WALL_WITH_SIGNBOARD.Id, X = 4, Y = 1, Z = 0, Rotated = true},
                new InitialLandItem { ItemId = DefaultItems.Decorations.WALL.Id, X = 4, Y = 2, Z = 0, Rotated = true},
                new InitialLandItem { ItemId = DefaultItems.Decorations.WALL.Id, X = 4, Y = 3, Z = 0, Rotated = true},
                new InitialLandItem { ItemId = DefaultItems.Furniture.GREEN_TABLE.Id, X = 1, Y = 1, Z = 1, Rotated = false},
                new InitialLandItem { ItemId = DefaultItems.Furniture.GREEN_CHAIR.Id, X = 1, Y = 2, Z = 1, Rotated = false},
                new InitialLandItem { ItemId = DefaultItems.Decorations.PLANT.Id, X = 1, Y = 3  , Z = 1, Rotated = false},
                new InitialLandItem { ItemId = DefaultItems.Furniture.BAR_COUNTER.Id, X = 3, Y = 2, Z = 1, Rotated = false},
                new InitialLandItem { ItemId = DefaultItems.Furniture.BAR_COUNTER.Id, X = 3, Y = 3, Z = 1, Rotated = false},
                new InitialLandItem { ItemId = DefaultItems.Cooking.COFFEE_MACHINE.Id, X = 3, Y = 3, Z = 2, Rotated = false},

            };

            return gridItems;
        }

        public static List<InitialLandItem> GetRandomItemsOnGrid(int maxSizeX, int maxSizeY, HashSet<(int, int)> occupiedPositions = null)
        {
            var gridItems = new List<InitialLandItem>();
            if (occupiedPositions == null) occupiedPositions = new HashSet<(int, int)>();
            var random = new Random();

            foreach (var initialItem in GetInitialItems())
            {
                for (int i = 0; i < initialItem.Quantity; i++)
                {
                    (int x, int y) position;
                    do
                    {
                        position = (random.Next(maxSizeX), random.Next(maxSizeY)); // Random position on 10x10 grid
                    }
                    while (occupiedPositions.Contains(position));

                    occupiedPositions.Add(position);

                    gridItems.Add(new InitialLandItem
                    {
                        X = new BigInteger(position.x),
                        Y = new BigInteger(position.y),
                        Z = 0,
                        Rotated = false,
                        ItemId = new BigInteger(initialItem.ItemId)
                    });
                }
            }

            return gridItems;
        }
    }
}
