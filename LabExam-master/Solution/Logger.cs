using System.IO;

namespace Solution
{
    //реализация конкретного логгера в рамках данного проекта
    public class Logger : ILog
    {
        public void Log(string s)
        {
            using (StreamWriter f = File.AppendText("log.txt"))
            {
                f.Write(s);
            }
        }
    }
}