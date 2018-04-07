using System;
using System.Collections.Generic;
using NET.S._2018.Dvorkin.Task1;
using System.Globalization;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book("123-4-5678-9101-1", "Author1", "Author 1", "title1", "publisher1", 2015, 123, 56.10m);
            
            Console.WriteLine(book1.ToString());
            Console.WriteLine(book1.ToString("AT", CultureInfo.CurrentCulture));
            Book book2 = new Book("123-4-5678-9101-2", "Author1", "Author1", "title2", "publisher2", 2015, 123, 78.10m);
            Book book3 = new Book("123-4-5678-9101-3", "Author2", "Author2", "title3", "publisher1", 2015, 123, 45.10m);
            List<Book> books = new List<Book> { book1, book2 };
            BookStorage bookStorage = new BookStorage(@"storage.bin");
            BookService bookService = new BookService(books, new Logger());
            WriteCui(bookService);
            bookService.AddBook(book3);
            WriteCui(bookService);
            bookService.WriteBooks(bookStorage, books);
            bookService.FindBookByTag(new AuthorNamePredicate("Author1"));
            bookService.DeleteBook(book1);
            WriteCui(bookService);

            Console.ReadKey();
        }

        private static void WriteCui(BookService service)
        {
            foreach (Book book in service)
            {
                Console.WriteLine(book.ToString());
            }
        }
    }

    public class AuthorNamePredicate : IPredicate<Book>
    {
        private string authorFirstName;

        public AuthorNamePredicate(string authorFirstName)
        {
            this.authorFirstName = authorFirstName;
        }

        public bool Find(Book predicate)
        {
            return predicate.AuthorFirstName == authorFirstName;
        }
    }
}
