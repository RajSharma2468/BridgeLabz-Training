using Models;

namespace Algorithms
{
    public class RadixSorter
    {
        public static void Sort(AadhaarRecord[] records)
        {
            long max = GetMax(records);

            for (long exp = 1; max / exp > 0; exp *= 10)
            {
                CountingSort(records, exp);
            }
        }

        private static void CountingSort(AadhaarRecord[] records, long exp)
        {
            int n = records.Length;
            AadhaarRecord[] output = new AadhaarRecord[n];
            int[] count = new int[10];

            for (int i = 0; i < n; i++)
            {
                int digit = (int)((records[i].AadhaarNumber / exp) % 10);
                count[digit]++;
            }

            for (int i = 1; i < 10; i++)
                count[i] += count[i - 1];

            for (int i = n - 1; i >= 0; i--)
            {
                int digit = (int)((records[i].AadhaarNumber / exp) % 10);
                output[count[digit] - 1] = records[i];
                count[digit]--;
            }

            for (int i = 0; i < n; i++)
                records[i] = output[i];
        }

        private static long GetMax(AadhaarRecord[] records)
        {
            long max = records[0].AadhaarNumber;
            foreach (var r in records)
                if (r.AadhaarNumber > max) max = r.AadhaarNumber;
            return max;
        }
    }
}
