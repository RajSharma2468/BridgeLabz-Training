using System;

class ReverseNumber
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
        temp = number;

        for (int i = 0; i < count; i++)
        {
            digits[i] = temp % 10;
            temp = temp / 10;
        }

        Console.WriteLine("Reversed number:");
        for (int i = 0; i < count; i++)
            Console.Write(digits[i]);
    }
}
