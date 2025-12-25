using System;

class FriendsInfo
{
    static int FindYoungest(int[] ages)
    {
        int min = ages[0];
        for (int i = 1; i < ages.Length; i++)
            if (ages[i] < min)
                min = ages[i];
        return min;
    }

    static int FindTallest(int[] heights)
    {
        int max = heights[0];
        for (int i = 1; i < heights.Length; i++)
            if (heights[i] > max)
                max = heights[i];
        return max;
    }

    static void Main()
    {
        int[] ages = new int[3];
        int[] heights = new int[3];

        for (int i = 0; i < 3; i++)
        {
            Console.Write("Enter age: ");
            ages[i] = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter height: ");
            heights[i] = Convert.ToInt32(Console.ReadLine());
        }

        Console.WriteLine("Youngest Age: " + FindYoungest(ages));
        Console.WriteLine("Tallest Height: " + FindTallest(heights));
    }
}
