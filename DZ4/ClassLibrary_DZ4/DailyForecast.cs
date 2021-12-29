using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary_DZ4
{
    public class DailyForecast 
    {
        public DateTime time { get; set; }
        public Weather Weather = new Weather(); 

        public DailyForecast()
        {
            time = default;
            Weather = default;
        }

        public DailyForecast(DateTime day, Weather weather)
        {
            this.time = day;
            this.Weather = weather;
        }

        public override string ToString()
        {
            return $"{time}: T = {Weather.temperature}°C, w = {Weather.windSpeed}km / h, h = {Weather.humidity} %";
        }

    }
}
