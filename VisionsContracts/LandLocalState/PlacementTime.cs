using System.Numerics;

namespace VisionsContracts.LandLocalState
{
    public class PlacementTime
    {
        public BigInteger X { get; set; }
        public BigInteger Y { get; set; }
        public BigInteger Time { get; set; }
        public bool ToUpdateTimeAfterSubmission { get; set; }
        public int UnlockTime { get; set; }
    }

}
