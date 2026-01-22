using SortingAlgorithms.Interfaces;

namespace SortingAlgorithms.Algorithms
{
    class RadixSort : ISortAlgorithm
    {
        public void Sort(int[] arr)
        {
            int max = GetMax(arr);

            for (int exp = 1; max / exp > 0; exp = exp * 10)
                CountingSortByDigit(arr, exp);
        }

        private int GetMax(int[] arr)
        {
            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
                if (arr[i] > max)
                    max = arr[i];
            return max;
        }

        private void CountingSortByDigit(int[] arr, int exp)
        {
            int n = arr.Length;
            int[] output = new int[n];
            int[] count = new int[10];

            for (int i = 0; i < n; i++)
                count[(arr[i] / exp) % 10]++;

            for (int i = 1; i < 10; i++)
                count[i] += count[i - 1];

            for (int i = n - 1; i >= 0; i--)
            {
                int index = (arr[i] / exp) % 10;
                output[count[index] - 1] = arr[i];
                count[index]--;
            }

            for (int i = 0; i < n; i++)
                arr[i] = output[i];
        }
    }
}
