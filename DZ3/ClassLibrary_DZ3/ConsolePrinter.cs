using System;

namespace ClassLibrary_DZ3
{
    public class ConsolePrinter : IPrinter
    {
        ConsoleColor color { get; set; }

        public ConsolePrinter(ConsoleColor color)
        {
            this.color = color;
        }

        public void Print(string text)
        {
            Console.ForegroundColor = color;

            Console.WriteLine(text);

            Console.ResetColor();
        }
    }
}
