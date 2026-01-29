using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var ids = new HashSet<string>();

        foreach (var line in File.ReadAllLines("students.csv").Skip(1))
        {
            var id = line.Split(',')[0];
            if (!ids.Add(id))
                Console.WriteLine("Duplicate: " + line);
        }
    }
}
