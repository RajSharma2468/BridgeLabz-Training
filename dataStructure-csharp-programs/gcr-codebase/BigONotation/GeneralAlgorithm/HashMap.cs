// Choose the right data structure
//  Use HashMap for O(1) lookup instead of ArrayList O(N)
//  Code: HashMap (Dictionary) Lookup

using System;
using System.Collections.Generic;

class HashMapLookup
{
    static void Main()
    {
        Dictionary<int, string> students = new Dictionary<int, string>();

        students.Add(101, "Amit");
        students.Add(102, "Ravi");
        students.Add(103, "Neha");

        int searchKey = 102;

        if (students.ContainsKey(searchKey))
            Console.WriteLine("Found: " + students[searchKey]);
        else
            Console.WriteLine("Not Found");
    }
}
