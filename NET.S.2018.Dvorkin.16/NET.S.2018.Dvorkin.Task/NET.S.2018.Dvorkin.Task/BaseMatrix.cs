using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NET.S._2018.Dvorkin.Task
{
    /// <summary>
    /// Contains definitions of the base matrix.
    /// </summary>
    /// <typeparam name="T">Type of elements.</typeparam>
    public abstract class BaseMatrix<T> : IEnumerable<T>
    {
        private int size;
        private const int defaultsize = 3;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseMatrix{T}" /> class.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <exception cref="ArgumentException">size</exception>
        protected BaseMatrix(int size)
        {
            if (size < 1)
            {
                throw new ArgumentException($"{nameof(size)} is incorrect");
            }

            Size = size;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseMatrix{T}"/> class.
        /// </summary>
        protected BaseMatrix()
        {
            Size = defaultsize;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseMatrix{T}"/> class.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <exception cref="ArgumentNullException">matrix</exception>
        /// <exception cref="ArgumentException"></exception>
        protected BaseMatrix(T[][] matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException($"Argument {nameof(matrix)} is null");
            }

            if (matrix[0].Length != matrix.Count())
            {
                throw new ArgumentException($"The matrix isn't square matrix");
            }

            Size = matrix[0].Length;
        }


        /// <summary>
        /// Occurs when [items changed].
        /// </summary>
        public event EventHandler<MatrixEventArg<T>> ItemsChanged = delegate { };

        /// <summary>
        /// Gets the row.
        /// </summary>
        /// <value>
        /// The row.
        /// </value>
        /// <exception cref="ArgumentOutOfRangeException">value</exception>
        public int Size
        {
            get => size;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(value)} is incorrect");
                }

                size = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the <see cref="T"/> with the specified i.
        /// </summary>
        /// <value>
        /// The <see cref="T"/>.
        /// </value>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <returns></returns>
        public virtual T this[int i, int j]
        {
            get
            {
                Check(i, j);
                return this[i, j];
            }

            set
            {
                Check(i, j);
                T oldItem = GetElement(i, j);
                SetElement(value, i, j);
                OnSetItem(this, new MatrixEventArg<T>(oldItem, value));
            }
        }

        /// <summary>
        /// Called when [set item].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        protected virtual void OnSetItem(object sender, MatrixEventArg<T> e)
        {
            EventHandler<MatrixEventArg<T>> temp = ItemsChanged;
            temp?.Invoke(sender, e);
        }

        /// <summary>
        /// Gets the element.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <returns></returns>
        protected abstract T GetElement(int i, int j);

        /// <summary>
        /// Sets the element.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        protected abstract void SetElement(T value, int i, int j);

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    yield return this[i, j];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Checks the specified indexes.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// i is wrong value
        /// or
        /// j is wrong value.
        /// </exception>
        private void Check(int i, int j)
        {
            if (i < 0 || i > Size)
            {
                throw new ArgumentOutOfRangeException($"Index {nameof(i)} is out of range");
            }

            if (j < 0 || j > Size)
            {
                throw new ArgumentOutOfRangeException($"Index {nameof(j)} is out of range");
            }
        }
    }
}
