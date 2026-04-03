using System;

class Vehicle
{
    public void Move()
    {
        Console.WriteLine("Vehicle moves");
    }
}

class Bike : Vehicle
{
}

class Program
{
    static void Main()
    {
        Bike b = new Bike();
        b.Move();
    }
}
