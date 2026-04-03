using System;

class SmallestLargest
{
    public static int[] FindSmallestAndLargest(int a, int b, int c)
    {
        int smallest = a;
        int largest = a;

        if (b < smallest) smallest = b;
        if (c < smallest) smallest = c;

        if (b > largest) largest = b;
        if (c > largest) largest = c;

        return new int[] { smallest, largest };
    }

    static void Main()
    {
        Console.WriteLine("Enter three numbers");
        int a = Convert.ToInt32(Console.ReadLine());
        int b = Convert.ToInt32(Console.ReadLine());
        int c = Convert.ToInt32(Console.ReadLine());

        int[] result = FindSmallestAndLargest(a, b, c);

        Console.WriteLine("Smallest = " + result[0]);
        Console.WriteLine("Largest = " + result[1]);
    }
}
