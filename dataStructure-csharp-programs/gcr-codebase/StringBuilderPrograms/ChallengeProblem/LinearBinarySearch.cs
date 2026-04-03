using System;

class Program
{
    static void Main()
    {
        int[] arr = {3, 4, -1, 1};

        int missing = 1;
        while (true)
        {
            bool found = false;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == missing)
                {
                    found = true;
                    break;
                }
            }

            if (!found) break;
            missing++;
        }

        Console.WriteLine(missing);

        int target = 4;
        int index = -1;

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == target)
            {
                index = i;
                break;
            }
        }

        Console.WriteLine(index);
    }
}
