using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApi.EventsDataBase.Models
{
    /// <summary>
    /// Model defining database table Event
    /// </summary>
    public class Event
    {
        public int Id { get; set; }
        public int DayBookId { get; set; }
        public String Title { get; set; }
        public String Location { get; set; }
        public DateTime StartDate { get; set; }
        public String Description { get; set; }
    }
}
