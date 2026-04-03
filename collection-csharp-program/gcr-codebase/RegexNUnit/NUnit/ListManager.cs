using System;
using System.Collections.Generic;

class ListManager
{
    public void AddElement(List<int> list, int element)
    {
        list.Add(element);
    }

    public void RemoveElement(List<int> list, int element)
    {
        list.Remove(element);
    }

    public int GetSize(List<int> list)
    {
        return list.Count;
    }
}

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>();
        ListManager lm = new ListManager();

        lm.AddElement(numbers, 10);
        lm.AddElement(numbers, 20);
        lm.AddElement(numbers, 30);

        Console.WriteLine("Size after add: " + lm.GetSize(numbers));

        lm.RemoveElement(numbers, 20);
        Console.WriteLine("Size after remove: " + lm.GetSize(numbers));
    }
}
