using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter first date (yyyy-MM-dd): ");
        DateTime date1 = Convert.ToDateTime(Console.ReadLine());

        Console.Write("Enter second date (yyyy-MM-dd): ");
        DateTime date2 = Convert.ToDateTime(Console.ReadLine());

        int result = DateTime.Compare(date1, date2);

        if (result < 0)
            Console.WriteLine("First date is BEFORE second date");
        else if (result > 0)
            Console.WriteLine("First date is AFTER second date");
        else
            Console.WriteLine("Both dates are SAME");
    }
}
