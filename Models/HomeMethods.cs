using Newtonsoft.Json.Linq;
using TestBudgeting.Models;

namespace APIsAndJSON
{
    public class OpenWeatherMapAPI
    {
        public static Weather GetTemp()
        {

            HttpClient client = new HttpClient();
            string endPoint = $"https://api.openweathermap.org/data/2.5/weather?q=London&appid=a309632b9e81d1e5db78633cd6f73ec5&units=imperial";       
            string weatherInfo = client.GetStringAsync(endPoint).Result;
            JObject weatherObject = JObject.Parse(weatherInfo);
            Weather weather = new Weather();
            weather.Temp = double.Parse(weatherObject["main"]["temp"].ToString());



            return weather;
            // grabbing value at that indiex - type JOBject. Conver to string, then parse to double
        }
    }
}
//endpoint https://api.openweathermap.org/data/2.5/weather?q={city name}&appid={API key}&units=imperial