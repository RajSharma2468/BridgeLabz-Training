using System;

class StudentGrade
{
    static void Main()
    {
        Console.WriteLine("Enter number of students");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] physics = new int[n];
        int[] chemistry = new int[n];
        int[] maths = new int[n];
        double[] percentage = new double[n];
        string[] grade = new string[n];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Enter Physics marks");
            physics[i] = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Chemistry marks");
            chemistry[i] = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Maths marks");
            maths[i] = Convert.ToInt32(Console.ReadLine());

            if (physics[i] < 0 || chemistry[i] < 0 || maths[i] < 0)
            {
                Console.WriteLine("Invalid marks");
                i--;
                continue;
            }

            percentage[i] = (physics[i] + chemistry[i] + maths[i]) / 3.0;

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
