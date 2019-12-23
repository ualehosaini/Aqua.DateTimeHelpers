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
    }
}
