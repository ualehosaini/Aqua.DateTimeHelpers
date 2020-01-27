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

    }
}
