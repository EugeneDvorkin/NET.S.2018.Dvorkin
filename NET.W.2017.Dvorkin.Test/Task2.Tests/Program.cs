using Task_2;

namespace Task2.Tests
{
    public class Program
    {
        static void Main(string[] args)
        {
            RandomBytesFileGenerator bytes = new RandomBytesFileGenerator();
            bytes.GenerateFiles(1,15);
            //RandomCharsFileGenerator chars=new RandomCharsFileGenerator();
            //chars.GenerateFiles(1,15);
        }
    }
}