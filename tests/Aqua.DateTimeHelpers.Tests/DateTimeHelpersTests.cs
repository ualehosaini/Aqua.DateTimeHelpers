using System;
using System.Collections.Generic;
using Xunit;

namespace Aqua.DateTimeHelpers.Tests
{
    public class DateTimeHelpersTests
    {
        [Theory]
        [InlineData(true, 2017, 1, 1)]
        [InlineData(false, 2017, 10, 35)]
        [InlineData(false, 2017, 13, 1)]
        public void IsValidDate_Valid(bool expected, int year, int month, int day)
        {
            Assert.Equal(expected, DateTimeHelpers.IsValidDate(year, month, day));
        }

        [Theory]
        [InlineData(true, 23, 30)]
        [InlineData(true, 23, 30, 10)]
        [InlineData(false, 25, 30, 10)]
        [InlineData(false, 23, 65, 10)]
        [InlineData(false, 23, 30, 65)]
        public void IsValidTime_Valid(bool expected, int hour, int minute, int second = 0)
        {
            Assert.Equal(expected, DateTimeHelpers.IsValidTime(hour, minute, second));
        }

        [Theory]
        [InlineData(true, 2017, 1, 1, 22, 30)]
        [InlineData(true, 2017, 1, 1, 22, 30, 10)]
        [InlineData(false, 2017, 1, 1, 22, 30, 65)]
        [InlineData(false, 2017, 10, 35, 10, 10, 10)]
        [InlineData(false, 2017, 13, 1, 25, 25, 10)]
        public void IsValidDateTime_Valid(bool expected, int year, int month, int day, int hour, int minute, int second = 0)
        {
            Assert.Equal(expected, DateTimeHelpers.IsValidDateTime(year, month, day, hour, minute, second));
        }

        [Theory]
        [InlineData(0, 1970, 1, 1, 0, 0, 0)]
        [InlineData(86399, 1970, 1, 1, 23, 59, 59)]
        [InlineData(1444471810, 2015, 10, 10, 10, 10, 10)]
        [InlineData(1433592775, 2015, 6, 6, 12, 12, 55)]
        public void UnixTimeStampToDateTime_Valid(long input, int y, int m, int d, int h, int mnt, int s)
        {
            DateTime mid = new DateTime(y, m, d, h, mnt, s, DateTimeKind.Utc);
            DateTime expected = new DateTime(mid.ToLocalTime().Ticks);

            Assert.Equal(expected, DateTimeHelpers.UnixTimeStampToDateTime(input));
        }

        [Theory]
        [InlineData(0, 1970, 1, 1, 0, 0, 0)]
        [InlineData(86399, 1970, 1, 1, 23, 59, 59)]
        [InlineData(1444471810, 2015, 10, 10, 10, 10, 10)]
        [InlineData(1433592775, 2015, 6, 6, 12, 12, 55)]
        public void UnixTimeStampToDateTimeUTC_Valid(long input, int y, int m, int d, int h, int mnt, int s)
        {
            DateTime expected = new DateTime(y, m, d, h, mnt, s, DateTimeKind.Utc);

            Assert.Equal(expected, DateTimeHelpers.UnixTimeStampToDateTimeUTC(input));
        }

        [Theory]
        [InlineData(0, 1970, 1, 1, 0, 0, 0)]
        [InlineData(86399, 1970, 1, 1, 23, 59, 59)]
        [InlineData(1444471810, 2015, 10, 10, 10, 10, 10)]
        [InlineData(1433592775, 2015, 6, 6, 12, 12, 55)]
        public void DateTimeToUnixTimeStamp_Valid(long expected, int y, int m, int d, int h, int mnt, int s)
        {
            DateTime value = new DateTime(y, m, d, h, mnt, s, DateTimeKind.Utc);

            Assert.Equal(expected, DateTimeHelpers.DateTimeToUnixTimeStamp(value));
        }

        [Theory]
        [MemberData(nameof(IsBetweenData))]
        public void IsBetween_Valid(bool expected, DateTime input, DateTime rangeBegining, DateTime rangeEnd)
        {
            Assert.Equal(expected, input.IsBetween(rangeBegining, rangeEnd));
        }

