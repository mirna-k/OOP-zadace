using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary_DZ4
{
    interface IRandomGenerator
    {
        public double GenerateNumber(double min, double max);
    }
}
