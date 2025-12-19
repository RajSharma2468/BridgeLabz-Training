using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter perimeter: ");
        double perimeter = Convert.ToDouble(Console.ReadLine());

        double side = perimeter / 4;

        Console.WriteLine("The length of the side is " + side +
                          " whose perimeter is " + perimeter);
    }
}
