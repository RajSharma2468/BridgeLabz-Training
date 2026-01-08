using System;

class BookNode
{
    public string title;
    public BookNode prev, next;

    public BookNode(string title)
    {
        this.title = title;
    }
}

class Library
{
    BookNode head;

    public void Add(string title)
    {
        BookNode node = new BookNode(title);

        if (head != null)
        {
            node.next = head;
            head.prev = node;
        }
        head = node;
    }

    public void Display()
    {
        BookNode temp = head;
        while (temp != null)
        {
            Console.WriteLine("Book: " + temp.title);
            temp = temp.next;
        }
    }
}

class Program
{
    static void Main()
    {
        Library lib = new Library();
        lib.Add("C#");
        lib.Add("DSA");
        lib.Display();
    }
}
