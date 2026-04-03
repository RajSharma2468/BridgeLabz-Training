using System;

class Program
{
    static void Main()
    {
        int[] arr = { 8, 3, 2, 9, 7, 1 };

        Console.WriteLine("Original Array:");
        PrintArray(arr);

        // Bubble Sort (O(N^2))
        int[] bubbleArr = (int[])arr.Clone();
        BubbleSort(bubbleArr);
        Console.WriteLine("\nAfter Bubble Sort:");
        PrintArray(bubbleArr);

        // Merge Sort (O(N log N))
        int[] mergeArr = (int[])arr.Clone();
        MergeSort(mergeArr, 0, mergeArr.Length - 1);
        Console.WriteLine("\nAfter Merge Sort:");
        PrintArray(mergeArr);
    }

    // ---------------- BUBBLE SORT ----------------
    static void BubbleSort(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = 0; j < arr.Length - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }

    // ---------------- MERGE SORT ----------------
    static void MergeSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int mid = (left + right) / 2;

            MergeSort(arr, left, mid);
            MergeSort(arr, mid + 1, right);
            Merge(arr, left, mid, right);
        }
    }

    static void Merge(int[] arr, int left, int mid, int right)
    {
        int[] temp = new int[right - left + 1];
        int i = left, j = mid + 1, k = 0;

        while (i <= mid && j <= right)
        {
            if (arr[i] <= arr[j])
                temp[k++] = arr[i++];
            else
                temp[k++] = arr[j++];
        }

        while (i <= mid)
            temp[k++] = arr[i++];

        while (j <= right)
            temp[k++] = arr[j++];

        for (i = left, k = 0; i <= right; i++, k++)
            arr[i] = temp[k];
    }

    // ---------------- PRINT ARRAY ----------------
    static void PrintArray(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
            Console.Write(arr[i] + " ");
        Console.WriteLine();
    }
}
