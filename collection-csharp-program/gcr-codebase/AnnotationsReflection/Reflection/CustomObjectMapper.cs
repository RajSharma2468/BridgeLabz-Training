using System;
using System.Collections.Generic;
using System.Reflection;

class User
{
    public int Id;
    public string Name;
}

class Program
{
    static T ToObject<T>(Dictionary<string, object> data) where T : new()
    {
        T obj = new T();
        Type t = typeof(T);

        foreach (var item in data)
        {
            FieldInfo field = t.GetField(item.Key);
            if (field != null)
                field.SetValue(obj, item.Value);
        }
        return obj;
    }

    static void Main()
    {
        var dict = new Dictionary<string, object>()
        {
            { "Id", 101 },
            { "Name", "Raj" }
        };

        User u = ToObject<User>(dict);
        Console.WriteLine(u.Id + " " + u.Name);
    }
}
