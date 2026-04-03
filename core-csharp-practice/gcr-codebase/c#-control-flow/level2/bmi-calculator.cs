using System;

class BmiCalculatorApp
{
    static void Main()
    {
        double weight = Convert.ToDouble(Console.ReadLine());
        double heightCm = Convert.ToDouble(Console.ReadLine());

        double heightMeter = heightCm / 100;
        double bmi = weight / (heightMeter * heightMeter);

        Console.WriteLine("BMI is " + bmi);

        if (bmi < 18.5)
            Console.WriteLine("Underweight");
        else if (bmi >= 18.5 && bmi < 25)
            Console.WriteLine("Normal");
        else if (bmi >= 25 && bmi < 30)
            Console.WriteLine("Overweight");
        else
            Console.WriteLine("Obese");
    }
}
