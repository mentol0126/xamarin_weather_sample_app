using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    public class Core
    {
        public static async Task<Weather> GetWeather(string zipCode)
        {
            const string key = "";
            var queryString = 
                "http://api.openweathermap.org/data/2.5/weather?zip=" 
                + zipCode + ",jp&appid=" + key + "&units=imperial";

            dynamic results = await DetaService.GetDataFromService(queryString);
            if (results == null || results["weather"] == null) return null;

            var weather = new Weather() { };
            weather.Title = (string)results["name"];
            weather.Temperature = (string)results["main"]["temp"] + "F";
            weather.Wind = (string)results["wind"]["speed"] + "mph";
            weather.Humidity = (string)results["main"]["humidity"] + "%";
            weather.Visibility = (string)results["weather"][0]["main"];

            var time = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            var sunrise = time.AddSeconds((double)results["sys"]["sunrise"]);
            var sunset = time.AddSeconds((double)results["sys"]["sunset"]);
            weather.Sunrise = sunrise.ToString() + "UTC";
            weather.Sunset = sunset.ToString() + "UTC";

            return weather;
        }
    }
}
