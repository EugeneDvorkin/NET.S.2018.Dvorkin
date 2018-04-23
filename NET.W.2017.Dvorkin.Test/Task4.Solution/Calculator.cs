using System;
using System.Collections.Generic;

namespace Task4
{
    public static class Calculator
    {
        public static double CalculateAverage(List<double> values, ICalculate method)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            if (method == null)
            {
                throw new ArgumentNullException($"{nameof(method)} is null");
            }

            Func<IEnumerable<double>, double> func = method.Method;

            return func(values);
        }

        public static double CalculateAverage(List<double> values, Func<IEnumerable<double>, double> func)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            if (func == null)
            {
                throw new ArgumentNullException($"{nameof(func)} is null");
            }

            return func(values);
        }
    }
}
