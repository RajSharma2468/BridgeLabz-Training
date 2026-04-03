using System;

class LargestOfThreeApp
{
    static void Main()
    {
        int a = Convert.ToInt32(Console.ReadLine());
        int b = Convert.ToInt32(Console.ReadLine());
        int c = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Is the first number the largest? " + (a > b && a > c));
        Console.WriteLine("Is the second number the largest? " + (b > a && b > c));
        Console.WriteLine("Is the third number the largest? " + (c > a && c > b));
    }
}
