using System;

class ZeroSum
{
    static bool HasZeroSum(int[] arr)
    {
        int[] hash = new int[200];
        int sum = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
            if (sum == 0 || hash[sum + 100] == 1)
                return true;

            hash[sum + 100] = 1;
        }
        return false;
    }

    static void Main()
    {
        int[] arr = { 4, 2, -3, 1, 6 };
        Console.WriteLine(HasZeroSum(arr));
    }
}
