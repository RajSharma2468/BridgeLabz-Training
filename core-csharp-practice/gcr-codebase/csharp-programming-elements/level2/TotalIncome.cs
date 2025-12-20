using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter Salary: ");
        double salary = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Bonus: ");
        double bonus = Convert.ToDouble(Console.ReadLine());

        double income = salary + bonus;

        Console.WriteLine("The salary is INR " + salary +
                          " and bonus is INR " + bonus +
                          ". Hence Total Income is INR " + income);
    }
}
