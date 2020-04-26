using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar.Tests
{
    class EventCalendarTests
    {
        [Test]
        public void EventCalendar_sortTwoEvents_Sorted() {
            var calendar = new EventCalendar();
            var newEvent = new Event(1, "monday", "training", "gym", "10/10/2010");
            calendar.addNewEvent(newEvent);
            newEvent = new Event(1, "tuesday", "birtday", "friend's house", "06/08/2009");
            calendar.addNewEvent(newEvent);

            calendar.sortEvents();

            Assert.AreEqual(newEvent, calendar.eventList[0]);
        }

        [Test]
        public void EventCalendar_removeEventFromCalendar_Removed() {
            var calendar = new EventCalendar();
            var newEvent = new Event(1, "monday", "training", "gym", "10/10/2010");
            calendar.addNewEvent(newEvent);

            calendar.removeEvent(1);

            Assert.IsFalse(calendar.whetherEventInTheCalendar(newEvent));
        }
    }

}
