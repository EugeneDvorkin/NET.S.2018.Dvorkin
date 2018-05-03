using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using NET.S._2018.Dvorkin.Task.v._2.Interfaces;

namespace NET.S._2018.Dvorkin.Task.v._2
{
    /// <summary>
    /// Contains definition of creating XML file.
    /// </summary>
    /// <typeparam name="T">Type of elements.</typeparam>
    public class XmlCreate<T> : IXmlCreate<T>
    {
        private string path;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlCreateCreateCreat{T}"/> class.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <exception cref="ArgumentNullException">path</exception>
        public XmlCreate(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException($"{nameof(path)} is null");
            }

            this.path = path;
        }

        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        /// <value>
        /// The path.
        /// </value>
        /// <exception cref="ArgumentNullException">value</exception>
        public string Path
        {
            get => path;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException($"{nameof(value)} is null");
                }

                path = value;
            }
        }

        /// <summary>
        /// Writes the XML.
        /// </summary>
        /// <param name="parser">The parser.</param>
        /// <param name="list">The list.</param>
        /// <exception cref="ArgumentNullException">
        /// parser is null
        /// or
        /// list is null
        /// </exception>
        public void WriteXml(IParser<T> parser, IEnumerable<T> list)
        {
            if (ReferenceEquals(parser, null))
            {
                throw new ArgumentNullException($"{nameof(parser)} is null");
            }

            if (ReferenceEquals(list, null))
            {
                throw new ArgumentNullException($"{nameof(list)} is null");
            }

            WriteXml(parser, list, this.path);
        }

        /// <summary>
        /// Writes the XML.
        /// </summary>
        /// <param name="parser">The parser.</param>
        /// <param name="list">The list.</param>
        /// <param name="path">The path.</param>
        /// <exception cref="ArgumentNullException">
        /// parser is null
        /// or
        /// list is null
        /// or
        /// path is null
        /// </exception>
        public void WriteXml(IParser<T> parser, IEnumerable<T> list, string path)
        {
            if (ReferenceEquals(parser, null))
            {
                throw new ArgumentNullException($"{nameof(parser)} is null");
            }

            if (ReferenceEquals(list, null))
            {
                throw new ArgumentNullException($"{nameof(list)} is null");
            }

            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException($"{nameof(path)} is null");
            }

            XDocument document = new XDocument(parser.Parse(list));
            document.Save(path);
        }
    }
}
