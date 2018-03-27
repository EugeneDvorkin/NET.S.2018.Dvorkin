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
        /// <param name="digit">Filtering key</param>
        /// <returns>
        /// Filtering array
        /// </returns>
        /// <exception cref="ArgumentNullException">filterArray</exception>
        /// <exception cref="ArgumentException">
        /// digit
        /// or
        /// filterArray
        /// </exception>
        public static int[] FilterDigit(int[] filterArray, int digit)
        {
            if (filterArray == null)
            {
                throw new ArgumentNullException($"{nameof(filterArray)} is null");
            }

            if (digit > 9 || digit < 0)
            {
                throw new ArgumentException($"{nameof(digit)} is not a digit");
            }

            if (filterArray.Length == 0)
            {
                throw new ArgumentException($"{nameof(filterArray)} is empty");
            }

            List<int> result = new List<int>();
            foreach (var item in filterArray)
            {
                if (IsElementContainsDigit(item, digit))
                {
                    result.Add(item);
                }
            }

            return result.ToArray();
        }

        /// <summary>
        /// Checking Element for contains digit
        /// </summary>
        /// <param name="element">Element from array</param>
        /// <param name="digit">Flag for checking</param>
        /// <returns>
        /// True if element contains digit
        /// </returns>
        private static bool IsElementContainsDigit(int element, int digit)
        {
            if (element < 0)
            {
                element = Math.Abs(element);
            }

            if (element == digit)
            {
                return true;
            }

            while (element > 0)
            {
                if (element % 10 == digit)
                {
                    return true;
                }

                element /= 10;
            }

            return false;
        }
    }
}
