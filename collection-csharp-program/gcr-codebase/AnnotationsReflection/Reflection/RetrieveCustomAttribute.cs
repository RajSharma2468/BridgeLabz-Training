using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Class)]
class AuthorAttribute : Attribute
{
    public string Name;
    public AuthorAttribute(string name)
    {
        Name = name;
    }
}

[Author("Raj Sharma")]
class Demo { }

class Program
{
    static void Main()
    {
        Type t = typeof(Demo);
        AuthorAttribute attr =
            (AuthorAttribute)Attribute.GetCustomAttribute(t, typeof(AuthorAttribute));

        Console.WriteLine("Author = " + attr.Name);
    }
}
