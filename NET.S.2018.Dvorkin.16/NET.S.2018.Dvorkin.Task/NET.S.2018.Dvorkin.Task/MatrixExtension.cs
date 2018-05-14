using System;

namespace NET.S._2018.Dvorkin.Task
{
    /// <summary>
    /// Implementation of matrix extensions.
    /// </summary>
    public static class MatrixExtension
    {
        /// <summary>
        /// Sums the specified other.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="matrix">The matrix.</param>
        /// <param name="other">The other.</param>
        /// <returns>Resulted matrix.</returns>
        /// <exception cref="ArgumentNullException">other</exception>
        public static BaseMatrix<T> Sum<T>(this BaseMatrix<T> matrix, BaseMatrix<T> other)
        {
            if (other is null)
            {
                throw new ArgumentNullException($"{nameof(other)} is null");
            }

            MatrixVisitor<T> visitor = new MatrixVisitor<T>(other);
            visitor.Visit((dynamic)matrix);

            return matrix;
        }
    }
}