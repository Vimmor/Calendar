using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace CalendarUI.Communication
{
    /// <summary>
    /// Class to communication with api
    /// sending requests and getting responses
    /// </summary>
    class CommunicateWithApi
    {
        /// <summary>
        /// Method to get list of all daybooks from 
        /// data base tables by using request get
        /// to the local hosted server
        /// </summary>
        /// <param name="date">specified datetime</param>
        /// <returns>specified daybook</returns>
        public static Models.DayBook getDataFromApi(String date)
        {
            WebClient client = new WebClient();
            var response = JsonConvert.DeserializeObject<List<Models.Event>>(client.DownloadString($"http://localhost:1998/Events/{date}"));
            Models.DayBook dayBook = new Models.DayBook() { date = DateTime.Parse(date) };

            foreach (var dayBookEvent in response) {
                dayBook.eventList.Add(dayBookEvent);
            }
            return dayBook;
        }

        /// <summary>
        /// Method to get all events from database
        /// </summary>
        /// <returns>list of all daybooks</returns>
        public static List<Models.Event> getAllEvents()
        {
            WebClient client = new WebClient();
            var response = JsonConvert.DeserializeObject<List<Models.Event>>(client.DownloadString("http://localhost:1998/Events/allDayBooks"));
            return response;
        }

        /// <summary>
        /// Method makes a put request to server
        /// to add a new record to database
        /// </summary>
        public static void addNewRecord(Models.Event newEvent, String date)
        {
            var client = new WebClient();
            var data = JsonConvert.SerializeObject(newEvent);
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.UploadString($"http://localhost:1998/Events/{date}", "PUT", data);
        }

        /// <summary>
        /// Method to get string contained information about
        /// current weather in location specified by variable
        /// </summary>
        /// <param name="date">Specify location that we want to get weather forecast
        /// specified by cityname or zip and country code</param>
        /// <returns>String ready to display in TextBox</returns>
        public static String getWeatherForecast(String city) {
            WebClient client = new WebClient();
            var response = client.DownloadString("http://localhost:1998/Weather/" + city);
            return response;
        }

        /// <summary>
        /// Method to get string contained information about 
        /// current weather in location specified by variable
        /// </summary>
        /// <param name="id">Specify location that we want to get weather forecast
        /// specified by City ID</param>
        /// <returns>String ready to display in TextBox</returns>
        public static String getWeatherByCityId(String id) {
            WebClient client = new WebClient();
            var response = client.DownloadString("http://localhost:1998/Weather/city/" + id);
            return response;
        }
    }
}