        public static IEnumerable<object[]> IsBetweenData =>
            new List<object[]>
                {
                    new object[]{true, new DateTime(2019, 5, 5), new DateTime(2019, 5, 1), new DateTime(2019, 12, 20)},
                    new object[]{false, new DateTime(2019, 5, 5), new DateTime(2019, 5, 6), new DateTime(2019, 12, 20)}
                };

        [Fact]
        public void GetMinDate_Valid()
        {
            Assert.Equal(new DateTime(0001, 1, 1), DateTimeHelpers.GetMinDate());
        }

        [Fact]
        public void IgnoreTimeSpan_Valid()
        {
            Assert.Equal(new DateTime(9999, 12, 31, 23, 59, 59), DateTimeHelpers.IgnoreTimeSpan(DateTime.MaxValue, TimeSpan.FromMilliseconds(1000)));
            Assert.Equal(new DateTime(9999, 12, 31, 23, 59, 0), DateTimeHelpers.IgnoreTimeSpan(DateTime.MaxValue, TimeSpan.FromSeconds(60)));
            Assert.Equal(new DateTime(9999, 12, 31, 23, 0, 0), DateTimeHelpers.IgnoreTimeSpan(DateTime.MaxValue, TimeSpan.FromMinutes(60)));
            Assert.Equal(new DateTime(9999, 12, 31, 0, 0, 0), DateTimeHelpers.IgnoreTimeSpan(DateTime.MaxValue, TimeSpan.FromHours(24)));
        }

        [Fact]
        public void IgnoreMilliseconds_Valid()
        {
            Assert.Equal(new DateTime(9999, 12, 31, 23, 59, 59), DateTime.MaxValue.IgnoreMilliseconds());
        }

        [Fact]
        public void IgnoreSeconds_Valid()
        {
            Assert.Equal(new DateTime(9999, 12, 31, 23, 59, 0), DateTime.MaxValue.IgnoreSeconds());
        }

        [Fact]
        public void IgnoreMinutes_Valid()
        {
            Assert.Equal(new DateTime(9999, 12, 31, 23, 0, 0), DateTime.MaxValue.IgnoreMinutes());
        }

        [Fact]
        public void IgnoreHours_Valid()
        {
            Assert.Equal(new DateTime(9999, 12, 31, 0, 0, 0), DateTime.MaxValue.IgnoreHours());
        }

        [Theory]
        [InlineData(true, 2019, 2, 10)]
        [InlineData(true, 2017, 10, 15)]
        [InlineData(false, 2019, 8, 15)]
        public void IsSunday_Valid(bool expected, int year, int month, int day)
        {
            Assert.Equal(expected, DateTimeHelpers.IsSunday(new DateTime(year, month, day)));
        }

        [Theory]
        [InlineData(false, 2019, 2, 10)]
        [InlineData(false, 2017, 10, 15)]
        [InlineData(true, 2019, 8, 12)]
        public void IsMonday_Valid(bool expected, int year, int month, int day)
        {
            Assert.Equal(expected, DateTimeHelpers.IsMonday(new DateTime(year, month, day)));
        }

        [Theory]
        [InlineData(false, 2019, 2, 10)]
        [InlineData(false, 2017, 10, 15)]
        [InlineData(true, 2019, 8, 13)]
        public void IsTuesday_Valid(bool expected, int year, int month, int day)
        {
            Assert.Equal(expected, DateTimeHelpers.IsTuesday(new DateTime(year, month, day)));
        }

        [Theory]
        [InlineData(false, 2019, 2, 10)]
        [InlineData(false, 2017, 10, 15)]
        [InlineData(true, 2019, 8, 14)]
        public void IsWednesday_Valid(bool expected, int year, int month, int day)
        {
            Assert.Equal(expected, DateTimeHelpers.IsWednesday(new DateTime(year, month, day)));
        }

        [Theory]
        [InlineData(false, 2019, 2, 10)]
        [InlineData(false, 2017, 10, 15)]
        [InlineData(true, 2019, 8, 15)]
        public void IsThursday_Valid(bool expected, int year, int month, int day)
        {
            Assert.Equal(expected, DateTimeHelpers.IsThursday(new DateTime(year, month, day)));
        }

