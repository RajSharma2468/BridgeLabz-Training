using System;

class DigitFrequency
{
    static void Main()
    {
        Console.WriteLine("Enter a number");
        int number = Convert.ToInt32(Console.ReadLine());

        int temp = number;
        int count = 0;

        while (temp != 0)
        {
            count++;
            temp = temp / 10;
        }

        int[] digits = new int[count];
        int[] frequency = new int[10];

        temp = number;

        for (int i = 0; i < count; i++)
        {
            digits[i] = temp % 10;
            temp = temp / 10;
        }

        for (int i = 0; i < count; i++)
            frequency[digits[i]]++;

        for (int i = 0; i < 10; i++)
            Console.WriteLine("Digit " + i + " occurs " + frequency[i] + " times");
    }
}
