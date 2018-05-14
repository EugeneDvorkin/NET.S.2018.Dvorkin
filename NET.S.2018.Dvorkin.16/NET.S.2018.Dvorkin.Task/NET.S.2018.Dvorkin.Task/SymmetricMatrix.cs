using System;
using System.Linq;

namespace NET.S._2018.Dvorkin.Task
{
    /// <summary>
    /// Contains definitions of work with the Symmetric Matrix.
    /// </summary>
    /// <typeparam name="T">Type of elements.</typeparam>
    /// <seealso cref="NET.S._2018.Dvorkin.Task.BaseMatrix{T}" />
    public class SymmetricMatrix<T> : BaseMatrix<T>
    {
        private readonly T[][] symmetricMatrix;
        /// <summary>
        /// Initializes a new instance of the <see cref="SymmetricMatrix{T}"/> class.
        /// </summary>
        /// <param name="size">The size.</param>
        public SymmetricMatrix(int size) : base(size)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SymmetricMatrix{T}"/> class.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <exception cref="ArgumentException">matrix</exception>
        public SymmetricMatrix(T[][] matrix) : base(matrix)
        {
            if (!Symmetry(matrix))
            {
                throw new ArgumentException($"{nameof(matrix)} is not symmetric");
            }

            this.symmetricMatrix = matrix;
        }

        /// <summary>
        /// Gets or sets the <see cref="T"/> with the specified i.
        /// </summary>
        /// <value>
        /// The <see cref="T"/>.
        /// </value>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <returns>Element at the current index.</returns>
        public override T this[int i, int j]
        {
            get => base[i, j];
            set
            {
                if (i == j)
                {
                    base[i, j] = value;
                }
                else
                {
                    base[i, j] = value;
                    base[j, i] = value;
                }
            }
        }

        /// <summary>
        /// Gets the element.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <returns></returns>
        protected override T GetElement(int i, int j)
        {
            return symmetricMatrix[i].ElementAt(j);
        }

        /// <summary>
        /// Sets the element.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        protected override void SetElement(T value, int i, int j)
        {
            symmetricMatrix[i].SetValue(value, j);
        }

        /// <summary>
        /// Symmetries the specified matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns>
        ///     <c>true</c> if the specified matrix is symmetry; otherwise, <c>false</c>.
        /// </returns>
        private bool Symmetry(T[][] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (!object.Equals(matrix[i][j], matrix[j][i]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}