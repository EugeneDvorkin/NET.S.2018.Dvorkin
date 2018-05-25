namespace Crossword
{
    public interface IGenerateCrossword
    {
        char[,] Generate(string[] words, Word dictionary, char[,] crosWord);
    }
}