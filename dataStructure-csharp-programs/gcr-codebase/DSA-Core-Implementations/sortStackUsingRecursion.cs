using System;

class Stack
{
    public int[] arr = new int[100];
    public int top = -1;

    public void Push(int x)
    {
        top++;
        arr[top] = x;
    }

    public int Pop()
    {
        int value = arr[top];
        top--;
        return value;
    }

    public int Peek()
    {
        return arr[top];
    }

    public bool IsEmpty()
    {
        if (top == -1)
            return true;
        else
            return false;
    }
}

class SortStackUsingRecursion
{
    static void InsertSorted(Stack s, int x)
    {
        if (s.IsEmpty() || x > s.Peek())
        {
            s.Push(x);
            return;
        }

        int temp = s.Pop();
        InsertSorted(s, x);
        s.Push(temp);
    }

    static void Sort(Stack s)
    {
        if (!s.IsEmpty())
        {
            int x = s.Pop();
            Sort(s);
            InsertSorted(s, x);
        }
    }

    static void Main()
    {
        Stack s = new Stack();
        s.Push(3);
        s.Push(1);
        s.Push(4);
        s.Push(2);

        Sort(s);

        Console.WriteLine("Sorted Stack:");
        while (!s.IsEmpty())
        {
            Console.WriteLine(s.Pop());
        }
    }
}
