using System.IO;

namespace Solution
{
    public interface IPrint
    {
        string Name { get; }
        string Model { get; }
        void Print(FileStream fs);
    }
}