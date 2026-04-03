using System.Collections.Generic;
using SortingAlgorithms.Interfaces;

namespace SortingAlgorithms.Algorithms
{
    class BucketSort : ISortAlgorithm
    {
        public void Sort(int[] arr)
        {
            int n = arr.Length;
            List<int>[] buckets = new List<int>[n];

            for (int i = 0; i < n; i++)
                buckets[i] = new List<int>();

            int max = arr[0];
            for (int i = 1; i < n; i++)
                if (arr[i] > max)
                    max = arr[i];

            for (int i = 0; i < n; i++)
            {
                int index = arr[i] * n / (max + 1);
                buckets[index].Add(arr[i]);
            }

            int k = 0;
            for (int i = 0; i < n; i++)
            {
                buckets[i].Sort();
                foreach (int value in buckets[i])
                    arr[k++] = value;
            }
        }
    }
}
