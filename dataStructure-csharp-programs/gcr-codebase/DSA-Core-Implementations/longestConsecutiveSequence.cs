using System;

class LongestConsecutive
{
    static int Longest(int[] arr)
    {
        int longest = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            int count = 1;
            int current = arr[i];

            for (int j = 0; j < arr.Length; j++)
                if (arr[j] == current - 1)
                    goto skip;

            while (true)
            {
                bool found = false;
                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[j] == current + 1)
                    {
                        current++;
                        count++;
                        found = true;
                        break;
                    }
                }
                if (!found) break;
            }

            if (count > longest)
                longest = count;

        skip:;
        }
        return longest;
    }

    static void Main()
    {
        int[] arr = { 100, 4, 200, 1, 3, 2 };
        Console.WriteLine(Longest(arr));
    }
}
