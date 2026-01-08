using System;

class ItemNode
{
    public int id;
    public int qty;
    public double price;
    public ItemNode next;

    public ItemNode(int id, int qty, double price)
    {
        this.id = id;
        this.qty = qty;
        this.price = price;
    }
}

class Inventory
{
    ItemNode head;

    public void Add(int id, int qty, double price)
    {
        ItemNode node = new ItemNode(id, qty, price);
        node.next = head;
        head = node;
    }

    public void Display()
    {
        ItemNode temp = head;
        while (temp != null)
        {
            Console.WriteLine(
                "ID: " + temp.id +
                " Quantity: " + temp.qty +
                " Price: " + temp.price
            );
            temp = temp.next;
        }
    }
}

class Program
{
    static void Main()
    {
        Inventory inv = new Inventory();
        inv.Add(1, 10, 50);
        inv.Add(2, 5, 100);
        inv.Display();
    }
}
