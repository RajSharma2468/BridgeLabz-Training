using System;

class Program
{
    static bool IsPrime(int num)
    {
        if (num <= 1)
            return false;

        for (int i = 2; i <= num / 2; i++)
        {
            if (num % i == 0)
                return false;
        }
        return true;
    }

    static void Main()
    {
        Console.Write("Enter number: ");
        int num = Convert.ToInt32(Console.ReadLine());

        if (IsPrime(num))
            Console.WriteLine("Prime Number");
        else
            Console.WriteLine("Not a Prime Number");
    }
}
