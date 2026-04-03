using System;

class OddEvenApp
{
    static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            if (i % 2 == 0)
                Console.WriteLine(i + " is Even");
            else
                Console.WriteLine(i + " is Odd");
        }
    }
}
