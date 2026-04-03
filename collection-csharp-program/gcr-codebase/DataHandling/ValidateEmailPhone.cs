using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

class Program
{
    static void Main()
    {
        var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        var phoneRegex = new Regex(@"^\d{10}$");

        foreach (var line in File.ReadAllLines("users.csv").Skip(1))
        {
            var data = line.Split(',');
            if (!emailRegex.IsMatch(data[2]) || !phoneRegex.IsMatch(data[3]))
                Console.WriteLine("Invalid Row: " + line);
        }
    }
}
