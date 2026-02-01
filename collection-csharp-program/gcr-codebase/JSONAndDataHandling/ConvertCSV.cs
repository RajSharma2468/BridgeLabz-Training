using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        var lines = File.ReadAllLines("data.csv");
        var list = new List<object>();

        for (int i = 1; i < lines.Length; i++)
        {
            var p = lines[i].Split(',');
            list.Add(new { name = p[0], age = p[1] });
        }

        File.WriteAllText("data.json", JsonConvert.SerializeObject(list, Formatting.Indented));
    }
}
