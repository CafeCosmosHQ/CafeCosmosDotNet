using System.Collections.Generic;
using VisionsContracts.Transformations.Model;
using VisionsContracts.LandLocalState;
using VisionsContracts.Transformations;
using VisionsContracts.Land.Model;

namespace VisionsContracts.LandPlacingStrategies
{
    public class TransformationExecution
    {
        public LandItem LandItem { get; set; }
        public Transformation Transformation { get; set; }  
    }


    public class CollectEverythingStrategy
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
                DefaultTransformations.ToolsTransformations.LettuceGrassScytheTransformation,
                DefaultTransformations.ToolsTransformations.TomatoGrassScytheTransformation,
                DefaultTransformations.ToolsTransformations.WheatGrassScytheTransformation,
                DefaultTransformations.ToolsTransformations.CrystalClickTransformation,
                DefaultTransformations.ToolsTransformations.BismuthPickAxeTransformation,
                
            };
        }
    }
   
}
