using System;

class Bank
{
    public virtual void Interest()
    {
        Console.WriteLine("Base Interest");
    }
}

class SBI : Bank
{
    public sealed override void Interest()
    {
        Console.WriteLine("SBI Interest");
    }
}

class Program
{
    static void Main()
    {
        Bank b = new SBI();
        b.Interest();
    }
}
