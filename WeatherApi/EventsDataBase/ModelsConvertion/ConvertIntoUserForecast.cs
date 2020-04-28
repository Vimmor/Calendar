using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApi.EventsDataBase.ModelsConvertion
{
    public class ConvertIntoUserForecast
    {
        /// <summary>
        /// Method to convert current waether forecast data 
        /// to the string that will be displayed in window
        /// </summary>
        /// <param name="forecast">Forecast model with download data from Api</param>
        /// <returns>StringBuild object convert to big String</returns>
        public static String convertFromJsonToString(WeatherApi.Models.Forecast forecast) {
            var stringBuilder = new System.Text.StringBuilder();
            stringBuilder.AppendLine("------------ Weather Forecast --------------");
            stringBuilder.AppendLine($"------------ {DateTime.Now.ToString()} --------------");
            stringBuilder.AppendLine($"------------ {forecast.city.name} --------------");
            stringBuilder.AppendLine($"------------ City Location --------------");
            stringBuilder.AppendLine($"Longitude: {String.Format("{0:N2}", forecast.city.coord.lon)} |  Latitude: {String.Format("{0:N2}", forecast.city.coord.lon)}");
            stringBuilder.AppendLine("------------ Main Information --------------");
            stringBuilder.AppendLine("------- Temperature -------");
            stringBuilder.AppendLine($"Temperature: {String.Format("{0:N2}", forecast.list[0].main.Temp-273.15)}C");
            if (forecast.list[0].main.FeelsLike != 0) {
                stringBuilder.AppendLine($"Perceived temperature: {String.Format("{0:N2}",forecast.list[0].main.FeelsLike-273.15)}C");
            }
            stringBuilder.AppendLine($"Humidity: {forecast.list[0].main.Humidity}%");
            stringBuilder.AppendLine($"Atmospheric pressure: {forecast.list[0].main.Pressure}C");
            stringBuilder.AppendLine($"Atmospheric pressure on the sea level: {forecast.list[0].main.SeaLevel} hPa");
            stringBuilder.AppendLine($"Atmospheric pressure on the ground level: {forecast.list[0].main.GrndLevel} hPa");
            stringBuilder.AppendLine("------- Wind -------");
            stringBuilder.AppendLine($"Wind Speed: {forecast.list[0].wind.speed} meter/sec");
            stringBuilder.AppendLine($"Wind Direction: {forecast.list[0].wind.deg} Degrees");
            stringBuilder.AppendLine("------- Cloud-------");
            stringBuilder.AppendLine($"Cloudiness: {forecast.list[0].clouds.all}%");
            stringBuilder.AppendLine("------- Rain -------");
            stringBuilder.AppendLine($"Rain Volume for the last 3 hour: {forecast.list[0].rain._invalid_name_3h} mm");
            return stringBuilder.ToString();
        }
    }
}
