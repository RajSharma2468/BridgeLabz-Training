using Newtonsoft.Json.Linq;
using System;
using System.IO;

class Program
{
    static void Main()
    {
        string json = File.ReadAllText("sample.json");
        JArray arr = JArray.Parse(json);

        foreach (var item in arr)
        {
            Console.WriteLine("Name: " + item["name"] + ", Email: " + item["email"]);
        }
    }
}
