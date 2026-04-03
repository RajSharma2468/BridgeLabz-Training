using System;

class SelectionSortScores
{
    static void Main()
    {
        int[] scores = { 67, 85, 45, 90, 72 };

        for (int i = 0; i < scores.Length - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < scores.Length; j++)
                if (scores[j] < scores[minIndex])
                    minIndex = j;

            int temp = scores[minIndex];
            scores[minIndex] = scores[i];
            scores[i] = temp;
        }

        Console.WriteLine("Sorted Exam Scores:");
        foreach (int s in scores)
            Console.Write(s + " ");
    }
}
