using System;

namespace Task1
{
    public interface ICheck
    {
        Tuple<bool, string> Check(string password);
    }
}