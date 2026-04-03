using System;
using System.Reflection;

class Configuration
{
    private static string API_KEY = "OLD_KEY";
}

class Program
{
    static void Main()
    {
        Type t = typeof(Configuration);

        FieldInfo field = t.GetField("API_KEY",
            BindingFlags.NonPublic | BindingFlags.Static);

        field.SetValue(null, "NEW_SECRET_KEY");

        Console.WriteLine("API_KEY = " + field.GetValue(null));
    }
}
