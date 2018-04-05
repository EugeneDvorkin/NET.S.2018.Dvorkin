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
    public class BookStorage : Storage
    {
        /// <summary>
        /// The book storage
        /// </summary>
        private List<Book> bookStorage;

        /// <summary>
        /// Gets the books storage.
        /// </summary>
        /// <value>
        /// The books storage.
        /// </value>
        /// <exception cref="ArgumentNullException">bookStorage</exception>
        public List<Book> BooksStorage
        {
            get
            {
                if (bookStorage.Count == 0 || bookStorage == null)
                {
                    throw new ArgumentNullException($"{nameof(bookStorage)} is null or empty");
                }

                return bookStorage.ToList();
            }
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
        public override List<Book> ReadBooks(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentNullException($"{nameof(filePath)} is null");
            }

            if (!File.Exists(filePath))
            {
                throw new IOException($"{nameof(filePath)} doesn't exist");
            }

            return BinaryReaderLocal(filePath);
        }

        /// <summary>
        /// Reads the books.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="storage">The storage.</param>
        /// <param name="logger">The logger.</param>
        /// <returns>
        /// Copy of the current collection of the books.
        /// </returns>
        /// <exception cref="ArgumentNullException">filePath is null or empty
        /// or
        /// storage is null.</exception>
        /// <exception cref="ArgumentException">filePath</exception>
        /// <exception cref="CustomException">
        /// There is no such storage
        /// or
        /// The path is wrong
        /// </exception>
        /// <exception cref="StackTrace">
        /// </exception>
        public List<Book> ReadBooks(string filePath, IStream storage, ILogger logger)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(filePath))
                {
                    throw new ArgumentNullException($"{nameof(filePath)} is null");
                }

                if (storage == null)
                {
                    throw new ArgumentNullException($"{nameof(storage)} is null");
                }

                if (!File.Exists(filePath))
                {
                    throw new ArgumentException($"{nameof(filePath)} doesn't exist");
                }

                bookStorage = storage.ReadBooks(filePath);

                return bookStorage.ToList();
            }
            catch (IOException e)
            {
                logger.Log(e, $"{nameof(filePath)} doesn't exist", LogLevel.Fatal);
                throw new CustomException(e, new StackTrace(e), "There is no such storage");
            }
            catch (ArgumentNullException e)
            {
                logger.Log(e, $"{nameof(filePath)} is null", LogLevel.Error);
                throw new CustomException(e, new StackTrace(e), "The path is wrong");
            }
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
        public override void WriteBooks(string filePath, List<Book> books)
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

            BinaryWriterLocal(filePath, books);
        }

        /// <summary>
        /// Writes the books.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="books">The books.</param>
        /// <param name="storage">The storage.</param>
        /// <param name="logger">The logger.</param>
        /// <exception cref="IOException">filePath</exception>
        /// <exception cref="ArgumentNullException">filePath is null or empty
        /// or
        /// books is null
        /// or
        /// storage is null</exception>
        /// <exception cref="ArgumentException">books has 0 elements</exception>
        /// <exception cref="CustomException">
        /// There is no such storage
        /// or
        /// There is no books in the storage
        /// or
        /// There is no such storage
        /// </exception>
        /// <exception cref="StackTrace">
        /// </exception>
        public void WriteBooks(string filePath, List<Book> books, IStream storage, ILogger logger)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(filePath))
                {
                    throw new IOException($"{nameof(filePath)} is null");
                }

                if (books == null)
                {
                    throw new ArgumentNullException($"{nameof(books)} is null");
                }

                if (books.Count == 0)
                {
                    throw new ArgumentException($"{nameof(books)} has 0 books");
                }

                if (storage == null)
                {
                    throw new ArgumentNullException($"{nameof(storage)} is null");
                }

                storage.WriteBooks(filePath, books);
            }
            catch (IOException e)
            {
                logger.Log(e, $"{nameof(filePath)} doesn't exist", LogLevel.Fatal);
                throw new CustomException(e, new StackTrace(e), "There is no such storage");
            }
            catch (ArgumentNullException e) when (e.ParamName == books.ToString())
            {
                logger.Log(e, $"{nameof(books)} is null", LogLevel.Error);
                throw new CustomException(e, new StackTrace(e), "There is no books in the storage");
            }
            catch (ArgumentNullException e) when (e.ParamName == storage.ToString())
            {
                logger.Log(e, $"{nameof(books)} is null", LogLevel.Fatal);
                throw new CustomException(e, new StackTrace(e), "There is no such storage");
            }
        }

        /// <summary>
        /// Copies the current collection of the books.
        /// </summary>
        /// <returns>New temporary collection of current book's storage.</returns>
        private List<Book> CopyBookstorage()
        {
            Book[] temp = new Book[bookStorage.Count];
            bookStorage.CopyTo(temp);

            return temp.ToList();
        }

        /// <summary>
        /// Binaries the reader local.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>Copied collection of current storage.</returns>
        private List<Book> BinaryReaderLocal(string filePath)
        {
            FileStream fileReaderStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            BinaryReader fileBinaryReader = new BinaryReader(fileReaderStream);
            for (int i = 0; i < fileReaderStream.Length; i++)
            {
                Book temp = new Book
                {
                    Isbn = fileBinaryReader.ReadString(),
                    AuthorFirstName = fileBinaryReader.ReadString(),
                    AuthorLastName = fileBinaryReader.ReadString(),
                    Title = fileBinaryReader.ReadString(),
                    Page = fileBinaryReader.ReadInt32(),
                    Publisher = fileBinaryReader.ReadString(),
                    YearPublish = fileBinaryReader.ReadInt32(),
                    Price = fileBinaryReader.ReadDecimal()
                };
                bookStorage.Add(temp);
            }

            fileBinaryReader.Dispose();
            fileReaderStream.Dispose();

            return bookStorage.ToList();
        }

        /// <summary>
        /// Binaries the writer local.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="books">The books.</param>
        private void BinaryWriterLocal(string filePath, List<Book> books)
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
