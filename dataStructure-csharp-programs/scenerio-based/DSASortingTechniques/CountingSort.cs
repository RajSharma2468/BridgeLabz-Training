using SortingAlgorithms.Interfaces;

namespace SortingAlgorithms.Algorithms
{
    class CountingSort : ISortAlgorithm
    {
        public void Sort(int[] arr)
        {
            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max)
                    max = arr[i];
            }

            int[] count = new int[max + 1];

            for (int i = 0; i < arr.Length; i++)
                count[arr[i]]++;

            int index = 0;
            for (int i = 0; i < count.Length; i++)
            {
                while (count[i] > 0)
                {
                    arr[index++] = i;
                    count[i]--;
                }
            }
        }
    }
}
