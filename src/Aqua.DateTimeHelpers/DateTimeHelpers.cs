using System;
using System.Collections.Generic;

namespace Aqua.DateTimeHelpers
{
    public static class DateTimeHelpers
    {
        private static readonly DateTime _epochDateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private static readonly long _epochTicks = 621355968000000000L;

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

        /// <summary>
        /// To Convert Unix Time Stamp To DateTimeUTC
        /// </summary>
        /// <param name="unixTimeStamp"></param>
        /// <returns></returns>
        public static DateTime UnixTimeStampToDateTimeUTC(double unixTimeStamp)
        {
            return _epochDateTime.AddSeconds(unixTimeStamp);
        }

        /// <summary>
        /// To Convert DateTime To Unix Time Stamp
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static double DateTimeToUnixTimeStamp(DateTime dateTime)
        {
            return (dateTime.ToUniversalTime().Ticks - _epochTicks) / TimeSpan.TicksPerSecond;
        }

        /// <summary>
        /// Check the input if it is within a range of DateTime
        /// </summary>
        /// <param name="input"></param>
        /// <param name="rangeBegining"></param>
        /// <param name="rangeEnd"></param>
        /// <returns></returns>
        public static bool IsBetween(this DateTime input, DateTime rangeBegining, DateTime rangeEnd)
        {
            return input.Ticks >= rangeBegining.Ticks &&
                   input.Ticks < rangeEnd.Ticks;
        }

        /// <summary>
        /// Returns the DateTime.MinValue
        /// </summary>
        /// <returns></returns>
        public static DateTime GetMinDate()
        {
            return DateTime.MinValue;
        }

        /// <summary>
        /// Ignore Specific DateTime Part
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="timeSpan"></param>
        /// <returns></returns>
        public static DateTime IgnoreTimeSpan(this DateTime dateTime, TimeSpan timeSpan)
        {
            if (timeSpan == TimeSpan.Zero)
                return dateTime;

            return dateTime.AddTicks(-(dateTime.Ticks % timeSpan.Ticks));
        }

        /// <summary>
        /// Ignore the Milliseconds Part
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime IgnoreMilliseconds(this DateTime dateTime)
        {
            return dateTime.IgnoreTimeSpan(TimeSpan.FromMilliseconds(1000));
        }

        /// <summary>
        /// Ignore the Seconds Part
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime IgnoreSeconds(this DateTime dateTime)
        {
            return dateTime.IgnoreTimeSpan(TimeSpan.FromSeconds(60));
        }

        /// <summary>
        /// Ignore the Minutes Part
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime IgnoreMinutes(this DateTime dateTime)
        {
            return dateTime.IgnoreTimeSpan(TimeSpan.FromMinutes(60));
        }

        /// <summary>
        /// Ignore the Hours Part
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime IgnoreHours(this DateTime dateTime)
        {
            return dateTime.IgnoreTimeSpan(TimeSpan.FromHours(24));
        }

        /// <summary>
        /// Is The Date is Sunday?
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static bool IsSunday(this DateTime dateTime)
        {
            return dateTime.DayOfWeek == DayOfWeek.Sunday;
        }

        /// <summary>
        /// Is The Date is Moday?
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static bool IsMonday(this DateTime dateTime)
        {
            return dateTime.DayOfWeek == DayOfWeek.Monday;
        }

        /// <summary>
        /// Is The Date is Tuesday?
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static bool IsTuesday(this DateTime dateTime)
        {
            return dateTime.DayOfWeek == DayOfWeek.Tuesday;
        }

        /// <summary>
        /// Is The Date is Wednesday?
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static bool IsWednesday(this DateTime dateTime)
        {
            return dateTime.DayOfWeek == DayOfWeek.Wednesday;
        }

        /// <summary>
        /// Is The Date is Thursday?
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static bool IsThursday(this DateTime dateTime)
        {
            return dateTime.DayOfWeek == DayOfWeek.Thursday;
        }

        /// <summary>
        /// Is The Date is Friday?
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static bool IsFriday(this DateTime dateTime)
        {
            return dateTime.DayOfWeek == DayOfWeek.Friday;
        }

        /// <summary>
        /// Is The Date is Saturday?
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static bool IsSaturday(this DateTime dateTime)
        {
            return dateTime.DayOfWeek == DayOfWeek.Saturday;
        }

        /// <summary>
        /// Last WeekDay in a Year / Month
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static DateTime GetLastWeekdayOfMonth(int year, int month, DayOfWeek day)
        {
            DateTime lastDayOfTheMonth = new DateTime(year, month, 1)
                                        .AddMonths(1)
                                        .AddDays(-1);
            int searchDay = (int)day;
            int lastDay = (int)lastDayOfTheMonth.DayOfWeek;
            return lastDayOfTheMonth.AddDays(lastDay >= searchDay
                                                ? searchDay - lastDay
                                                : searchDay - lastDay - 7);
        }

        /// <summary>
        /// Generate Date List between two dates
        /// </summary>
        /// <param name="fisrtDate"></param>
        /// <param name="lastDate"></param>
        /// <returns></returns>
        public static List<DateTime> GenerateDateList(DateTime fisrtDate, DateTime lastDate)
        {
            if (fisrtDate > lastDate)
                throw new ArgumentException("Incorrect last date " + lastDate);

            List<DateTime> result = new List<DateTime>();
            for (DateTime day = fisrtDate.Date; day.Date <= lastDate.Date; day = day.AddDays(1))
            {
                result.Add(day);
            }

            return result;

        }

    }
}
