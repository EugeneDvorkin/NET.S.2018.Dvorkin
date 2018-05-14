namespace NET.S._2018.Dvorkin.Task
{
    /// <summary>
    /// Implementation pattern visitor
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="NET.S._2018.Dvorkin.Task.IMatrixVisitor{T}" />
    public class MatrixVisitor<T> : IMatrixVisitor<T>
    {
        private BaseMatrix<T> temp;

        /// <summary>
        /// Initializes a new instance of the <see cref="MatrixVisitor{T}"/> class.
        /// </summary>
        /// <param name="other">The other.</param>
        public MatrixVisitor(BaseMatrix<T> other)
        {
            temp = other;
        }

        /// <summary>
        /// Visits the specified matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns></returns>
        public SquareMatrix<T> Visit(SquareMatrix<T> matrix)
        {
            for (int i = 0; i < matrix.Size; i++)
            {
                for (int j = 0; j < matrix.Size; j++)
                {
                    matrix[i, j] += (dynamic)temp[i, j];
                }
            }

            return matrix;
        }

        /// <summary>
        /// Visits the specified matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns></returns>
        public SymmetricMatrix<T> Visit(SymmetricMatrix<T> matrix)
        {
            for (int i = 0; i < matrix.Size; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    matrix[i, j] += (dynamic)temp[i, j];
                }
            }

            return matrix;
        }

        /// <summary>
        /// Visits the specified matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns></returns>
        public DiagonalMatrix<T> Visit(DiagonalMatrix<T> matrix)
        {
            for (int i = 0; i < matrix.Size; i++)
            {
                matrix[i, 0] += (dynamic)temp[i, 0];
            }

            return matrix;
        }
    }
}