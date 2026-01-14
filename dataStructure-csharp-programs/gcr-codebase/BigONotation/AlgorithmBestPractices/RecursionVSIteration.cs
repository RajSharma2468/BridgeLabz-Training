using System;

class Program
{
    static void Main()
    {
        Console.WriteLine(Fibonacci(50));
    }

    static long Fibonacci(int n)
    {
        if (n <= 1) return n;

        long a = 0, b = 1, sum = 0;

        for (int i = 2; i <= n; i++)
        {
            sum = a + b;
            a = b;
            b = sum;
        }
        return b;
    }
}
