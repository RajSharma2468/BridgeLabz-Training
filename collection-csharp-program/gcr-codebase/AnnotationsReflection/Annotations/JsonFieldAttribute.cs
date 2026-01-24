using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Field)]
class JsonFieldAttribute : Attribute
{
    public string Name;
    public JsonFieldAttribute(string name)
    {
        Name = name;
    }
}

class User
{
    [JsonField("user_name")]
    public string Name = "Raj";
}

class Program
{
    static void Main()
    {
        User u = new User();
        FieldInfo[] fields = typeof(User).GetFields();

        Console.Write("{");
        foreach (FieldInfo f in fields)
        {
            JsonFieldAttribute attr =
                (JsonFieldAttribute)Attribute.GetCustomAttribute(
                    f, typeof(JsonFieldAttribute));

            Console.Write("\"" + attr.Name + "\":\"" + f.GetValue(u) + "\"");
        }
        Console.Write("}");
    }
}
