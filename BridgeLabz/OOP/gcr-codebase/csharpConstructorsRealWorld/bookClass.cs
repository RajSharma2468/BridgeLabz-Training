using System;

class Book
{
    public string title;
    public string author;
    public double price;

    // Default Constructor
    public Book()
    {
        title = "Unknown";
        author = "Unknown";
        price = 0;
    }

    // Parameterized Constructor
    public Book(string title, string author, double price)
    {
        this.title = title;
        this.author = author;
        this.price = price;
    }

    public void Display()
    {
        Console.WriteLine("Title: " + title);
        Console.WriteLine("Author: " + author);
        Console.WriteLine("Price: " + price);
    }
}

class Program
{
    static void Main()
    {
        Book b1 = new Book();
        b1.Display();

        Book b2 = new Book("C# Basics", "John", 350);
        b2.Display();
    }
}
