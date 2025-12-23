using System;

class Program
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        if (number >= 0)
        {
            int sum = number * (number + 1) / 2;
            Console.WriteLine("The sum of " + number + " natural numbers is " + sum);
        }
        else
        {
            Console.WriteLine("The number " + number + " is not a natural number");
        }
    }
}
