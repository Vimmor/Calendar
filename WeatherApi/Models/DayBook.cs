using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApi.Models
{
    /// <summary>
    /// DayBook class Model
    /// </summary>
    public class DayBook
    {
        public List<Event> eventList { get; set; } = new List<Event>();
        public DateTime date { get; set; }
    }
}
