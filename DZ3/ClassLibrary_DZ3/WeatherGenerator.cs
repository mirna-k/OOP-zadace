using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary_DZ3
{
    class WeatherGenerator
    {
        IRandomGenerator randomGenerator;
        public double minTemperature { get; set; }
        public double maxTemperature { get; set; }
        public double minHumidity { get; set; }
        public double maxHumidity { get; set; }
        public double minWindSpeed { get; set; }
        public double maxWindSpeed { get; set; }

        public WeatherGenerator()
        {
            this.minTemperature = 0;
            this.maxTemperature = 0;
            this.minHumidity = 0;
            this.maxHumidity = 0;
            this.minWindSpeed = 0;
            this.maxWindSpeed = 0;
        }
        
        public WeatherGenerator(double minTemperature,double maxTemperature,double minHumidity,double maxHumidity,
                                double minWindSpeed,double maxWindSpeed, IRandomGenerator randomGenerator)
        {
            this.minTemperature = minTemperature;
            this.maxTemperature = maxTemperature;
            this.minHumidity = minHumidity;
            this.maxHumidity = maxHumidity;
            this.minWindSpeed = minWindSpeed;
            this.maxWindSpeed = maxWindSpeed;
            this.randomGenerator = randomGenerator;
        }

        public void SetGenerator(IRandomGenerator generator)
        {
            this.randomGenerator = generator;
        }

        public Weather Generate()
        {
            Weather vrijeme = new Weather();
            vrijeme.temperature = randomGenerator.GenerateNumber(minTemperature, maxTemperature);
            vrijeme.humidity = randomGenerator.GenerateNumber(minHumidity, maxHumidity);
            vrijeme.windSpeed = randomGenerator.GenerateNumber(minWindSpeed, maxWindSpeed);

            return vrijeme;
        }
    }
}
