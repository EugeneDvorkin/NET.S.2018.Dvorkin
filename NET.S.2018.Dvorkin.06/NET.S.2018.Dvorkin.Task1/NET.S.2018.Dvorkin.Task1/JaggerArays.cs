using System;

namespace NET.S._2018.Dvorkin.Task1
{
    /// <summary>
    /// Contains methods for sorting jaggers array.
    /// </summary>
    public class JaggerArays
    {
        #region Public methods
        /// <summary>
        /// Sums the increasing sort.
        /// </summary>
        /// <param name = "jaggerArray" > The jaggers array.</param>
        public static void SumIncreasingSort(int[][] jaggerArray)
        {
            Checker(jaggerArray);

            for (int i = 0; i < jaggerArray.Length; i++)
            {
                for (int j = 0; j < jaggerArray.Length - 1; j++)
                {
                    if (jaggerArray[j] == null)
                    {
                        Swapper(ref jaggerArray[j], ref jaggerArray[j + 1]);
                        continue;
                    }

                    if (Sum(jaggerArray[j]) > Sum(jaggerArray[j + 1]))
                    {
                        Swapper(ref jaggerArray[j], ref jaggerArray[j + 1]);
                    }
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

            for (int i = 0; i < jaggerArray.Length; i++)
            {
                for (int j = 0; j < jaggerArray.Length - 1; j++)
                {
                    if (jaggerArray[j] == null)
                    {
                        Swapper(ref jaggerArray[j], ref jaggerArray[j + 1]);
                        continue;
                    }

                    if (MaxElement(jaggerArray[j]) > MaxElement(jaggerArray[j + 1]))
                    {
                        Swapper(ref jaggerArray[j], ref jaggerArray[j + 1]);
                    }
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

            for (int i = 0; i < jaggerArray.Length; i++)
            {
                for (int j = 0; j < jaggerArray.Length - 1; j++)
                {
                    if (jaggerArray[j] == null)
                    {
                        Swapper(ref jaggerArray[j], ref jaggerArray[j + 1]);
                        continue;
                    }

                    if (MinElement(jaggerArray[j]) > MinElement(jaggerArray[j + 1]))
                    {
                        Swapper(ref jaggerArray[j], ref jaggerArray[j + 1]);
                    }
                }
            }
        }

        /// <summary>
        /// Sums the decreasing sort.
        /// </summary>
        /// <param name="jaggerArray">The jaggers array.</param>
        public static void SumDecreasingSort(int[][] jaggerArray)
        {
            Checker(jaggerArray);

            for (int i = 0; i < jaggerArray.Length; i++)
            {
                for (int j = 0; j < jaggerArray.Length - 1; j++)
                {
                    if (jaggerArray[j + 1] == null)
                    {
                        Swapper(ref jaggerArray[j], ref jaggerArray[j + 1]);
                        continue;
                    }

                    if (Sum(jaggerArray[j]) < Sum(jaggerArray[j + 1]))
                    {
                        Swapper(ref jaggerArray[j], ref jaggerArray[j + 1]);
                    }
                }
            }
        }

        /// <summary>
        /// Maximums the decreasing sort.
        /// </summary>
        /// <param name="jaggerArray">The jaggers array.</param>
        public static void MaxDecreasingSort(int[][] jaggerArray)
        {
            Checker(jaggerArray);

            for (int i = 0; i < jaggerArray.Length; i++)
            {
                for (int j = 0; j < jaggerArray.Length - 1; j++)
                {
                    if (jaggerArray[j + 1] == null)
                    {
                        Swapper(ref jaggerArray[j], ref jaggerArray[j + 1]);
                        continue;
                    }

                    if (MaxElement(jaggerArray[j]) < MaxElement(jaggerArray[j + 1]))
                    {
                        Swapper(ref jaggerArray[j], ref jaggerArray[j + 1]);
                    }
                }
            }
        }

        /// <summary>
        /// Minimums the decreasing sort.
        /// </summary>
        /// <param name="jaggerArray">The jaggers array.</param>
        public static void MinDecreasingSort(int[][] jaggerArray)
        {
            Checker(jaggerArray);

            for (int i = 0; i < jaggerArray.Length; i++)
            {
                for (int j = 0; j < jaggerArray.Length - 1; j++)
                {
                    if (jaggerArray[j + 1] == null)
                    {
                        Swapper(ref jaggerArray[j], ref jaggerArray[j + 1]);
                        break;
                    }

                    if (MinElement(jaggerArray[j]) < MinElement(jaggerArray[j + 1]))
                    {
                        Swapper(ref jaggerArray[j], ref jaggerArray[j + 1]);
                    }
                }
            }
        }
        #endregion

        #region Private methods
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
        private static void Swapper(ref int[] first, ref int[] second)
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
        #endregion
    }
}
