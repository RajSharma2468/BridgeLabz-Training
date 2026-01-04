using System;

class Circle
{
    public double radius;

    public void CalculateArea()
    {
        double area = 3.14 * radius * radius;
        Console.WriteLine("Area of Circle: " + area);
    }

    public void CalculateCircumference()
    {
        double circumference = 2 * 3.14 * radius;
        Console.WriteLine("Circumference of Circle: " + circumference);
    }
}

class Program
{
    static void Main()
    {
        Circle c = new Circle();

        c.radius = 7;

        c.CalculateArea();
        c.CalculateCircumference();
    }
}
