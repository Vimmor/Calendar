using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApi.EventsDataBase.ModelsConvertion
{
    /// <summary>
    /// Class to convert data from Data Base to Class Model
    /// </summary>
    public class ConvertIntoClass
    {
        /// <summary>
        /// Method to convert DayBook from DataBase to class Model
        /// </summary>
        /// <param name="dataBaseDayBook">DayBook from DataBase</param>
        /// <returns>Converted DayBook to class Model</returns>
        public static WeatherApi.Models.DayBook convertDayBook(Models.DayBook dataBaseDayBook) {
            WeatherApi.Models.DayBook dayBook = new WeatherApi.Models.DayBook() { date = dataBaseDayBook.Date };
            List<WeatherApi.Models.Event> events = new List<WeatherApi.Models.Event>();
            foreach (var element in dataBaseDayBook.EventList) {
                events.Add(new WeatherApi.Models.Event() {  location = element.Location, title = element.Title});
            }
            dayBook.eventList = events;
            return dayBook;
        }

        /// <summary>
        /// Method to convert Event from DataBase to class Model
        /// </summary>
        /// <param name="dataBaseEvent">Event from DataBase</param>
        /// <returns>Converted Event to class Model</returns>
        public static WeatherApi.Models.Event convertEvent(Models.Event dataBaseEvent) {
            return new WeatherApi.Models.Event() { title = dataBaseEvent.Title, location = dataBaseEvent.Location };
        }
    }
}
