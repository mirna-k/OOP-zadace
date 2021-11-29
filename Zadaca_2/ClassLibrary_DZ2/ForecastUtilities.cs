using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ClassLibrary_DZ2
{
    public class ForecastUtilities
    {

        DailyForecast today = new DailyForecast();

        public ForecastUtilities(DailyForecast today)
        {
            this.today = today;
        }

        public double CalculateWindChill()
        {
            double windchill = 13.12 + 0.6215 * today.weather.temperature - 11.37 * Math.Pow(today.weather.windSpeed, 0.16) + 
                               0.3965 * today.weather.temperature * Math.Pow(today.weather.windSpeed, 0.16);

            if (today.weather.temperature > 10 && today.weather.windSpeed < 4.8)
            {
                windchill = 0;
            }

            return windchill;
        }

        public static DailyForecast Parse(string v)
        {
            char tocka = '.'; //u file.txt zamijenje su tocke i zarezi jer u protivnom se broj citao kao int a ne double
            string[] odvojeno = v.Split(tocka);
            DateTime dan = DateTime.Parse(odvojeno[0]);
            Weather vrijeme = new Weather();
            vrijeme.temperature = double.Parse(odvojeno[1]);
            vrijeme.humidity = double.Parse(odvojeno[2]);
            vrijeme.windSpeed = double.Parse(odvojeno[3]);

            DailyForecast today = new DailyForecast(dan, vrijeme);

            return today;
        }

        public static void RunDemoForHW2()
        {
            DateTime monday = new DateTime(2021, 11, 8);
            Weather mondayWeather = new Weather(6.17, 56.13, 4.9);
            DailyForecast mondayForecast = new DailyForecast(monday, mondayWeather); 
            Console.WriteLine(monday.ToString());
            Console.WriteLine(mondayWeather.GetAsString());
            Console.WriteLine(mondayForecast.GetAsString());

            // Assume a valid input file (correct format).
            // Assume that the number of rows in the text file is always 7. 
            string fileName = @"C:\Users\mirna\source\repos\Zadaca_2\ClassLibrary_DZ2\file.txt";
            if (File.Exists(fileName) == false)
            {
                Console.WriteLine("The required file does not exist. Please create it, or change the path.");
                return;
            }

            string[] dailyWeatherInputs = File.ReadAllLines(fileName);
            DailyForecast[] dailyForecasts = new DailyForecast[dailyWeatherInputs.Length];
            for (int i = 0; i < dailyForecasts.Length; i++)
            {
                dailyForecasts[i] = ForecastUtilities.Parse(dailyWeatherInputs[i]); 
            }
            WeeklyForecast weeklyForecast = new WeeklyForecast(dailyForecasts);
            Console.WriteLine(weeklyForecast.GetAsString());
            Console.WriteLine("Maximal weekly temperature:");
            Console.WriteLine(weeklyForecast.GetMaxTemperature());
            Console.WriteLine(dailyForecasts[0].GetAsString()); //izmjenjeno: Console.WriteLine(weeklyForecast[0].GetAsString());
        }
    }
}
