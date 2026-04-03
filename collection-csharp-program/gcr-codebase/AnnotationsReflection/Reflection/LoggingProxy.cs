using System;
using System.Reflection;

interface IGreeting
{
    void SayHello();
}

class Greeting : IGreeting
{
    public void SayHello()
    {
        Console.WriteLine("Hello!");
    }
}

class Program
{
    static void Main()
    {
        IGreeting g = new Greeting();
        Type t = g.GetType();

        MethodInfo method = t.GetMethod("SayHello");
        Console.WriteLine("Calling method: " + method.Name);
        method.Invoke(g, null);
    }
}
