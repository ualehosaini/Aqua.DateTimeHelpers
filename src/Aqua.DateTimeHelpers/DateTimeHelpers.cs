using System;

namespace Aqua.DateTimeHelpers
{
    public class DateTimeHelpers
    {
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
    }
}
