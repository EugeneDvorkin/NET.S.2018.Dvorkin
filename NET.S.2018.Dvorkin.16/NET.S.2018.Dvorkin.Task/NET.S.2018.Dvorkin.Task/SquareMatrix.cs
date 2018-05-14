using System.Linq;

namespace NET.S._2018.Dvorkin.Task
{
    /// <summary>
    /// Contains definitions of work with the Square Matrix.
    /// </summary>
    /// <typeparam name="T">Type of elements.</typeparam>
    /// <seealso cref="NET.S._2018.Dvorkin.Task.BaseMatrix{T}" />
    public class SquareMatrix<T> : BaseMatrix<T>
    {
        private readonly T[][] squareMatrix;

        /// <summary>
        /// Initializes a new instance of the <see cref="SquareMatrix{T}"/> class.
        /// </summary>
        /// <param name="size">The size.</param>
        public SquareMatrix(int size) : base(size)
        {
            this.squareMatrix = new T[size][];
            for (int i = 0; i < Size; i++)
            {
                this.squareMatrix[i] = new T[Size];
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SquareMatrix{T}"/> class.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        public SquareMatrix(T[][] matrix) : base(matrix)
        {
            this.squareMatrix = matrix;
        }

        /// <summary>
        /// Gets the element.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <returns>Element at current index.</returns>
        protected override T GetElement(int i, int j)
        {
            return squareMatrix[i].ElementAt(j);
        }

        /// <summary>
        /// Sets the element.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        protected override void SetElement(T value, int i, int j)
        {
            squareMatrix[i].SetValue(value, j);
        }
    }
}