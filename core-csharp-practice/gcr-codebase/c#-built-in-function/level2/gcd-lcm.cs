using System;

class Program
{
    static int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    static int LCM(int a, int b)
    {
        return (a * b) / GCD(a, b);
    }

    static void Main()
    {
        Console.Write("Enter first number: ");
        int a = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter second number: ");
        int b = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("GCD: " + GCD(a, b));
        Console.WriteLine("LCM: " + LCM(a, b));
    }
}
