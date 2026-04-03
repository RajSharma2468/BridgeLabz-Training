using System;

class FactorialWhileApp
{
    static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int fact = 1;

        while (n > 0)
        {
            fact = fact * n;
            n--;
        }

        Console.WriteLine("Factorial is " + fact);
    }
}
