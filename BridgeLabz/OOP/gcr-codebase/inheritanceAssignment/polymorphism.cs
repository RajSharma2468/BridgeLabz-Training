using System;

class Shape
{
    public virtual void Area()
    {
        Console.WriteLine("Calculating Area");
    }
}

class Square : Shape
{
    public override void Area()
    {
        Console.WriteLine("Square Area");
    }
}

class Program
{
    static void Main()
    {
        Shape s = new Square();
        s.Area();
    }
}
