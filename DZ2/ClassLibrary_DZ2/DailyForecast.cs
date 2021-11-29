using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary_DZ2
{
    public class DailyForecast
    {
        public DateTime day { get; set; }
        public Weather weather = new Weather(); 

        public DailyForecast()
        {
            day = default;
            weather = default;
        }

        public DailyForecast(DateTime day, Weather weather)
        {
            this.day = day;
            this.weather = weather;
        }

        public string GetAsString()
        {
            return $"{day}: T = {weather.temperature}°C, w = {weather.windSpeed}km / h, h = {weather.humidity} %\n";
        }

    }
}
