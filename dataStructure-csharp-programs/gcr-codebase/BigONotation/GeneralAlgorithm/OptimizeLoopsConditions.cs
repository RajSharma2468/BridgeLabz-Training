using System;

class EarlyExitLoop
{
    static void Main()
    {
        int[] arr = { 5, 8, 3, 9, 2 };
        int target = 3;

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == target)
            {
                Console.WriteLine("Found at index " + i);
                return;   // early exit
            }
        }

        Console.WriteLine("Not Found");
    }
}
