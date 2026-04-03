// Use TreeSet for ordered data retrieval
//  In C#: SortedSet (TreeSet equivalent)

using System;
using System.Collections.Generic;

class TreeSetExample
{
    static void Main()
    {
        SortedSet<int> numbers = new SortedSet<int>();

        numbers.Add(40);
        numbers.Add(10);
        numbers.Add(30);
        numbers.Add(20);

        foreach (int n in numbers)
            Console.Write(n + " ");
    }
}
