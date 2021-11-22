using System;

namespace ClassLibrary_DZ1
{
    public class Weather
    {
        double temperature, humidity, windSpeed;

        public Weather()
        {
            this.temperature = 0;
            this.humidity = 0;
            this.windSpeed = 0;
        }
        
        public Weather(double temperature, double humidity, double windSpeed)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.windSpeed = windSpeed;
        }

        public double GetTemperature() { return this.temperature; }
        public double GetHumidity() { return this.humidity; }
        public double GetWindSpeed() { return this.windSpeed; }
        public void SetTemperature(double temperature) { this.temperature = temperature; }
        public void SetWindSpeed(double windSpeed) { this.windSpeed = windSpeed; }
        public void SetHumidity(double humidity) { this.humidity = humidity; }

        public double CalculateFeelsLikeTemperature()
        {
            return -8.78469475556 + 1.61139411 * this.temperature + 2.33854883889 * this.humidity - 0.14611605 * this.temperature *
                   this.humidity - 0.012308094 * Math.Pow(this.temperature, 2) - 0.0164248277778 * Math.Pow(this.humidity, 2) +
                   0.002211732 * Math.Pow(this.temperature, 2) * this.humidity + 0.00072546 * this.temperature * 
                   Math.Pow(this.humidity, 2) - 0.000003582 * Math.Pow(this.temperature, 2) * Math.Pow(this.humidity, 2);
        }
    
        public double CalculateWindChill()
        {
            double windchill = 13.12 + 0.6215 * this.temperature - 11.37 * Math.Pow(this.windSpeed, 0.16) + 0.3965 *
                               this.temperature * Math.Pow(this.windSpeed, 0.16);

            if (windchill > this.temperature) 
            {
                windchill = 0; 
            }

            return windchill;
        }

       public static Weather FindWeatherWithLargestWindchill(Weather[] weathers)
       {
            double windchill;
            int num = 0;
            double max = 0;
            for(int i = 0; i < weathers.Length; i++)
            {
                windchill = weathers[i].CalculateWindChill();
                if (windchill > max)
                {
                    num = i;
                    max = windchill;
                }
            }
            return weathers[num];
       }

        public static void RunDemoForHW1()
        {
            Weather current = new Weather();
            current.SetTemperature(24.12);
            current.SetWindSpeed(3.5);
            current.SetHumidity(0.56);
            Console.WriteLine("Weather info:\n"
                + "\ttemperature: " + current.GetTemperature() + "\n"
                + "\thumidity: " + current.GetHumidity() + "\n"
                + "\twind speed: " + current.GetWindSpeed() + "\n");
            Console.WriteLine("Feels like: " + current.CalculateFeelsLikeTemperature());

            Console.WriteLine("Finding weather info with largest windchill!");
            const int Count = 5;
            double[] temperatures = new double[Count] { 8.33, -1.45, 5.00, 12.37, 7.67 };
            double[] humidities = new double[Count] { 0.3790, 0.4555, 0.743, 0.3750, 0.6612 };
            double[] windSpeeds = new double[Count] { 4.81, 1.5, 5.7, 4.9, 1.2 };

            Weather[] weathers = new Weather[Count];
            for (int i = 0; i < weathers.Length; i++)
            {
                weathers[i] = new Weather(temperatures[i], humidities[i], windSpeeds[i]);
                Console.WriteLine("Windchill for weathers[" + i + "] is: " + weathers[i].CalculateWindChill());
            }
            Weather largestWindchill = FindWeatherWithLargestWindchill(weathers);
            Console.WriteLine(
                "Weather info:" + largestWindchill.GetTemperature() + ", " +
                largestWindchill.GetHumidity() + ", " + largestWindchill.GetWindSpeed()
            );
        }
    }
}
