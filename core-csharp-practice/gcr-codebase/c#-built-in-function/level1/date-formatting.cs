using System;

class Program
{
    static void Main()
    {
        DateTime now = DateTime.Now;

        Console.WriteLine("Format 1: " + now.ToString("dd/MM/yyyy"));
        Console.WriteLine("Format 2: " + now.ToString("yyyy-MM-dd"));
        Console.WriteLine("Format 3: " + now.ToString("ddd, MMM dd, yyyy"));
    }
}
