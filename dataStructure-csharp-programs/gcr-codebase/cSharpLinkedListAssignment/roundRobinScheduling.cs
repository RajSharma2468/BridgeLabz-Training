using System;

class ProcessNode
{
    public int pid;
    public ProcessNode next;

    public ProcessNode(int pid)
    {
        this.pid = pid;
    }
}

class RoundRobin
{
    ProcessNode head;

    public void Add(int pid)
    {
        ProcessNode node = new ProcessNode(pid);

        if (head == null)
        {
            head = node;
            head.next = head;
            return;
        }

        ProcessNode temp = head;
        while (temp.next != head)
            temp = temp.next;

        temp.next = node;
        node.next = head;
    }

    public void Display()
    {
        ProcessNode temp = head;
        do
        {
            Console.WriteLine("Process ID: " + temp.pid);
            temp = temp.next;
        }
        while (temp != head);
    }
}

class Program
{
    static void Main()
    {
        RoundRobin rr = new RoundRobin();
        rr.Add(1);
        rr.Add(2);
        rr.Display();
    }
}
