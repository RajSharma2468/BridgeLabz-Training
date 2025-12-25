using System;

class FootballTeamHeight
{
    static int FindSum(int[] heights)
    {
        int sum = 0;
        for (int i = 0; i < heights.Length; i++)
            sum += heights[i];
        return sum;
    }

    static double FindMean(int[] heights)
    {
        return (double)FindSum(heights) / heights.Length;
    }

    static int FindShortest(int[] heights)
    {
        int min = heights[0];
        for (int i = 1; i < heights.Length; i++)
            if (heights[i] < min)
                min = heights[i];
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
        int[] heights = new int[11];
        Random r = new Random();

        for (int i = 0; i < heights.Length; i++)
            heights[i] = r.Next(150, 251);

        Console.WriteLine("Player Heights:");
        foreach (int h in heights)
            Console.Write(h + " ");

        Console.WriteLine("\nShortest Height: " + FindShortest(heights));
        Console.WriteLine("Tallest Height: " + FindTallest(heights));
        Console.WriteLine("Mean Height: " + FindMean(heights));
    }
}
