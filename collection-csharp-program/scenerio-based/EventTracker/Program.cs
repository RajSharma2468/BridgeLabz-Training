using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("EventTracker Audit System Running...\n");

        EventTrackerEngine.RunAudit();

        Console.ReadLine();
    }
}
