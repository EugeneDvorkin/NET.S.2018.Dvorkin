using System;
using System.Linq;

namespace Crossword
{
    public class GenerateCrossword : IGenerateCrossword
    {
        public char[,] Generate(string[] words, Word dictionary, char[,] crosWord)
        {
            if (!Check(words, dictionary))
            {
                throw new ArgumentException($"{nameof(words)} is wrong");
            }

            foreach (string s in words)
            {
                int index = GetIndex(s, dictionary.Words, dictionary);

                if (index == -1)
                {
                    throw new ArgumentException($"{nameof(words)} contains wrong argument");
                }

                crosWord = InsertWord(s, index, crosWord);
            }

            return crosWord;
        }

        // Этот метод не универсален (вообще). Но исходя из задания ("данный кроссворд, заданными словами") и алгоритма, что пришел мне в голову 
        // пришлось руками прописывать куда и какое слово вставлять, потому что многие слова имеют одинаковую длину.
        // И, в таком случае, они будут вставляться взависимости от того в какой последовательности пришли.
        // К, сожалению, другой алгоритм мне в голову во время задания не пришел. 
        private char[,] InsertWord(string temp, int index, char[,] result)
        {
            switch (index)
            {
                case 0:
                    {
                        int start = 2;

                        foreach (char c in temp)
                        {
                            result[0, start++] = c;
                        }

                        break;
                    }
                case 1:
                    {
                        int start = 0;

                        foreach (char c in temp)
                        {
                            result[start++, 7] = c;
                        }

                        break;
                    }
                case 2:
                    {
                        int start = 3;

                        foreach (char c in temp)
                        {
                            result[4, start++] = c;
                        }

                        break;
                    }
                case 3:
                    {
                        int start = 0;

                        foreach (char c in temp)
                        {
                            result[7, start++] = c;
                        }

                        break;
                    }
                case 4:
                    {
                        int start = 6;

                        foreach (char c in temp)
                        {
                            result[start++, 4] = c;
                        }

                        break;
                    }
                case 5:
                    {
                        int start = 2;

                        foreach (char c in temp)
                        {
                            result[9, start++] = c;
                        }

                        break;
                    }
                case 6:
                    {
                        int start = 4;

                        foreach (char c in temp)
                        {
                            result[start++, 1] = c;
                        }

                        break;
                    }

                default: throw new ArgumentException($"{temp} can't be place here");
            }

            return result;
        }

        // Метод возвращает индекс слова из словаря в зависимости от входящего слова.
        // Этот индекс используется для получения места вставки данного слова в кроссворде.
        private int GetIndex(string temp, string[] words, Word dictionary)
        {
            int result;

            foreach (string s in words)
            {
                if (temp.Equals(s))
                {
                    result = Array.IndexOf(dictionary.Words, s);

                    return result;
                }
            }

            return result = -1;
        }

        // Проверка содержания данного слвоа в словаре.
        private bool Check(string[] words, Word dictionary)
        {
            foreach (string value in words)
            {
                if (!dictionary.Words.Contains(value))
                {
                    return false;
                }
            }

            return true;
        }
    }
}