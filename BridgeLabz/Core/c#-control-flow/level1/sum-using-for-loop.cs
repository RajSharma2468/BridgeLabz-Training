using System;

class SumCompareForApp
{
    static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());

        if (n >= 0)
        {
            int sum1 = n * (n + 1) / 2;
            int sum2 = 0;

            for (int i = 1; i <= n; i++)
            {
                sum2 = sum2 + i;
            }

            Console.WriteLine("Formula Result: " + sum1);
            Console.WriteLine("For Loop Result: " + sum2);
        }
    }
}
