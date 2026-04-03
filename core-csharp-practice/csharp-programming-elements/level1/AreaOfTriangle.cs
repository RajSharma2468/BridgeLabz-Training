using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter base: ");
        double baseVal = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter height: ");
        double height = Convert.ToDouble(Console.ReadLine());

        double areaCm = 0.5 * baseVal * height;
        double areaInch = areaCm / 6.4516;

        Console.WriteLine("Area of triangle is " + areaCm +
                          " square cm and " + areaInch + " square inches");
    }
}
