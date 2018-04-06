using System.Collections.Generic;

namespace NET.S._2018.Dvorkin.Task1
{
    /// <summary>
    /// Contains the definitions of a storage.
    /// </summary>
    public interface IStogare
    {
        /// <summary>
        /// Reads the books.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>Collection of book from current storage.</returns>
        List<Book> ReadBooks();

        /// <summary>
        /// Writes the books.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="books">The books.</param>
        void WriteBooks(List<Book> books);
    }
}