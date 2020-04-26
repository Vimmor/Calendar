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
            public DbSet<Event> Event { get; set; }
            public DbSet<DayBook> EventDay { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = CalendarAppData");
            }
        }
    }
}
