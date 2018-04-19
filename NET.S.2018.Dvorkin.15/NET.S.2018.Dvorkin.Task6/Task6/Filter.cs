using System.Collections.Generic;
using System;

namespace Task6
{
    /// <summary>
    /// Filtering array with digit key
    /// </summary>
    public static class Filters
    {
        /// <summary>
        /// Filtering array with the digit
        /// </summary>
        /// <param name="filterArray">Filtering array</param>
        /// <param name="logicPredicate">The logic predicate.</param>
        /// <returns>
        /// Filtering array
        /// </returns>
        /// <exception cref="ArgumentNullException">filterArray</exception>
        /// <exception cref="ArgumentException">digit
        /// or
        /// filterArray</exception>
        public static T[] FilterDigit<T>(this T[] filterArray, IPredicate<T> logicPredicate)
        {
            if (filterArray == null)
            {
                throw new ArgumentNullException($"{nameof(filterArray)} is null");
            }

            if (filterArray.Length == 0)
            {
                throw new ArgumentException($"{nameof(filterArray)} is empty");
            }

            if (logicPredicate==null)
            {
                throw new ArgumentNullException($"{nameof(logicPredicate)} is null");
            }

            Predicate<T> predicate = logicPredicate.IsMatch;

            return Filter(filterArray, predicate);
        }

        /// <summary>
        /// Filters the digit.
        /// </summary>
        /// <param name="filterArray">The filter array.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns>Filtered array.</returns>
        /// <exception cref="ArgumentNullException">
        /// filterArray is null
        /// or
        /// predicate is null.
        /// </exception>
        /// <exception cref="ArgumentException">filterArray</exception>
        public static T[] FilterDigit<T>(this T[] filterArray, Predicate<T> predicate)
        {
            if (filterArray == null)
            {
                throw new ArgumentNullException($"{nameof(filterArray)} is null");
            }

            if (filterArray.Length == 0)
            {
                throw new ArgumentException($"{nameof(filterArray)} is empty");
            }

            if (predicate==null)
            {
                throw new ArgumentNullException($"{nameof(predicate)} is null");
            }

            return Filter(filterArray, predicate);
        }

        /// <summary>
        /// Filters the specified filter array.
        /// </summary>
        /// <param name="filterArray">The filter array.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns>Filtered array.</returns>
        private static T[] Filter<T>(T[] filterArray, Predicate<T> predicate)
        {
            List<T> result = new List<T>();
            foreach (var item in filterArray)
            {
                if (predicate.Invoke(item))
                {
                    result.Add(item);
                }
            }

            return result.ToArray();
        }
    }
}
