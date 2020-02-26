using System;

namespace Aqua.DateTimeHelpers
{
    public class DateTimeHelpers
    {
        private static readonly DateTime _epochDateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Check the combination of Year, Month, and Day is a Valid Date
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static bool IsValidDate(int year, int month, int day)
        {
            return
                year >= DateTime.MinValue.Year &&
                year <= DateTime.MaxValue.Year &&
                month >= 1 &&
                month <= 12 &&
                day >= 1 &&
                DateTime.DaysInMonth(year, month) >= day;
        }

        /// <summary>
        /// Check the combination of Hour, Minute, and Second is a Valid Time
        /// </summary>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static bool IsValidTime(int hour, int minute, int second = 0)
        {
            return
                hour >= 0 &&
                hour <= 23 &&
                minute >= 0 &&
                minute <= 59 &&
                second >= 0 &&
                second <= 59;
        }

        /// <summary>
        /// Check the combination of Year, Month, Day, Hour, Minute, and Second is a Valid DateTime
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static bool IsValidDateTime(int year, int month, int day, int hour, int minute, int second = 0)
        {
            return IsValidDate(year, month, day) &&
                   IsValidTime(hour, minute, second);
        }

        /// <summary>
        /// To Convert Unix 
        /// Time Stamp To DateTime
        /// </summary>
        /// <param name="unixTimeStamp"></param>
        /// <returns></returns>
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            return new DateTime(_epochDateTime.AddSeconds(unixTimeStamp).ToLocalTime().Ticks);
        }
    }
}
