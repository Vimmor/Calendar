using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarTests
{
    class DayBookTest
    {
        [Test]
        public void DayBook_WhenCreatingObjectWithInitializationParams_ParamsSetCorrectly() {
            var testDayBook = new WeatherApi.Models.DayBook();
            testDayBook.date = DateTime.Parse("25/09/2021");
            var comparedDayBook = new WeatherApi.Models.DayBook() { date = DateTime.Parse("25/09/2021"), eventList = null};
            Assert.AreEqual(testDayBook.date, comparedDayBook.date);
            Assert.AreNotEqual(testDayBook.eventList, comparedDayBook.eventList);
        }
    }
}
