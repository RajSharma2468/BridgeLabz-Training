using System;

class Program
{
    static void Main()
    {
        int[,] mat = {
            {1,3,5},
            {7,9,11}
        };

        int target = 9;
        int rows = 2, cols = 3;
        int low = 0, high = rows * cols - 1;

        while (low <= high)
        {
            int mid = (low + high) / 2;
            int r = mid / cols;
            int c = mid % cols;

            if (mat[r, c] == target)
            {
                Console.WriteLine("Found");
                return;
            }
            else if (mat[r, c] < target)
                low = mid + 1;
            else
                high = mid - 1;
        }

        Console.WriteLine("Not Found");
    }
}
