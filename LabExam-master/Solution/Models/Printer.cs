using System;
using System.IO;

namespace Solution
{
    //базовый класс для принтеров. В случае, если при добавлении нового принтера будут вноситься изменения
    //в проект/его архитектуру(будут добавляться новые классы для каждого принтера) класс можно сделать абстрактным
    //
    public class Printer : IPrint
    {
        public virtual string Name { get; }

        public virtual string Model { get; }

        public Printer(string name, string model, PrinterManager manager)
        {
            this.Name = name;
            this.Model = model;
            manager.Printed += PrintLog;
        }

        //общий метод печати для всех принтеров
        public void Print(FileStream fs)
        {
            {
                for (int i = 0; i < fs.Length; i++)
                {
                    // simulate printing
                    Console.WriteLine(fs.ReadByte());
                }
            }
        }

        public void PrintLog(object sender, PrinterEventArg e)
        {
            Console.WriteLine($"Was printed {e.Name} {e.Model}");
        }
    }
}