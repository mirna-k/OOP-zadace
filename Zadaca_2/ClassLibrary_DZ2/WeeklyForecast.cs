using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary_DZ2
{
    class WeeklyForecast
    {
        readonly DailyForecast[] theDay = new DailyForecast[7];

        public WeeklyForecast(DailyForecast[] weeklyWeather)
        {
            this.theDay = weeklyWeather;
        }

        public double GetMaxTemperature()
        {
            double max = 0;
            for(int i = 0; i < theDay.Length; i++)
            {
                if (theDay[i].weather.temperature > max) max = theDay[i].weather.temperature;
            }
            return max;
        }

        public string GetAsString()
        {
            return $"{theDay[0].day}: T = {theDay[0].weather.temperature}°C, w = {theDay[0].weather.windSpeed}km / h, h = {theDay[0].weather.humidity} %\n" +
                $"{theDay[1].day}: T = {theDay[1].weather.temperature}°C, w = {theDay[1].weather.windSpeed}km / h, h = {theDay[1].weather.humidity} %\n" +
                $"{theDay[2].day}: T = {theDay[2].weather.temperature}°C, w = {theDay[2].weather.windSpeed}km / h, h = {theDay[2].weather.humidity} %\n" +
                $"{theDay[3].day}: T = {theDay[3].weather.temperature} °C, w =  {theDay[3].weather.windSpeed} km / h, h =  {theDay[3].weather.humidity} %\n" +
                $"{theDay[4].day}: T = {theDay[4].weather.temperature}°C, w = {theDay[4].weather.windSpeed}km / h, h = {theDay[4].weather.humidity} %\n" +
                $"{theDay[5].day}: T = {theDay[5].weather.temperature} °C, w =  {theDay[5].weather.windSpeed} km / h, h =  {theDay[5].weather.humidity} %\n" +
                $"{theDay[6].day}: T = {theDay[6].weather.temperature}°C, w = {theDay[6].weather.windSpeed}km / h, h = {theDay[6].weather.humidity} %\n"; 
        }
    }
}
