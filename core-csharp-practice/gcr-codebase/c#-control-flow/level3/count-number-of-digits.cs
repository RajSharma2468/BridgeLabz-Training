using System;

class DigitCountApp
{
    static void Main()
    {
        int number = Convert.ToInt32(Console.ReadLine());
        int count = 0;

        while (number != 0)
        {
            number = number / 10;
            count++;
        }

        Console.WriteLine("Number of digits is " + count);
    }
}
