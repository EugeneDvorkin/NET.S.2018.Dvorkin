using System;
using System.Collections.Generic;
using System.IO;

namespace NET.S._2018.Dvorkin.Task
{
    /// <summary>
    /// Contains definition of interface representation.
    /// </summary>
    /// <seealso cref="NET.S._2018.Dvorkin.Task.IRead" />
    public class Read : IRead
    {
        //private string path;

        /// <summary>
        /// Initializes a new instance of the <see cref="Read"/> class.
        /// </summary>
        public Read()
        {
            //this.path = path;
        }

        /// <summary>
        /// Reads the line.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>
        /// String representation of URIes
        /// </returns>
        /// <exception cref="System.ArgumentNullException">path</exception>
        /// <exception cref="System.ArgumentException">path</exception>
        public IEnumerable<string> ReadLine(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException($"{nameof(path)} is null");
            }

            if (!File.Exists(path))
            {
                throw new ArgumentException($"{nameof(path)} is wrong");
            }

            return Readline(path);
        }

        /// <summary>
        /// Readlines the specified path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>URI</returns>
        private IEnumerable<string> Readline(string path)
        {
            StreamReader stream = new StreamReader(path);
            string line;
            while ((line = stream.ReadLine()) != null)
            {
                yield return line;
            }
        }
    }
}