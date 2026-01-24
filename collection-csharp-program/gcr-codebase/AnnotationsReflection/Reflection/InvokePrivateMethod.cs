using System;
using System.Reflection;

class Calculator
{
    private int Multiply(int a, int b)
    {
        return a * b;
    }
}

class Program
{
    static void Main()
    {
        Calculator c = new Calculator();
        Type t = typeof(Calculator);

        MethodInfo method = t.GetMethod("Multiply",
            BindingFlags.NonPublic | BindingFlags.Instance);

        object result = method.Invoke(c, new object[] { 4, 5 });
        Console.WriteLine("Result = " + result);
    }
}
