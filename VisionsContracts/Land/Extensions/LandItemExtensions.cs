using LandItem = VisionsContracts.Land.Model.LandItem;

namespace VisionsContracts.Land.Extensions
{
    public static class LandItemExtensions
    {
        public static object Clone(this LandItem landItem)
        {
            return new LandItem()
            {
                ItemId = landItem.ItemId,
                PlacementTime = landItem.PlacementTime,
                DynamicTimeoutTime = landItem.DynamicTimeoutTime,
                DynamicUnlockTime = landItem.DynamicUnlockTime,
                IsRotated = landItem.IsRotated,
                StackIndex = landItem.StackIndex,
                X = landItem.X,
                Y = landItem.Y,
            };
        }

        public static bool Equals(this LandItem source, LandItem other)
        {
            return
              other.ItemId == source.ItemId
              && other.PlacementTime == source.PlacementTime
              && other.DynamicUnlockTime == source.DynamicUnlockTime
              && other.DynamicTimeoutTime == source.DynamicTimeoutTime
              && other.IsRotated == source.IsRotated
              && other.StackIndex == source.StackIndex
              && other.X == source.X
              && other.Y == source.Y;
        }
    }

}



