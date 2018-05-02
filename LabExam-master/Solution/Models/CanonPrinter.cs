using System;
using System.IO;

namespace Solution
{
    //метод печати перенесен в базовый класс т.к. он одинаков для всех принтеров.
    public class CanonPrinter : Printer
    {
        public CanonPrinter(PrinterManager manager) : base("Canon", "123x", manager)
        {
        }

        //свойсва сделаны виртуальными, что бы при полиморфном вывзове подставлялись необходимые значения
        public override string Name => "Canon";

        public override string Model => "123x";
    }
}