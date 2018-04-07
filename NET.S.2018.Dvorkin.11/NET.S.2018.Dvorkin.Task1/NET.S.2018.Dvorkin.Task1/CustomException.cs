using System;
using System.Diagnostics;

namespace NET.S._2018.Dvorkin.Task1
{
    /// <summary>
    /// Definitions of custom exception
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class CustomException : Exception
    {
        /// <summary>
        /// The stack trace
        /// </summary>
        private StackTrace stackTrace;

        /// <summary>
        /// The message details
        /// </summary>
        private string messageDetails = string.Empty;

        /// <summary>
        /// The inner exception
        /// </summary>
        private Exception innerException;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomException"/> class.
        /// </summary>
        public CustomException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomException"/> class.
        /// </summary>
        /// <param name="innerException">The inner exception.</param>
        /// <param name="stackTrace">The stack trace.</param>
        /// <param name="message">The message.</param>
        public CustomException(Exception innerException, StackTrace stackTrace, string message)
        {
            this.innerException = innerException;
            this.stackTrace = stackTrace;
            this.messageDetails = message;
        }
    }
}
