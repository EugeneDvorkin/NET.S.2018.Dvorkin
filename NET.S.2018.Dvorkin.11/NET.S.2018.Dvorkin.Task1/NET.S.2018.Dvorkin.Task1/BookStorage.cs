using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace NET.S._2018.Dvorkin.Task1
{
    /// <summary>
    /// Contains the description of the books storage. 
    /// </summary>
    public class BookStorage : IStogare
    {
        /// <summary>
        /// The book storage
        /// </summary>
        private string filePath;

        public BookStorage(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentNullException($"{nameof(filePath)} is null or empty");
            }

            this.filePath = filePath;
        }

        /// <summary>
        /// Reads the books.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>
        /// The collection of the books from the current storage.
        /// </returns>
        /// <exception cref="ArgumentNullException">filePath</exception>
        /// <exception cref="IOException">filePath</exception>
        public List<Book> ReadBooks()
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentNullException($"{nameof(filePath)} is null");
            }

            if (!File.Exists(filePath))
            {
                throw new IOException($"{nameof(filePath)} doesn't exist");
            }

            return BinaryReaderLocal();
        }

        /// <summary>
        /// Writes the books.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="books">The books.</param>
        /// <exception cref="ArgumentNullException">
        /// filePath is null or empty
        /// or
        /// books is null or has 0 elements.
        /// </exception>
        /// <exception cref="ArgumentException">books</exception>
        public void WriteBooks(List<Book> books)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentNullException($"{nameof(filePath)} is null");
            }

            if (books == null)
            {
                throw new ArgumentNullException($"{nameof(books)} is null");
            }

            if (books.Count == 0)
            {
                throw new ArgumentException($"{nameof(books)} has 0 books");
            }

            BinaryWriterLocal(books);
        }

        /// <summary>
        /// Binaries the reader local.
        /// </summary>
        /// <returns>
        /// Copied collection of current storage.
        /// </returns>
        private List<Book> BinaryReaderLocal()
        {
            List<Book> bookStorage = new List<Book>();
            FileStream fileReaderStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            BinaryReader fileBinaryReader = new BinaryReader(fileReaderStream);
            for (int i = 0; i < fileReaderStream.Length; i++)
            {
                string isbn = fileBinaryReader.ReadString();
                string authorFirstName = fileBinaryReader.ReadString();
                string authorLastName = fileBinaryReader.ReadString();
                string title = fileBinaryReader.ReadString();
                int page = fileBinaryReader.ReadInt32();
                string publisher = fileBinaryReader.ReadString();
                int yearPublish = fileBinaryReader.ReadInt32();
                decimal price = fileBinaryReader.ReadDecimal();
                Book temp = new Book(isbn, authorFirstName, authorLastName, title, publisher, yearPublish, page, price);
                bookStorage.Add(temp);
            }

            fileBinaryReader.Dispose();
            fileReaderStream.Dispose();

            return bookStorage.ToList();
        }

        /// <summary>
        /// Binaries the writer local.
        /// </summary>
        /// <param name="books">The books.</param>
        private void BinaryWriterLocal(List<Book> books)
        {
            FileStream fileWriterStream = new FileStream(filePath, FileMode.OpenOrCreate);
            BinaryWriter fileBinaryWriter = new BinaryWriter(fileWriterStream);
            foreach (Book book in books)
            {
                fileBinaryWriter.Write(book.Isbn);
                fileBinaryWriter.Write(book.AuthorFirstName);
                fileBinaryWriter.Write(book.AuthorLastName);
                fileBinaryWriter.Write(book.Title);
                fileBinaryWriter.Write(book.Page);
                fileBinaryWriter.Write(book.Publisher);
                fileBinaryWriter.Write(book.YearPublish);
                fileBinaryWriter.Write(book.Price);
            }

            fileBinaryWriter.Dispose();
            fileWriterStream.Dispose();
        }
    }
}