using System;
using System.Collections.Generic;

namespace NET.S._2018.Dvorkin.Task1
{
    /// <summary>
    /// Contains methods for sorting jaggers array.
    /// </summary>
    public static class JaggerArays
    {
        #region Public methods

        //public delegate int Predicate(int[] jaggerArrayA, int[] jaggerArrayB);

        /// <summary>
        /// Sums the increasing sort.
        /// </summary>
        /// <param name="jaggerArray">The jaggers array.</param>
        /// <param name="keyComparer">The key comparer.</param>
        public static void BubbleSort(int[][] jaggerArray, IComparer<int[]> keyComparer)
        {
            Checker(jaggerArray, keyComparer);

            for (int i = 0; i < jaggerArray.Length; i++)
            {
                for (int j = 0; j < jaggerArray.Length - 1 - i; j++)
                {
                    if (keyComparer.Compare(jaggerArray[j], jaggerArray[j + 1]) > 0)
                    {
                        Swapper(ref jaggerArray[j], ref jaggerArray[j + 1]);
                    }
                }
            }
        }

        /// <summary>
        /// Bubbles the sort.
        /// </summary>
        /// <param name="jaggerArray">The jagger array.</param>
        /// <param name="predicate">The predicate.</param>
        public static void BubbleSort(int[][] jaggerArray, Func<int[], int[], int> predicate)
        {
            Checker(jaggerArray, predicate);

            for (int i = 0; i < jaggerArray.Length; i++)
            {
                for (int j = 0; j < jaggerArray.Length - 1 - i; j++)
                {
                    if (predicate(jaggerArray[j], jaggerArray[j + 1]) > 0)
                    {
                        Swapper(ref jaggerArray[j], ref jaggerArray[j + 1]);
                    }
                }
            }
        }
        #endregion

        #region Private methods
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
        /// <param name="keyComparer">The key comparer.</param>
        /// <exception cref="ArgumentNullException">jaggerArray</exception>
        private static void Checker(int[][] jaggerArray, IComparer<int[]> keyComparer)
        {
            if (jaggerArray == null)
            {
                throw new ArgumentNullException($"{nameof(jaggerArray)} is null");
            }

            if (keyComparer == null)
            {
                throw new ArgumentNullException($"{nameof(keyComparer)} is null");
            }
        }

        /// <summary>
        /// Checkers the specified jaggers array.
        /// </summary>
        /// <param name="jaggerArray">The jaggers array.</param>
        /// <param name="keyComparer">The key comparer.</param>
        /// <exception cref="ArgumentNullException">jaggerArray</exception>
        private static void Checker(int[][] jaggerArray, Func<int[], int[], int> keyComparer)
        {
            if (jaggerArray == null)
            {
                throw new ArgumentNullException($"{nameof(jaggerArray)} is null");
            }

            if (keyComparer == null)
            {
                throw new ArgumentNullException($"{nameof(keyComparer)} is null");
            }
        }
        #endregion
    }
}
