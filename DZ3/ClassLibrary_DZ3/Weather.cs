using System;

namespace ClassLibrary_DZ3
{
    public class Weather
    {
        public double temperature, humidity, windSpeed;

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

        public override string ToString()
        {
            return $"T = {temperature}°C, w = {windSpeed}km / h, h = {humidity} %";
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
            double windchill = 13.12 + 0.6215 * this.temperature - 11.37 * Math.Pow(this.windSpeed, 0.16) + 
                               0.3965 * this.temperature * Math.Pow(this.windSpeed, 0.16);

            if (this.temperature > 10 && this.windSpeed < 4.8)
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
            for (int i = 0; i < weathers.Length; i++)
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
    }
}
