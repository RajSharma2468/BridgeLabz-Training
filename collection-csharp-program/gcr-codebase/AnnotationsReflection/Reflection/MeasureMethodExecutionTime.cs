using System;
using System.Diagnostics;
using System.Reflection;

class TaskRunner
{
    public void Run()
    {
        for (int i = 0; i < 1000000; i++) { }
    }
}

class Program
{
    static void Main()
    {
        TaskRunner t = new TaskRunner();
        MethodInfo method = typeof(TaskRunner).GetMethod("Run");

        Stopwatch sw = Stopwatch.StartNew();
        method.Invoke(t, null);
        sw.Stop();

        Console.WriteLine("Execution Time: " + sw.ElapsedMilliseconds + " ms");
    }
}
