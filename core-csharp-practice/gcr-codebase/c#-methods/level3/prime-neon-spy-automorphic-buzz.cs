using System;

class NumberChecker
{
    static bool IsPrime(int n)
    {
        if (n <= 1) return false;
        for (int i = 2; i <= n / 2; i++)
            if (n % i == 0)
                return false;
        return true;
    }

    static bool IsNeon(int n)
    {
        int sq = n * n, sum = 0;
        while (sq > 0)
        {
            sum += sq % 10;
            sq /= 10;
        }
        return sum == n;
    }

    static bool IsSpy(int n)
    {
        int sum = 0, product = 1;
        while (n > 0)
        {
            int d = n % 10;
            sum += d;
            product *= d;
            n /= 10;
        }
        return sum == product;
    }

    static bool IsAutomorphic(int n)
    {
        int sq = n * n;
        return sq.ToString().EndsWith(n.ToString());
    }

    static bool IsBuzz(int n)
    {
        return n % 7 == 0 || n % 10 == 7;
    }

    static void Main()
    {
        Console.Write("Enter number: ");
        int num = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Prime: " + IsPrime(num));
        Console.WriteLine("Neon: " + IsNeon(num));
        Console.WriteLine("Spy: " + IsSpy(num));
        Console.WriteLine("Automorphic: " + IsAutomorphic(num));
        Console.WriteLine("Buzz: " + IsBuzz(num));
    }
}
