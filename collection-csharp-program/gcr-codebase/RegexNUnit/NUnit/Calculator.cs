using System;

class Calculator
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    public int Subtract(int a, int b)
    {
        return a - b;
    }

    public int Multiply(int a, int b)
    {
        return a * b;
    }

    public int Divide(int a, int b)
    {
        return a / b;
    }
}

class Program
{
    static void Main()
    {
        Calculator calc = new Calculator();

        int num1 = 20;
        int num2 = 5;

        Console.WriteLine("Number 1: " + num1);
        Console.WriteLine("Number 2: " + num2);
        Console.WriteLine();

        Console.WriteLine("Addition: " + calc.Add(num1, num2));
        Console.WriteLine("Subtraction: " + calc.Subtract(num1, num2));
        Console.WriteLine("Multiplication: " + calc.Multiply(num1, num2));
        Console.WriteLine("Division: " + calc.Divide(num1, num2));

        Console.ReadLine();
    }
}
