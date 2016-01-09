using System.Diagnostics;

namespace Soul.Engine
{
    public static class Clock
    {
        public const int MS_PER_SECOND = 1000;
        public const int MS_PER_MINUTE = 60000;
        public const int MS_PER_HOUR = 3600000;
        private static readonly Stopwatch Sw = Stopwatch.StartNew();

        public static long Ticks
        {
            get { return Sw.ElapsedMilliseconds; }
        }

        public static uint SecondsTicks
        {
            get { return (uint) (Sw.ElapsedMilliseconds/MS_PER_SECOND); }
        }

        public static uint MinutesTicks
        {
            get { return (uint) (Sw.ElapsedMilliseconds/MS_PER_MINUTE); }
        }

        public static uint HoursTicks
        {
            get { return (uint) (Sw.ElapsedMilliseconds/MS_PER_HOUR); }
        }
    }
}