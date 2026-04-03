using System;

class NumberChecker
{
    static int[] GetFactors(int n)
    {
        int count = 0;
        for (int i = 1; i <= n; i++)
            if (n % i == 0)
                count++;

        int[] factors = new int[count];
        int index = 0;
        for (int i = 1; i <= n; i++)
            if (n % i == 0)
                factors[index++] = i;

        return factors;
    }

    static bool IsPerfect(int n, int[] factors)
    {
        int sum = 0;
        for (int i = 0; i < factors.Length - 1; i++)
            sum += factors[i];
        return sum == n;
    }

    static bool IsAbundant(int n, int[] factors)
    {
        int sum = 0;
        for (int i = 0; i < factors.Length - 1; i++)
            sum += factors[i];
        return sum > n;
    }

    static bool IsDeficient(int n, int[] factors)
    {
        int sum = 0;
        for (int i = 0; i < factors.Length - 1; i++)
            sum += factors[i];
        return sum < n;
    }

    static int Factorial(int n)
    {
        int fact = 1;
        for (int i = 1; i <= n; i++)
            fact *= i;
        return fact;
    }

    static bool IsStrong(int n)
    {
        int temp = n, sum = 0;
        while (temp > 0)
        {
            sum += Factorial(temp % 10);
            temp /= 10;
        }
        return sum == n;
    }

    static void Main()
    {
        Console.Write("Enter number: ");
        int num = Convert.ToInt32(Console.ReadLine());

        int[] factors = GetFactors(num);

        Console.WriteLine("Perfect: " + IsPerfect(num, factors));
        Console.WriteLine("Abundant: " + IsAbundant(num, factors));
        Console.WriteLine("Deficient: " + IsDeficient(num, factors));
        Console.WriteLine("Strong: " + IsStrong(num));
    }
}
