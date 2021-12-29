using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary_DZ4
{
    class UniformGenerator : IRandomGenerator
    {
        Random generator = new Random();

        public UniformGenerator(Random generator)
        {
            this.generator = generator;
        }

        public double GenerateNumber(double min, double max)
        {
            return generator.NextDouble() * (max - min) + min;
        }
    }
}
