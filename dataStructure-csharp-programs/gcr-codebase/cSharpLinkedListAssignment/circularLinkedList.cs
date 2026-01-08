using System;

class TaskNode
{
    public int id;
    public TaskNode next;

    public TaskNode(int id)
    {
        this.id = id;
    }
}

class TaskScheduler
{
    TaskNode head;

    public void Add(int id)
    {
        TaskNode node = new TaskNode(id);

        if (head == null)
        {
            head = node;
            head.next = head;
            return;
        }

        TaskNode temp = head;
        while (temp.next != head)
            temp = temp.next;

        temp.next = node;
        node.next = head;
    }

    public void Display()
    {
        TaskNode temp = head;
        do
        {
            Console.WriteLine("Task ID: " + temp.id);
            temp = temp.next;
        }
        while (temp != head);
    }
}

class Program
{
    static void Main()
    {
        TaskScheduler ts = new TaskScheduler();
        ts.Add(101);
        ts.Add(102);
        ts.Display();
    }
}
