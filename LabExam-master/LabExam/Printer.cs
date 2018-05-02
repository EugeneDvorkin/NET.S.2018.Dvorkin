using System;
using System.IO;

namespace LabExam1
{
    //базовый класс для принтеров. В случае, если при добавлении нового принтера будут вноситься изменения
    //в проект/его архитектуру(будут добавляться новые классы для каждого принтера) класс можно сделать абстрактным
    //
    public class Printer
    {
        public virtual string Name { get; }

        public virtual string Model { get; }

        public Printer(string name, string model)
        {
            this.Name = name;
            this.Model = model;
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

        
    }
}