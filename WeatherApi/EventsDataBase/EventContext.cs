using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApi.Models;

namespace WeatherApi.EventData
{
    public class EventContext
    {
        public class DataContext : DbContext
        {
            public DbSet<EventsDataBase.Models.DayBook> EventDay { get; set; }
            public DbSet<EventsDataBase.Models.Event> Event { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = CalendarAppData");
            }
        }
    }
}
