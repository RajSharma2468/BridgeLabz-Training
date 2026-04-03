using System;

class BMI2D
{
    static void Main()
    {
        Console.WriteLine("Enter number of persons");
        int n = Convert.ToInt32(Console.ReadLine());

        double[][] personData = new double[n][];
        string[] status = new string[n];

        for (int i = 0; i < n; i++)
            personData[i] = new double[3];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Enter height");
            personData[i][0] = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter weight");
            personData[i][1] = Convert.ToDouble(Console.ReadLine());

            personData[i][2] = personData[i][1] /
                               (personData[i][0] * personData[i][0]);

            if (personData[i][2] < 18.5)
                status[i] = "Underweight";
            else if (personData[i][2] < 25)
                status[i] = "Normal";
            else if (personData[i][2] < 30)
                status[i] = "Overweight";
            else
                status[i] = "Obese";
        }

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Height = " + personData[i][0] +
                              " Weight = " + personData[i][1] +
                              " BMI = " + personData[i][2] +
                              " Status = " + status[i]);
        }
    }
}
