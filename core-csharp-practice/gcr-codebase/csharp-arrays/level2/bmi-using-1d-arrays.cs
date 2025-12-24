using System;

class BMI
{
    static void Main()
    {
        Console.WriteLine("Enter number of persons");
        int n = Convert.ToInt32(Console.ReadLine());

        double[] height = new double[n];
        double[] weight = new double[n];
        double[] bmi = new double[n];
        string[] status = new string[n];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Enter height (meters)");
            height[i] = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter weight (kg)");
            weight[i] = Convert.ToDouble(Console.ReadLine());
        }

        for (int i = 0; i < n; i++)
        {
            bmi[i] = weight[i] / (height[i] * height[i]);

            if (bmi[i] < 18.5)
                status[i] = "Underweight";
            else if (bmi[i] < 25)
                status[i] = "Normal";
            else if (bmi[i] < 30)
                status[i] = "Overweight";
            else
                status[i] = "Obese";
        }

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Height = " + height[i] + " Weight = " + weight[i] +
                              " BMI = " + bmi[i] + " Status = " + status[i]);
        }
    }
}
