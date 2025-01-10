using System;
using VisionsContracts.Land.Model;
using VisionsContracts.Transformations.Model;

namespace VisionsContracts.Land.Exceptions
{
    public class LandPlaceItemNeedsSavingForTransformationException : Exception
    {
        public LandPlaceItemNeedsSavingForTransformationException(Transformation transformation) : base($"Item needs to be saved into chain, elapsed the following time: {transformation.UnlockTime} before placing: {transformation.Input}")
        {
            Transformation = transformation;
        }

        public Transformation Transformation { get; }
    }


    public class LandPlaceItemUnlockTimeHasNotElapsed : Exception
    {
        public LandPlaceItemUnlockTimeHasNotElapsed(Transformation transformation, LandItem landItem) : base($"Land Item unlock time has not elapsed: {transformation.UnlockTime}, placement time: {landItem.PlacementTime} before placing: {transformation.Input}")
        {
            Transformation = transformation;
            LandItem = landItem;
        }

        public Transformation Transformation { get; }
        public LandItem LandItem { get; }
    }

}
