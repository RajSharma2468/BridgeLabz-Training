using System;

class Book
{
    public string title;
    public string author;
    public double price;

    public void DisplayBookDetails()
    {
        Console.WriteLine("Book Title: " + title);
        Console.WriteLine("Author Name: " + author);
        Console.WriteLine("Book Price: " + price);
    }
}

class Program
{
    static void Main()
    {
        Book b = new Book();

        b.title = "C# Programming";
        b.author = "John Smith";
        b.price = 399.50;

        b.DisplayBookDetails();
    }
}
