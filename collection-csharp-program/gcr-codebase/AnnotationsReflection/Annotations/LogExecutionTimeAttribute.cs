using System;
using System.Diagnostics;
using System.Reflection;

[AttributeUsage(AttributeTargets.Method)]
class LogExecutionTimeAttribute : Attribute { }

class Test
{
    [LogExecutionTime]
    public void Run()
    {
        for (int i = 0; i < 1000000; i++) { }
    }
}

class Program
{
    static void Main()
    {
        Test t = new Test();
        MethodInfo m = typeof(Test).GetMethod("Run");

        Stopwatch sw = Stopwatch.StartNew();
        m.Invoke(t, null);
        sw.Stop();

        Console.WriteLine("Time: " + sw.ElapsedMilliseconds);
    }
}
