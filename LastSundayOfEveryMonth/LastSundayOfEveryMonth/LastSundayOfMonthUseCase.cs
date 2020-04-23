using NUnit.Framework;
using System;

namespace LastSundayOfEveryMonth
{
    [TestFixture]
    public class LastSundayOfMonthUseCase
    {
        [TestCase(1, 2013, "2013/01/27")]
        [TestCase(2, 2013, "2013/02/24")]
        [TestCase(3, 2013, "2013/03/31")]
        [TestCase(4, 2013, "2013/04/28")]
        [TestCase(5, 2013, "2013/05/26")]
        [TestCase(6, 2013, "2013/06/30")]
        [TestCase(7, 2013, "2013/07/28")]
        [TestCase(8, 2013, "2013/08/25")]
        [TestCase(9, 2013, "2013/09/29")]
        [TestCase(10, 2013, "2013/10/27")]
        [TestCase(11, 2013, "2013/11/24")]
        [TestCase(12, 2013, "2013/12/29")]
        public void CalculateDate_GivenMonthAndYear_ShouldReturnLastSunday(int month, int year, string expected)
        {
            //Arrange
            int wantedDay = (int)DayOfWeek.Sunday;

            //Act
            string actual = Get_Last_Sunday_Of_Month(year, month, wantedDay);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(02, 2020, "2020/02/23")]
        [TestCase(02, 2032, "2032/02/29")]
        public void CalculateDate_GivenLeapYear_ShouldReturnLastSunday(int month, int year, string expected)
        {
            //Arrange
            int wantedDay = (int)DayOfWeek.Sunday;

            //Act
            string actual = Get_Last_Sunday_Of_Month(year, month, wantedDay);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        private string Get_Last_Sunday_Of_Month(int year, int month, int wantedDay)
        {
            var lastDayOfMonth = new DateTime(year, month, 1).AddMonths(1).AddDays(-1);
            int lastDay = (int)lastDayOfMonth.DayOfWeek;
            var sameWeek = lastDay >= wantedDay;

            return lastDayOfMonth.AddDays(sameWeek ? wantedDay - lastDay : wantedDay - lastDay - 7).ToShortDateString();
        }
    }
}
