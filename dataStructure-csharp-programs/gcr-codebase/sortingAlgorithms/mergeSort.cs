using System;

class MergeSortBooks
{
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
        int[] L = new int[mid - left + 1];
        int[] R = new int[right - mid];

        for (int i = 0; i < L.Length; i++)
            L[i] = arr[left + i];
        for (int j = 0; j < R.Length; j++)
            R[j] = arr[mid + 1 + j];

        int iIndex = 0, jIndex = 0, k = left;

        while (iIndex < L.Length && jIndex < R.Length)
            arr[k++] = (L[iIndex] <= R[jIndex]) ? L[iIndex++] : R[jIndex++];

        while (iIndex < L.Length)
            arr[k++] = L[iIndex++];
        while (jIndex < R.Length)
            arr[k++] = R[jIndex++];
    }

    static void Main()
    {
        int[] prices = { 450, 299, 799, 150, 600 };
        MergeSort(prices, 0, prices.Length - 1);

        Console.WriteLine("Sorted Book Prices:");
        foreach (int p in prices)
            Console.Write(p + " ");
    }
}
