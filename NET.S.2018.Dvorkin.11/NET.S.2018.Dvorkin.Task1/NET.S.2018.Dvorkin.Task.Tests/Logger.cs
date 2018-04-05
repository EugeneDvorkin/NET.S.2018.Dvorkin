using System;
using NLog;
using NET.S._2018.Dvorkin.Task;
using ILogger = NET.S._2018.Dvorkin.Task1.ILogger;
using LogLevel = NET.S._2018.Dvorkin.Task1.LogLevel;

namespace NET.S._2018.Dvorkin.Task.Tests
{
    /// <summary>
    /// Contains example of a logger.
    /// </summary>
    /// <seealso cref="ILogger" />
    public class Logger : ILogger
    {
        private static NLog.Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Logs the specified exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="message">The message.</param>
        /// <param name="logLevel">The log level.</param>
        public void Log(Exception exception, string message, LogLevel logLevel)
        {
            logger.Log(NLog.LogLevel.FromString(logLevel.ToString()), exception, message);
        }
    }
}