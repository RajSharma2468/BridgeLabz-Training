using System;
using System.IO;

class Program
{
    static void Main()
    {
        string[] lines = File.ReadAllLines("students.csv");
        Console.WriteLine("Total Records: " + (lines.Length - 1));
    }
}
