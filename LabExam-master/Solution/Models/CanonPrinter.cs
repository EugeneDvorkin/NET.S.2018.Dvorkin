using System;
using System.IO;

namespace Solution
{
    //метод печати перенесен в базовый класс т.к. он одинаков для всех принтеров.
    internal class CanonPrinter : Printer
    {
        public CanonPrinter() : base("Canon", "123x")
        {
        }

        public CanonPrinter(string model) : base("Canon", model)
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