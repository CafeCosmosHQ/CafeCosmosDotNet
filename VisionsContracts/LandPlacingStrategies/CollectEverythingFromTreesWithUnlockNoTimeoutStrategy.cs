using System.Collections.Generic;
using VisionsContracts.Transformations.Model;
using VisionsContracts.LandLocalState;
using VisionsContracts.Transformations;
using System.Linq;
using System.Numerics;

namespace VisionsContracts.LandPlacingStrategies
{
    public class CollectEverythingFromTreesWithUnlockNoTimeoutStrategy
    {
        public BigInteger GetMaxUnlockTime()
        {
            return GetTransformations().Max(x => x.UnlockTime);
        }

        public PlayerLocalState PerformStrategy(PlayerLocalState updateLandOperations)
        {
            var transformations = GetTransformations();
            if (transformations.Any(x => x.Timeout > 0)) throw new System.Exception("Transformation found with Timeout, check the transformations");
            foreach (var transformation in transformations)
            {
                var landStrategy = new LandStrategy(transformation);
                updateLandOperations = landStrategy.PerformStrategy(updateLandOperations);
            }
            return updateLandOperations;
        }

        public List<Transformation> GetTransformations()
        {
            return new List<Transformation>()
            {
                DefaultTransformations.TreesTransformations.SugarTreeClickTransformation,
                DefaultTransformations.TreesTransformations.AvocadoTreeClickTransformation,
                DefaultTransformations.TreesTransformations.RaspberryBushClickTransformation,
                DefaultTransformations.TreesTransformations.CoffeeBushClickTransformation,
            };
        }
    }
   
}
