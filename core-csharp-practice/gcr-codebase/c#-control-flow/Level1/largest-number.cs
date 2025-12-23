using System;

class Program
{
    static void Main()
    {
        int number1 = int.Parse(Console.ReadLine());
        int number2 = int.Parse(Console.ReadLine());
        int number3 = int.Parse(Console.ReadLine());

        Console.WriteLine("Is the first number the largest? " + (number1 > number2 && number1 > number3));
        Console.WriteLine("Is the second number the largest? " + (number2 > number1 && number2 > number3));
        Console.WriteLine("Is the third number the largest? " + (number3 > number1 && number3 > number2));
    }
}
