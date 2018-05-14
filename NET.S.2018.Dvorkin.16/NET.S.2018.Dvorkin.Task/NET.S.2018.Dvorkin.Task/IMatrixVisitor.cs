namespace NET.S._2018.Dvorkin.Task
{
    public interface IMatrixVisitor<T>
    {
        SquareMatrix<T> Visit(SquareMatrix<T> matrix);

        SymmetricMatrix<T> Visit(SymmetricMatrix<T> matrix);

        DiagonalMatrix<T> Visit(DiagonalMatrix<T> matrix);
    }
}