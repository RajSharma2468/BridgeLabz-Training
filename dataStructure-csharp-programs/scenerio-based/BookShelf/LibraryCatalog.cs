using System;
using System.Collections.Generic;
using BookShelf.Models;

namespace BookShelf.Library
{
    class LibraryCatalog
    {
        private Dictionary<string, LinkedList<Book>> catalog;
        private HashSet<Book> uniqueBooks;   // optional duplication check

        public LibraryCatalog()
        {
            catalog = new Dictionary<string, LinkedList<Book>>();
            uniqueBooks = new HashSet<Book>();
        }

        public void AddBook(string genre, Book book)
        {
            if (uniqueBooks.Contains(book))
            {
                Console.WriteLine("Duplicate book ignored: " + book.Title);
                return;
            }

            if (!catalog.ContainsKey(genre))
            {
                catalog[genre] = new LinkedList<Book>();
            }

            catalog[genre].AddLast(book);
            uniqueBooks.Add(book);

            Console.WriteLine("Book added: " + book.Title + " (" + genre + ")");
        }

        public void RemoveBook(string genre, Book book)
        {
            if (!catalog.ContainsKey(genre))
            {
                Console.WriteLine("Genre not found");
                return;
            }

            if (catalog[genre].Remove(book))
            {
                uniqueBooks.Remove(book);
                Console.WriteLine("Book removed: " + book.Title);
            }
            else
            {
                Console.WriteLine("Book not found in genre");
            }
        }

        public void DisplayCatalog()
        {
            Console.WriteLine("\n📚 Library Catalog:");

            foreach (var genre in catalog)
            {
                Console.WriteLine("\nGenre: " + genre.Key);
                foreach (var book in genre.Value)
                {
                    Console.WriteLine(" - " + book.Title + " by " + book.Author);
                }
            }
        }
    }
}
