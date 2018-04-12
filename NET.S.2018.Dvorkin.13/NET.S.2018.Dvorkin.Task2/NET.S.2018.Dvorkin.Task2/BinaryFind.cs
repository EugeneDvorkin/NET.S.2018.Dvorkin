﻿using System;
using System.Collections.Generic;

namespace NET.S._2018.Dvorkin.Task2
{
    /// <summary>
    /// Contains binary search method.
    /// </summary>
    public static class BinaryFind
    {
        /// <summary>
        /// Binaries the find search.
        /// </summary>
        /// <typeparam name="T">Type of elements.</typeparam>
        /// <param name="array">The array.</param>
        /// <param name="elem">The elem.</param>
        /// <returns>Index of necessary element.</returns>
        /// <exception cref="ArgumentException">array</exception>
        /// <exception cref="ArgumentNullException">elem</exception>
        public static int BinaryFindSearch<T>(T[] array, T elem) where T : IComparable<T>
        {
            Check(array, elem);

            Adapter<T> adapter = new Adapter<T>();
            Func<T, T, int> compareFunc = adapter.Compare;

            return Search(array, elem, compareFunc);
        }

        /// <summary>
        /// Binaries the find search.
        /// </summary>
        /// <typeparam name="T">Type of elements.</typeparam>
        /// <param name="array">The array.</param>
        /// <param name="elem">The elem.</param>
        /// <param name="comparer">The comparer.</param>
        /// <returns>Index of necessary element.</returns>
        /// <exception cref="ArgumentException">array</exception>
        /// <exception cref="ArgumentNullException">
        /// elem is null
        /// or
        /// comparer is null
        /// </exception>
        public static int BinaryFindSearch<T>(T[] array, T elem, IComparer<T> comparer)
        {
            Check(array, elem);

            if (comparer == null)
            {
                throw new ArgumentNullException($"{nameof(comparer)} is null");
            }

            Func<T, T, int> compareFunc = comparer.Compare;

            return Search(array, elem, compareFunc);
        }

        /// <summary>
        /// Checkers the specified array.
        /// </summary>
        /// <typeparam name="T">Type of elements.</typeparam>
        /// <param name="array">The array.</param>
        /// <param name="elem">The elem.</param>
        /// <exception cref="ArgumentNullException">
        /// array is null
        /// or
        /// elem is null.
        /// </exception>
        /// <exception cref="ArgumentException">array</exception>
        private static void Check<T>(T[] array, T elem)
        {
            if (ReferenceEquals(array, null))
            {
                throw new ArgumentNullException($"{nameof(array)} is null");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException($"{nameof(array)} has 0 elements");
            }

            if (ReferenceEquals(elem, null))
            {
                throw new ArgumentNullException($"{nameof(elem)} is null");
            }
        }

        /// <summary>
        /// Searches the specified array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">The array.</param>
        /// <param name="elem">The elem.</param>
        /// <param name="compareFunc">The comparator.</param>
        /// <returns>Index of necessary element or -1 if there is no such element.</returns>
        /// <exception cref="ArgumentException">array</exception>
        private static int Search<T>(T[] array, T elem, Func<T, T, int> compareFunc)
        {
            Array.Sort(array);
            int first = 0;
            int last = array.Length;

            while (first < last)
            {
                int mid = first + (last - first) / 2;

                if (compareFunc(array[mid], elem) == 0 || compareFunc(array[mid], elem) > 0)
                {
                    last = mid;
                }
                else
                {
                    first = mid + 1;
                }
            }
            
            if (compareFunc(array[last], elem) == 0)
            {
                return last;
            }
            else
            {
                return -1;
            }
        }
    }
}
