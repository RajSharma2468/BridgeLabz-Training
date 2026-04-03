using System;

class Printer
{
    public virtual void Print()
    {
        Console.WriteLine("Printing document");
    }
}

class ColorPrinter : Printer
{
    public override void Print()
    {
        Console.WriteLine("Printing color document");
    }
}

class Program
{
    static void Main()
    {
        Printer p = new ColorPrinter();
        p.Print();
    }
}
