using System;

class SmallestOfThreeApp
{
    static void Main()
    {
        int a = Convert.ToInt32(Console.ReadLine());
        int b = Convert.ToInt32(Console.ReadLine());
        int c = Convert.ToInt32(Console.ReadLine());

        bool isSmallest = (a < b && a < c);
        Console.WriteLine("Is the first number the smallest? " + isSmallest);
    }
}
