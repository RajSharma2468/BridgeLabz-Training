using System;
using System.Threading;

class TaskRunner
{
    public void LongRunningTask()
    {
        Thread.Sleep(3000);
        Console.WriteLine("Task Completed");
    }
}

class Program
{
    static void Main()
    {
        TaskRunner t = new TaskRunner();
        t.LongRunningTask();
    }
}
