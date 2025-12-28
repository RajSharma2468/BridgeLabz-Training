using System;

class Program
{
    static void PrintFibonacci(int n)
    {
        int a = 0, b = 1;

        for (int i = 1; i <= n; i++)
        {
            Console.Write(a + " ");
            int next = a + b;
            a = b;
            b = next;
        }
    }

    static void Main()
    {
        Console.Write("Enter number of terms: ");
        int n = Convert.ToInt32(Console.ReadLine());

        PrintFibonacci(n);
    }
}
