using Newtonsoft.Json.Linq;

namespace TestBudgeting.Models.Weather
{
    public class WeatherMethods
    {
        public static Home GetWeather()
        {
            Home home = new Home();
            Weather1 weather1 = new Weather1();
            Weather2 weather2 = new Weather2();
            HttpClient client = new HttpClient();

            string endPoint1 = $"https://api.openweathermap.org/data/2.5/weather?q=hoboken&appid=a309632b9e81d1e5db78633cd6f73ec5&units=imperial";
            string weatherInfo1 = client.GetStringAsync(endPoint1).Result;
            JObject weather1Object = JObject.Parse(weatherInfo1);
            weather1.Temp = double.Parse(weather1Object["main"]["temp"].ToString());
            weather1.Wind = weather1Object["wind"]["speed"].ToString();
            weather1.Low = double.Parse(weather1Object["main"]["temp_min"].ToString());
            weather1.High = double.Parse(weather1Object["main"]["temp_max"].ToString());
            weather1.FeelsLike = double.Parse(weather1Object["main"]["feels_like"].ToString());
            weather1.CityName = weather1Object["name"].ToString();
            weather1.Description = weather1Object["weather"]["description"].ToString();
            weather1.SunDown = TimeOnly.Parse(weather1Object["sys"]["sunset"].ToString());
            weather1.SunUp = TimeOnly.Parse(weather1Object["sys"]["sunrise"].ToString());
            home.Weather1Var = weather1 ;

            string endPoint2 = $"https://api.openweathermap.org/data/2.5/weather?q=mckinney&appid=a309632b9e81d1e5db78633cd6f73ec5&units=imperial";
            string weatherInfo2 = client.GetStringAsync(endPoint2).Result;
            JObject weather2Object = JObject.Parse(weatherInfo2);
            weather2.Temp = double.Parse(weather2Object["main"]["temp"].ToString());
            weather2.Wind = weather2Object["wind"]["speed"].ToString();
            weather2.Low = double.Parse(weather2Object["main"]["temp_min"].ToString());
            weather2.High = double.Parse(weather2Object["main"]["temp_max"].ToString());
            weather2    .FeelsLike = double.Parse(weather2Object["main"]["feels_like"].ToString());
            weather2.CityName = weather2Object["name"].ToString();
            weather2.Description = weather2Object["weather"]["description"].ToString();
            weather2.SunDown = TimeOnly.Parse(weather2Object["sys"]["sunset"].ToString());
            weather2.SunUp = TimeOnly.Parse(weather2Object["sys"]["sunrise"].ToString());
            home.Weather2Var = weather2;
            
            return home;
            // grabbing value at that indiex - type JOBject. Conver to string, then parse to double
        }
    }
}
//endpoint https://api.openweathermap.org/data/2.5/weather?q={city name}&appid={API key}&units=imperial