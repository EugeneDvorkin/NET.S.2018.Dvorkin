using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossword.Tests
{
    class Program
    {
        
        static void Main(string[] args)
        {
            // string[] dictionary= new string[] { "перелом", "открытый", "подвывих", "закрытый", "вывих", "ушиб", "шина" };
            string[] words = new string[] { "подвывих", "вывих", "открытый", "закрытый", "ушиб", "шина", "перелом" };
            Cross cros=new Cross();
            char[,] crosWord = cros.GenerateCrossword(words);

            PrintArray(crosWord);
        }

        static void PrintArray(char[,] mas)
        {
            //Console.WriteLine();
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    Console.Write("{0} ", mas[i, j]);
                }
                    
                Console.WriteLine();
            }
        }


    }
}
