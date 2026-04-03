using System;

class UnitConverter
{
    public static double ConvertYardsToFeet(double yards)
    {
        return yards * 3;
    }

    public static double ConvertFeetToYards(double feet)
    {
        return feet * 0.333333;
    }

    public static double ConvertMetersToInches(double meters)
    {
        return meters * 39.3701;
    }

    public static double ConvertInchesToMeters(double inches)
    {
        return inches * 0.0254;
    }

    public static double ConvertInchesToCentimeters(double inches)
    {
        return inches * 2.54;
    }

    static void Main()
    {
        Console.WriteLine("1. Yards to Feet");
        Console.WriteLine("2. Feet to Yards");
        Console.WriteLine("3. Meters to Inches");
        Console.WriteLine("4. Inches to Meters");
        Console.WriteLine("5. Inches to Centimeters");
        Console.Write("Enter choice: ");

        int choice = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter value: ");
        double value = Convert.ToDouble(Console.ReadLine());

        if (choice == 1)
            Console.WriteLine("Feet = " + ConvertYardsToFeet(value));
        else if (choice == 2)
            Console.WriteLine("Yards = " + ConvertFeetToYards(value));
        else if (choice == 3)
            Console.WriteLine("Inches = " + ConvertMetersToInches(value));
        else if (choice == 4)
            Console.WriteLine("Meters = " + ConvertInchesToMeters(value));
        else if (choice == 5)
            Console.WriteLine("Centimeters = " + ConvertInchesToCentimeters(value));
        else
            Console.WriteLine("Invalid choice");
    }
}
