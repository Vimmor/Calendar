using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApi.Models
{
    /// <summary>
    /// Event class Model
    /// </summary>
    public class Event
    {
        public String title { get; set; }
        public String location { get; set; }
        public DateTime startDate { get; set; }
        public String description{ get; set; }
    }
}
