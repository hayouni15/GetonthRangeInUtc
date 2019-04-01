using System;

namespace CS
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime utcMonthStart;
            DateTime utcNextMonthStart;
            DateTime aDate = new DateTime(2019, 2, 1);
            GetMonthRangeInUtc(aDate, out utcMonthStart, out utcNextMonthStart);
            Console.WriteLine("The first second of the first day of the month is: {0} (UTC)",utcMonthStart);
            Console.WriteLine("The first second of the first day of the next month: {0} (UTC)",utcNextMonthStart);
        }
        static void GetMonthRangeInUtc(DateTime aDate, out DateTime utcMonthStart, out DateTime utcNextMonthStart)
        {
            // compute the first day of the month containing aDate and successive months
            DateTime[] monthBoundaries = new DateTime[2];
            for (int i = 0; i < monthBoundaries.Length; i++)
            {
                monthBoundaries[i] = new DateTime(aDate.Year, aDate.Month+i, 1);
            }
            // Compute the offset from UTC to our local time (UTC + offset = localtime).
            TimeSpan utcOffset = TimeZoneInfo.Local.GetUtcOffset(aDate); //use TimeZoneInfo instead of TimeZone(obsolete)
            TimeZoneInfo localZone = TimeZoneInfo.Local;
            Console.WriteLine("Local Time zone:{0} , UTC Offset: {1}", localZone.StandardName,utcOffset);
            // convert local times to UTC (UTC = localtime - offset)
            utcMonthStart = monthBoundaries[0].Subtract(utcOffset);
            utcNextMonthStart = monthBoundaries[1].Subtract(utcOffset);
        }
    }
}
