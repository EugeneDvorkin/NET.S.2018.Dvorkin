using System;

namespace NET.S._2018.Dvorkin.Task
{
    /// <summary>
    /// Contains definitions of work with the Diagonal Matrix.
    /// </summary>
    /// <typeparam name="T">Type of elements.</typeparam>
    /// <seealso cref="NET.S._2018.Dvorkin.Task.BaseMatrix{T}" />
    public class DiagonalMatrix<T> : BaseMatrix<T>
    {
        private readonly T[] diagonal;

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagonalMatrix{T}"/> class.
        /// </summary>
        /// <param name="size">The size.</param>
        public DiagonalMatrix(int size) : base(size)
        {
            this.diagonal = new T[size];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagonalMatrix{T}"/> class.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        public DiagonalMatrix(T[][] matrix) : base(matrix)
        {
        }

        /// <summary>
        /// Determines whether the specified matrix is diagonal.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns>
        ///   <c>true</c> if the specified matrix is diagonal; otherwise, <c>false</c>.
        /// </returns>
        private bool IsDiagonal(T[,] matrix)
        {
            for (int i = 0; i < this.Size; i++)
            {
                for (int j = 0; j < this.Size; j++)
                {
                    if ((i != j) && (!object.Equals(matrix[i, j], default(T))))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Gets the element.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <returns></returns>
        protected override T GetElement(int i, int j)
        {
            return i != j ? default(T) : this.diagonal[i];
        }

        /// <summary>
        /// Sets the element.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <exception cref="ArgumentException"></exception>
        protected override void SetElement(T value, int i, int j)
        {
            this.diagonal[i] = i != j ? throw new ArgumentException($"There is not diagonal matrix") : value;
        }
    }
}