using System;

class Stack
{
    int[] arr = new int[100];
    int top = -1;

    public void Push(int x)
    {
        arr[++top] = x;
    }

    public int Pop()
    {
        return arr[top--];
    }

    public bool IsEmpty()
    {
        return top == -1;
    }
}

class QueueUsingStacks
{
    static Stack s1 = new Stack();
    static Stack s2 = new Stack();

    static void Enqueue(int x)
    {
        s1.Push(x);
    }

    static int Dequeue()
    {
        if (s2.IsEmpty())
        {
            while (!s1.IsEmpty())
                s2.Push(s1.Pop());
        }
        return s2.Pop();
    }

    static void Main()
    {
        Enqueue(10);
        Enqueue(20);
        Enqueue(30);

        Console.WriteLine(Dequeue());
        Console.WriteLine(Dequeue());
    }
}
