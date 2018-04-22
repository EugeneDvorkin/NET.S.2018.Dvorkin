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
        /// <summary>
        /// Initializes a new instance of the <see cref="DiagonalMatrix{T}"/> class.
        /// </summary>
        /// <param name="size">The size.</param>
        public DiagonalMatrix(int size) : base(size)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagonalMatrix{T}"/> class.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <exception cref="ArgumentException">matrix</exception>
        public DiagonalMatrix(T[,] matrix) : base(matrix)
        {
            if (this.IsDiagonal(matrix) == false)
            {
                throw new ArgumentException($"{nameof(matrix)} is wrong");
            }
        }

        //public override BaseMatrix<T> Add(BaseMatrix<T> first, BaseMatrix<T> second)
        //{
        //    if (first is DiagonalMatrix<T> == false)
        //    {
        //        throw new ArgumentException($"{nameof(first)} is not a Diagonal Matrix");
        //    }

        //    if (second is DiagonalMatrix<T> == false)
        //    {
        //        throw new ArgumentException($"{nameof(second)} is not a Diagonal Matrix");
        //    }

        //    if (first.Row != second.Row)
        //    {
        //        throw new ArgumentException("Matrix is not the same order");
        //    }

        //    DiagonalMatrix<T> result = new DiagonalMatrix<T>(first.Row);
        //    for (int i = 0; i < first.Row; i++)
        //    {
        //        for (int j = 0; j < first.Row; j++)
        //        {
        //            result[i, j] = first[i, j] + second[i, j];
        //        }
        //    }

        //    return result;
        //}

        /// <summary>
        /// Gets or sets the <see cref="T"/> with the specified i.
        /// </summary>
        /// <value>
        /// The <see cref="T"/>.
        /// </value>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Elements outside the main diagonal should have default values for the element type.</exception>
        public override T this[int i, int j]
        {
            get => base[i, j];
            set
            {
                if ((i != j) && (!object.Equals(value, default(T))))
                {
                    throw new ArgumentException("Elements outside the main diagonal should have default values for the element type.");
                }

                base[i, j] = value;
            }
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
            for (int i = 0; i < this.Row; i++)
            {
                for (int j = 0; j < this.Row; j++)
                {
                    if ((i != j) && (!object.Equals(matrix[i, j], default(T))))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}