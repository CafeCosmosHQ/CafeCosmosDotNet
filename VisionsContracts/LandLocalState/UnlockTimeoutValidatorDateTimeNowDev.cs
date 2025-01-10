using System;
using System.Numerics;
using VisionsContracts.Utils;

namespace VisionsContracts.LandLocalState
{
    public class UnlockTimeoutValidatorDateTimeNowDev : UnlockTimeoutValidator
    {
        public DateTime? DateTimeNow { get; set; }

        public void Reset()
        {
            DateTimeNow = null;
        }

        public void IncreaseSeconds(int seconds)
        {
            if (DateTimeNow != null) DateTimeNow = DateTimeNow.Value.AddSeconds((int)seconds);
            else
                DateTimeNow = DateTime.Now.AddSeconds((int)seconds);
        }

        public void SetDateTimeNow(long unixTime)
        {
            DateTimeNow = DateTimeHelper.ParseUnixTimestamp(unixTime);
        }

        public void IncreaseSeconds(BigInteger secondsAsInt)
        {
            if (DateTimeNow != null) DateTimeNow = DateTimeNow.Value.AddSeconds((int)secondsAsInt);
            else
            DateTimeNow = DateTime.Now.AddSeconds((int)secondsAsInt);
        }

        public override DateTime GetDateTimeNow()
        {
            if(DateTimeNow != null)
            {
                return DateTimeNow.Value;
            }
            return DateTime.Now;
        }
    }
}
