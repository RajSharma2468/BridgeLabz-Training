using System;

class BMIProgram
{
    static double CalculateBMI(double weight, double heightCm)
    {
        double heightM = heightCm / 100;
        return weight / (heightM * heightM);
    }

    static void Main()
    {
        double[,] data = new double[10, 3];

        for (int i = 0; i < 10; i++)
        {
            Console.Write("Enter weight (kg): ");
            data[i, 0] = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter height (cm): ");
            data[i, 1] = Convert.ToDouble(Console.ReadLine());

            data[i, 2] = CalculateBMI(data[i, 0], data[i, 1]);
        }

        for (int i = 0; i < 10; i++)
            Console.WriteLine("BMI: " + data[i, 2]);
    }
}
