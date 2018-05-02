using System;
using LabExam1;

namespace Solution
{
    class Program
    {
        static PrinterManager manager = new PrinterManager();

        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Select your choice:");
            Console.WriteLine("1:Add new printer");
            Console.WriteLine("2:Print on Canon");
            Console.WriteLine("3:Print on Epson");

            var key = Console.ReadKey();

            if (key.Key == ConsoleKey.D1)
            {
                CreatePrinter();
            }

            if (key.Key == ConsoleKey.D2)
            {
                Print(new CanonPrinter());
            }

            if (key.Key == ConsoleKey.D3)
            {
                Print(new EpsonPrinter());
            }

            while (true)
            {
                // waiting
            }
        }

        private static void Print(EpsonPrinter epsonPrinter)
        {
            manager.Print(epsonPrinter, "Printed on Epson");
        }

        private static void Print(CanonPrinter canonPrinter)
        {
            manager.Print(canonPrinter, "Printed on Canon");
        }

        private static void CreatePrinter()
        {
            Console.WriteLine("Enter printer name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter printer model");
            string model = Console.ReadLine();
            manager.Add(name, model);
        }
    }
}
