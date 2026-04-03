using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        var top5 = File.ReadAllLines("employees.csv")
            .Skip(1)
            .Select(x => x.Split(','))
            .OrderByDescending(x => double.Parse(x[3]))
            .Take(5);

        foreach (var emp in top5)
            Console.WriteLine(emp[1] + " - " + emp[3]);
    }
}
