using System;

class SumNatural
{
    static int FindSum(int n)
    {
        int sum = 0;

        for (int i = 1; i <= n; i++)
            sum = sum + i;

        return sum;
    }

    static void Main()
    {
        Console.WriteLine("Enter n");
        int n = Convert.ToInt32(Console.ReadLine());

        int result = FindSum(n);
        Console.WriteLine("Sum = " + result);
    }
}
