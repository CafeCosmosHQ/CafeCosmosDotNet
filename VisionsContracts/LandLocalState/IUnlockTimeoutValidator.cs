using System;
using System.Numerics;
using VisionsContracts.Land.Model;
using VisionsContracts.Transformations.Model;

namespace VisionsContracts.LandLocalState
{
    public interface IUnlockTimeoutValidator
    {
        DateTime GetDateTimeNow();
        bool HasLockedDurationFinished(BigInteger placementTime, BigInteger unlockTime);
        bool HasLockedDurationFinished(LandItemNextTransformation nextTransformation);
        bool HasLockedDurationFinished(LandItem landItem, Transformation transformation);
        DateTime GetUnlockTime(BigInteger placementTime, BigInteger unlockDuration);
        double GetRemainingSecondsToTimedOut(LandItemNextTransformation nextTransformation);
        double GetRemainingSecondsToTimedOut(BigInteger placementTime, BigInteger timeOutDuration);
        double GetRemainingSecondsToTimedOut(LandItem landItem, Transformation transformation);
        DateTime GetTimedOutTime(BigInteger placementTime, BigInteger timeOutDuration);
        bool HasTimedOut(LandItemNextTransformation nextTransformation);
        double GetRemainingSecondsToUnlock(BigInteger placementTime, BigInteger unlockDuration);
        double GetRemainingSecondsToUnlock(LandItem landItem, Transformation transformation);
        double GetRemainingSecondsToUnlock(LandItemNextTransformation nextTransformation);
    }
}
