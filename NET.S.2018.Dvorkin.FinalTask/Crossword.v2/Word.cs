using System;
using System.Collections.Generic;

namespace Crossword
{
    // Класс-словарь. Содержит список допустимых слов. В случае генерации случайного кроссворда, он не нужен. 
    // Но как я понял из задания слова сторого регламентированы.
    public class Word
    {
        public Word()
        {
            this.Words = new string[] {"перелом", "открытый", "подвывих", "закрытый", "вывих", "ушиб", "шина"};
        }

        public Word(string[] dictionary)
        {
            if (ReferenceEquals(dictionary,null))
            {
                throw new ArgumentNullException($"{nameof(dictionary)} is null");
            }
            this.Words = dictionary;
        }

        public string[] Words { get; private set; }

    }
}