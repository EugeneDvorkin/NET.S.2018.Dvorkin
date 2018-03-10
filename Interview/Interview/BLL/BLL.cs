using System;

namespace BLL
{
    public class ArrayFunc
    {
        ///<summary>
        ///Инкапсулированный метод для разбора и анализа введенной пользователем строки. 
        ///</summary>
        ///<param name="c">Введенная в консоль строка пользователем</param>
        ///<returns>Обработанная информация(либо длина необходимого массива, либо команда на закрытие приложения)</returns>
        private int Parsing(string c)
        {
            bool result = false;
            string temp = c;
            result = int.TryParse(temp, out int length);
            if (result != true)
            {
                do
                {
                    Console.WriteLine("The element must be an integer");
                    temp = Console.ReadLine();
                    if (temp == "q")
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        result = int.TryParse(temp, out length);
                    }

                } while (result != true);
            }
            return length;
        }
        /// <summary>
        /// Обслуживающий метод. 
        /// Необходим для получения необходимой длины массива и непосредственнно самого массива. 
        /// Оперирует методами и передает полученную информацию в методы.
        /// </summary>
        /// <returns>Созданный массив заданной длины вызывающему коду</returns>
        public int[] GettingArray()
        {
            Console.WriteLine("Enter the length of an array or 'q' for close");
            string temp = Console.ReadLine();
            int length = Parsing(temp);
            int[] A = CreateArray(length);
            return A;
        }
        /// <summary>
        /// Инкапсулированный метод для непосредственного создания массива заданной пользователем длины случайными числами 
        /// </summary>
        /// <param name="length">Длина необходимого массива</param>
        /// <returns>Созданный массив</returns>
        private int[] CreateArray(int length)
        {
            int[] A = new int[length];
            Random rnd = new Random();
            for (int i = 0; i < length; i++)
            {
                A[i] = rnd.Next(1, 100);
                if (i != Array.IndexOf(A, A[i]))
                {
                    do
                    {
                        A[i] = rnd.Next(1, 1000);
                    } while (i != Array.IndexOf(A, A[i]));
                }
            }
            return A;
        }
        /// <summary>
        /// Выводит полученный массив в консоль
        /// </summary>
        /// <param name="A">Массив, выводимый в консоль</param>
        public void PrintArray(int[] A)
        {
            Console.WriteLine("The array before task:");
            for (int i = 0; i < A.Length; i++)
            {
                Console.WriteLine("A[{0}]={1}", i, A[i]);
            }
        }
        /// <summary>
        /// Обслуживающий метод.
        /// Позволяет выйти из приложения. 
        /// Передает введенную информацию пользователем в метод анализа введенной строки. При необходимости вызывает метод по бинарному поиску введенного элемента 
        /// </summary>
        /// <param name="A">Массив, в котором происходит поиск элемента</param>
        public void ElementForSearch(int[] A)
        {
            Console.WriteLine("Enter an element for search or 'q' for close");
            string c = Console.ReadLine();
            while (c != "q")
            {
                if (c == "q")
                {
                    Environment.Exit(0);
                }
                else
                {
                    int key = Parsing(c);
                    BinarySearch(key, A);
                }
                Console.WriteLine("Repeat or enter 'q'");
                c = Console.ReadLine();
            }
        }
        /// <summary>
        /// Инкапсулированный метод поиска заданного элемента в заданном массиве.
        /// </summary>
        /// <param name="key">Искомый элемент</param>
        /// <param name="A">Заданный массив</param>
        private void BinarySearch(int key, int[] A)
        {
            if ((A.Length == 0) || (key < A[0]) || (key > A[A.Length - 1]))
            {
                Console.WriteLine("The array doesn't contain this element");
            }
            else
            {
                int first = 0;
                int last = A.Length;
                while (first < last)
                {
                    int mid = first + (last - first) / 2;
                    if (key <= A[mid])
                    {
                        last = mid;
                    }
                    else
                    {
                        first = mid + 1;
                    }
                }
                if (A[last] == key)
                {
                    Console.WriteLine("Position of the element is {0}", last);
                }
                else
                {
                    Console.WriteLine("The array doesn't contain this element");
                }
            }
        }
    }
}
