using System;
using System.IO;

namespace Solution
{
    //метод печати перенесен в базовый класс т.к. он одинаков для всех принтеров.
    public class EpsonPrinter : Printer
    {
        public EpsonPrinter() : base("Epson", "231")
        {
        }

        //свойсва сделаны виртуальными, что бы при полиморфном вывзове подставлялись необходимые значения
        public override string Name => "Epson";

        public override string Model => "231";
    }
}