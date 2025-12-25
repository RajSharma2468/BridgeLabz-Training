using System;

class NaturalSum
{
    static int RecursiveSum(int n)
    {
        if (n == 0)
            return 0;
        return n + RecursiveSum(n - 1);
    }

    static int FormulaSum(int n)
    {
        return n * (n + 1) / 2;
    }

    static void Main()
    {
        Console.WriteLine("Enter a natural number");
        int n = Convert.ToInt32(Console.ReadLine());

        if (n <= 0)
            return;

        int sum1 = RecursiveSum(n);
        int sum2 = FormulaSum(n);

        Console.WriteLine("Recursive Sum = " + sum1);
        Console.WriteLine("Formula Sum = " + sum2);
    }
}
