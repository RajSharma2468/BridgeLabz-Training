using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.Write("Enter employee name: ");
        string name = Console.ReadLine();

        var lines = File.ReadAllLines("employees.csv").Skip(1);

        foreach (var line in lines)
        {
            var data = line.Split(',');
            if (data[1].Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Department: " + data[2] + ", Salary: " + data[3]);
                return;
            }
        }

        Console.WriteLine("Employee not found.");
    }
}
