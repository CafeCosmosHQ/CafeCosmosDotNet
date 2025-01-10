using System.Linq;
using System.Numerics;
using VisionsContracts.Items;
using VisionsContracts.Redistributor.ContractDefinition;

namespace VisionsContracts.Redistributor.Model
{
    public record SubSection
    {
        public SubSection(int masterShares, string name)
        {
            MasterShares = masterShares;
            Name = name;
        }
        public int MasterShares { get; init; }
        public string Name { get; init; }

        public SubSectionCreation CreateSubSectionCreation()
        {
            return new SubSectionCreation()
            {
                MasterShares = MasterShares,
                Name = Name,
                PoolIdentifiers = DefaultItems.GetAllRedistributionRecipes().Where(x => x.SubSection == this).Select(x => (BigInteger)x.Id).ToList()
            };
        }
    }
}
