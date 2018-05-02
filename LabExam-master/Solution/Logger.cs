using System.IO;

namespace Solution
{
    //реализация конкретного логгера в рамках данного проекта
    public class Logger : ILog
    {
        public void Log(string s)
        {
            File.AppendText("log.txt").Write(s);
        }
    }
}