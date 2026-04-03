using System;
using SortingAlgorithms.Interfaces;
using SortingAlgorithms.Algorithms;
using SortingAlgorithms.Utilities;

namespace SortingAlgorithms
{
    class Program
    {
        static void Main()
        {
            int[] data = { 64, 25, 12, 22, 11 };

            ISortAlgorithm sort;

            sort = new SelectionSort();
            sort.Sort(data);
            Console.WriteLine("Selection Sort:");
            ArrayHelper.Print(data);

            int[] data2 = { 10, 7, 8, 9, 1, 5 };
            sort = new HeapSort();
            sort.Sort(data2);
            Console.WriteLine("Heap Sort:");
            ArrayHelper.Print(data2);

            int[] data3 = { 4, 2, 2, 8, 3, 3, 1 };
            sort = new CountingSort();
            sort.Sort(data3);
            Console.WriteLine("Counting Sort:");
            ArrayHelper.Print(data3);

            int[] data4 = { 170, 45, 75, 90, 802, 24, 2, 66 };
            sort = new RadixSort();
            sort.Sort(data4);
            Console.WriteLine("Radix Sort:");
            ArrayHelper.Print(data4);

            int[] data5 = { 42, 32, 33, 52, 37, 47, 51 };
            sort = new BucketSort();
            sort.Sort(data5);
            Console.WriteLine("Bucket Sort:");
            ArrayHelper.Print(data5);
        }
    }
}
