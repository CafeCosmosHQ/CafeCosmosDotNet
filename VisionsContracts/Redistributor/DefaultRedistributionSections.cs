using System;
using System.Collections.Generic;
using VisionsContracts.Redistributor.ContractDefinition;
using VisionsContracts.Redistributor.Model;
using SubSection = VisionsContracts.Redistributor.Model.SubSection;

namespace VisionsContracts.Redistributor
{
    public static class DefaultRedistributionSections
    {
        public static SubSection MAINS = new(65, "Mains");
        public static SubSection DESSERTS = new(25, "Desserts");
        public static SubSection DRINKS = new(10, "Drinks");

        public static List<SubSectionCreation> GetDefaultSubsectionCreations()
        {
            return new List<SubSectionCreation> { MAINS.CreateSubSectionCreation(), DESSERTS.CreateSubSectionCreation(), DRINKS.CreateSubSectionCreation() };
        }

    }
}
