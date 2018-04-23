using System.Collections.Generic;
using System.Linq;

namespace Task4.Solution
{
    public class MeanCalc : ICalculate
    {
        public double Method(IEnumerable<double> values)
        {
            return values.Sum() / values.Count();
        }
    }
}
