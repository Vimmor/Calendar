using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApi.Models;

namespace WeatherApi.EventData
{
    /// <summary>
    /// Class to set DbSets and build up Local DataBase 
    /// that is extension to Microsoft SQL Server
    /// </summary>
    public class EventContext
    {
        public class DataContext : DbContext
        {
            public DbSet<EventsDataBase.Models.DayBook> DayBook { get; set; }
            public DbSet<EventsDataBase.Models.Event> Event { get; set; }

            /// <summary>
            /// Creating an database specified by DataSource in catalog from Initial Catalog
            /// </summary>
            /// <param name="optionsBuilder">variable specifies config for building DB</param>
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = CalendarAppData");
            }
        }
    }
}
