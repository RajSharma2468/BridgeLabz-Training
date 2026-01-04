using System;

class Book
{
    public static string LibraryName = "Central Library";

    public string title;
    public string author;
    public readonly string isbn;

    public Book(string title, string author, string isbn)
    {
        this.title = title;
        this.author = author;
        this.isbn = isbn;
    }

    public static void DisplayLibraryName()
    {
        Console.WriteLine("Library Name: " + LibraryName);
    }

    public void DisplayDetails(object obj)
    {
        if (obj is Book)
        {
            Console.WriteLine("Title: " + title);
            Console.WriteLine("Author: " + author);
            Console.WriteLine("ISBN: " + isbn);
        }
    }
}

class Program
{
    static void Main()
    {
        Book b = new Book("C# Basics", "John", "ISBN123");
        Book.DisplayLibraryName();
        b.DisplayDetails(b);
    }
}
