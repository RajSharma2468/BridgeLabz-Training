using System;
using System.Reflection;

class MathOperations
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    public int Subtract(int a, int b)
    {
        return a - b;
    }

    public int Multiply(int a, int b)
    {
        return a * b;
    }
}

class Program
{
    static void Main()
    {
        MathOperations obj = new MathOperations();
        Type t = typeof(MathOperations);

        Console.Write("Enter method name (Add / Subtract / Multiply): ");
        string methodName = Console.ReadLine();

        MethodInfo method = t.GetMethod(methodName);

        if (method != null)
        {
            object result = method.Invoke(obj, new object[] { 10, 5 });
            Console.WriteLine("Result = " + result);
        }
        else
        {
            Console.WriteLine("Method not found");
        }
    }
}
