using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Calendar
{
    class EventCalendar
    {
        private List<Event> eventList = new List<Event>();

        public string getAllEvents() {
            var report = new System.Text.StringBuilder();
            report.AppendLine("ID\tDay\tBeginning\t\tlocation\ttitle");

            foreach (var item in eventList) {
                report.AppendLine($"{item.ID}\t{item.dayOfTheWeek}\t{item.eventDuration}\t{item.location}\t{item.title}");
            }
            return report.ToString();
        }

        public int getAvailableId() {
            bool flag = false;
            int newId;
            Random rnd = new Random();

            do {
                if(eventList.Count != 0) {
                    newId = rnd.Next(1, 512);
                    Console.WriteLine(newId);
                    foreach (var item in eventList) {
                        if (item.ID == newId) {
                            flag = true;
                        }
                    }
                }
                else {
                    newId = 1;
                    flag = true;
                }
            } while (flag == false);

            return newId;
        }
        public void addNewEvent() {
            Console.WriteLine("Provide event's data in format: day, title, location, date");
            string[] elements = Console.ReadLine().Split(", ");
            Event newEvent = new Event(getAvailableId(),elements[0], elements[1], elements[2], elements[3]);
            eventList.Add(newEvent);
        }

        public void removeEvent(int id) {
            for(int i = 0; i < eventList.Count; i++) {
                if (eventList[i].ID == id)
                    eventList.RemoveAt(i);
            }
        }

        public void writeToAFile() {
            string dir = Path.Combine(Directory.GetCurrentDirectory(), "calendar.bin");
            using (Stream stream = File.Open(dir, FileMode.OpenOrCreate)) {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                bformatter.Serialize(stream, eventList);
            }
        }
        
        public void readFromTheFile() {
            string dir = Path.Combine(Directory.GetCurrentDirectory(), "calendar.bin");
            using (Stream stream = File.Open(dir, FileMode.Open)) {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                eventList = (List<Event>)bformatter.Deserialize(stream);
            }
        }
    }
}
