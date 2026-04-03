using System;

class PowerOfNumberApp
{
    static void Main()
    {
        int number = Convert.ToInt32(Console.ReadLine());
        int power = Convert.ToInt32(Console.ReadLine());
        int result = 1;

        for (int i = 1; i <= power; i++)
        {
            result = result * number;
        }

        Console.WriteLine("Result is " + result);
    }
}
