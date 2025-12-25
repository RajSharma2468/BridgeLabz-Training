using System;

class UnitConverter
{
    public static double ConvertKmToMiles(double km)
    {
        return km * 0.621371;
    }

    public static double ConvertMilesToKm(double miles)
    {
        return miles * 1.60934;
    }

    public static double ConvertMetersToFeet(double meters)
    {
        return meters * 3.28084;
    }

    public static double ConvertFeetToMeters(double feet)
    {
        return feet * 0.3048;
    }

    static void Main()
    {
        Console.WriteLine("1. KM to Miles");
        Console.WriteLine("2. Miles to KM");
        Console.WriteLine("3. Meters to Feet");
        Console.WriteLine("4. Feet to Meters");
        Console.Write("Enter choice: ");

        int choice = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter value: ");
        double value = Convert.ToDouble(Console.ReadLine());

        if (choice == 1)
            Console.WriteLine("Miles = " + ConvertKmToMiles(value));
        else if (choice == 2)
            Console.WriteLine("Kilometers = " + ConvertMilesToKm(value));
        else if (choice == 3)
            Console.WriteLine("Feet = " + ConvertMetersToFeet(value));
        else if (choice == 4)
            Console.WriteLine("Meters = " + ConvertFeetToMeters(value));
        else
            Console.WriteLine("Invalid choice");
    }
}
