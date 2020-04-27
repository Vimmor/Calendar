using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApi.EventsDataBase.Models
{
    public class Event
    {
        public int id { get; set; }
        public int dayBookId { get; set; }
        public string title { get; set; }
        public string location { get; set; }
        public DateTime eventDate { get; set; }
        
    }
}
