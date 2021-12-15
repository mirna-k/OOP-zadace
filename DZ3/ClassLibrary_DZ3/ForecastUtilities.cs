using System;
using System.Globalization;

namespace ClassLibrary_DZ3
{
    public static class ForecastUtilities
    {
        public static void PrintWeathers(IPrinter[] print, Weather[] vrijeme)
        {
            for(int i = 0; i < vrijeme.Length; i++)
            {
                foreach(IPrinter p in print)
                {
                    p.Print(vrijeme[i].ToString());
                }
            }
        }
    }
}