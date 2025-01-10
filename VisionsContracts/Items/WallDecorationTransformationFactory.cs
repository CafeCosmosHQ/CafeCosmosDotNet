using System.Collections.Generic;
using VisionsContracts.Items.Model;
using VisionsContracts.Transformations.Model;

namespace VisionsContracts.Items
{
    public class WallDecorationTransformationFactory
    {
        public static List<Transformation> CreateTransformations(Item wall, Item wallWithDecoration, Item decoration)
        {
            return new List<Transformation>
            {
                new Transformation
                {
                    Base = wall.Id,
                    Input = decoration.Id,
                    Next = wallWithDecoration.Id,
                    Yield = 0,
                    YieldQuantity = 0,
                    UnlockTime = 0,
                    Timeout = 0,
                    TimeoutNext = 0,
                    TimeoutYield = 0,
                    TimeoutYieldQuantity = 0,
                    IsRecipe = false,
                    Exists = true
                },
                new Transformation
                {
                    Base = wallWithDecoration.Id,
                    Input = DefaultItems.Tools.PICKAXE.Id,
                    Next = wall.Id,
                    Yield = decoration.Id,
                    YieldQuantity = 1,
                    UnlockTime = 0,
                    Timeout = 0,
                    TimeoutNext = 0,
                    TimeoutYield = 0,
                    TimeoutYieldQuantity = 0,
                    IsRecipe = false,
                    Exists = true
                }
            };
        }
    }
}
