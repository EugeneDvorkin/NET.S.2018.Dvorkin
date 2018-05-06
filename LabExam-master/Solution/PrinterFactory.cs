using System;

namespace Solution
{
    public static class PrinterFactory
    {
        public static Printer CreatPrinter(string name, string model)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException($"{nameof(name)} is null");
            }

            if (string.IsNullOrWhiteSpace(model))
            {
                throw new ArgumentNullException($"{nameof(model)} is null");
            }

            switch (name)
            {
                case ("Epson"):
                {
                    return new EpsonPrinter(model);
                }
                case ("Canon"):
                {
                    return new CanonPrinter(model);
                }
                default:
                {
                    throw new ArgumentException($"{nameof(name)} is wrong");
                }
            }
        }
    }
}