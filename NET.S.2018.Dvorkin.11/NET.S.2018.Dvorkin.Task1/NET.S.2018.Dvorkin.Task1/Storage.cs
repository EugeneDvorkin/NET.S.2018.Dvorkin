using System.Collections.Generic;

namespace NET.S._2018.Dvorkin.Task1
{
    /// <summary>
    /// Contains the definitions of a storage.
    /// </summary>
    public abstract class Storage
    {
        /// <summary>
        /// Reads the books.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>Collection of book from current storage.</returns>
        public abstract List<Book> ReadBooks(string filePath);

        /// <summary>
        /// Writes the books.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="books">The books.</param>
        public abstract void WriteBooks(string filePath, List<Book> books);
    }
}