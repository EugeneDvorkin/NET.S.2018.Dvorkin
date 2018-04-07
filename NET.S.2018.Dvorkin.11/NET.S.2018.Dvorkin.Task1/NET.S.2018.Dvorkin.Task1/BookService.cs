using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace NET.S._2018.Dvorkin.Task1
{
    /// <summary>
    /// Contains method for services for a book.
    /// </summary>
    public class BookService : IEnumerable<Book>
    {
        /// <summary>
        /// The books
        /// </summary>
        private List<Book> books = new List<Book>();

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookService"/> class.
        /// </summary>
        public BookService()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookService" /> class.
        /// </summary>
        /// <param name="books">The books.</param>
        /// <param name="logger">The logger.</param>
        /// <exception cref="System.ArgumentNullException">
        /// books
        /// or
        /// logger
        /// </exception>
        public BookService(List<Book> books, ILogger logger)
        {
            this.books = books ?? throw new ArgumentNullException($"{nameof(books)} is null");
            this.logger = logger ?? throw new ArgumentNullException($"{nameof(logger)} is null");
        }

        /// <summary>
        /// Gets the books.
        /// </summary>
        /// <value>
        /// The books.
        /// </value>
        public List<Book> Books => this.books.ToList();

        /// <summary>
        /// Reads the books.
        /// </summary>
        /// <param name="storage">The storage.</param>
        /// <returns>
        /// Copy of current collection
        /// </returns>
        /// <exception cref="ArgumentNullException">storage</exception>
        /// <exception cref="CustomException">There is no such storage</exception>
        /// <exception cref="StackTrace"></exception>
        public IEnumerable<Book> ReadBooks(IStogare storage)
        {
            if (storage == null)
            {
                throw new ArgumentNullException($"{nameof(storage)} is null");
            }

            try
            {
                this.books = storage.ReadBooks();
            }
            catch (IOException e)
            {
                logger.Log(e, e.Message, LogLevel.Fatal);
                throw new CustomException(e, new StackTrace(e), "There is no such storage");
            }

            return this.books.ToList();
        }

        /// <summary>
        /// Writes the books.
        /// </summary>
        /// <param name="storage">The storage.</param>
        /// <param name="books">The books.</param>
        /// <exception cref="ArgumentNullException">storage in null
        /// or
        /// filePath is null or empty</exception>
        /// <exception cref="CustomException">There is no such storage</exception>
        /// <exception cref="StackTrace"></exception>
        public void WriteBooks(IStogare storage, IEnumerable<Book> books)
        {
            if (storage == null)
            {
                throw new ArgumentNullException($"{nameof(storage)} is null");
            }

            try
            {
                storage.WriteBooks(books.ToList());
            }
            catch (IOException e)
            {
                logger.Log(e, e.Message, LogLevel.Fatal);
                throw new CustomException(e, new StackTrace(e), "There is no such storage");
            }
        }

        /// <summary>
        /// Adds the book.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <returns>Copy of the current collection of books after adding the book</returns>
        /// <exception cref="ArgumentNullException">book</exception>
        /// <exception cref="ArgumentException">book</exception>
        public void AddBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException($"{nameof(book)} is null");
            }

            if (this.books.Contains(book))
            {
                throw new ArgumentException($"{nameof(book)} has been already added in the collection");
            }

            this.books.Add(book);
        }

        /// <summary>
        /// Deletes the book.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <returns>Copy of the current collection of books after deleting the book.</returns>
        /// <exception cref="ArgumentNullException">
        /// book
        /// or
        /// </exception>
        /// <exception cref="ArgumentException">book</exception>
        public void DeleteBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException($"{nameof(book)} is null");
            }

            if (this.books.Count == 0)
            {
                throw new ArgumentNullException($"There is no book in the collection");
            }

            if (!this.books.Contains(book))
            {
                throw new ArgumentException($"There is no such a {nameof(book)} in the collection");
            }

            this.books.Remove(book);
        }

        /// <summary>
        /// Sorts the book by tag.
        /// </summary>
        /// <exception cref="ArgumentNullException">books</exception>
        public void SortBookByTag()
        {
            if (this.books.Count == 0)
            {
                throw new ArgumentNullException($"{nameof(this.books)} is null or has 0 elements");
            }

            for (int i = 0; i < this.books.Count - 1; i++)
            {
                if (this.books[i].CompareTo(this.books[i + 1]) > 0)
                {
                    Swap(i);
                }
            }
        }

        /// <summary>
        /// Sorts the book by tag.
        /// </summary>
        /// <param name="tagComparer">The tag comparer.</param>
        /// <exception cref="ArgumentNullException">tagComparer</exception>
        public void SortBookByTag(IComparer<Book> tagComparer)
        {
            if (this.books.Count == 0)
            {
                throw new ArgumentNullException($"{nameof(books)} is null or has 0 elements");
            }

            if (tagComparer == null)
            {
                throw new ArgumentNullException($"{nameof(tagComparer)} is null");
            }

            for (int i = 0; i < books.Count - 1; i++)
            {
                if (tagComparer.Compare(books[i], books[i + 1]) > 0)
                {
                    Swap(i);
                }
            }
        }

        /// <summary>
        /// Finds the book by tag.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <returns>Founded book.</returns>
        /// <exception cref="ArgumentNullException">
        /// title is null or empty
        /// or
        /// title hasn't been founded.
        /// </exception>
        /// <exception cref="ArgumentException">books</exception>
        public Book FindBookByTag(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException($"{nameof(title)} is null");
            }

            if (this.books.Count == 0)
            {
                throw new ArgumentException($"{nameof(this.books)} has 0 elements");
            }

            foreach (Book book in this.books)
            {
                if (book.Title == title)
                {
                    return book;
                }
            }

            throw new ArgumentNullException($"There is no book with such {nameof(title)}");
        }


        /// <summary>
        /// Finds the book by tag.
        /// </summary>
        /// <param name="tagPredicate">The tag predicate.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">tagPredicate</exception>
        /// <exception cref="System.ArgumentException">
        /// books count is 0
        /// or
        /// tagPredicate can't find such book.
        /// </exception>
        public Book FindBookByTag(IPredicate<Book> tagPredicate)
        {
            if (tagPredicate == null)
            {
                throw new ArgumentNullException($"{nameof(tagPredicate)} is null");
            }

            if (this.books.Count == 0)
            {
                throw new ArgumentException($"{nameof(books)} has 0 elements");
            }

            foreach (Book book in books)
            {
                if (tagPredicate.Find(book))
                {
                    return book;
                }
            }

            throw new ArgumentException($"{nameof(tagPredicate)} can't find such book");
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// An enumerator that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<Book> GetEnumerator()
        {
            return books.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)books).GetEnumerator();
        }

        /// <summary>
        /// Swaps the elements in the collection of the books by counter.
        /// </summary>
        /// <param name="i">The counter.</param>
        /// <exception cref="ArgumentException">i</exception>
        private void Swap(int i)
        {
            if (i < 0)
            {
                throw new ArgumentException($"{nameof(i)} is less than 0");
            }

            Book temp = this.books[i];
            this.books[i] = this.books[i + 1];
            this.books[i + 1] = temp;
        }


    }
}