        [Theory]
        [InlineData(false, 2019, 2, 10)]
        [InlineData(false, 2017, 10, 15)]
        [InlineData(true, 2019, 8, 16)]
        public void IsFriday_Valid(bool expected, int year, int month, int day)
        {
            Assert.Equal(expected, DateTimeHelpers.IsFriday(new DateTime(year, month, day)));
        }

        [Theory]
        [InlineData(false, 2019, 2, 10)]
        [InlineData(false, 2017, 10, 15)]
        [InlineData(true, 2019, 8, 17)]
        public void IsSaturday_Valid(bool expected, int year, int month, int day)
        {
            Assert.Equal(expected, DateTimeHelpers.IsSaturday(new DateTime(year, month, day)));
        }

        [Theory]
        [MemberData(nameof(GetLastWeekdayOfMonthData))]
        public void GetLastWeekdayOfMonth_Valid(DateTime expected, int year, int month, DayOfWeek day)
        {
            Assert.Equal(expected, DateTimeHelpers.GetLastWeekdayOfMonth(year, month, day));
        }

        public static IEnumerable<object[]> GetLastWeekdayOfMonthData =>
            new List<object[]>
            {
                    new object[]{new DateTime(2019, 8, 25), 2019, 8, DayOfWeek.Sunday},
                    new object[]{new DateTime(2019, 8, 30), 2019, 8, DayOfWeek.Friday},
            };

        [Theory]
        [MemberData(nameof(GenerateDateListData))]
        public void GenerateDateList_Valid(IEnumerable<DateTime> expected, DateTime fisrtDate, DateTime lastDate)
        {
            Assert.Equal(expected, DateTimeHelpers.GenerateDateList(fisrtDate, lastDate));
        }

        public static IEnumerable<object[]> GenerateDateListData =>
            new List<object[]>
                {
                    // DaysOfWeek Int Sunday = 0, Monday = 1 ... Saturday = 6
                    new object[]{new List<DateTime> { new DateTime (2019, 1, 2) , new DateTime (2019, 1, 3) , new DateTime (2019, 1, 4), new DateTime(2019, 1, 5) } ,
                                 new DateTime (2019, 1, 2), new DateTime (2019, 1, 5),
                    },
                    new object[]{new List<DateTime> { new DateTime(2019, 5, 27), new DateTime (2019, 5, 28) , new DateTime (2019, 5, 29) , new DateTime (2019, 5, 30) , new DateTime (2019, 5, 31), new DateTime(2019, 6, 1), new DateTime(2019, 6, 2) } ,
                                 new DateTime (2019, 5, 27), new DateTime (2019, 6, 2),
                    }
                };

        [Theory(Skip = "culture difference")]
        [MemberData(nameof(GetFirstDayOfWeekData))]
        public void GetFirstDayOfWeek_Valid(DateTime expected, DateTime dateTime)
        {
            Assert.Equal(expected, DateTimeHelpers.GetFirstDayOfWeek(dateTime));
        }

        public static IEnumerable<object[]> GetFirstDayOfWeekData =>
            new List<object[]>
            {
                    new object[]{new DateTime(2019, 4, 29), new DateTime(2019, 5, 4)},
                    new object[]{new DateTime(2019, 4, 29), new DateTime(2019, 5, 2)},
            };

        [Fact]
        public void QuarterOfYear_Valid()
        {
            Assert.Equal(1, (new DateTime(2019, 2, 25)).QuarterOfYear());
            Assert.Equal(2, (new DateTime(2019, 6, 20)).QuarterOfYear());
            Assert.Equal(3, (new DateTime(2019, 7, 25)).QuarterOfYear());
            Assert.Equal(4, (new DateTime(2019, 10, 25)).QuarterOfYear());
        }

        [Fact]
        public void Midnight_Valid()
        {
            Assert.Equal(new DateTime(2019, 12, 25), (new DateTime(2019, 12, 25, 1, 0, 0)).Midnight());
            Assert.Equal(new DateTime(2019, 12, 25), (new DateTime(2019, 12, 25, 1, 10, 0)).Midnight());
            Assert.Equal(new DateTime(2019, 12, 25), (new DateTime(2019, 12, 25, 1, 10, 55)).Midnight());
        }

        [Fact]
        public void AgeYears_Valid()
        {
            Assert.Equal(40, DateTimeHelpers.AgeCalenderYears(new DateTime(1980, 8, 10, 13, 0, 0), new DateTime(2020, 5, 5)));
        }

