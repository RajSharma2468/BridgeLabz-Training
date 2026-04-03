using System;

class NumberChecker
{
    static int[] GetDigits(int number)
    {
        int temp = number, count = 0;
        while (temp > 0)
        {
            count++;
            temp /= 10;
        }

        int[] digits = new int[count];
        for (int i = 0; i < count; i++)
        {
            digits[i] = number % 10;
            number /= 10;
        }
        return digits;
    }

    static int SumDigits(int[] digits)
    {
        int sum = 0;
        foreach (int d in digits)
            sum += d;
        return sum;
    }

    static bool IsHarshad(int number, int[] digits)
    {
        return number % SumDigits(digits) == 0;
    }

    static void Main()
    {
        Console.Write("Enter number: ");
        int num = Convert.ToInt32(Console.ReadLine());

        int[] digits = GetDigits(num);

        Console.WriteLine("Sum of Digits: " + SumDigits(digits));
        Console.WriteLine("Harshad Number: " + IsHarshad(num, digits));
    }
}
