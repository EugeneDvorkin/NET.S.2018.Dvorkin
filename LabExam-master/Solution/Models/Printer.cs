using System;
using System.IO;

namespace Solution
{
    //базовый класс для принтеров. В случае, если при добавлении нового принтера будут вноситься изменения
    //в проект/его архитектуру(будут добавляться новые классы для каждого принтера) класс можно сделать абстрактным
    //
    public abstract class Printer : IEquatable<Printer>
    {
        public abstract string Name { get; protected set; }

        public abstract string Model { get; protected set; }

        public Printer(string name, string model)
        {
            this.Name = name;
            this.Model = model;
        }

        public event EventHandler<PrinterEventArg> StartPrint = delegate { };

        public event EventHandler<PrinterEventArg> EndPrint = delegate { };

        //общий метод печати для всех принтеров
        public void Print(Stream stream)
        {
            OnStartPrint(new PrinterEventArg(this.Name, this.Model));
            PrintingType(stream);
            OnEndPrint(new PrinterEventArg(this.Name, this.Model));
        }

        protected abstract void PrintingType(Stream stream);

        //метод, запускающий обработчик собития
        private void OnStartPrint(PrinterEventArg e)
        {
            EventHandler<PrinterEventArg> temp = StartPrint;
            temp?.Invoke(this, e);
        }

        private void OnEndPrint(PrinterEventArg e)
        {
            EventHandler<PrinterEventArg> temp = EndPrint;
            temp?.Invoke(this, e);
        }

        public bool Equals(Printer other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Name, other.Name) && string.Equals(Model, other.Model);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Printer)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? Name.GetHashCode() : 0) * 397) ^ (Model != null ? Model.GetHashCode() : 0);
            }
        }
    }
}