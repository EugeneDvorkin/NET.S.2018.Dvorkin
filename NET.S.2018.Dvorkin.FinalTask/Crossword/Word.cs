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

        public string[] Words { get; private set; }

    }
}