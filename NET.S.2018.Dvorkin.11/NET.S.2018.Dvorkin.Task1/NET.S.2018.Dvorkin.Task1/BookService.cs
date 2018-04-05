using System;
using System.Collections.Generic;
using System.Linq;

namespace NET.S._2018.Dvorkin.Task1
{
    /// <summary>
    /// Contains method for services for a book.
    /// </summary>
    public class BookService
    {
        /// <summary>
        /// The books
        /// </summary>
        private List<Book> books = new List<Book>();

        /// <summary>
        /// Initializes a new instance of the <see cref="BookService"/> class.
        /// </summary>
        public BookService()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookService"/> class.
        /// </summary>
        /// <param name="books">The books.</param>
        public BookService(List<Book> books)
        {
            this.books = books.ToList();
            ////this.books = books;
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
        /// <param name="filePath">The file path.</param>
        /// <returns>Copy of current collection</returns>
        /// <exception cref="ArgumentNullException">storage</exception>
        public List<Book> ReadBooks(Storage storage, string filePath)
        {
            if (storage == null)
            {
                throw new ArgumentNullException($"{nameof(storage)} is null");
            }

            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentNullException($"{nameof(storage)} is null");
            }
            
            this.books = storage.ReadBooks(filePath);

            return this.books.ToList();
        }

        /// <summary>
        /// Writes the books.
        /// </summary>
        /// <param name="storage">The storage.</param>
        /// <param name="filePath">The file path.</param>
        /// <exception cref="ArgumentNullException">
        /// storage in null
        /// or
        /// filePath is null or empty
        /// </exception>
        public void WriteBooks(Storage storage, string filePath)
        {
            if (storage == null)
            {
                throw new ArgumentNullException($"{nameof(storage)} is null");
            }

            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentNullException($"{nameof(filePath)} is null");
            }

            storage.WriteBooks(filePath, this.books);
        }

        /// <summary>
        /// Adds the book.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <returns>Copy of the current collection of books after adding the book</returns>
        /// <exception cref="ArgumentNullException">book</exception>
        /// <exception cref="ArgumentException">book</exception>
        public List<Book> AddBook(Book book)
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

            return this.books.ToList();
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
        public List<Book> DeleteBook(Book book)
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

            return this.books.ToList();
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
                    this.Swap(i);
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

            this.books.Sort(tagComparer);
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
        /// <param name="tag">The tag.</param>
        /// <param name="tagFinder">The tag finder.</param>
        /// <returns>Founded book.</returns>
        /// <exception cref="ArgumentNullException">
        /// tagFinder is null
        /// or
        /// tag is null or empty.
        /// </exception>
        /// <exception cref="ArgumentException">books</exception>
        public Book FindBookByTag(string tag, IFinder tagFinder)
        {
            if (tagFinder == null)
            {
                throw new ArgumentNullException($"{nameof(tagFinder)} is null");
            }

            if (this.books.Count == 0)
            {
                throw new ArgumentException($"{nameof(books)} has 0 elements");
            }

            if (string.IsNullOrWhiteSpace(tag))
            {
                throw new ArgumentNullException($"{nameof(tag)} is null");
            }

            return tagFinder.Find(tag);
        }

        /// <summary>
        /// Copies the books.
        /// </summary>
        /// <returns>Copied list of current books collection.</returns>
        private List<Book> CopyBooks()
        {
            Book[] temp = new Book[this.books.Count];
            this.books.CopyTo(temp);

            return temp.ToList();
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
