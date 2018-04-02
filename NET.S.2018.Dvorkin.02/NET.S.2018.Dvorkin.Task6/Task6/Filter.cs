using System.Collections.Generic;
using System;

namespace Task6
{
    /// <summary>
    /// Filtering array with digit key
    /// </summary>
    public class Filter
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
        public static int[] FilterDigit(int[] filterArray, IPredicate logicPredicate)
        {
            if (filterArray == null)
            {
                throw new ArgumentNullException($"{nameof(filterArray)} is null");
            }

            if (filterArray.Length == 0)
            {
                throw new ArgumentException($"{nameof(filterArray)} is empty");
            }

            List<int> result = new List<int>();
            foreach (var item in filterArray)
            {
                if (logicPredicate.IsMatch(item))
                {
                    result.Add(item);
                }
            }

            return result.ToArray();
        }
    }
}
