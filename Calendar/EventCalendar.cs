using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Calendar
{
    public class EventCalendar
    {
        public List<Event> eventList { get;  set; }

        public EventCalendar() {
            eventList = new List<Event>();
        }
        public string getAllEvents() {
            var report = new System.Text.StringBuilder();
            report.AppendLine("ID\tDay\tBeginning\t\tlocation\ttitle");

            foreach (var item in eventList) {
                report.AppendLine($"{item.ID}\t{item.dayOfTheWeek}\t{item.eventDuration}\t{item.location}\t{item.title}");
            }
            return report.ToString();
        }
        public int getAvailableId() {
            var flag = false;
            int newId;
            Random rnd = new Random();

            do {
                if(eventList.Count != 0) {
                    newId = rnd.Next();
                    foreach (var item in eventList) {
                        if (item.ID != newId) {
                            flag = true;
                        }
                    }
                }
                else {
                    newId = rnd.Next(1, 512);
                    flag = true;
                }
            } while (flag == false);

            return newId;
        }
        public void addNewEvent(Event newEvent) {
            //Console.WriteLine("Provide event's data in format: day, title, location, date");
            //string[] elements = Console.ReadLine().Split(", ");
            //Event newEvent = new Event(getAvailableId(),elements[0], elements[1], elements[2], elements[3]);
            this.eventList.Add(newEvent);
            this.sortEvents();
        }
        public void removeEvent(int id) {
            readFromTheFile();
            for(int i = 0; i < eventList.Count; i++) {
                if (eventList[i].ID == id)
                    eventList.RemoveAt(i);
            }
            writeToAFile();
        }
        public bool eventListEmpty() { 
            if(this.eventList.Count == 0) {
                return true;
            }
            else {
                return false;
            }
        }
        public bool whetherEventInTheCalendar(Event newEvent) {
            foreach (var item in eventList) {
                if (item == newEvent) {
                    return true;
                }
            }
            return false;
        }
        public void removeDataBase() {
            var dir = Path.Combine(Directory.GetCurrentDirectory(), "calendar.bin");
            File.Delete(dir);
            eventList.Clear();
        }
        public void writeToAFile() {
            var dir = Path.Combine(Directory.GetCurrentDirectory(), "calendar.bin");
            using (Stream stream = File.Open(dir, FileMode.OpenOrCreate)) {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                bformatter.Serialize(stream, eventList);
            }
        }
        public void readFromTheFile() {
            var dir = Path.Combine(Directory.GetCurrentDirectory(), "calendar.bin");
            if (File.Exists(dir)) {
                using (Stream stream = File.Open(dir, FileMode.Open)) {
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    eventList = (List<Event>)bformatter.Deserialize(stream);
                }
            }
        }
        public void sortEvents() {
            List<DateTime> dateTimeList = new List<DateTime>();
             foreach(var dates in eventList) {
                dateTimeList.Add(dates.eventDuration);
            }
            dateTimeList.Sort();

            List<Event> newListOfEvents = new List<Event>();
            for(int i = 0; i < dateTimeList.Count; i++) { 
                foreach(var Event in eventList) { 
                    if(Event.eventDuration == dateTimeList[i]) {
                        newListOfEvents.Add(Event);
                    }
                }
            }
            eventList = newListOfEvents;
        }
    }
}
