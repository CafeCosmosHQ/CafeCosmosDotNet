using System.Numerics;

namespace VisionsContracts.Land.Model
{
    public partial class LandItem
    { 
        public virtual BigInteger X { get; set; }
      
        public virtual BigInteger Y { get; set; }
      
        public virtual BigInteger ItemId { get; set; }
       
        public virtual BigInteger PlacementTime { get; set; }
     
        public virtual BigInteger StackIndex { get; set; }
       
        public virtual bool IsRotated { get; set; }
       
        public virtual BigInteger DynamicUnlockTime { get; set; }
       
        public virtual BigInteger DynamicTimeoutTime { get; set; }
    }
}
