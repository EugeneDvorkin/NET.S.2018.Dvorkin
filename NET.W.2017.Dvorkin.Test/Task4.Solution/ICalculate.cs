using System.Collections.Generic;

namespace Task4
{
    public interface ICalculate
    {
        double Method(IEnumerable<double> values);
    }
}