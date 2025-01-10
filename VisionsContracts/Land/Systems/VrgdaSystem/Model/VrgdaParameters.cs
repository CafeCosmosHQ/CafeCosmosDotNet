using System.Numerics;

namespace VisionsContracts.Land.Systems.VrgdaSystem.Model
{
    public class VrgdaParameters
    {
        public BigInteger TargetPrice { get; set; }
        public BigInteger PriceDecayPercent { get; set; }
        public BigInteger PerTimeUnit { get; set; }
    }
}