        [Fact]
        public void SetTime_Valid()
        {
            Assert.Equal(new DateTime(2019, 12, 25), (new DateTime(2019, 12, 25)).SetTime());
            Assert.Equal(new DateTime(2019, 12, 25, 1, 0, 0), (new DateTime(2019, 12, 25)).SetTime(1));
            Assert.Equal(new DateTime(2019, 12, 25, 1, 10, 0), (new DateTime(2019, 12, 25)).SetTime(1, 10));
            Assert.Equal(new DateTime(2019, 12, 25, 1, 10, 55), (new DateTime(2019, 12, 25)).SetTime(1, 10, 55));
        }

        [Theory(Skip = "culture difference")]
        [MemberData(nameof(GetLastDayOfWeekData))]
        public void GetLastDayOfWeek_Valid(DateTime expected, DateTime dateTime)
        {
            Assert.Equal(expected, DateTimeHelpers.GetLastDayOfWeek(dateTime));
        }

        public static IEnumerable<object[]> GetLastDayOfWeekData =>
            new List<object[]>
            {
                    new object[]{new DateTime(2019, 5, 5), new DateTime(2019, 5, 4)},
                    new object[]{new DateTime(2019, 5, 5), new DateTime(2019, 5, 2)},
            };

        [Theory(Skip = "culture difference")]
        [MemberData(nameof(GetFirstDayOfNextWeekData))]
        public void GetFirstDayOfNextWeek_Valid(DateTime expected, DateTime dateTime)
        {
            Assert.Equal(expected, DateTimeHelpers.GetFirstDayOfNextWeek(dateTime));
        }

        public static IEnumerable<object[]> GetFirstDayOfNextWeekData =>
            new List<object[]>
            {
                    new object[]{new DateTime(2019, 8, 5), new DateTime(2019, 8, 4)},
                    new object[]{new DateTime(2019, 8, 5), new DateTime(2019, 8, 2)},
            };

        [Fact]
        public void NextMonthSameDay_Valid()
        {
            Assert.Equal(new DateTime(2019, 8, 17), (new DateTime(2019, 7, 17)).NextMonthSameDay());
            Assert.Equal(new DateTime(2019, 7, 3), (new DateTime(2019, 6, 3)).NextMonthSameDay());
        }

        [Fact]
        public void SetDay_Valid()
        {
            Assert.Equal(new DateTime(2019, 12, 20), (new DateTime(2019, 12, 25)).SetDay(20));
            Assert.Equal(new DateTime(2019, 12, 20, 1, 0, 0), (new DateTime(2019, 12, 25, 1, 0, 0)).SetDay(20));
            Assert.Equal(new DateTime(2019, 12, 20, 1, 10, 0), (new DateTime(2019, 12, 25, 1, 10, 0)).SetDay(20));
            Assert.Equal(new DateTime(2019, 12, 20, 1, 10, 55), (new DateTime(2019, 12, 25, 1, 10, 55)).SetDay(20));
        }

        [Fact]
        public void NextYearSameDay_Valid()
        {
            Assert.Equal(new DateTime(2020, 12, 25), (new DateTime(2019, 12, 25)).NextYearSameDay());
            Assert.Equal(new DateTime(2020, 12, 25, 1, 0, 0), (new DateTime(2019, 12, 25, 1, 0, 0)).NextYearSameDay());
            Assert.Equal(new DateTime(2020, 12, 25, 1, 10, 0), (new DateTime(2019, 12, 25, 1, 10, 0)).NextYearSameDay());
            Assert.Equal(new DateTime(2020, 12, 25, 1, 10, 55), (new DateTime(2019, 12, 25, 1, 10, 55)).NextYearSameDay());
        }

        [Fact]
        public void Noon_Valid()
        {
            Assert.Equal(new DateTime(2019, 12, 25, 12, 0, 0), (new DateTime(2019, 12, 25, 1, 0, 0)).Noon());
            Assert.Equal(new DateTime(2019, 12, 25, 12, 0, 0), (new DateTime(2019, 12, 25, 1, 10, 0)).Noon());
            Assert.Equal(new DateTime(2019, 12, 25, 12, 0, 0), (new DateTime(2019, 12, 25, 1, 10, 55)).Noon());
        }

