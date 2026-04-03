using System;

class Program
{
    static void Main()
    {
        int n = 100000;
        int[] arr = new int[n];

        for (int i = 0; i < n; i++)
            arr[i] = i + 1;

        int target = 99999;

        Console.WriteLine("Linear Search Index: " + LinearSearch(arr, target));
        Console.WriteLine("Binary Search Index: " + BinarySearch(arr, target));
    }

    static int LinearSearch(int[] arr, int target)
    {
        for (int i = 0; i < arr.Length; i++)
            if (arr[i] == target)
                return i;
        return -1;
    }

    static int BinarySearch(int[] arr, int target)
    {
        int low = 0, high = arr.Length - 1;

        while (low <= high)
        {
            int mid = (low + high) / 2;

            if (arr[mid] == target)
                return mid;
            else if (arr[mid] < target)
                low = mid + 1;
            else
                high = mid - 1;
        }
        return -1;
    }
}
