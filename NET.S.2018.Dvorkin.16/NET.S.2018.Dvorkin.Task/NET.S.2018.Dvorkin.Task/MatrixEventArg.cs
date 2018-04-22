using System;

namespace NET.S._2018.Dvorkin.Task
{
    public class MatrixEventArg<T> : EventArgs
    {
        private readonly T oldItem;
        private readonly T newItem;

        public MatrixEventArg(T oldItem, T newItem)
        {
            this.oldItem = oldItem;
            this.newItem = newItem;
        }

        public T OldItem
        {
            get => this.oldItem;
        }

        public T NewItem
        {
            get => this.newItem;
        }
    }
}