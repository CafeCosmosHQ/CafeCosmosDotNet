using System.Collections.Generic;
using VisionsContracts.Transformations.Model;
using VisionsContracts.LandLocalState;
using VisionsContracts.Transformations;

namespace VisionsContracts.LandPlacingStrategies
{
    public class ChopTreesAndBushesStrategy
    {
        public PlayerLocalState PerformStrategy(PlayerLocalState updateLandOperations)
        {
            var transformations = GetTransformations();
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
                DefaultTransformations.ToolsTransformations.AvocadoTreeAxeTransformation,
                DefaultTransformations.ToolsTransformations.BananaTreeAxeTransformation,
                DefaultTransformations.ToolsTransformations.OliveTreeAxeTransformation,
                DefaultTransformations.ToolsTransformations.CoffeeBushAxeTransformation,
                DefaultTransformations.ToolsTransformations.RaspberryBushAxeTransformation,
               

            };
        }

    }
   
}
