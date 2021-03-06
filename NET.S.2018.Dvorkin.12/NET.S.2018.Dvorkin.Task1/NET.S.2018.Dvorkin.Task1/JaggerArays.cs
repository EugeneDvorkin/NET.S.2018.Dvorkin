﻿using System;
using System.Collections.Generic;

namespace NET.S._2018.Dvorkin.Task1
{
    /// <summary>
    /// Contains methods for sorting jaggers array.
    /// </summary>
    public static class JaggerArays
    {
        #region Public methods

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

            BubbleSort(jaggerArray, new ComparerFunc(predicate));
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

    /// <summary>
    /// Adapter for IComparer.
    /// </summary>
    /// <seealso cref="int" />
    public class ComparerFunc : IComparer<int[]>
    {
        /// <summary>
        /// The comparer.
        /// </summary>
        private Func<int[], int[], int> comparer;

        /// <summary>
        /// Gets the comparer.
        /// </summary>
        /// <value>
        /// The comparer.
        /// </value>
        /// <exception cref="ArgumentNullException">comparer</exception>
        public Func<int[], int[], int> Comparer
        {
            get => comparer;
            private set
            {
                this.comparer = value ?? throw new ArgumentNullException($"{nameof(comparer)} is null");
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ComparerFunc"/> class.
        /// </summary>
        /// <param name="comparer">The comparer.</param>
        public ComparerFunc(Func<int[], int[], int> comparer)
        {
            this.Comparer = comparer;
        }

        /// <summary>
        /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="x">The first object to compare.</param>
        /// <param name="y">The second object to compare.</param>
        /// <returns>
        /// A signed integer that indicates the relative values of <paramref name="x" /> and <paramref name="y" />, as shown in the following table.Value Meaning Less than zero
        /// <paramref name="x" /> is less than <paramref name="y" />.Zero
        /// <paramref name="x" /> equals <paramref name="y" />.Greater than zero
        /// <paramref name="x" /> is greater than <paramref name="y" />.
        /// </returns>
        public int Compare(int[] x, int[] y)
        {
            return comparer(x, y);
        }
    }
}
