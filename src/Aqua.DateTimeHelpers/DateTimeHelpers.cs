using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

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
        public static bool IsValidDate(int year, int month, int day) => year >= DateTime.MinValue.Year &&
                year <= DateTime.MaxValue.Year &&
                month >= 1 &&
                month <= 12 &&
                day >= 1 &&
                DateTime.DaysInMonth(year, month) >= day;

        /// <summary>
        /// Check the combination of Hour, Minute, and Second is a Valid Time
        /// </summary>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static bool IsValidTime(int hour, int minute, int second = 0) => hour >= 0 &&
                hour <= 23 &&
                minute >= 0 &&
                minute <= 59 &&
                second >= 0 &&
                second <= 59;

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
        public static bool IsValidDateTime(int year, int month, int day, int hour, int minute, int second = 0) => IsValidDate(year, month, day) &&
                   IsValidTime(hour, minute, second);

        /// <summary>
        /// To Convert Unix 
        /// Time Stamp To DateTime
        /// </summary>
        /// <param name="unixTimeStamp"></param>
        /// <returns></returns>
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp) => new DateTime(_epochDateTime.AddSeconds(unixTimeStamp).ToLocalTime().Ticks);

        /// <summary>
        /// To Convert Unix Time Stamp To DateTimeUTC
        /// </summary>
        /// <param name="unixTimeStamp"></param>
        /// <returns></returns>
        public static DateTime UnixTimeStampToDateTimeUTC(double unixTimeStamp) => _epochDateTime.AddSeconds(unixTimeStamp);

        /// <summary>
        /// To Convert DateTime To Unix Time Stamp
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static double DateTimeToUnixTimeStamp(DateTime dateTime) => (dateTime.ToUniversalTime().Ticks - _epochTicks) / TimeSpan.TicksPerSecond;

        /// <summary>
        /// Check the input if it is within a range of DateTime
        /// </summary>
        /// <param name="input"></param>
        /// <param name="rangeBegining"></param>
        /// <param name="rangeEnd"></param>
        /// <returns></returns>
        public static bool IsBetween(this DateTime input, DateTime rangeBegining, DateTime rangeEnd) => input.Ticks >= rangeBegining.Ticks &&
                   input.Ticks < rangeEnd.Ticks;

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

        /// <summary>
        /// Return the Date of the first day of week of specific Date
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime GetFirstDayOfWeek(DateTime dateTime)
        {
            CultureInfo culture = Thread.CurrentThread.CurrentCulture;
            int diff = dateTime.DayOfWeek - culture.DateTimeFormat.FirstDayOfWeek;

            if (diff < 0)
            {
                diff += 7;
            }

            return dateTime.AddDays(-diff).Date;
        }

        /// <summary>
        /// Return the Year's quarter number of specific date
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static int QuarterOfYear(this DateTime dateTime)
        {
            return dateTime.Month >= 1 && dateTime.Month <= 3
                ? 1
                : dateTime.Month >= 4 && dateTime.Month <= 6
                    ? 2
                    : dateTime.Month >= 7 && dateTime.Month <= 9
                        ? 3 : 4;
        }

        /// <summary>
        /// Returns Midnight of a DateTime
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime Midnight(this DateTime dateTime)
        {
            return dateTime.Date;
        }

        /// <summary>
        /// Returns the age in years
        /// </summary>
        /// <param name="referenceDate"></param>
        /// <param name="today"></param>
        /// <returns></returns>
        public static int AgeCalenderYears(DateTime referenceDate, DateTime today)
        {
            if (referenceDate > today)
                throw new ArgumentOutOfRangeException(nameof(referenceDate));

            return today.Year - referenceDate.Year;
        }

        /// <summary>
        /// Set a Time to a DateTime
        /// </summary>
        /// <param name="date"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static DateTime SetTime(this DateTime date, int hour = 0, int minute = 0, int second = 0)
        {
            if (!IsValidTime(hour, minute, second))
                throw new ArgumentOutOfRangeException("Time values are not within ccepted range");
            return new DateTime(date.Year, date.Month, date.Day, hour, minute, second);
        }

        /// <summary>
        /// Return the Date of the last day of week of specific Date
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime GetLastDayOfWeek(DateTime dateTime)
        {
            return GetFirstDayOfWeek(dateTime).AddDays(6);
        }

        /// <summary>
        /// Return the Date of the first day of next week of specific Date
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime GetFirstDayOfNextWeek(DateTime dateTime)
        {
            return GetFirstDayOfWeek(dateTime).AddDays(7);
        }

        /// <summary>
        /// Return the Date of the same day of next month
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime NextMonthSameDay(this DateTime dateTime)
        {
            return dateTime.AddMonths(1);
        }

        /// <summary>
        /// Set a Day to a DateTime
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static DateTime SetDay(this DateTime dateTime, int day)
        {
            if (!IsValidDate(dateTime.Year, dateTime.Month, day))
                throw new ArgumentOutOfRangeException(nameof(day));

            return dateTime.AddDays(-1 * dateTime.Day).AddDays(day);

            //return new DateTime(dateTime.Year, dateTime.Month, day, dateTime.Hour, dateTime.Minute, dateTime.Second);
        }

        /// <summary>
        /// Returns same DateTime as Next Year
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime NextYearSameDay(this DateTime dateTime)
        {
            return dateTime.AddYears(1);
        }

        /// <summary>
        /// Returns Noon of a DateTime
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime Noon(this DateTime dateTime)
        {
            return dateTime.SetTime(12, 0, 0);
        }

        /// <summary>
        /// Checks if The DateTime is an AM DateTime value
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static bool IsDateAM(this DateTime dateTime)
        {
            return dateTime >= dateTime.Midnight() && dateTime < dateTime.Noon();
        }

        /// <summary>
        /// Return the Date of the same day of next week
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime NextWeekSameDay(this DateTime dateTime)
        {
            return dateTime.AddDays(7);
        }

        /// <summary>
        /// Return the Year's week number of specific date
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static int WeekOfYear(this DateTime dateTime)
        {
            int day = (int)dateTime.DayOfWeek;
            return CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                 dateTime.AddDays(4 - (day == 0 ? 7 : day)),
                 CalendarWeekRule.FirstFourDayWeek,
                 DayOfWeek.Monday);
        }

        /// <summary>
        /// Set a Month to a DateTime
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static DateTime SetMonth(this DateTime dateTime, int month)
        {
            if (!IsValidDate(dateTime.Year, month, dateTime.Day))
                throw new ArgumentOutOfRangeException("Either month value is not within the range or Month days became out of range");

            return dateTime.AddMonths(-1 * dateTime.Month).AddMonths(month);
        }

        /// <summary>
        /// Return the Date of the same day of previous week
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime PreviousWeekSameDay(this DateTime dateTime)
        {
            return dateTime.AddDays(-7);
        }

        /// <summary>
        /// First WeekDay in a Year / Month
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateTime GetFirstWeekdayOfMonth(int year, int month, DayOfWeek dayOfWeek)
        {
            return Enumerable.Range(1, 7).
                              Select(day => new DateTime(year, month, day)).
                              First(dateTime => (dateTime.DayOfWeek == dayOfWeek));
        }

        /// <summary>
        /// Returns same DateTime as Previous Year
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime PreviousYearSameDay(this DateTime dateTime)
        {
            return dateTime.AddYears(-1);
        }


        /// <summary>
        /// Returns the age in years and months
        /// </summary>
        /// <param name="referenceDate"></param>
        /// <param name="today"></param>
        /// <returns></returns>
        public static int AgeMonths(DateTime referenceDate, DateTime today)
        {
            if (referenceDate > today)
                throw new ArgumentOutOfRangeException(nameof(referenceDate));

            return (today.Year * 12 + today.Month) - (referenceDate.Year * 12 + referenceDate.Month);
        }

        /// <summary>
        /// Return the Date of the last day of previous week of specific Date
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime GetLastDayOfPreviousWeek(DateTime dateTime)
        {
            return GetFirstDayOfWeek(dateTime).AddDays(-1);
        }

        /// <summary>
        /// Checks if The DateTime is an PM DateTime value
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static bool IsDatePM(this DateTime dateTime)
        {
            return dateTime >= dateTime.Noon() && dateTime < dateTime.AddDays(1).Midnight();
        }

        /// <summary>
        /// Set a Year to a DateTime
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime SetYear(this DateTime dateTime, int year)
        {
            if (!IsValidDate(year, dateTime.Month, dateTime.Day))
                throw new ArgumentOutOfRangeException(nameof(dateTime));

            return new DateTime(year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second)
                ;
        }

        /// <summary>
        /// Return the Date of the same day of previous week
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime PreviousMonthSameDay(this DateTime dateTime)
        {
            return dateTime.AddMonths(-1);
        }

        /// <summary>
        /// Returns the age's exact number of years- calulatedfrom exact months
        /// </summary>
        /// <param name="referenceDate"></param>
        /// <param name="today"></param>
        /// <returns></returns>
        public static decimal AgeExactYears(DateTime referenceDate, DateTime today)
        {
            if (referenceDate > today)
                throw new ArgumentOutOfRangeException(nameof(referenceDate));

            return Math.Round(((decimal)(today.Year * 12 + today.Month) - (referenceDate.Year * 12 + referenceDate.Month)) / 12, 2);
        }

        /// <summary>
        /// Generate a List of BusinessDays with considering 
        /// Local Weekend Days Sequence (entered s list)
        /// and national holidays (entered as list)
        /// </summary>
        /// <param name="fisrtDate"></param>
        /// <param name="lastDate"></param>
        /// <param name="holidays"></param>
        /// <param name="weekends">Sunday = 0 .. Satuday = 6</param>
        /// <returns></returns>
        public static IEnumerable<DateTime> GenerateBusinessDaysList(DateTime fisrtDate, DateTime lastDate, List<DateTime> holidays, List<int> weekends)
        {
            if (fisrtDate > lastDate)
                throw new ArgumentException("Incorrect last date " + lastDate);

            List<DateTime> result = GenerateDateList(fisrtDate, lastDate);

            foreach (int d in weekends)
            {
                for (int i = 0; i < result.Count; i++)
                {
                    if ((int)result[i].DayOfWeek == d)
                    {
                        result.RemoveAt(i);
                    }
                }
            }

            foreach (DateTime d in holidays)
            {
                for (int i = 0; i < result.Count; i++)
                {
                    if (result[i] == d)
                    {
                        result.RemoveAt(i);
                    }
                }
            }

            return result.OrderBy(d => d.Date);
        }

        /// <summary>
        /// Returns the DateTime.MaxValue
        /// </summary>
        /// <returns></returns>
        public static DateTime GetMaxDate()
        {
            return DateTime.MaxValue;
        }

    }
}
