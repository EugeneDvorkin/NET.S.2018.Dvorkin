using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    /// <summary>
    /// Sorting class. This class contains two type of sorting integer array: Merge Sorting and Quick Sorting
    /// </summary>
    public static class Sorting
    {
        /// <summary>
        /// Quick sorting of the array which consists of integer elements 
        /// </summary>
        /// <param name="arrayForSort">Array which needs to be sorted</param>
        /// <param name="start">Start index of sorting</param>
        /// <param name="end">End index of sorting</param>        
        public static void QuickSort(int[] arrayForSort, int start, int end)
        {
            if (arrayForSort == null)
            {
                throw new ArgumentNullException($"{nameof(arrayForSort)} is null");
            }

            if (start > end)
            {
                throw new ArgumentException($"{nameof(start)} is more then{nameof(end)}");
            }

            int startingElem = start;
            int endingElem = end;
            int middle = arrayForSort[(start + end) / 2];
            int swapper;
            do
            {
                while (arrayForSort[startingElem] < middle)
                {
                    startingElem++;
                }

                while (arrayForSort[endingElem] > middle)
                {
                    endingElem--;
                }

                if (startingElem <= endingElem)
                {
                    swapper = arrayForSort[startingElem];
                    arrayForSort[startingElem] = arrayForSort[endingElem];
                    arrayForSort[endingElem] = swapper;
                    startingElem++;
                    endingElem--;
                }
            }
            while (startingElem < endingElem);

            if (start < endingElem)
            {
                QuickSort(arrayForSort, start, endingElem);
            }

            if (start < end)
            {
                QuickSort(arrayForSort, startingElem, end);
            }
        }

        /// <summary>
        /// Merge sorting of the array which consists of integer elements 
        /// </summary>
        /// <param name="arrayforsort">Array which needs to be sorted</param>
        /// <param name="start">Start index of sorting</param>
        /// <param name="end">End index of sorting</param>
        /// <returns>New sorted array which consists of integer elements</returns>
        public static void MergeSort(int[] arrayforsort, int start, int end)
        {
            if (arrayforsort == null)
            {
                throw new ArgumentNullException($"{nameof(arrayforsort)} is null");
            }

            if (start>end)
            {
                throw new ArgumentException($"{nameof(start)} is more then{nameof(end)}");
            }

            int middle = (start + end) / 2;
            if (end > start)
            {
                MergeSort(arrayforsort, start, middle);
                MergeSort(arrayforsort, middle + 1, end);

                Merge(arrayforsort, start, middle + 1, end);
            }

        }

        /// <summary>
        /// Merging array from starting element to middle element and from middle to ending element
        /// </summary>
        /// <param name="arrayforsort">Merging array</param>
        /// <param name="start">Starting element for merge</param>
        /// <param name="mid">Middle element of the array</param>
        /// <param name="end">Ending element for merge</param>
        private static void Merge(int[] arrayforsort, int start, int mid, int end)
        {
            int[] temp = new int[arrayforsort.Length * 2];
            int counter = end - start + 1;
            int temp_pos = start;
            while ((start <= mid - 1) && (mid <= end))
            {
                if (arrayforsort[start] <= arrayforsort[mid])
                {
                    temp[temp_pos] = arrayforsort[start];
                    temp_pos++;
                    start++;
                }
                else
                {
                    temp[temp_pos] = arrayforsort[mid];
                    temp_pos++;
                    mid++;
                }
            }

            while (start <= mid - 1)
            {
                temp[temp_pos] = arrayforsort[start];
                temp_pos++;
                start++;
            }

            while (mid <= end)
            {
                temp[temp_pos] = arrayforsort[mid];
                temp_pos++;
                mid++;
            }

            for (int i = 0; i < counter; i++)
            {
                arrayforsort[end] = temp[end];
                end--;
            }
        }
    }
}
