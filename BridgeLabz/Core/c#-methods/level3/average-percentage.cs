using System;

class StudentMarks
{
    static void Main()
    {
        Console.Write("Enter number of students: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[,] marks = new int[n, 3];
        double[,] result = new double[n, 3];

        Random rand = new Random();

        // Generate random marks
        for (int i = 0; i < n; i++)
        {
            marks[i, 0] = rand.Next(40, 100); // Physics
            marks[i, 1] = rand.Next(40, 100); // Chemistry
            marks[i, 2] = rand.Next(40, 100); // Maths
        }

        // Calculate total, average, percentage
        for (int i = 0; i < n; i++)
        {
            double total = marks[i, 0] + marks[i, 1] + marks[i, 2];
            double average = total / 3;
            double percentage = total / 300 * 100;

            result[i, 0] = Math.Round(total, 2);
            result[i, 1] = Math.Round(average, 2);
            result[i, 2] = Math.Round(percentage, 2);
        }

        // Display result
        Console.WriteLine("\nPhy\tChem\tMath\tTotal\tAvg\tPercent");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(
                marks[i, 0] + "\t" +
                marks[i, 1] + "\t" +
                marks[i, 2] + "\t" +
                result[i, 0] + "\t" +
                result[i, 1] + "\t" +
                result[i, 2]
            );
        }
    }
}
