using System;

namespace NET.S._2018.Dvorkin.Task1
{
    /// <summary>
    /// Contains the definitions of a logger.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Logs the specified exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="message">The message.</param>
        /// <param name="logLevel">The log level.</param>
        void Log(Exception exception, string message, LogLevel logLevel);
    }

    /// <summary>
    /// Level of errors for logger.
    /// </summary>
    public enum LogLevel
    {
        Trace,
        Debug,
        Info,
        Warn,
        Error,
        Fatal
    }
}