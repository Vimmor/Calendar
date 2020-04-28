using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using unirest_net.http;
using WeatherApi.Models;
namespace WeatherApi.Controllers
{
    /// <summary>
    /// Controller to download data from Weather
    /// Forecast Api and send it to application
    /// in user-friendly form
    /// </summary>
    [ApiController]
    [Route("Weather")]
    public class ForecastController : ControllerBase
    {
        static string defaultCityName = "Wrocław";
        static string accessCode = "dc824588c300d1d3d2a93c90f9368431";
        static string basicUrl = "http://api.openweathermap.org/data/2.5/forecast";

        /// <summary>
        /// Get endpoints to get an information from Api 
        /// for default location set in defaultCityName variable
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        public String GetDefaultWeatherForecast() {
            var response = JsonConvert.DeserializeObject<Forecast>(Unirest.get(basicUrl + "?q=" + defaultCityName + "&APPID=" + accessCode).asJson<string>().Body.ToString());
            return EventsDataBase.ModelsConvertion.ConvertIntoUserForecast.convertFromJsonToString(response);
        }

        /// <summary>
        /// Get endpoints to get an information from Api
        /// for the specified City located in the end of 
        /// url adress 
        /// </summary>
        /// <param name="name">It specifies the City name</param>
        /// <returns>Information in suitable format</returns>
        [HttpGet("{name}")]
        public String GetWeatherForecastByCityName(string name) {
            var response = JsonConvert.DeserializeObject<Forecast>(Unirest.get(basicUrl + "?q=" + name + "&APPID=" + accessCode).asJson<string>().Body.ToString());
            return EventsDataBase.ModelsConvertion.ConvertIntoUserForecast.convertFromJsonToString(response);
        }

        /// <summary>
        /// Get endpoints to get an information from Api
        /// for the City specified by Zip and Country Code
        /// </summary>
        /// <param name="zip_code">Zip Code specified in Api Documentation</param>
        /// <param name="country_code">Same as upper</param>
        /// <returns>Information in suitable format</returns>
        [HttpGet("{zip_code}/{country_code}")]
        public String GetWeatherByZipCode(string zip_code, string country_code) {
            var response = JsonConvert.DeserializeObject<Forecast>(Unirest.get(basicUrl + "?zip" + zip_code + "," + country_code + "&APPID=" + accessCode).asJson<string>().Body.ToString());
            return EventsDataBase.ModelsConvertion.ConvertIntoUserForecast.convertFromJsonToString(response);
        }
    }
}
