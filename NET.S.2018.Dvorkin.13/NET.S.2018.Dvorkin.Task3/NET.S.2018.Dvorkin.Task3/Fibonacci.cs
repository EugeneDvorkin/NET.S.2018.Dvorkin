using System;
using System.Collections.Generic;

namespace NET.S._2018.Dvorkin.Task3
{
    public static class Fibonacci
    {
        /// <summary>
        /// Fibonaccis the sequence.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <returns>IEnumerable list of Fibonacci Sequence for necessary count.</returns>
        public static IEnumerable<int> FibonacciSequence(int count)
        {
            if (count <= 0)
            {
                throw new ArgumentException($"{nameof(count)} is less than 0");
            }

            ////List<int> result = new List<int>();
            for (int i = 0, prev = 1, cur = 1; i < count; i++)
            {
                yield return prev;
                int newFib = prev + cur;
                prev = cur;
                cur = newFib;
            }
        }
    }
}
