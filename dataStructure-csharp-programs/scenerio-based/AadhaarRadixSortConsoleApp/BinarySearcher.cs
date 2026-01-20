using Models;

namespace Algorithms
{
    public class BinarySearcher
    {
        public static int Search(AadhaarRecord[] records, long target)
        {
            int left = 0, right = records.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (records[mid].AadhaarNumber == target)
                    return mid;
                else if (records[mid].AadhaarNumber < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            return -1;
        }
    }
}
