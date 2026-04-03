using System;

class LeapYear
{
    static bool IsLeapYear(int year)
    {
        if (year < 1582)
            return false;

        return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
    }

    static void Main()
    {
        Console.WriteLine("Enter year");
        int year = Convert.ToInt32(Console.ReadLine());

        if (IsLeapYear(year))
            Console.WriteLine("Leap Year");
        else
            Console.WriteLine("Not a Leap Year");
    }
}
