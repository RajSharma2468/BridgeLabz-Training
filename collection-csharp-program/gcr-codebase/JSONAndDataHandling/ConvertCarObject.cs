using Newtonsoft.Json;
using System;

class Car
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
}

class Program
{
    static void Main()
    {
        Car car = new Car();
        car.Brand = "Tesla";
        car.Model = "Model S";
        car.Year = 2024;

        string json = JsonConvert.SerializeObject(car, Formatting.Indented);
        Console.WriteLine(json);
    }
}
