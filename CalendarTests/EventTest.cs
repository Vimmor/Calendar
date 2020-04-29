using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarTests
{
    class EventTest
    {
        [Test]
        public void Event_WhenCreatingObjectWithInitializationParams_ParamsSetCorrectly() {
            WeatherApi.Models.Event testEvent = new WeatherApi.Models.Event();
            testEvent.location = "testLocation";
            testEvent.title = "testTitle";
            testEvent.startDate = DateTime.Parse("25/09/2021");
            testEvent.description = "testDescription";
            var comparativeTestEvent = new WeatherApi.Models.Event() { location = "testLocation", title = "testTitle", startDate = DateTime.Parse("25/09/2021"), description = "testDescription" };
            Assert.AreEqual(comparativeTestEvent.title, testEvent.title);
            Assert.AreEqual(comparativeTestEvent.location, testEvent.location);
            Assert.AreEqual(comparativeTestEvent.startDate, testEvent.startDate);
            Assert.AreEqual(comparativeTestEvent.description, testEvent.description);
        }

        [Test]
        public void Event_ConvertFromClassToDataBase_ConvertedEvent() {
            var testEvent = new WeatherApi.Models.Event() { location = "testLocation", title = "testTitle", startDate = DateTime.Parse("25/09/2021"), description = "testDescription" };
            var comparativeTestEvent = WeatherApi.EventsDataBase.ModelsConvertion.ConvertIntoDataBase.convertEvent(testEvent);
            Assert.AreEqual(testEvent.location, comparativeTestEvent.Location);
            Assert.AreEqual(testEvent.title, comparativeTestEvent.Title);
            Assert.AreEqual(comparativeTestEvent.StartDate, testEvent.startDate);
            Assert.AreEqual(comparativeTestEvent.Description, testEvent.description);
        }

        [Test]
        public void Event_ConvertFromDataBaseToClass_ConvertedEvent() {
            var testEvent = new WeatherApi.EventsDataBase.Models.Event() { Title = "testTitle", Location = "testLocation", StartDate = DateTime.Parse("25/09/2021"), Description = "testDescription", DayBookId = 1, Id = 1 };
            var comparativeTestEvent = WeatherApi.EventsDataBase.ModelsConvertion.ConvertIntoClass.convertEvent(testEvent);
            Assert.AreEqual(testEvent.Location, comparativeTestEvent.location);
            Assert.AreEqual(testEvent.Title, comparativeTestEvent.title);
        }
    }
}
