using System;

class PrimeNumberCheckApp
{
    static void Main()
    {
        int number = Convert.ToInt32(Console.ReadLine());
        bool isPrime = true;

        if (number <= 1)
        {
            isPrime = false;
        }
        else
        {
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }
        }

        Console.WriteLine("Is the number prime? " + isPrime);
    }
}
