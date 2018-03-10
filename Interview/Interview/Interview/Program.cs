using System;
using BLL;

namespace Interview
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task 1");
            ArrayFunc arrayFunc = new ArrayFunc();
            int[] A = arrayFunc.GettingArray();
            arrayFunc.PrintArray(A);
            Array.Sort(A);
            arrayFunc.PrintArray(A);
            arrayFunc.ElementForSearch(A);
        }
    }
}
