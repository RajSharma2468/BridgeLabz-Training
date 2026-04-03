using Newtonsoft.Json;
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var student = new
        {
            name = "Rahul",
            age = 21,
            subjects = new List<string> { "Math", "Physics", "CS" }
        };

        string json = JsonConvert.SerializeObject(student, Formatting.Indented);
        Console.WriteLine(json);
    }
}
