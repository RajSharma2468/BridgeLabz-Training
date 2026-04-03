using System;

namespace SortingAlgorithms.Utilities
{
    class ArrayHelper
    {
        public static void Print(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }
    }
}
