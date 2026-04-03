using System;

class StudentGrade2D
{
    static void Main()
    {
        Console.WriteLine("Enter number of students");
        int n = Convert.ToInt32(Console.ReadLine());

        int[,] marks = new int[n, 3];
        double[] percentage = new double[n];
        string[] grade = new string[n];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Enter Physics marks");
            marks[i, 0] = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Chemistry marks");
            marks[i, 1] = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Maths marks");
            marks[i, 2] = Convert.ToInt32(Console.ReadLine());

            percentage[i] = (marks[i, 0] + marks[i, 1] + marks[i, 2]) / 3.0;

            if (percentage[i] >= 75)
                grade[i] = "A";
            else if (percentage[i] >= 60)
                grade[i] = "B";
            else if (percentage[i] >= 50)
                grade[i] = "C";
            else
                grade[i] = "Fail";
        }

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Percentage = " + percentage[i] + " Grade = " + grade[i]);
        }
    }
}
