using System;

class ZaraBonus
{
    static double CalculateBonus(double salary, int years)
    {
        if (years > 5)
            return salary * 0.05;
        else
            return 0;
    }

    static void Main()
    {
        Console.Write("Enter employee salary: ");
        double salary = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter years of service: ");
        int years = Convert.ToInt32(Console.ReadLine());

        double bonus = CalculateBonus(salary, years);

        if (bonus > 0)
            Console.WriteLine("Bonus Amount: " + bonus);
        else
            Console.WriteLine("No bonus applicable");
    }
}
