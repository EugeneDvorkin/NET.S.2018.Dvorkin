using System;
using System.Threading;

namespace NET.S._2018.Dvorkin.Task1
{
    /// <summary>
    /// Contains definitions of the EventArgs
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class TimerEventArgs : EventArgs
    {
        /// <summary>
        /// The message
        /// </summary>
        private readonly string message;

        /// <summary>
        /// The information
        /// </summary>
        private readonly string info;

        /// <summary>
        /// Initializes a new instance of the <see cref="TimerEventArgs"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="info">The information.</param>
        public TimerEventArgs(string message, string info)
        {
            this.message = message;
            this.info = info;
        }

        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message
        {
            get => message;
        }

        /// <summary>
        /// Gets the information.
        /// </summary>
        /// <value>
        /// The information.
        /// </value>
        public string Info => info;
    }

    /// <summary>
    /// Contains event logic
    /// </summary>
    public sealed class TimerManager
    {
        public event EventHandler<TimerEventArgs> Timer = delegate { };

        /// <summary>
        /// Raises the <see cref="E:EndTimer" /> event.
        /// </summary>
        /// <param name="e">The <see cref="TimerEventArgs"/> instance containing the event data.</param>
        private void OnEndTimer(TimerEventArgs e)
        {
            EventHandler<TimerEventArgs> temp = Timer;
            temp?.Invoke(this, e);
        }

        /// <summary>
        /// Adds the timer.
        /// </summary>
        /// <param name="time">The time.</param>
        /// <param name="message">The message.</param>
        /// <param name="info">The information.</param>
        public void AddTimer(int time, string message, string info)
        {
            Thread.Sleep(time);
            OnEndTimer(new TimerEventArgs(message, info));
        }
    }
}
