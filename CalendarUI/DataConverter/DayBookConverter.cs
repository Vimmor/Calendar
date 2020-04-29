using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarUI.DataConverter
{
    /// <summary>
    /// Class to convert data download in 
    /// json format to string ready to 
    /// display in User Inferface Window
    /// </summary>
    class DayBookConverter
    {
        /// <summary>
        /// Method to create String in right format for the client
        /// </summary>
        /// <param name="listOfDayBooks">DayBook object</param>
        /// <returns>String ready to display</returns>
        public static String getDayBooks(Models.DayBook listOfDayBooks) {
            var allEventsTable = new StringBuilder();
            allEventsTable.AppendLine($"--------- {listOfDayBooks.date.ToShortDateString()} -----------");
            allEventsTable.AppendLine("Title\tLocation\tStart Date\tDescription");
            foreach (var dayBook in listOfDayBooks.eventList) {
                    allEventsTable.AppendLine($"{dayBook.title}\t{dayBook.location}\t{dayBook.startDate.ToShortTimeString()}\t{dayBook.description}");
            }
            return allEventsTable.ToString();
        }

        /// <summary>
        /// Method to create String in right format with all Events from DataBase
        /// </summary>
        /// <param name="listOfDayBooks">List of all events</param>
        /// <returns>String ready to display</returns>
        public static String getAllEvents(List<Models.Event> listOfAllEvents) { 
            var allEventsTable = new System.Text.StringBuilder();
            foreach (var dayBookEvent in listOfAllEvents)
            {
                allEventsTable.AppendLine($"{dayBookEvent.title}\t{dayBookEvent.location}\t{dayBookEvent.startDate.ToShortDateString()} {dayBookEvent.startDate.ToShortTimeString()}\t{dayBookEvent.description}");
            }
            return allEventsTable.ToString();
        }
    }
}
