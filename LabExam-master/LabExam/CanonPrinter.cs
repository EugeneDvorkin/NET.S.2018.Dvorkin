using System;
using System.IO;

namespace LabExam1
{
    //метод печати перенесен в базовый класс т.к. он одинаков для всех принтеров.
    public class CanonPrinter : Printer
    {
        public CanonPrinter() : base("Canon", "123x")
        {
        }

        //свойсва сделаны виртуальными, что бы при полиморфном вывзове подставлялись необходимые значения
        public override string Name => "Canon";

        public override string Model => "123x";
    }
}