using System;

class Program
{
    static void AnalyzeScores(int[] marks, int count)
    {
        int index = 0;
        int sum = 0;

        int highest = marks[0];
        int lowest = marks[0];

        while (index < count)
        {
            int current = marks[index];

            sum = sum + current;

            if (current > highest)
            {
                highest = current;
            }
            else
            {
                // nothing
            }

            if (current < lowest)
            {
                lowest = current;
            }
            else
            {
                // nothing
            }

            index = index + 1;
        }

        float average = (float)sum / count;

        Console.WriteLine("Average Score = " + average);
        Console.WriteLine("Highest Score = " + highest);
        Console.WriteLine("Lowest Score = " + lowest);

        Console.WriteLine("Scores Above Average:");

        for (int i = 0; i < count; i++)
        {
            if (marks[i] > average)
            {
                Console.WriteLine(marks[i]);
            }
            else
            {
                // skip
            }
        }
    }

    static void Main()
    {
        Console.WriteLine("Enter number of students:");

        int n;

        if (!int.TryParse(Console.ReadLine(), out n))
        {
            Console.WriteLine("Invalid input");
            return;
        }

        if (n <= 0)
        {
            Console.WriteLine("Invalid number of students");
            return;
        }

        int[] scores = new int[n];

        int i = 0;

        do
        {
            Console.WriteLine("Enter score for student " + (i + 1));

            int value;

            if (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Invalid input, enter again");
                continue;
            }

            if (value < 0)
            {
                Console.WriteLine("Negative score not allowed");
                continue;
            }

            scores[i] = value;
            i = i + 1;

        } while (i < n);

        AnalyzeScores(scores, n);
    }
}
