using System;
using System.Linq;

namespace Crossword
{
    public class Cross
    {
        private char[,] crosWord;
        private Word dictionary;
        private IGenerateCrossword generate;
        //private const int row = 11;
        //private const int heigh = 11;

        public Cross(Word dictionary, IGenerateCrossword generate, int row, int heigh)
        {
            this.dictionary = dictionary;
            this.crosWord = new char[row, heigh];
            this.generate = generate;
        }

        public char[,] Generate(string[] word)
        {
            if (ReferenceEquals(word,null))
            {
                throw new ArgumentNullException($"{nameof(word)} is null");
            }

            return generate.Generate(word, dictionary, crosWord);
        }
    }
}
