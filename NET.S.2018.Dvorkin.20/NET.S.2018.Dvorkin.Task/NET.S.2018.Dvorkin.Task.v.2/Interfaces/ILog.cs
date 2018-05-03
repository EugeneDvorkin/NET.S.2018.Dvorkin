using System;

namespace NET.S._2018.Dvorkin.Task.v._2.Interfaces
{
    /// <summary>
    /// Contains the definitions of a logger.
    /// </summary>
    public interface ILog
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
    /// Levels of errors for logger.
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