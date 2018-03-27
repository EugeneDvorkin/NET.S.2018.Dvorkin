using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace NET.S._2018.Dvorkin.Task5
{
    /// <summary>
    /// Contains method for search next specific bigger number
    /// </summary>
    public static class FindBiggerNumber
    {
        /// <summary>
        /// Search next bigger number, which consists of elements <paramref name="enterNumber" />
        /// </summary>
        /// <param name="enterNumber">Element for search</param>
        /// <returns>
        /// Next bigger number
        /// </returns>
        /// <exception cref="ArgumentException">enterNumber</exception>
        public static int FindNextBiggerNumber(int enterNumber)
        {
            if (enterNumber <= 0)
            {
                throw new ArgumentException($"{nameof(enterNumber)} should be more 0");
            }

            return NextBiggerNumber(enterNumber);
        }

        /// <summary>
        /// Search next bigger number, which consists of elements <paramref name="enterNumber" /> and time of working
        /// </summary>
        /// <param name="enterNumber">Element for search</param>
        /// <param name="timeOfWork">Time of working</param>
        /// <returns>
        /// Next bigger number
        /// </returns>
        /// <exception cref="ArgumentException">enterNumber</exception>
        public static int FindNextBiggerNumberWithTimer(int enterNumber, out double timeOfWork)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int result = FindNextBiggerNumber(enterNumber);
            stopwatch.Stop();
            timeOfWork = stopwatch.ElapsedMilliseconds;
            return result;
        }

        /// <summary>
        /// Nexts the bigger number.
        /// </summary>
        /// <param name="enterNumber">The enter number.</param>
        /// <returns>Next bigger number.</returns>
        private static int NextBiggerNumber(int enterNumber)
        {
            int result = 0;
            List<int> elementList = new List<int>();
            int counter = 0;
            int swapper;

            while (enterNumber > 0)
            {
                elementList.Add(enterNumber % 10);
                enterNumber /= 10;
            }

            elementList.Reverse();
            for (int i = elementList.Count - 1; i > 0; i--)
            {
                if (elementList[i] > elementList[i - 1])
                {
                    swapper = elementList[i - 1];
                    elementList[i - 1] = elementList[i];
                    elementList[i] = swapper;
                    counter = i;
                    break;
                }
            }

            if (counter < elementList.Count - 1)
            {
                elementList.Sort(counter, elementList.Count - counter, null);
            }

            if (counter == 0)
            {
                return -1;
            }
            else
            {
                elementList.Reverse();
                for (int i = 0; i < elementList.Count; i++)
                {
                    result += elementList[i] * (int)Math.Pow(10, i);
                }

                return result;
            }
        }
    }
}
