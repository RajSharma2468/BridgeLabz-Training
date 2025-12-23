using System;

class CountdownForApp
{
    static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());

        for (int i = n; i >= 1; i--)
        {
            Console.WriteLine(i);
        }
    }
}
