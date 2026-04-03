using System;

class EmployeeBonusApp
{
    static void Main()
    {
        double salary = Convert.ToDouble(Console.ReadLine());
        int years = Convert.ToInt32(Console.ReadLine());

        if (years > 5)
        {
            double bonus = salary * 0.05;
            Console.WriteLine("Bonus Amount: " + bonus);
        }
        else
        {
            Console.WriteLine("No Bonus");
        }
    }
}
