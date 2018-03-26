using System;

namespace NET.S._2018.Dvorkin.Task1
{
    /// <summary>
    /// Contains methods for sorting jaggers array.
    /// </summary>
    public class JaggerArays
    {
        /// <summary>
        /// Sums the increasing sort.
        /// </summary>
        /// <param name="jaggerArray">The jaggers array.</param>
        public static void SumIncreasingSort(int[][] jaggerArray)
        {
            Checker(jaggerArray);
            for (int i = 0; i < jaggerArray.Length - 1; i++)
            {
                if (jaggerArray[i] == null)
                {
                    Swapper(jaggerArray[i], jaggerArray[i + 1]);
                    break;
                }

                if (Sum(jaggerArray[i]) > Sum(jaggerArray[i + 1]))
                {
                    Swapper(jaggerArray[i], jaggerArray[i + 1]);
                }
            }
        }

        /// <summary>
        /// Maximums the increasing sort.
        /// </summary>
        /// <param name="jaggerArray">The jaggers array.</param>
        public static void MaxIncreasingSort(int[][] jaggerArray)
        {
            Checker(jaggerArray);

            for (int i = 0; i < jaggerArray.Length - 1; i++)
            {
                if (jaggerArray[i] == null)
                {
                    Swapper(jaggerArray[i], jaggerArray[i + 1]);
                    continue;
                }

                if (MaxElement(jaggerArray[i]) > MaxElement(jaggerArray[i + 1]))
                {
                    Swapper(jaggerArray[i], jaggerArray[i + 1]);
                }
            }
        }

        /// <summary>
        /// Minimums the increasing sort.
        /// </summary>
        /// <param name="jaggerArray">The jaggers array.</param>
        public static void MinIncreasingSort(int[][] jaggerArray)
        {
            Checker(jaggerArray);

            for (int i = 0; i < jaggerArray.Length - 1; i++)
            {
                if (jaggerArray[i] == null)
                {
                    Swapper(jaggerArray[i], jaggerArray[i + 1]);
                    continue;
                }

                if (MinElement(jaggerArray[i]) > MinElement(jaggerArray[i + 1]))
                {
                    Swapper(jaggerArray[i], jaggerArray[i + 1]);
                }
            }
        }

        /// <summary>
        /// Sums the decreasing sort.
        /// </summary>
        /// <param name="jaggerArray">The jaggers array.</param>
        public void SumDecreasingSort(int[][] jaggerArray)
        {
            Checker(jaggerArray);

            for (int i = 0; i < jaggerArray.Length - 1; i++)
            {
                if (jaggerArray[i] == null)
                {
                    Swapper(jaggerArray[i], jaggerArray[i + 1]);
                    continue;
                }

                if (Sum(jaggerArray[i]) < Sum(jaggerArray[i + 1]))
                {
                    Swapper(jaggerArray[i], jaggerArray[i + 1]);
                }
            }
        }

        /// <summary>
        /// Maximums the decreasing sort.
        /// </summary>
        /// <param name="jaggerArray">The jaggers array.</param>
        public void MaxDecreasingSort(int[][] jaggerArray)
        {
            Checker(jaggerArray);

            for (int i = 0; i < jaggerArray.Length - 1; i++)
            {
                if (jaggerArray[i] == null)
                {
                    Swapper(jaggerArray[i], jaggerArray[i + 1]);
                    continue;
                }

                if (MaxElement(jaggerArray[i]) < MaxElement(jaggerArray[i + 1]))
                {
                    Swapper(jaggerArray[i], jaggerArray[i + 1]);
                }
            }
        }

        /// <summary>
        /// Minimums the decreasing sort.
        /// </summary>
        /// <param name="jaggerArray">The jaggers array.</param>
        public void MinDecreasingSort(int[][] jaggerArray)
        {
            Checker(jaggerArray);

            for (int i = 0; i < jaggerArray.Length - 1; i++)
            {
                if (jaggerArray[i] == null)
                {
                    Swapper(jaggerArray[i], jaggerArray[i + 1]);
                    break;
                }

                if (MinElement(jaggerArray[i]) < MinElement(jaggerArray[i + 1]))
                {
                    Swapper(jaggerArray[i], jaggerArray[i + 1]);
                }
            }
        }

        /// <summary>
        /// Sums the specified row.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <returns>Sum of the elements.</returns>
        private static int Sum(int[] row)
        {
            int sum = 0;

            if (row == null)
            {
                return int.MaxValue;
            }

            foreach (var item in row)
            {
                sum += item;
            }

            return sum;
        }

        /// <summary>
        /// Maximums the element.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <returns>Maximums the element.</returns>
        private static int MaxElement(int[] row)
        {
            if (row == null)
            {
                return int.MaxValue;
            }

            int max = row[0];
            foreach (var item in row)
            {
                if (max < item)
                {
                    max = item;
                }
            }

            return max;
        }

        /// <summary>
        /// Minimums the element.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <returns>Minimums the element.</returns>
        private static int MinElement(int[] row)
        {
            if (row == null)
            {
                return int.MaxValue;
            }

            int min = row[0];
            foreach (var item in row)
            {
                if (min > item)
                {
                    min = item;
                }
            }

            return min;
        }

        /// <summary>
        /// Swappers the specified first.
        /// </summary>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        private static void Swapper(int[] first, int[] second)
        {
            int[] temp = first;
            first = second;
            second = temp;
        }

        /// <summary>
        /// Checkers the specified jaggers array.
        /// </summary>
        /// <param name="jaggerArray">The jaggers array.</param>
        /// <exception cref="ArgumentNullException">jaggerArray</exception>
        private static void Checker(int[][] jaggerArray)
        {
            if (jaggerArray == null)
            {
                throw new ArgumentNullException($"{nameof(jaggerArray)} is null");
            }
        }
    }
}
