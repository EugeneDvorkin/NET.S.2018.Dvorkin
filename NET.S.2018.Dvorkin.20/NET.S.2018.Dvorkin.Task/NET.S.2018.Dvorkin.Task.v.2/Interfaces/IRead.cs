using System.Collections.Generic;

namespace NET.S._2018.Dvorkin.Task.v._2.Interfaces
{
    /// <summary>
    /// Contains method for reading URI from the file. 
    /// </summary>
    public interface IRead
    {
        /// <summary>
        /// Reads the line.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>String representation of URIes</returns>
        IEnumerable<string> ReadLine(string path);
    }
}