using System;

namespace NET.S._2018.Dvorkin.Task
{
    /// <summary>
    /// Contains definitions of work with the Square Matrix.
    /// </summary>
    /// <typeparam name="T">Type of elements.</typeparam>
    /// <seealso cref="NET.S._2018.Dvorkin.Task.BaseMatrix{T}" />
    public class SquareMatrix<T> : BaseMatrix<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SquareMatrix{T}"/> class.
        /// </summary>
        /// <param name="size">The size.</param>
        public SquareMatrix(int size) : base(size)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SquareMatrix{T}"/> class.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <exception cref="ArgumentException">matrix</exception>
        public SquareMatrix(T[,] matrix) : base(matrix)
        {
            if (this.IsSquare(matrix) == false)
            {
                throw new ArgumentException($"{nameof(matrix)} is wrong");
            }
        }

        /// <summary>
        /// Determines whether the specified matrix is square.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns>
        ///   <c>true</c> if the specified matrix is square; otherwise, <c>false</c>.
        /// </returns>
        private bool IsSquare(T[,] matrix)
        {
            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                return true;
            }

            return false;
        }
    }
}