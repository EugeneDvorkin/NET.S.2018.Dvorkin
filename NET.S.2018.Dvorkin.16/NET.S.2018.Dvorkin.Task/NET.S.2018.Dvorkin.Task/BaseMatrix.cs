using System;

namespace NET.S._2018.Dvorkin.Task
{
    /// <summary>
    /// Contains definitions of the base matrix.
    /// </summary>
    /// <typeparam name="T">Type of elements.</typeparam>
    public abstract class BaseMatrix<T>
    {
        private int row;

        private T[,] matrix;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseMatrix{T}" /> class.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <param name="manager">The manager.</param>
        /// <exception cref="ArgumentException">size</exception>
        protected BaseMatrix(int size)
        {
            if (size < 0)
            {
                throw new ArgumentException($"{nameof(size)} is incorrect");
            }

            Matrix = new T[size, size];
            Row = size;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseMatrix{T}" /> class.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <exception cref="ArgumentNullException">matrix</exception>
        protected BaseMatrix(T[,] matrix)
        {
            if (ReferenceEquals(matrix, null))
            {
                throw new ArgumentNullException($"{nameof(matrix)} is null");
            }

            Matrix = matrix;
            Row = matrix.GetLength(0);
        }

        /// <summary>
        /// Occurs when [items].
        /// </summary>
        public event EventHandler<MatrixEventArg<T>> Items = delegate { };

        /// <summary>
        /// Gets the row.
        /// </summary>
        /// <value>
        /// The row.
        /// </value>
        /// <exception cref="ArgumentOutOfRangeException">value</exception>
        public int Row
        {
            get => row;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(value)} is incorrect");
                }

                row = value;
            }
        }

        /// <summary>
        /// Gets the matrix.
        /// </summary>
        /// <value>
        /// The matrix.
        /// </value>
        public T[,] Matrix
        {
            get => matrix;
            internal set => matrix = value;
        }

        //public abstract BaseMatrix<T> Add(BaseMatrix<T> first, BaseMatrix<T> second);

        /// <summary>
        /// Gets or sets the <see cref="T"/> with the specified i.
        /// </summary>
        /// <value>
        /// The <see cref="T"/>.
        /// </value>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <returns>Element at the current index.</returns>
        /// <exception cref="ArgumentException">
        /// i
        /// or
        /// j
        /// </exception>
        public virtual T this[int i, int j]
        {
            get
            {
                if (i < 0 || i > Row - 1)
                {
                    throw new ArgumentException($"{nameof(i)} is incorrect");
                }

                if (j < 0 || j > Row - 1)
                {
                    throw new ArgumentException($"{nameof(j)} is incorrect");
                }

                return this[i, j];
            }

            set
            {
                T oldItem = this.Matrix[i, j];
                this.matrix[i, j] = value;
                OnSetItem(this, new MatrixEventArg<T>(oldItem, matrix[i, j]));
            }
        }

        /// <summary>
        /// Called when [set item].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        protected virtual void OnSetItem(object sender, MatrixEventArg<T> e)
        {
            EventHandler<MatrixEventArg<T>> temp = Items;
            temp?.Invoke(sender, e);
        }
    }
}
