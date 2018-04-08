using System;
using System.Collections;
using System.Collections.Generic;

namespace NET.S._2018.Dvorkin.Task1.Tests
{
    public class ComparerSumIncrease : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            if (x == null)
            {
                return -1;
            }

            if (y == null)
            {
                return 1;
            }

            return Comparer.Sum(x) - Comparer.Sum(y);
        }
    }

    public class ComparerSumDecrease : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            if (x == null)
            {
                return -1;
            }

            if (y == null)
            {
                return 1;
            }

            return -Comparer.Sum(x) + Comparer.Sum(y);
        }
    }

    public class ComparerMaxEncrease : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            if (x == null)
            {
                return 1;
            }

            if (y == null)
            {
                return -1;
            }

            return Comparer.MaxElement(x) - Comparer.MaxElement(y);
        }
    }

    public class ComparerMaxDecrease : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            if (x == null)
            {
                return 1;
            }

            if (y == null)
            {
                return -1;
            }

            return -Comparer.MaxElement(x) + Comparer.MaxElement(y);
        }
    }

    public class ComparerMinEncrease : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            if (x == null)
            {
                return 1;
            }

            if (y == null)
            {
                return -1;
            }

            return Comparer.MinElement(x) - Comparer.MinElement(y);
        }
    }

    public class ComparerMinDecrease : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            if (x == null)
            {
                return 1;
            }

            if (y == null)
            {
                return -1;
            }

            return -Comparer.MinElement(x) + Comparer.MinElement(y);
        }
    }

    public class ComparerFunc : IComparer<int[]>
    {
        private readonly JaggerArays.Predicate predicate;

        public ComparerFunc(JaggerArays.Predicate predicate)
        {
            this.predicate = predicate;
        }

        public int Compare(int[] x, int[] y)
        {
            return predicate.Invoke(x, y);
        }
    }

    public class Comparer
    {
        /// <summary>
        /// Sums the specified row.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <returns>Sum of the elements.</returns>
        public static int Sum(int[] row)
        {
            int sum = 0;

            if (row == null)
            {
                return Int32.MaxValue;
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
        public static int MaxElement(int[] row)
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
        public static int MinElement(int[] row)
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
    }
}