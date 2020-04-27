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
    [Route("Events")]
    [ApiController]
    public class DataBaseController : ControllerBase
    {
        private static DataContext context = new DataContext();
        /// <summary>
        /// Get Endpoints that return DataBase Daybook specified by parametres 
        /// in Json Format
        /// </summary>
        /// <param name="dayOfTheEvents">Date of events day that we want to get</param>
        /// <returns>DayBook in Json Format</returns>
        [HttpGet("{eventDay}")]
        public String GetDayBookForSpecifiedDay(String eventDay) {
            context.Database.EnsureCreated();
        var dataBaseDayBook = context.EventDay.Where(e => e.date == DateTime.Parse(eventDay)).ToList();
        if (dataBaseDayBook.Count == 0) {
                return JsonConvert.SerializeObject(new EventsDataBase.Models.DayBook());
        }
            return JsonConvert.SerializeObject(dataBaseDayBook);
        }

        [HttpPut("{eventDay}")]
        public void AddToDataBase([FromBody] Models.DayBook daybook, String eventDay) {
            context.Database.EnsureCreated();   
            var dataBaseDayBook = context.EventDay.Where(d => d.date == DateTime.Parse(eventDay)).ToList();
            if (dataBaseDayBook.Count == 0) {
                context.EventDay.Add(EventsDataBase.ModelsConvertion.ConvertIntoDataBase.convertDayBook(daybook));
            }
            else { 

                
            }    
            context.SaveChanges();
        }
    }
}