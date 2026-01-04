using System;

interface IPrinter
{
    void Print();
}

interface IScanner
{
    void Scan();
}

class Machine : IPrinter, IScanner
{
    public void Print()
    {
        Console.WriteLine("Printing");
    }

    public void Scan()
    {
        Console.WriteLine("Scanning");
    }
}

class Program
{
    static void Main()
    {
        Machine m = new Machine();
        m.Print();
        m.Scan();
    }
}
