using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var lines = new List<string>(File.ReadAllLines("employees.csv"));

        for (int i = 1; i < lines.Count; i++)
        {
            var data = lines[i].Split(',');
            if (data[2] == "IT")
            {
                double salary = double.Parse(data[3]) * 1.10;
                lines[i] = data[0] + "," + data[1] + "," + data[2] + "," + salary;
            }
        }

        File.WriteAllLines("employees_updated.csv", lines);
        Console.WriteLine("Updated file saved!");
    }
}
