using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter date (yyyy-MM-dd): ");
        DateTime date = Convert.ToDateTime(Console.ReadLine());

        date = date.AddDays(7);
        date = date.AddMonths(1);
        date = date.AddYears(2);

        // Subtract 3 weeks = 21 days
        date = date.AddDays(-21);

        Console.WriteLine("Final Date: " + date.ToShortDateString());
    }
}
