using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary_DZ3
{
    class BiasedGenerator : IRandomGenerator
    {
        Random generator = new Random();

        public BiasedGenerator(Random generator)
        {
            this.generator = generator;
        }

        public double GenerateNumber(double min, double max)
        {
            int[] probabilityArray = { 1, 1, 1, 2 };
            double x;
            int pos = generator.Next(0, 4);
            if (probabilityArray[pos] == 1)
            {
                x = generator.NextDouble() * (max / 2 - min) + min;
            }
            else x = generator.NextDouble() * (max - max / 2) + max / 2;

            return x;
        }
    }
}
