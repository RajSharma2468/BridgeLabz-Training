using System;

class Program
{
    static void Main()
    {
        int number1 = int.Parse(Console.ReadLine());
        int number2 = int.Parse(Console.ReadLine());
        int number3 = int.Parse(Console.ReadLine());

        bool result = (number1 < number2 && number1 < number3);

        Console.WriteLine("Is the first number the smallest? " + result);
    }
}
