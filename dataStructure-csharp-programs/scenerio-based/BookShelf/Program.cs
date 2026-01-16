using System;
using BookShelf.Models;
using BookShelf.Library;

namespace BookShelf
{
    class Program
    {
        static void Main()
        {
            LibraryCatalog library = new LibraryCatalog();

            Book b1 = new Book("Clean Code", "Robert Martin");
            Book b2 = new Book("The Pragmatic Programmer", "Andrew Hunt");
            Book b3 = new Book("Harry Potter", "J.K. Rowling");

            library.AddBook("Programming", b1);
            library.AddBook("Programming", b2);
            library.AddBook("Fiction", b3);
            library.AddBook("Programming", b1); // duplicate

            library.DisplayCatalog();

            Console.WriteLine("\nBorrowing a book...");
            library.RemoveBook("Programming", b1);

            library.DisplayCatalog();
        }
    }
}
