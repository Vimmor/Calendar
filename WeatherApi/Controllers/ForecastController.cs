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
    [ApiController]
    [Route("Weather")]
    public class ForecastController : ControllerBase
    {
        static string defaultCityName = "Wrocław";
        static string accessCode = "dc824588c300d1d3d2a93c90f9368431";
        static string basicUrl = "http://api.openweathermap.org/data/2.5/forecast";
        [HttpGet("")]
        public String GetDefaultWeatherForecast() {
            var response = JsonConvert.DeserializeObject<Forecast>(Unirest.get(basicUrl + "?q=" + defaultCityName + "&APPID=" + accessCode).asJson<string>().Body.ToString());
            return (response.message + " " + response.cnt + " " + response.cod + " " + response.city.country);
        }

        [HttpGet("{name}")]
        public String GetWeatherForecastByCityName(string name) {
            var response = JsonConvert.DeserializeObject<Forecast>(Unirest.get(basicUrl + "?q=" + name + "&APPID=" + accessCode).asJson<string>().Body.ToString());
            return (response.message + " " + response.cnt + " " + response.cod + " " + response.city.country);
        }

        [HttpGet("{zip_code}/{country_code}")]
        public String GetWeatherByZipCode(string zip_code, string country_code) {
            var response = JsonConvert.DeserializeObject<Forecast>(Unirest.get(basicUrl + "?zip" + zip_code + "," + country_code + "&APPID=" + accessCode).asJson<string>().Body.ToString());
            return (response.message + " " + response.cnt + " " + response.cod + " " + response.city.country);
        }
    }
}
