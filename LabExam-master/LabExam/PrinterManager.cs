using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Solution;

namespace LabExam1
{
    //класс, обеспечивающий основную работу с принтерами(добавление принтеров с список, взаимодействие с файлами...)
    public class PrinterManager
    {
        private List<Printer> printers;
        private ILog logger;

        public event EventHandler<PrinterEventArg> Printed = delegate { };

        //
        public PrinterManager() : this(new Logger())
        {
        }

        public PrinterManager(ILog logger)
        {
            printers = new List<Printer>() { new EpsonPrinter(), new CanonPrinter() };
            this.logger = logger;
        }

        public List<Printer> Printers
        {
            get => printers;
        }

        //добавление принтера в список
        public void Add(string name, string model)
        {
            if (CheckPrinter(name, model))
            {
                Printers.Add(new Printer(name, model));
            }
            else
            {
                throw new ArgumentException("Such printer have been already added");
            }
        }

        //печать и логгирование 
        public void Print(Printer p1, string log)
        {
            logger.Log(log);
            logger.Log("Print started");
            FileStream f = OpenFile();
            p1.Print(f);
            logger.Log("Print finished");
            f.Dispose();
            OnPrinted(new PrinterEventArg(p1.Name, p1.Model));
        }


        //выделенный метод для открытия файла
        private FileStream OpenFile()
        {
            OpenFileDialog o = new OpenFileDialog();
            o.ShowDialog();
            FileStream f = File.OpenRead(o.FileName);
            return f;
        }


        //метод по проверки принтера с таким именем и моделью
        private bool CheckPrinter(string name, string model)
        {
            foreach (var item in Printers)
            {
                if (item.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase) && item.Model.Equals(model, StringComparison.InvariantCultureIgnoreCase))
                {
                    return false;
                }
            }

            return true;
        }


        //метод, запускающий обработчик собития
        private void OnPrinted(PrinterEventArg e)
        {
            EventHandler<PrinterEventArg> temp = Printed;
            temp?.Invoke(this, e);
        }
    }
}