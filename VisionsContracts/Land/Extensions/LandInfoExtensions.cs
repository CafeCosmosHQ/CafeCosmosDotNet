using VisionsContracts.Land.Model;

namespace VisionsContracts.Land.Extensions
{
    public static class LandInfoExtensions
    {
        public static bool HasLand(this LandInfo landInfo)
        {
            if (landInfo.LimitX > 0 && landInfo.LimitY > 0) return true;
            return false;
        }
    }

}



