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
            var comparedEvent = new WeatherApi.Models.Event() { location = "testLocation", title = "testTitle" };
            Assert.AreEqual(comparedEvent.title, testEvent.title);
            Assert.AreEqual(comparedEvent.location, testEvent.location);
        }
    }
}
