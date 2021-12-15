using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ClassLibrary_DZ3
{
    public class FilePrinter : IPrinter
    {
        public string fileName { get; set; }

        public FilePrinter(string fileName)
        {
            this.fileName = fileName;
        }
        public void Print(string text)
        {
            string fileName = @"C:\Users\mirna\source\repos\DZ3\ClassLibrary_DZ3\WeatherFile.txt";
            using (System.IO.StreamWriter writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine(text);
            }
            
        }
    }
}
