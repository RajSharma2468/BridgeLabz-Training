using System;

class RunningRounds
{
    static double CalculateRounds(double a, double b, double c)
    {
        double perimeter = a + b + c;
        double distance = 5000;   // 5 km in meters
        return distance / perimeter;
    }

    static void Main()
    {
        Console.WriteLine("Enter side 1");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter side 2");
        double b = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter side 3");
        double c = Convert.ToDouble(Console.ReadLine());

        double rounds = CalculateRounds(a, b, c);
        Console.WriteLine("Number of rounds = " + rounds);
    }
}
