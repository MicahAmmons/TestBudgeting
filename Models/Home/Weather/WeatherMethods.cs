using Newtonsoft.Json.Linq;
using TestBudgeting.Models.Home.Weather;

namespace TestBudgeting.Models.Home
{
    public class WeatherMethods
    {
        public static HomeVar GetWeather()
        {
            HomeVar home = new HomeVar();
            Weather1 weather1 = new Weather1();
            Weather2 weather2 = new Weather2();
            HttpClient client = new HttpClient();

            string endPoint1 = $"https://api.openweathermap.org/data/2.5/weather?q=hoboken&appid=a309632b9e81d1e5db78633cd6f73ec5&units=imperial";
            string weatherInfo1 = client.GetStringAsync(endPoint1).Result;
            JObject weather1Object = JObject.Parse(weatherInfo1);
            weather1.Temp = Math.Round(double.Parse(weather1Object["main"]["temp"].ToString()));
            weather1.Wind = weather1Object["wind"]["speed"].ToString();
            weather1.Low = Math.Round(double.Parse(weather1Object["main"]["temp_min"].ToString()));
            weather1.High = Math.Round(double.Parse(weather1Object["main"]["temp_max"].ToString()));
            weather1.FeelsLike = Math.Round(double.Parse(weather1Object["main"]["feels_like"].ToString()));
            weather1.CityName = weather1Object["name"].ToString();
            //weather1.Description = weather1Object[""].ToString();
            //
            long epochTimeW1 = long.Parse(weather1Object["sys"]["sunset"].ToString());
            DateTimeOffset dateTimeOffsetW1 = DateTimeOffset.FromUnixTimeSeconds(epochTimeW1);
            int hourW1 = dateTimeOffsetW1.Hour - 5;
            int minuteW1 = dateTimeOffsetW1.Minute;
            TimeOnly sunDownW1 = new TimeOnly(hourW1, minuteW1, 0);
            weather1.SunDown = sunDownW1;
            //
            long epochTimeW11 = long.Parse(weather1Object["sys"]["sunrise"].ToString());
            DateTimeOffset dateTimeOffsetW11 = DateTimeOffset.FromUnixTimeSeconds(epochTimeW11);
            int hourW11 = dateTimeOffsetW11.Hour - 5;
            int minuteW11 = dateTimeOffsetW11.Minute;
            TimeOnly sunDownW11 = new TimeOnly(hourW11, minuteW11, 0);
            weather1.SunUp = sunDownW11;
            //
            home.Weather1Var = weather1;

            string endPoint2 = $"https://api.openweathermap.org/data/2.5/weather?q=mckinney&appid=a309632b9e81d1e5db78633cd6f73ec5&units=imperial";
            string weatherInfo2 = client.GetStringAsync(endPoint2).Result;
            JObject weather2Object = JObject.Parse(weatherInfo2);
            weather2.Temp = Math.Round(double.Parse(weather2Object["main"]["temp"].ToString()));
            weather2.Wind = weather2Object["wind"]["speed"].ToString();
            weather2.Low = Math.Round(double.Parse(weather2Object["main"]["temp_min"].ToString()));
            weather2.High = Math.Round(double.Parse(weather2Object["main"]["temp_max"].ToString()));
            weather2.FeelsLike = Math.Round(double.Parse(weather2Object["main"]["feels_like"].ToString()));
            weather2.CityName = weather2Object["name"].ToString();
            //weather2.Description = weather2Object["weather"]["description"].ToString();
            //
            long epochTime = long.Parse(weather2Object["sys"]["sunset"].ToString());
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(epochTime);
            int hour = dateTimeOffset.Hour - 5;
            int minute = dateTimeOffset.Minute;
            TimeOnly sunDownW2 = new TimeOnly(hour, minute, 0);
            weather2.SunDown = sunDownW2;
            //
            long epochTime2 = long.Parse(weather2Object["sys"]["sunrise"].ToString());
            DateTimeOffset dateTimeOffset2 = DateTimeOffset.FromUnixTimeSeconds(epochTime2);
            int hour2 = dateTimeOffset2.Hour - 5;
            int minute2 = dateTimeOffset2.Minute;
            TimeOnly sunDownW22 = new TimeOnly(hour2, minute2, 0);
            weather2.SunUp = sunDownW22;
            //
            home.Weather2Var = weather2;

            return home;
            // grabbing value at that indiex - type JOBject. Conver to string, then parse to double
        }


    }
}
//endpoint https://api.openweathermap.org/data/2.5/weather?q={city name}&appid={API key}&units=imperial