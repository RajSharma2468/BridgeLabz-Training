using System;

class PairSum
{
    static bool HasPair(int[] arr, int target)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[i] + arr[j] == target)
                    return true;
            }
        }
        return false;
    }

    static void Main()
    {
        int[] arr = { 8, 7, 2, 5, 3, 1 };
        Console.WriteLine(HasPair(arr, 10));
    }
}
