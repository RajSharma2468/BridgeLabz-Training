using System;

class Program
{
    static int Add(int a, int b) { return a + b; }
    static int Subtract(int a, int b) { return a - b; }
    static int Multiply(int a, int b) { return a * b; }
    static int Divide(int a, int b) { return a / b; }

    static void Main()
    {
        Console.Write("Enter first number: ");
        int a = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter second number: ");
        int b = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("1. Add");
        Console.WriteLine("2. Subtract");
        Console.WriteLine("3. Multiply");
        Console.WriteLine("4. Divide");

        Console.Write("Choose operation: ");
        int choice = Convert.ToInt32(Console.ReadLine());

        if (choice == 1)
            Console.WriteLine("Result: " + Add(a, b));
        else if (choice == 2)
            Console.WriteLine("Result: " + Subtract(a, b));
        else if (choice == 3)
            Console.WriteLine("Result: " + Multiply(a, b));
        else if (choice == 4)
            Console.WriteLine("Result: " + Divide(a, b));
    }
}
