using System.Collections.Generic;
using System;
using System.Linq;
using System.Web;
using NET.S._2018.Dvorkin.Task.Model;

namespace NET.S._2018.Dvorkin.Task
{
    /// <summary>
    /// Contains definition of interface representation.
    /// </summary>
    /// <seealso cref="NET.S._2018.Dvorkin.Task.ICreat" />
    public class UriCreat : ICreat
    {
        private Adresses uris = new Adresses();
        //private ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UriCreat"/> class.
        /// </summary>
        public UriCreat()
        {
            //uris = new Adresses();
            //this.logger = logger;
        }

        /// <summary>
        /// Reads the URI.
        /// </summary>
        /// <param name="read">The read.</param>
        /// <param name="path">The path.</param>
        /// <param name="logger">The logger.</param>
        /// <returns>Addresses.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// read
        /// or
        /// path
        /// </exception>
        public Adresses ReadUri(IRead read, string path, ILog logger)
        {
            if (ReferenceEquals(read, null))
            {
                throw new ArgumentNullException($"{nameof(read)} is null");
            }

            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException($"{nameof(path)} is null");
            }

            foreach (string item in read.ReadLine(path))
            {
                if (Uri.TryCreate(item, UriKind.RelativeOrAbsolute, out Uri temp))
                {
                    uris.Uris.Add(Creat(temp));
                }
                else
                {
                    logger.Log(new ArgumentException(), item, LogLevel.Error);
                }
            }

            return uris;
        }

        /// <summary>
        /// Create the specified URI.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <returns></returns>
        private UriScheme Creat(Uri uri)
        {
            UriScheme temp = new UriScheme
            {
                Host = uri.Host,
                Segments = Segments(uri).ToList(),
                Parameters = Parameters(uri).ToList()
            };

            return temp;
        }

        /// <summary>
        /// Parameters the specified URI.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <returns></returns>
        private IEnumerable<Parameter> Parameters(Uri uri)
        {
            foreach (string paramerer in HttpUtility.ParseQueryString(uri.Query).AllKeys)
            {
                if (string.IsNullOrWhiteSpace(paramerer))
                {
                    yield return null;
                }
                else
                {
                    yield return new Parameter() { Value = HttpUtility.ParseQueryString(uri.Query)[paramerer], Key = paramerer };
                }
            }
        }

        /// <summary>
        /// Segments the specified URI.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <returns></returns>
        private IEnumerable<Segment> Segments(Uri uri)
        {
            foreach (string segment in uri.Segments)
            {
                if (segment == @"/")
                {
                    continue;
                }

                yield return new Segment { Path = segment.Trim('/') };
            }
        }
    }
}