using System;
using System.Numerics;
using VisionsContracts.Land.Model;
using VisionsContracts.Transformations.Model;
using VisionsContracts.Utils;

namespace VisionsContracts.LandLocalState
{
    public class UnlockTimeoutValidator : IUnlockTimeoutValidator
    {
        public virtual DateTime GetDateTimeNow()
        {
            return DateTime.Now;
        }

        public double GetRemainingSecondsToTimedOut(LandItemNextTransformation nextTransformation)
        {
            return GetRemainingSecondsToTimedOut(nextTransformation.LandItem.PlacementTime, GetTimeoutDuration(nextTransformation));
        }

        public BigInteger GetTimeoutDuration(LandItemNextTransformation nextTransformation)
        {
            if (nextTransformation.LandItem.DynamicTimeoutTime > 0)
            {
                return nextTransformation.LandItem.DynamicTimeoutTime;
            }

            return nextTransformation.Transformation.Timeout;
        }

        public BigInteger GetUnlockDuration(LandItemNextTransformation nextTransformation)
        {
            if (nextTransformation.LandItem.DynamicUnlockTime > 0)
            {
                return nextTransformation.LandItem.DynamicUnlockTime;
            }

            return nextTransformation.Transformation.UnlockTime;
        }

        public double GetRemainingSecondsToTimedOut(LandItem landItem, Transformation transformation)
        {
            return GetRemainingSecondsToTimedOut(landItem.PlacementTime, GetTimeoutDuration(landItem, transformation));
        }

        public BigInteger GetTimeoutDuration(LandItem landItem, Transformation transformation)
        {
            if (landItem.DynamicTimeoutTime > 0)
            {
                return landItem.DynamicTimeoutTime;
            }

            return transformation.Timeout;
        }

        public BigInteger GetUnlockDuration(LandItem landItem, Transformation transformation)
        {
            if (landItem.DynamicUnlockTime > 0)
            {
                return landItem.DynamicUnlockTime;
            }

            return transformation.UnlockTime;
        }

        public double GetRemainingSecondsToTimedOut(BigInteger placementTime, BigInteger timeOutDuration)
        {
            return (GetTimedOutTime(placementTime, timeOutDuration) - GetDateTimeNow()).TotalSeconds;
        }

        public double GetRemainingSecondsToUnlock(LandItemNextTransformation nextTransformation)
        {
            if (nextTransformation == null) return 0;
            return GetRemainingSecondsToUnlock(nextTransformation.LandItem.PlacementTime, GetUnlockDuration(nextTransformation));
        }

        public double GetRemainingSecondsToUnlock(LandItem landItem, Transformation transformation)
        {
            return GetRemainingSecondsToUnlock(landItem.PlacementTime, GetUnlockDuration(landItem, transformation));
        }

        public double GetRemainingSecondsToUnlock(BigInteger placementTime, BigInteger unlockDuration)
        {
            return (GetUnlockTime(placementTime, unlockDuration) - GetDateTimeNow()).TotalSeconds;
        }

        public bool HasTimedOut(LandItemNextTransformation nextTransformation)
        {
            return HasTimedOut(nextTransformation.LandItem, nextTransformation.Transformation);
        }

        public bool HasTimedOut(LandItem landItem, Transformation transformation)
        {
            return HasTimedOut(landItem.PlacementTime, GetTimeoutDuration(landItem, transformation));
        }

        public bool HasTimedOut(BigInteger placementTime, BigInteger unlockDuration)
        {
            return GetTimedOutTime(placementTime, unlockDuration) < GetDateTimeNow();
        }

        public bool HasLockedDurationFinished(LandItemNextTransformation nextTransformation)
        {
            return HasLockedDurationFinished(nextTransformation.LandItem, nextTransformation.Transformation);
        }

        public bool HasLockedDurationFinished(LandItem landItem, Transformation transformation)
        {
            return HasLockedDurationFinished(landItem.PlacementTime, GetUnlockDuration(landItem, transformation));
        }

        public bool HasLockedDurationFinished(BigInteger placementTime, BigInteger unlockDuration)
        {
            return GetUnlockTime(placementTime, unlockDuration) < GetDateTimeNow();
        }

        public DateTime GetUnlockTime(BigInteger placementTime, BigInteger unlockDuration)
        {
            return DateTimeHelper.ParseUnixTimestamp((long)placementTime + (long)unlockDuration);
        }

        public DateTime GetTimedOutTime(BigInteger placementTime, BigInteger timeOutDuration)
        {
            return DateTimeHelper.ParseUnixTimestamp((long)placementTime + (long)timeOutDuration);
        }
    }
}
