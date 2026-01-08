using System;

class TicketNode
{
    public int id;
    public TicketNode next;

    public TicketNode(int id)
    {
        this.id = id;
    }
}

class TicketSystem
{
    TicketNode head;

    public void Book(int id)
    {
        TicketNode node = new TicketNode(id);

        if (head == null)
        {
            head = node;
            head.next = head;
            return;
        }

        TicketNode temp = head;
        while (temp.next != head)
            temp = temp.next;

        temp.next = node;
        node.next = head;
    }

    public void Display()
    {
        TicketNode temp = head;
        do
        {
            Console.WriteLine("Ticket ID: " + temp.id);
            temp = temp.next;
        }
        while (temp != head);
    }
}

class Program
{
    static void Main()
    {
        TicketSystem ts = new TicketSystem();
        ts.Book(501);
        ts.Book(502);
        ts.Display();
    }
}
