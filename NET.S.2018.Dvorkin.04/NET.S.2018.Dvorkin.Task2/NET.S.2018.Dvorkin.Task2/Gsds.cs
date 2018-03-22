using System;
using System.Linq;

namespace NET.S._2018.Dvorkin.Task2
{

    /// <summary>
    /// Contains GSD methods
    /// </summary>
    public class Gsds
    {

        /// <summary>
        /// GSDs for params elements.
        /// </summary>
        /// <param name="numbers">The params.</param>
        /// <returns>GSD for params</returns>
        /// <exception cref="ArgumentException">
        /// If params contains int.MinValue
        /// or
        /// there is 0 params
        /// </exception>
        public static int GsdParams(params int[] numbers)
        {
            if (numbers.Contains(int.MinValue))
            {
                throw new ArgumentException($"{nameof(numbers)} contains int.MinValue. It can't be processed");
            }

            if (numbers.Length == 0)
            {
                throw new ArgumentException($"{nameof(numbers)} contains 0 element");
            }

            int gsd = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                gsd = Gsd(Math.Abs(gsd), Math.Abs(numbers[i]));
            }

            return gsd;
        }

        /// <summary>
        /// Euclideans the GSD.
        /// </summary>
        /// <param name="first">The first number.</param>
        /// <param name="second">The second number.</param>
        /// <returns>GSD for this 2 numbers</returns>
        /// <exception cref="ArgumentException">
        /// If any parameters are int.Minvalue
        /// or
        /// first and second parametrs are 0
        /// </exception>
        public static int EuclideanGsd(int first, int second)
        {
            if (first == int.MinValue || second == int.MinValue)
            {
                throw new ArgumentException($"{nameof(first)} or {nameof(second)} can't be processed");
            }

            if (first == 0 && second == 0)
            {
                throw new ArgumentException($"{nameof(first)} and {nameof(second)} are 0.");
            }

            return Gsd(Math.Abs(first), Math.Abs(second));
        }

        /// <summary>
        /// Binaries the GSD with params.
        /// </summary>
        /// <param name="numbers">The numbers.</param>
        /// <returns>GSD for this params</returns>
        /// <exception cref="ArgumentException">
        /// If params contains int.MinValue
        /// or
        /// there is 0 params
        /// </exception>
        public static int BinaryGsdParams(params int[] numbers)
        {
            if (numbers.Contains(int.MinValue))
            {
                throw new ArgumentException($"{nameof(numbers)} contains int.MinValue. It can't be processed");
            }

            if (numbers.Length == 0)
            {
                throw new ArgumentException($"{nameof(numbers)} contains 0 element");
            }

            int gsd = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                gsd = BinaryGsd(Math.Abs(gsd), Math.Abs(numbers[i]));
            }

            return gsd;
        }

        /// <summary>
        /// GSDs between two elements.
        /// </summary>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <returns>GSD for this two elements</returns>
        private static int Gsd(int first, int second)
        {
            while (second != 0)
            {
                int temp = second;
                second = first % second;
                first = temp;
            }

            return first;
        }

        /// <summary>
        /// Binaries the GSD.
        /// </summary>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <returns>GSD for this two elements</returns>
        private static int BinaryGsd(int first, int second)
        {
            while (true)
            {
                if (first == second)
                {
                    return first;
                }

                if (first == 0)
                {
                    return second;
                }

                if (second == 0)
                {
                    return first;
                }

                if ((~first & 1) != 0)
                {
                    if ((second & 1) != 0)
                    {
                        first = first >> 1;
                        continue;
                    }

                    else
                    {
                        return BinaryGsd(first >> 1, second >> 1) << 1;
                    }
                }

                if ((~second & 1) != 0)
                {
                    second = second >> 1;
                    continue;
                }

                if (first > second)
                {
                    first = (first - second) >> 1;
                    continue;
                }

                var first1 = first;
                first = (second - first) >> 1;
                second = first1;
            }
        }
    }
}
