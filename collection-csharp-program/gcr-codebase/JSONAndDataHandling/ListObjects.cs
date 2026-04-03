using Newtonsoft.Json;
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var users = new List<object>();
        users.Add(new { name = "Raj", age = 30 });
        users.Add(new { name = "Simran", age = 24 });

        string json = JsonConvert.SerializeObject(users, Formatting.Indented);
        Console.WriteLine(json);
    }
}
