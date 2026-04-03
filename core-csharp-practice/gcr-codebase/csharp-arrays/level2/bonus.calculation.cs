using System;

class ZaraBonus
{
    static void Main()
    {
        double[] salary = new double[10];
        double[] service = new double[10];
        double[] bonus = new double[10];
        double[] newSalary = new double[10];

        double totalBonus = 0;
        double totalOldSalary = 0;
        double totalNewSalary = 0;

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Enter salary of employee " + (i + 1));
            salary[i] = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter years of service of employee " + (i + 1));
            service[i] = Convert.ToDouble(Console.ReadLine());

            if (salary[i] <= 0 || service[i] < 0)
            {
                Console.WriteLine("Invalid input, enter again");
                i--;
                continue;
            }
        }

        for (int i = 0; i < 10; i++)
        {
            if (service[i] > 5)
                bonus[i] = salary[i] * 0.05;
            else
                bonus[i] = salary[i] * 0.02;

            newSalary[i] = salary[i] + bonus[i];

            totalBonus = totalBonus + bonus[i];
            totalOldSalary = totalOldSalary + salary[i];
            totalNewSalary = totalNewSalary + newSalary[i];
        }

        Console.WriteLine("Total Bonus = " + totalBonus);
        Console.WriteLine("Total Old Salary = " + totalOldSalary);
        Console.WriteLine("Total New Salary = " + totalNewSalary);
    }
}
