using System;

class CountingSortAges
{
    static void Main()
    {
        int[] ages = { 12, 15, 10, 14, 18, 12, 16 };
        int min = 10, max = 18;

        int[] count = new int[max - min + 1];

        foreach (int age in ages)
            count[age - min]++;

        Console.WriteLine("Sorted Ages:");
        for (int i = 0; i < count.Length; i++)
            while (count[i]-- > 0)
                Console.Write((i + min) + " ");
    }
}