        [Fact]
        public void IsDayAM_Valid()
        {
            Assert.True(new DateTime(2019, 12, 25, 1, 10, 50).IsDateAM());
            Assert.False(new DateTime(2019, 12, 25, 15, 10, 50).IsDateAM());
            Assert.True(new DateTime(2019, 12, 25, 10, 10, 55).IsDateAM());
        }

        [Fact]
        public void NextWeekSameDay_Valid()
        {
            Assert.Equal(new DateTime(2019, 7, 24), (new DateTime(2019, 7, 17)).NextWeekSameDay());
            Assert.Equal(new DateTime(2019, 6, 10), (new DateTime(2019, 6, 3)).NextWeekSameDay());
        }

        [Fact]
        public void WeekOfYear_Valid()
        {
            Assert.Equal(9, (new DateTime(2019, 2, 25)).WeekOfYear());
            Assert.Equal(3, (new DateTime(2019, 1, 20)).WeekOfYear());
            Assert.Equal(52, (new DateTime(2019, 12, 25)).WeekOfYear());
        }

        [Fact]
        public void SetMonth_Valid()
        {
            Assert.Equal(new DateTime(2019, 5, 25), (new DateTime(2019, 12, 25)).SetMonth(5));
            Assert.Equal(new DateTime(2019, 5, 25, 1, 0, 0), (new DateTime(2019, 12, 25, 1, 0, 0)).SetMonth(5));
            Assert.Equal(new DateTime(2019, 5, 25, 1, 10, 0), (new DateTime(2019, 12, 25, 1, 10, 0)).SetMonth(5));
            Assert.Equal(new DateTime(2019, 5, 25, 1, 10, 55), (new DateTime(2019, 12, 25, 1, 10, 55)).SetMonth(5));
        }

        [Fact]
        public void PreviousWeekSameDay_Valid()
        {
            Assert.Equal(new DateTime(2019, 6, 30), (new DateTime(2019, 7, 7)).PreviousWeekSameDay());
            Assert.Equal(new DateTime(2019, 5, 27), (new DateTime(2019, 6, 3)).PreviousWeekSameDay());
        }

        [Theory]
        [MemberData(nameof(GetFirstWeekdayOfMonthData))]
        public void GetFirstWeekdayOfMonth_Valid(DateTime expected, int year, int month, DayOfWeek day)
        {
            Assert.Equal(expected, DateTimeHelpers.GetFirstWeekdayOfMonth(year, month, day));
        }

        public static IEnumerable<object[]> GetFirstWeekdayOfMonthData =>
            new List<object[]>
            {
                    new object[]{new DateTime(2019, 8, 4), 2019, 8, DayOfWeek.Sunday},
                    new object[]{new DateTime(2019, 8, 2), 2019, 8, DayOfWeek.Friday},
            };

        [Fact]
        public void PreviousYearSameDay_Valid()
        {
            Assert.Equal(new DateTime(2018, 12, 25), (new DateTime(2019, 12, 25)).PreviousYearSameDay());
            Assert.Equal(new DateTime(2018, 12, 25, 1, 0, 0), (new DateTime(2019, 12, 25, 1, 0, 0)).PreviousYearSameDay());
            Assert.Equal(new DateTime(2018, 12, 25, 1, 10, 0), (new DateTime(2019, 12, 25, 1, 10, 0)).PreviousYearSameDay());
            Assert.Equal(new DateTime(2018, 12, 25, 1, 10, 55), (new DateTime(2019, 12, 25, 1, 10, 55)).PreviousYearSameDay());
        }

        [Fact]
        public void AgeMonths_Valid()
        {
            Assert.Equal(477, DateTimeHelpers.AgeMonths(new DateTime(1980, 8, 10, 13, 0, 0), new DateTime(2020, 5, 5)));
        }

        [Theory(Skip = "culture difference")]
        [MemberData(nameof(GetLastDayOfPreviousWeekData))]
        public void GetLastDayOfPreviousWeek_Valid(DateTime expected, DateTime dateTime)
        {
            Assert.Equal(expected, DateTimeHelpers.GetLastDayOfPreviousWeek(dateTime));
        }

