using System;
using System.Collections.Generic;
using System.Numerics;

namespace NET.S._2018.Dvorkin.Task3
{
    public static class Fibonacci
    {
        /// <summary>
        /// Fibonaches the generator.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <returns>Fibonacci Sequence for necessary count.</returns>
        /// <exception cref="ArgumentException">count</exception>
        public static IEnumerable<BigInteger> FibonachGenerator(int count)
        {
            if (count <= 0)
            {
                throw new ArgumentException($"{nameof(count)} is less than 0");
            }

            return FibonacciSequence(count);
        }

        /// <summary>
        /// Fibonaccis the sequence.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <returns>Fibonacci Sequence for necessary count.</returns>
        private static IEnumerable<BigInteger> FibonacciSequence(int count)
        {
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
