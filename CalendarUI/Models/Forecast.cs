using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarUI.Models
{
    /// <summary>
    /// Forecast class Model to display in User Interface
    /// It will be download by http requests
    /// </summary>
    class Forecast
    {
        public String cod { get; set; } = "";
        public int message { get; set; } = 0;
        public int cnt { get; set; } = 0;
        public City city { get; set; } = new City();
        public List<List> list { get; set; } = new List<List>();
    }

    public class City
    {
        public int id { get; set; } = 0;
        public string name { get; set; } = "";
        public Coord coord { get; set; } = new Coord();
        public string country { get; set; } = "";
        public int population { get; set; } = 0;
        public int timezone { get; set; } = 0;
        public int sunrise { get; set; } = 0;
        public int sunset { get; set; } = 0;
    }

    public class Coord
    {
        public double lat { get; set; } = 0;
        public double lon { get; set; } = 0;
    }

    public class List
    {
        public int dt { get; set; } = 0;
        public Main main { get; set; } = new Main();
        public List<Weather> weather { get; set; } = new List<Weather>();
        public Clouds clouds { get; set; } = new Clouds();
        public Wind wind { get; set; } = new Wind();
        public Sys sys { get; set; } = new Sys();
        public string dt_txt { get; set; } = "";
        public Rain rain { get; set; } = new Rain();
    }

    public class Rain
    {
        public double _invalid_name_3h { get; set; } = 0;
    }

    public class Sys
    {
        public string pod { get; set; } = "";
    }

    public class Clouds
    {
        public int all { get; set; } = 0;
    }

    public class Wind
    {
        public double speed { get; set; } = 0;
        public int deg { get; set; } = 0;
    }

    public class Main
    {
        public double Temp { get; set; } = 0;
        public double FeelsLike { get; set; } = 0;
        public double TempMin { get; set; } = 0;
        public double TempMax { get; set; } = 0;
        public long Pressure { get; set; } = 0;
        public long SeaLevel { get; set; } = 0;
        public long GrndLevel { get; set; } = 0;
        public long Humidity { get; set; } = 0;
        public double TempKf { get; set; } = 0;
    }

    public class Weather
    {
        public int id { get; set; } = 0;
        public string main { get; set; } = "";
        public string description { get; set; } = "";
        public string icon { get; set; } = "";
    }
}
