// Use sorting efficiently
//  Bubble Sort (O(N²))
//  Merge Sort (O(N log N))
//  Code: Merge Sort

using System;

class MergeSortExample
{
    static void MergeSort(int[] arr, int left, int right)
    {
        if (left >= right) return;

        int mid = (left + right) / 2;
        MergeSort(arr, left, mid);
        MergeSort(arr, mid + 1, right);
        Merge(arr, left, mid, right);
    }

    static void Merge(int[] arr, int left, int mid, int right)
    {
        int[] temp = new int[right - left + 1];
        int i = left, j = mid + 1, k = 0;

        while (i <= mid && j <= right)
            temp[k++] = arr[i] < arr[j] ? arr[i++] : arr[j++];

        while (i <= mid) temp[k++] = arr[i++];
        while (j <= right) temp[k++] = arr[j++];

        for (i = left, k = 0; i <= right; i++, k++)
            arr[i] = temp[k];
    }

    static void Main()
    {
        int[] arr = { 5, 1, 4, 2 };
        MergeSort(arr, 0, arr.Length - 1);

        foreach (int x in arr)
            Console.Write(x + " ");
    }
}
