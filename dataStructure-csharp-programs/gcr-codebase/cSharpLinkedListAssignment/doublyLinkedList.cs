using System;

class MovieNode
{
    public string title;
    public MovieNode prev, next;

    public MovieNode(string title)
    {
        this.title = title;
    }
}

class MovieList
{
    MovieNode head;

    public void Add(string title)
    {
        MovieNode node = new MovieNode(title);

        if (head == null)
        {
            head = node;
            return;
        }

        MovieNode temp = head;
        while (temp.next != null)
            temp = temp.next;

        temp.next = node;
        node.prev = temp;
    }

    public void Display()
    {
        MovieNode temp = head;
        while (temp != null)
        {
            Console.WriteLine("Movie: " + temp.title);
            temp = temp.next;
        }
    }
}

class Program
{
    static void Main()
    {
        MovieList list = new MovieList();
        list.Add("Inception");
        list.Add("Interstellar");
        list.Display();
    }
}
