﻿
namespace TestBudgeting.Models
{
    public class Weather
    {

        public double Temp { get; set; }
        public double FeelsLike { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public double High {  get; set; }
        public double Low { get; set; } 
        public string Wind { get; set; }
        public TimeOnly SunDown { get; set; }
        public TimeOnly SunUp { get; set; }
        public string CityName { get; set; }


    }
}
