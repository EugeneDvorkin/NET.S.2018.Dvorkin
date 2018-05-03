using System.Collections.Generic;

namespace NET.S._2018.Dvorkin.Task.v._2.Interfaces
{
    /// <summary>
    /// Contains method for creating collection of adresses
    /// </summary>
    /// <typeparam name="T">Types of elements.</typeparam>
    public interface ICreat<out T>
    {
        ILog Logger { get; set; }
        IEnumerable<T> Read(IRead read, string path);
    }
}