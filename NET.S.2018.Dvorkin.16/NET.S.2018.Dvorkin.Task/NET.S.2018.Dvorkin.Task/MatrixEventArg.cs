using System;

namespace NET.S._2018.Dvorkin.Task
{
    public class MatrixEventArg<T> : EventArgs
    {
        private readonly T oldItem;
        private readonly T newItem;

        /// <summary>
        /// Initializes a new instance of the <see cref="MatrixEventArg{T}"/> class.
        /// </summary>
        /// <param name="oldItem">The old item.</param>
        /// <param name="newItem">The new item.</param>
        public MatrixEventArg(T oldItem, T newItem)
        {
            this.oldItem = oldItem;
            this.newItem = newItem;
        }

        /// <summary>
        /// Gets the old item.
        /// </summary>
        /// <value>
        /// The old item.
        /// </value>
        public T OldItem
        {
            get => this.oldItem;
        }

        /// <summary>
        /// Gets the new item.
        /// </summary>
        /// <value>
        /// The new item.
        /// </value>
        public T NewItem
        {
            get => this.newItem;
        }
    }
}