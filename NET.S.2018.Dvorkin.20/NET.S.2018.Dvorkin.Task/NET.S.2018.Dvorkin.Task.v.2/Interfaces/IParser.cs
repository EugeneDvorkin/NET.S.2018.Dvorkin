using System.Collections.Generic;
using System.Xml.Linq;

namespace NET.S._2018.Dvorkin.Task.v._2.Interfaces
{
    /// <summary>
    /// Contains method for parsing elements.
    /// </summary>
    /// <typeparam name="T">Type of elements.</typeparam>
    public interface IParser<in T>
    {
        /// <summary>
        /// Parses the specified list.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns>Root XElement</returns>
        XElement Parse(IEnumerable<T> list);
    }
}