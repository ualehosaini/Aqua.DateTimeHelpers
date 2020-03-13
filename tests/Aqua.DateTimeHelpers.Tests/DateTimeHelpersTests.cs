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
    }
}
