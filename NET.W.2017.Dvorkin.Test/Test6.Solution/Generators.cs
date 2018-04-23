using System;
using System.Collections.Generic;

namespace Test6.Solution
{
    public static class Generators<T>
    {
        public static IEnumerable<T> Generator(T first, T second, int count, Func<T, T, T> sequance)
        {
            if (count < 0)
            {
                throw new ArgumentException($"{nameof(count)} is less than 0");
            }

            if (sequance == null)
            {
                throw new ArgumentNullException($"{nameof(sequance)} is null");
            }

            if (first == null)
            {
                throw new ArgumentNullException($"{nameof(first)} is null");
            }

            if (second == null)
            {
                throw new ArgumentNullException($"{nameof(second)} is null");
            }

            return SequanceGenerator(first, second, count, sequance);
        }

        private static IEnumerable<T> SequanceGenerator(T first, T second, int count, Func<T, T, T> sequance)
        {
            yield return first;
            yield return second;

            for (int i = 2; i < count; i++)
            {
                T current = sequance(first,second);

                yield return current;
                first = second;
                second = current;
            }
        }
    }
}