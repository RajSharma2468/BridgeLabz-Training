using System;

class Chocolates
{
    static int[] FindRemainderAndQuotient(int chocolates, int children)
    {
        int each = chocolates / children;
        int remaining = chocolates % children;

        return new int[] { each, remaining };
    }

    static void Main()
    {
        Console.WriteLine("Enter number of chocolates");
        int chocolates = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter number of children");
        int children = Convert.ToInt32(Console.ReadLine());

        int[] result = FindRemainderAndQuotient(chocolates, children);

        Console.WriteLine("Each child gets = " + result[0]);
        Console.WriteLine("Remaining chocolates = " + result[1]);
    }
}
