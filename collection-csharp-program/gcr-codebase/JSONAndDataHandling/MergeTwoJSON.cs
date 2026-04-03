using Newtonsoft.Json.Linq;
using System;

class Program
{
    static void Main()
    {
        JObject obj1 = JObject.Parse("{ 'name':'Raj', 'age':22 }");
        JObject obj2 = JObject.Parse("{ 'city':'Delhi', 'country':'India' }");

        obj1.Merge(obj2);
        Console.WriteLine(obj1.ToString());
    }
}
