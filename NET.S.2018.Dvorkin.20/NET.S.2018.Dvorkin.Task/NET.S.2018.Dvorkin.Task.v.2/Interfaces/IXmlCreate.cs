using System.Collections.Generic;

namespace NET.S._2018.Dvorkin.Task.v._2.Interfaces
{
    /// <summary>
    /// Contains method for writing the XML file.
    /// </summary>
    /// <typeparam name="T">Type of elements.</typeparam>
    public interface IXmlCreate<T>
    {
        /// <summary>
        /// Writes the XML.
        /// </summary>
        /// <param name="parser">The parser.</param>
        /// <param name="list">The list.</param>
        /// <param name="path">The path.</param>
        void WriteXml(IParser<T> parser, IEnumerable<T> list, string path);
    }
}