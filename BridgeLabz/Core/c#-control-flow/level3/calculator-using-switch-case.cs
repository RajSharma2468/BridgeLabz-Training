using System;

class CalculatorSwitchApp
{
    static void Main()
    {
        double first = Convert.ToDouble(Console.ReadLine());
        double second = Convert.ToDouble(Console.ReadLine());
        string op = Console.ReadLine();

        switch (op)
        {
            case "+":
                Console.WriteLine("Result is " + (first + second));
                break;

            case "-":
                Console.WriteLine("Result is " + (first - second));
                break;

            case "*":
                Console.WriteLine("Result is " + (first * second));
                break;

            case "/":
                Console.WriteLine("Result is " + (first / second));
                break;

            default:
                Console.WriteLine("Invalid Operator");
                break;
        }
    }
}
