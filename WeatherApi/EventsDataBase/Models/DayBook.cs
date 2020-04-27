using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApi.EventsDataBase.Models
{
    /// <summary>
    /// Model defining dataBase table DayBook
    /// List<Event>Variable providing one-to-many relation</Event>
    /// </summary>
    public class DayBook
    {
        public int Id { get; set; }
        public List<Event> EventList { get; set; } = new List<Event>();
        public DateTime Date { get; set; }
    }
}
