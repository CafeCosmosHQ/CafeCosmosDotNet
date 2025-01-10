using VisionsContracts.Transformations.Model;
using VisionsContracts.LandLocalState;
using System.Collections.Generic;
using VisionsContracts.Land.Model;

namespace VisionsContracts.LandPlacingStrategies
{
    public class LandStrategy
    {
        public Transformation Transformation { get; protected set; }

        public List<LandItem> ExecutedAt { get; protected set; } = new List<LandItem>();

        public List<LandItem> FailedAt { get; protected set; } = new List<LandItem> { };

        public LandStrategy(Transformation transformation)
        {
            Transformation = transformation;
        }

        public virtual PlayerLocalState PerformStrategy(PlayerLocalState playerLocalState)
        {
            var baseItemId = Transformation.Base;
            var inputItemId = Transformation.Input;
            foreach (var landItem in playerLocalState.UpdatedLand)
            {
                if (landItem.ItemId == baseItemId)
                {
                    if (playerLocalState.ContainsInventoryItemInPlayerInventory((int)inputItemId))
                    {
                        try
                        {
                            playerLocalState.PlaceItem(landItem, (int)inputItemId);
                            ExecutedAt.Add(landItem);
                        }
                        catch
                        {
                            FailedAt.Add(landItem);
                            //catch gracefully we cannot perform item strategy here
                        }
                    }
                    else
                    {
                        break; //no more inventory items.
                    }
                }
            }
            return playerLocalState;
        }
    }

}
