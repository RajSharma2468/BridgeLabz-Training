using Newtonsoft.Json.Linq;
using System;

class Program
{
    static void Main()
    {
        string json = "[{'name':'Raj','age':30},{'name':'Aman','age':22}]";
        JArray arr = JArray.Parse(json);

        foreach (var person in arr)
        {
            if ((int)person["age"] > 25)
            {
                Console.WriteLine(person["name"].ToString());
            }
        }
    }
}
