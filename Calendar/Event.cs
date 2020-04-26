using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar
{
    [Serializable]
    public class Event {

        public int ID { get; private set; }
        public string dayOfTheWeek { get; private set; }
        public string title { get; private set; }
        public string location { get; private set; }
        public DateTime eventDuration { get;  private set; }

        public Event(int id, string day, string title, string location, string date) {
            this.ID = id;
            this.dayOfTheWeek = day;
            this.title = title;
            this.location = location;
            this.eventDuration = new DateTime();
            setEventDuration(date);
        }

        public void setEventDuration(string date) {
            eventDuration = DateTime.Parse(date.ToString());    
        }
    }
}
