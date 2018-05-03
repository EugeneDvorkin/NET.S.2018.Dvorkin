using System;
using NET.S._2018.Dvorkin.Task.v._2.Interfaces;
using NLog;
using LogLevel = NET.S._2018.Dvorkin.Task.v._2.Interfaces.LogLevel;

namespace NET.S._2018.Dvorkin.Task.Tests
{
    public class Logger : ILog
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