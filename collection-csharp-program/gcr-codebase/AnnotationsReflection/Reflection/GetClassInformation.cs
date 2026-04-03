using System;
using System.Reflection;

class Sample
{
    public int x;
    private string name;

    public Sample() { }
    public Sample(int x) { }

    public void Show() { }
    private void Hidden() { }
}

class Program
{
    static void Main()
    {
        Type t = typeof(Sample);

        Console.WriteLine("Methods:");
        foreach (MethodInfo m in t.GetMethods(
            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
        {
            Console.WriteLine(m.Name);
        }

        Console.WriteLine("\nFields:");
        foreach (FieldInfo f in t.GetFields(
            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
        {
            Console.WriteLine(f.Name);
        }

        Console.WriteLine("\nConstructors:");
        foreach (ConstructorInfo c in t.GetConstructors())
        {
            Console.WriteLine(c.ToString());
        }
    }
}
