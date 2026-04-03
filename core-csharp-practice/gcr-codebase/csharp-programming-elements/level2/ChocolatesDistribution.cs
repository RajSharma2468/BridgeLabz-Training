using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter number of chocolates: ");
        int chocolates = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter number of children: ");
        int children = Convert.ToInt32(Console.ReadLine());

        int eachGets = chocolates / children;
        int remaining = chocolates % children;

        Console.WriteLine("The number of chocolates each child gets is " +
                          eachGets + " and the number of remaining chocolates is " +
                          remaining);
    }
}
