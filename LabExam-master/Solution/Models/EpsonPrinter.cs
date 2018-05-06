using System;
using System.IO;

namespace Solution
{
    //метод печати перенесен в базовый класс т.к. он одинаков для всех принтеров.
    internal class EpsonPrinter : Printer
    {
        public EpsonPrinter() : base("Epson", "231")
        {
        }

        public EpsonPrinter(string model) : base("Epson", model)
        {
        }

        //свойсва сделаны виртуальными, что бы при полиморфном вывзове подставлялись необходимые значения
        public override string Name { get; protected set; }

        public override string Model { get; protected set; }

        protected override void PrintingType(Stream stream)
        {
            for (int i = 0; i < stream.Length; i++)
            {
                // simulate printing
                Console.WriteLine(stream.ReadByte());
            }
        }
    }
}