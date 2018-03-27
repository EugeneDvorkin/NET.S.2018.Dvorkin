using System;

namespace NET.S._2018.Dvorkin.Task4
{
    /// <summary>
    /// Contains method for getting number from its binary string representations.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Getting number from its binary string representations.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="notations">The notations.</param>
        /// <returns>Number from <param name="source"/> binary string representations</returns>
        /// <exception cref="ArgumentException">source</exception>
        public static int ToNumber(this string source, Notation notations)
        { 
            foreach (char item in source.ToUpper())
            {
                if (!notations.ActualString.Contains(item.ToString()))
                {
                    throw new ArgumentException($"{nameof(source)} contains invalid letters");
                }
            }

            int result = 0;

            checked
            {
                for (int i = 0, j = source.Length - 1; i < source.Length; i++)
                {
                    result += (int)(Math.Pow(notations.Order, j - i)) * notations.ActualString.IndexOf(source[i].ToString().ToUpper(), StringComparison.Ordinal);
                }
            }            

            return result;
        }
    }
}
