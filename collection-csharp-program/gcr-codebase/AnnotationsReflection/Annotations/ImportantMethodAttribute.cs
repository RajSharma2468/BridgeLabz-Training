using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Method)]
class ImportantMethodAttribute : Attribute
{
    public string Level;

    public ImportantMethodAttribute()
    {
        Level = "HIGH";
    }

    public ImportantMethodAttribute(string level)
    {
        Level = level;
    }
}

class Demo
{
    [ImportantMethod]
    public void MethodA() { }

    [ImportantMethod("LOW")]
    public void MethodB() { }
}

class Program
{
    static void Main()
    {
        MethodInfo[] methods = typeof(Demo).GetMethods();

        foreach (MethodInfo m in methods)
        {
            object attr = Attribute.GetCustomAttribute(
                m, typeof(ImportantMethodAttribute));

            if (attr != null)
            {
                ImportantMethodAttribute im =
                    (ImportantMethodAttribute)attr;

                Console.WriteLine(m.Name + " - " + im.Level);
            }
        }
    }
}
