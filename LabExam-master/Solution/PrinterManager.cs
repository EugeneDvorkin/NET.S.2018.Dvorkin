using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Solution
{
    //класс, обеспечивающий основную работу с принтерами(добавление принтеров с список, взаимодействие с файлами...)
    public sealed class PrinterManager
    {
        private List<Printer> printers;
        private ILog logger;

        private static readonly Lazy<PrinterManager> instance =
            new Lazy<PrinterManager>(() => new PrinterManager(), LazyThreadSafetyMode.PublicationOnly);
        //
        private PrinterManager()
        {
        }

        public ILog Logger
        {
            get => logger;
            set
            {
                if (ReferenceEquals(value, null))
                {
                    throw new ArgumentNullException($"{nameof(value)} is null");
                }

                if (value.GetType() != typeof(ILog))
                {
                    throw new ArgumentException($"{nameof(value)} is wrong type");
                }

                logger = value;
            }
        }

        public static PrinterManager Instance
        {
            get => instance.Value;
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
                Printer temp = new Printer(name, model);
                temp.StartPrint += StartPrint;
                temp.EndPrint += EndPrint;
                Printers.Add(temp);
            }
            else
            {
                throw new ArgumentException("Such printer have been already added");
            }
        }

        //печать и логгирование 
        public void Print(Printer p1, string log)
        {
            if (printers.Contains(p1))
            {
                logger.Log(log);
                logger.Log("Print started");
                using (FileStream f = OpenFile())
                {
                    p1.Print(f);
                    logger.Log("Print finished");
                }
            }
            else
            {
                throw new ArgumentException($"{nameof(p1)} is wrong printer");
            }

        }

        //выделенный метод для открытия файла
        private FileStream OpenFile()
        {
            using (OpenFileDialog o = new OpenFileDialog())
            {
                o.ShowDialog();
                FileStream f = File.OpenRead(o.FileName);
                return f;
            }
        }

        private void StartPrint(object sender, PrinterEventArg e)
        {
            Logger.Log($"{nameof(e.Model)} {nameof(e.Name)} started print {DateTime.Now}");
        }

        private void EndPrint(object sender, PrinterEventArg e)
        {
            Logger.Log($"{nameof(e.Model)} {nameof(e.Name)} ended print {DateTime.Now}");
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
    }
}