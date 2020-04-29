using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static WeatherApi.EventData.EventContext;

namespace WeatherApi.Controllers
{
    /// <summary>
    /// Controller that enable connection
    /// between application and database
    /// </summary>
    [Route("Events")]
    [ApiController]
    public class DataBaseController : ControllerBase
    {
        DataContext context = new DataContext();

        /// <summary>
        /// Get Endpoints that return DataBase Daybook specified by parametres 
        /// in Json Format
        /// </summary>
        /// <param name="dayOfTheEvents">Date of events day that we want to get</param>
        /// <returns>DayBook in Json Format</returns>
        [HttpGet("{eventDay}")]
        public String GetDayBookForSpecifiedDay(String eventDay) {
            context.Database.EnsureCreated();
        var dataBaseDayBook = context.DayBook.Where(e => e.Date == DateTime.Parse(eventDay)).ToList();
        if (dataBaseDayBook.Count == 0) {
            return JsonConvert.SerializeObject(new Models.DayBook());
        }
            List<Models.Event> rightData = new List<Models.Event>();
            var DbEvents = context.Event.Where(e => e.DayBookId == dataBaseDayBook[0].Id).ToList();
            foreach (var eventFromList in DbEvents) {
                rightData.Add(EventsDataBase.ModelsConvertion.ConvertIntoClass.convertEvent(eventFromList));
            }
            return JsonConvert.SerializeObject(rightData);
        }

        /// <summary>
        /// Get endpoints to get all day books
        /// </summary>
        /// <returns>List of daybooks in Json Format</returns>
        [HttpGet("allDayBooks")]
        public String GetAllDayBooks() {
            context.Database.EnsureCreated();
            var eventsFromDb= context.Event.ToList();
            var listOfAllEvents = new List<Models.Event>();
            foreach (var newEvent in eventsFromDb) {
                listOfAllEvents.Add(new Models.Event() { location = newEvent.Location, title = newEvent.Title, startDate = newEvent.StartDate, description = newEvent.Description });
            }
            return JsonConvert.SerializeObject(listOfAllEvents);
        }

        /// <summary>
        /// Put endpoints to put Event into Data Base
        /// specified by Event from class Model and 
        /// correct eventDay
        /// </summary>
        /// <param name="newEvent">Specified new Event that we want to add to Data Base</param>
        /// <param name="eventDay">String respresenting day of the events</param>
        [HttpPut("{Day}")]
        public void AddToDataBase([FromBody] Models.Event newEvent, String Day) {
            context.Database.EnsureCreated();
            var dataBaseDayBook = context.DayBook.Where(d => d.Date == DateTime.Parse(Day)).ToList();
            if (dataBaseDayBook.Count == 0) {
                var DataBaseEvent = EventsDataBase.ModelsConvertion.ConvertIntoDataBase.convertEvent(newEvent);
                var newDayBook= new EventsDataBase.Models.DayBook() { Date = DateTime.Parse(Day) };
                newDayBook.EventList.Add(DataBaseEvent);
                context.DayBook.Add(newDayBook);
            }
            else {
                var newDataBaseEvent = EventsDataBase.ModelsConvertion.ConvertIntoDataBase.convertEvent(newEvent);
                if (!dataBaseDayBook[0].EventList.Contains(newDataBaseEvent)) {
                    dataBaseDayBook[0].EventList.Add(newDataBaseEvent);
                    context.DayBook.Update(dataBaseDayBook[0]);
                }
            }  
            context.SaveChanges();
        }
    }
}