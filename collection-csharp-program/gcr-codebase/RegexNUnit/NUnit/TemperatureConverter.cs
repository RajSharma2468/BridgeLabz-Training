using System;

class TemperatureConverter
{
    public double CelsiusToFahrenheit(double c)
    {
        return (c * 9 / 5) + 32;
    }

    public double FahrenheitToCelsius(double f)
    {
        return (f - 32) * 5 / 9;
    }
}

class Program
{
    static void Main()
    {
        TemperatureConverter t = new TemperatureConverter();
        Console.WriteLine("C to F: " + t.CelsiusToFahrenheit(25));
        Console.WriteLine("F to C: " + t.FahrenheitToCelsius(98));
    }
}
