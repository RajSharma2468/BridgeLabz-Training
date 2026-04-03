using System;

class SumCompareWhileApp
{
    static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());

        if (n >= 0)
        {
            int sum1 = n * (n + 1) / 2;
            int sum2 = 0;
            int i = 1;

            while (i <= n)
            {
                sum2 = sum2 + i;
                i++;
            }

            Console.WriteLine("Formula Result: " + sum1);
            Console.WriteLine("While Loop Result: " + sum2);
        }
    }
}
