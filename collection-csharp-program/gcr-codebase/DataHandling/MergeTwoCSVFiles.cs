using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var file1 = File.ReadAllLines("students1.csv").Skip(1)
            .ToDictionary(x => x.Split(',')[0]);

        var merged = new List<string>();
        merged.Add("ID,Name,Age,Marks,Grade");

        foreach (var line in File.ReadAllLines("students2.csv").Skip(1))
        {
            var d = line.Split(',');
            if (file1.ContainsKey(d[0]))
                merged.Add(file1[d[0]] + "," + d[1] + "," + d[2]);
        }

        File.WriteAllLines("merged.csv", merged);
        Console.WriteLine("Files merged!");
    }
}
