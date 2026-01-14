using System;
using System.Collections.Generic;

class TreeMapExample
{
    static void Main()
    {
        SortedDictionary<int, string> map = new SortedDictionary<int, string>();

        map.Add(3, "C");
        map.Add(1, "A");
        map.Add(2, "B");

        foreach (var item in map)
            Console.WriteLine(item.Key + " " + item.Value);
    }
}
