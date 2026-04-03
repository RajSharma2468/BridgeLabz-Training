using System;

class Logger
{
    public void Log()
    {
        Console.WriteLine("Logging information");
    }
}

class Service
{
    Logger logger = new Logger();

    public void Execute()
    {
        logger.Log();
        Console.WriteLine("Service executed");
    }
}

class Program
{
    static void Main()
    {
        Service s = new Service();
        s.Execute();
    }
}
