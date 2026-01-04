using System;

class Engine
{
    public void Start()
    {
        Console.WriteLine("Engine started");
    }
}

class Car
{
    Engine engine = new Engine(); // composition

    public void Drive()
    {
        engine.Start();
        Console.WriteLine("Car is moving");
    }
}

class Program
{
    static void Main()
    {
        Car car = new Car();
        car.Drive();
    }
}
