using System;

class Program
{
    static void Main()
    {
        int[] arr = { 4, 2, -5, 6 };

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] < 0)
            {
                Console.WriteLine(arr[i]);
                return;
            }
        }

        Console.WriteLine("No negative number");
    }
}
