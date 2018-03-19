using System;

namespace NET.S._2018.Dvorkin.Task1
{
    /// <summary>
    /// Contains function for Sqrt by Newton method
    /// </summary>
    public class FindRoot
    {
        /// <summary>
        /// Sqrt by Newton method
        /// </summary>
        /// <param name="element">number for Sqrt</param>
        /// <param name="pow">Degree for Sqrt</param>
        /// <param name="eps">Precision</param>
        /// <returns>Result of Sqrt</returns>
        public static double FindNthRoot(double element, int pow, double eps)
        {
            if (pow < 0)
            {
                throw new ArgumentException($"{nameof(pow)} must be more than 0");
            }

            if (element < 0 && pow % 2 == 0)
            {
                throw new ArgumentException($"{nameof(element)} and {nameof(pow)} can't be is less, than 0 and be even at the same time");
            }

            if (eps < 0)
            {
                throw new ArgumentException($"{nameof(eps)} is less than 0");
            }

            double x0 = pow;
            double x1 = element / eps;

            while (Math.Abs(x1 - x0) > eps)
            {
                x0 = x1;
                x1 = 1.0 / element * ((element - 1) * x1 + element / Math.Pow(x1, pow - 1));
            }

            return x1;
        }
    }
}
