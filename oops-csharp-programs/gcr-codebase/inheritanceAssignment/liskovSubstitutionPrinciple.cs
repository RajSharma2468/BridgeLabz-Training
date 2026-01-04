using System;

class Bird
{
    public virtual void Fly()
    {
        Console.WriteLine("Bird can fly");
    }
}

class Sparrow : Bird
{
    public override void Fly()
    {
        Console.WriteLine("Sparrow flies");
    }
}

class Program
{
    static void Main()
    {
        Bird b = new Sparrow();
        b.Fly(); // works correctly
    }
}
