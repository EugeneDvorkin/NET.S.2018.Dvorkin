using System;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace NET.S._2018.Dvorkin.Task1
{
    /// <summary>
    /// Contains the definitions of the book entity.
    /// </summary>
    /// <seealso cref="System.IComparable" />
    /// <seealso cref="Book" />
    /// <seealso cref="Book" />
    public class Book : IComparable, IComparable<Book>, IEquatable<Book>, IFormattable
    {
        /// <summary>
        /// The ISBN
        /// </summary>
        private string isbn;

        /// <summary>
        /// The author first name
        /// </summary>
        private string authorFirstName;

        /// <summary>
        /// The author last name
        /// </summary>
        private string authorLastName;

        /// <summary>
        /// The title
        /// </summary>
        private string title;

        /// <summary>
        /// The publisher
        /// </summary>
        private string publisher;

        /// <summary>
        /// The year publish
        /// </summary>
        private int yearPublish;

        /// <summary>
        /// The page
        /// </summary>
        private int page;

        /// <summary>
        /// The price
        /// </summary>
        private decimal price;

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        public Book()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        /// <param name="isbn">The ISBN.</param>
        /// <param name="authorFirstName">First name of the author.</param>
        /// <param name="authorLastName">Last name of the author.</param>
        /// <param name="title">The title.</param>
        /// <param name="publisher">The publisher.</param>
        /// <param name="yearPublish">The year of the publish.</param>
        /// <param name="page">The count of pages.</param>
        /// <param name="price">The price.</param>
        public Book(string authorFirstName, string title)
        {
            this.AuthorFirstName = authorFirstName;
            this.Title = title;
        }

        /// <summary>
        /// Gets or sets the ISBN.
        /// </summary>
        /// <value>
        /// The ISBN.
        /// </value>
        /// <exception cref="ArgumentException">value</exception>
        public string Isbn
        {
            get => this.isbn;
            private set
            {
                Regex isbnRegex = new Regex("^[0-9]{3}[-][0-9]{1}[-][0-9]{4}[-][0-9]{4}[-][0-9]{1}$");
                if (isbnRegex.IsMatch(value) == false)
                {
                    throw new ArgumentException($"{nameof(value)} doesn't match the rules");
                }

                this.isbn = value;
            }
        }

        /// <summary>
        /// Gets or sets the first name of the author.
        /// </summary>
        /// <value>
        /// The first name of the author.
        /// </value>
        /// <exception cref="ArgumentException">value</exception>
        public string AuthorFirstName
        {
            get => this.authorFirstName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"{nameof(value)} is null");
                }

                this.authorFirstName = value;
            }
        }

        /// <summary>
        /// Gets or sets the last name of the author.
        /// </summary>
        /// <value>
        /// The last name of the author.
        /// </value>
        /// <exception cref="ArgumentException">value</exception>
        public string AuthorLastName
        {
            get => this.authorLastName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"{nameof(value)} is null");
                }

                this.authorLastName = value;
            }
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        /// <exception cref="ArgumentNullException">value</exception>
        public string Title
        {
            get => this.title;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException($"{nameof(value)} is null");
                }

                this.title = value;
            }
        }

        /// <summary>
        /// Gets or sets the publisher.
        /// </summary>
        /// <value>
        /// The publisher.
        /// </value>
        public string Publisher
        {
            get => this.publisher;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException($"{nameof(value)} is null");
                }

                this.publisher = value;
            }
        }

        /// <summary>
        /// Gets or sets the year of the publish.
        /// </summary>
        /// <value>
        /// The year of the publish.
        /// </value>
        /// <exception cref="ArgumentOutOfRangeException">value</exception>
        public int YearPublish
        {
            get => this.yearPublish;
            private set
            {
                if (value < 0 || value > DateTime.Now.Year)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(value)} can't be publish at this value");
                }

                this.yearPublish = value;
            }
        }

        /// <summary>
        /// Gets or sets the count of pages.
        /// </summary>
        /// <value>
        /// The count of pages.
        /// </value>
        /// <exception cref="ArgumentException">value</exception>
        public int Page
        {
            get => this.page;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{nameof(value)} is less than 0");
                }

                this.page = value;
            }
        }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        /// <exception cref="ArgumentException">value</exception>
        public decimal Price
        {
            get => this.price;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{nameof(value)} is less than 0");
                }

                this.price = value;
            }
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="book1">The book1.</param>
        /// <param name="book2">The book2.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(Book book1, Book book2) => Equals(book1, book2);

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="book1">The book1.</param>
        /// <param name="book2">The book2.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(Book book1, Book book2) => !Equals(book1, book2);

        /// <summary>
        /// Equals the specified temporary.
        /// </summary>
        /// <param name="temp">The temporary.</param>
        /// <returns>
        ///     <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(Book temp)
        {
            if (ReferenceEquals(temp, null))
            {
                return false;
            }

            if (ReferenceEquals(this, temp))
            {
                return true;
            }

            if (this.Isbn == temp.Isbn && this.AuthorFirstName == temp.AuthorFirstName && this.AuthorLastName == temp.AuthorLastName
                && this.Title == temp.Title && this.Publisher == temp.Publisher && this.YearPublish == temp.YearPublish &&
                this.Page == temp.Page && this.Price == temp.Price)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj.GetType(), typeof(Book)))
            {
                return this.Equals(obj);
            }

            return false;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return this.ToString("G", CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="other">An object to compare with this instance.</param>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance precedes <paramref name="other" /> in the sort order.  Zero This instance occurs in the same position in the sort order as <paramref name="other" />. Greater than zero This instance follows <paramref name="other" /> in the sort order.
        /// </returns>
        /// <exception cref="ArgumentNullException">other</exception>
        public int CompareTo(Book other)
        {
            if (ReferenceEquals(other, null))
            {
                throw new ArgumentNullException($"{nameof(other)} is null");
            }

            return (int)(this.Price - other.Price);
        }

        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance precedes <paramref name="obj" /> in the sort order. Zero This instance occurs in the same position in the sort order as <paramref name="obj" />. Greater than zero This instance follows <paramref name="obj" /> in the sort order.
        /// </returns>
        /// <exception cref="ArgumentNullException">obj</exception>
        /// <exception cref="ArgumentException">obj</exception>
        public int CompareTo(object obj)
        {
            if (ReferenceEquals(obj, null))
            {
                throw new ArgumentNullException($"{nameof(obj)} is null");
            }

            if (ReferenceEquals(obj.GetType(), typeof(Book)) == false)
            {
                throw new ArgumentException($"{nameof(obj)} is not a Book");
            }

            return this.CompareTo((Book)obj);
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// formatProvider is null
        /// or
        /// format is null or empty
        /// </exception>
        /// <exception cref="FormatException">format</exception>
        /// <exception cref="NotImplementedException"></exception>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (ReferenceEquals(formatProvider, null))
            {
                throw new ArgumentNullException($"{nameof(formatProvider)} is null");
            }

            if (string.IsNullOrWhiteSpace(format))
            {
                throw new ArgumentNullException($"{nameof(format)} is null or empty");
            }

            StringFormat stringFormat;
            StringBuilder result = new StringBuilder();
            if (!Enum.TryParse<StringFormat>(format.ToUpper(), out stringFormat))
            {
                throw new FormatException($"Invalid format {nameof(format)}");
            }

            switch (stringFormat)
            {
                case StringFormat.AT:
                    {
                        return result.Append($"Author - {AuthorFirstName} {this.AuthorLastName}. Title - {this.Title}.").ToString();
                    }

                case StringFormat.ATP:
                    {
                        return result.Append($"Author - {AuthorFirstName} {this.AuthorLastName}. Title - {this.Title}. Publisher - {this.Publisher}. Year of publish - {this.YearPublish}.").ToString();
                    }

                case StringFormat.IATPYP:
                    {
                        return result.Append($"ISBN - {this.Isbn}. Author - {AuthorFirstName} {this.AuthorLastName}. Title - {this.Title}. Publisher - {this.Publisher}." +
                                             $"Year of publish - {this.YearPublish}. Count of page - {this.Page}.").ToString();
                    }

                case StringFormat.IATPYPP:
                    {
                        return result.Append(
                            $"ISBN - {this.Isbn}. Title - {this.Title}. Author - {this.AuthorFirstName} {this.AuthorLastName}. " +
                            $"Publisher - {this.Publisher}.  Year of publish - {this.YearPublish}." +
                            $"Count of page - {this.Page}. Price - {this.Price}").ToString();
                    }

                case StringFormat.G:
                    {
                        return result.Append(
                            $"ISBN - {this.Isbn}. Title - {this.Title}. Author - {this.AuthorFirstName} {this.AuthorLastName}.").ToString();
                    }

                default:
                    {
                        return result.Append($"Title - {this.Title}. Author - {this.AuthorFirstName} {this.AuthorLastName}.")
                            .ToString();
                    }
            }
        }
    }
}
