using System;

class Program
{
    static void Main()
    {
        int[] arr = {1,2,2,2,3};
        int target = 2;

        int first = -1, last = -1;

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == target)
            {
                if (first == -1) first = i;
                last = i;
            }
        }

        Console.WriteLine(first);
        Console.WriteLine(last);
    }
}
