using System;

class FactorialForApp
{
    static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int fact = 1;

        for (int i = 1; i <= n; i++)
        {
            fact = fact * i;
        }

        Console.WriteLine("Factorial is " + fact);
    }
}
