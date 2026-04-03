using System;

class Circle
{
    public double radius;

    // Default Constructor
    public Circle() : this(1.0)
    {
    }

    // Parameterized Constructor
    public Circle(double radius)
    {
        this.radius = radius;
    }

    public void Display()
    {
        Console.WriteLine("Radius: " + radius);
        Console.WriteLine("Area: " + (3.14 * radius * radius));
    }
}

class Program
{
    static void Main()
    {
        Circle c1 = new Circle();
        c1.Display();

        Circle c2 = new Circle(5);
        c2.Display();
    }
}
