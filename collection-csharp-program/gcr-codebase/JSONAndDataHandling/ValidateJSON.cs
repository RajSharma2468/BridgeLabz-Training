using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;

class Program
{
    static void Main()
    {
        string schemaJson = "{ 'type':'object','properties':{'email':{'type':'string','format':'email'}} }";
        JSchema schema = JSchema.Parse(schemaJson);

        JObject user = JObject.Parse("{'email':'test@gmail.com'}");

        bool valid = user.IsValid(schema);
        Console.WriteLine("Valid JSON: " + valid);
    }
}
