using System;

class Book
{
    public string title;
    public string author;
    public bool isAvailable;

    public Book(string title, string author)
    {
        this.title = title;
        this.author = author;
        isAvailable = true;
    }
}

class Library
{
    Book[] books;
    int bookCount;

    public Library(int size)
    {
        books = new Book[size];
        bookCount = 0;
    }

    public void addBook(Book book)
    {
        books[bookCount] = book;
        bookCount++;
    }

    public void displayBooks()
    {
        for (int i = 0; i < bookCount; i++)
        {
            Console.WriteLine(
                books[i].title + " | " +
                books[i].author + " | " +
                (books[i].isAvailable ? "Available" : "Checked Out")
            );
        }
    }

    public void searchByTitle(string key)
    {
        for (int i = 0; i < bookCount; i++)
        {
            if (isPartialMatch(books[i].title, key))
            {
                Console.WriteLine(
                    books[i].title + " | " +
                    books[i].author + " | " +
                    (books[i].isAvailable ? "Available" : "Checked Out")
                );
            }
        }
    }

    public void checkoutBook(string title)
    {
        for (int i = 0; i < bookCount; i++)
        {
            if (isSameText(books[i].title, title))
            {
                if (books[i].isAvailable)
                {
                    books[i].isAvailable = false;
                    Console.WriteLine("Book checked out");
                }
                else
                {
                    Console.WriteLine("Book already checked out");
                }
                return;
            }
        }
        Console.WriteLine("Book not found");
    }

    bool isPartialMatch(string text, string key)
    {
        for (int i = 0; i <= text.Length - key.Length; i++)
        {
            int j = 0;
            while (j < key.Length && toLower(text[i + j]) == toLower(key[j]))
                j++;

            if (j == key.Length) return true;
        }
        return false;
    }

    bool isSameText(string a, string b)
    {
        if (a.Length != b.Length) return false;

        for (int i = 0; i < a.Length; i++)
            if (toLower(a[i]) != toLower(b[i])) return false;

        return true;
    }

    char toLower(char c)
    {
        if (c >= 'A' && c <= 'Z') return (char)(c + 32);
        return c;
    }
}

class Program
{
    static void Main()
    {
        Library library = new Library(5);

        library.addBook(new Book("C Sharp Programming", "John"));
        library.addBook(new Book("Java Basics", "James"));
        library.addBook(new Book("Python Guide", "Ross"));

        Console.WriteLine("All Books:");
        library.displayBooks();

        Console.WriteLine("\nSearch Result:");
        library.searchByTitle("Pro");

        Console.WriteLine("\nCheckout Book:");
        library.checkoutBook("Java Basics");

        Console.WriteLine("\nUpdated Book List:");
        library.displayBooks();
    }
}
