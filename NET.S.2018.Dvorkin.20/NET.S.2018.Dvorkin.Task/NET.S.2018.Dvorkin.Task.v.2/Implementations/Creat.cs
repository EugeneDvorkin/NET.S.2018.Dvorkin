using System;
using System.Collections.Generic;
using NET.S._2018.Dvorkin.Task.v._2.Interfaces;

namespace NET.S._2018.Dvorkin.Task.v._2.Implementations
{
    /// <summary>
    /// Contains definition of interface representation.
    /// </summary>
    /// <seealso cref="NET.S._2018.Dvorkin.Task.v._2.Interfaces.ICreat{System.Uri}" />    
    public class Creat : ICreat<Uri>
    {        
        private ILog logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="Creat{Uri}"/> class.
        /// </summary>
        public Creat(ILog logger)
        {            
            this.logger = logger;
        }

        /// <summary>
        /// Gets or sets the logger.
        /// </summary>
        /// <value>
        /// The logger.
        /// </value>
        /// <exception cref="ArgumentException">value</exception>
        public ILog Logger
        {
            get => logger;
            set
            {
                if (value.GetType()!=typeof(ILog))
                {
                    throw new ArgumentException($"{nameof(value)} is wrong type");
                }

                logger = value;
            }
        }

        /// <summary>
        /// Reads the URI.
        /// </summary>
        /// <param name="read">The read.</param>
        /// <param name="path">The path.</param>
        /// <param name="logger">The logger.</param>
        /// <returns>Addresses.</returns>
        /// <exception cref="ArgumentNullException">
        /// read
        /// or
        /// path
        /// </exception>
        public IEnumerable<Uri> Read(IRead read, string path)
        {
            if (ReferenceEquals(read, null))
            {
                throw new ArgumentNullException($"{nameof(read)} is null");
            }

            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException($"{nameof(path)} is null");
            }

            List<Uri> uris = new List<Uri>();
            foreach (string item in read.ReadLine(path))
            {
                if (Uri.TryCreate(item, UriKind.RelativeOrAbsolute, out Uri temp))
                {
                    uris.Add(temp);
                }
                else
                {
                    logger.Log(new ArgumentException(), item, LogLevel.Error);
                }
            }

            return uris;
        }        
    }
}