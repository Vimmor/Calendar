using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarUI.Models
{
    /// <summary>
    /// DayBook class model
    /// </summary>
    class DayBook
    {
        public List<Event> eventList { get; set; } = new List<Event>();
        public DateTime date { get; set; }
    }
}
