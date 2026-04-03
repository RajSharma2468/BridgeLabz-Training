using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter number 1: ");
        double number1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter number 2: ");
        double number2 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("The addition, subtraction, multiplication and division value of 2 numbers " +
                          number1 + " and " + number2 + " is " +
                          (number1 + number2) + ", " +
                          (number1 - number2) + ", " +
                          (number1 * number2) + ", " +
                          (number1 / number2));
    }
}
