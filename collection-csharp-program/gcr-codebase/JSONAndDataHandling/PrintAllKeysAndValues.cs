using Newtonsoft.Json.Linq;
using System;

class Program
{
    static void Main()
    {
        JObject obj = JObject.Parse("{'name':'Raj','age':22,'city':'Agra'}");

        foreach (var prop in obj.Properties())
        {
            Console.WriteLine(prop.Name + " : " + prop.Value);
        }
    }
}
