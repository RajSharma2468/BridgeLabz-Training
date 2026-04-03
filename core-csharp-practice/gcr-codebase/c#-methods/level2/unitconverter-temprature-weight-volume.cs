using System;

class UnitConverter
{
    public static double ConvertFahrenheitToCelsius(double fahrenheit)
    {
        return (fahrenheit - 32) * 5 / 9;
    }

    public static double ConvertCelsiusToFahrenheit(double celsius)
    {
        return (celsius * 9 / 5) + 32;
    }

    public static double ConvertPoundsToKilograms(double pounds)
    {
        return pounds * 0.453592;
    }

    public static double ConvertKilogramsToPounds(double kilograms)
    {
        return kilograms * 2.20462;
    }

    public static double ConvertGallonsToLiters(double gallons)
    {
        return gallons * 3.78541;
    }

    public static double ConvertLitersToGallons(double liters)
    {
        return liters * 0.264172;
    }

    static void Main()
    {
        Console.WriteLine("1. Fahrenheit to Celsius");
        Console.WriteLine("2. Celsius to Fahrenheit");
        Console.WriteLine("3. Pounds to Kilograms");
        Console.WriteLine("4. Kilograms to Pounds");
        Console.WriteLine("5. Gallons to Liters");
        Console.WriteLine("6. Liters to Gallons");
        Console.Write("Enter choice: ");

        int choice = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter value: ");
        double value = Convert.ToDouble(Console.ReadLine());

        if (choice == 1)
            Console.WriteLine("Celsius = " + ConvertFahrenheitToCelsius(value));
        else if (choice == 2)
            Console.WriteLine("Fahrenheit = " + ConvertCelsiusToFahrenheit(value));
        else if (choice == 3)
            Console.WriteLine("Kilograms = " + ConvertPoundsToKilograms(value));
        else if (choice == 4)
            Console.WriteLine("Pounds = " + ConvertKilogramsToPounds(value));
        else if (choice == 5)
            Console.WriteLine("Liters = " + ConvertGallonsToLiters(value));
        else if (choice == 6)
            Console.WriteLine("Gallons = " + ConvertLitersToGallons(value));
        else
            Console.WriteLine("Invalid choice");
    }
}
