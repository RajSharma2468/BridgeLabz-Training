using System;

class Book
{
    public string title;
    public string author;
    public double price;
    public bool available;

    public Book(string title, string author, double price)
    {
        this.title = title;
        this.author = author;
        this.price = price;
        available = true;
    }

    public void BorrowBook()
    {
        if (available)
        {
            available = false;
            Console.WriteLine("Book borrowed successfully");
        }
        else
        {
            Console.WriteLine("Book is not available");
        }
    }

    public void Display()
    {
        Console.WriteLine("Title: " + title);
        Console.WriteLine("Author: " + author);
        Console.WriteLine("Price: " + price);
        Console.WriteLine("Available: " + available);
    }
}

class Program
{
    static void Main()
    {
        Book b = new Book("C# Guide", "John", 400);
        b.Display();
        b.BorrowBook();
        b.Display();
    }
}