        public static IEnumerable<object[]> GetLastDayOfPreviousWeekData =>
            new List<object[]>
            {
                    new object[]{new DateTime(2019, 7, 28), new DateTime(2019, 8, 4)},
                    new object[]{new DateTime(2019, 7, 28), new DateTime(2019, 8, 2)},
            };

        [Fact]
        public void IsDayPM_Valid()
        {
            Assert.False(new DateTime(2019, 12, 25, 1, 10, 50).IsDatePM());
            Assert.True(new DateTime(2019, 12, 25, 15, 10, 50).IsDatePM());
            Assert.False(new DateTime(2019, 12, 25, 10, 10, 55).IsDatePM());
        }

        [Fact]
        public void SetYear_Valid()
        {
            Assert.Equal(new DateTime(2020, 12, 25), (new DateTime(2019, 12, 25)).SetYear(2020));
            Assert.Equal(new DateTime(2020, 12, 25, 1, 0, 0), (new DateTime(2019, 12, 25, 1, 0, 0)).SetYear(2020));
            Assert.Equal(new DateTime(2020, 12, 25, 1, 10, 0), (new DateTime(2019, 12, 25, 1, 10, 0)).SetYear(2020));
            Assert.Equal(new DateTime(2020, 12, 25, 1, 10, 55), (new DateTime(2019, 12, 25, 1, 10, 55)).SetYear(2020));
        }

        [Fact]
        public void PreviousMonthSameDay_Valid()
        {
            Assert.Equal(new DateTime(2019, 6, 7), (new DateTime(2019, 7, 7)).PreviousMonthSameDay());
            Assert.Equal(new DateTime(2019, 5, 3), (new DateTime(2019, 6, 3)).PreviousMonthSameDay());
        }

        [Fact]
        public void AgeExactYears_Valid()
        {
            Assert.Equal((decimal)39.75, DateTimeHelpers.AgeExactYears(new DateTime(1980, 8, 10, 13, 0, 0), new DateTime(2020, 5, 5)));
        }

        [Theory]
        [MemberData(nameof(GenerateBusinessDaysListData))]
        public void GenerateBusinessDaysList_Valid(IEnumerable<DateTime> expected, DateTime fisrtDate, DateTime lastDate, List<DateTime> holidays, List<int> weekends)
        {
            Assert.Equal(expected, DateTimeHelpers.GenerateBusinessDaysList(fisrtDate, lastDate, holidays, weekends));
        }

        public static IEnumerable<object[]> GenerateBusinessDaysListData =>
            new List<object[]>
                {
                    // DaysOfWeek Int Sunday = 0, Monday = 1 ... Saturday = 6
                    new object[]{new List<DateTime> { new DateTime (2019, 1, 2) , new DateTime (2019, 1, 3) , new DateTime (2019, 1, 4)} ,
                                 new DateTime (2019, 1, 2), new DateTime (2019, 1, 5),
                                 new List<DateTime> { new DateTime (2019, 1, 1) , new DateTime (2019, 4, 19) , new DateTime (2019, 4, 22) , new DateTime (2019, 5, 6) , new DateTime(2019, 5, 27), new DateTime(2019, 8, 26), new DateTime(2019, 12, 25), new DateTime(2019, 12, 26) } ,
                                 new List<int> {6,0}
                    },
                    new object[]{new List<DateTime> { new DateTime (2019, 5, 28) , new DateTime (2019, 5, 29) , new DateTime (2019, 5, 30) , new DateTime (2019, 5, 31)} ,
                                 new DateTime (2019, 5, 27), new DateTime (2019, 6, 2),
                                 new List<DateTime> { new DateTime (2019, 1, 1) , new DateTime (2019, 4, 19) , new DateTime (2019, 4, 22) , new DateTime (2019, 5, 6) , new DateTime(2019, 5, 27), new DateTime(2019, 8, 26), new DateTime(2019, 12, 25), new DateTime(2019, 12, 26) } ,
                                 new List<int> {6,0}

                    }
                };

        [Fact]
        public void GetMaxDate_Valid()
        {
            Assert.Equal((new DateTime(9999, 12, 31, 23, 59, 59)).IgnoreMilliseconds(), DateTimeHelpers.GetMaxDate().IgnoreMilliseconds());
        }
    }
}
