using System;

class NumberChecker
{
    static int CountDigits(int number)
    {
        int count = 0;
        while (number != 0)
        {
            count++;
            number /= 10;
        }
        return count;
    }

    static int[] GetDigits(int number)
    {
        int count = CountDigits(number);
        int[] digits = new int[count];

        for (int i = 0; i < count; i++)
        {
            digits[i] = number % 10;
            number /= 10;
        }
        return digits;
    }

    static bool IsDuckNumber(int[] digits)
    {
        foreach (int d in digits)
            if (d == 0)
                return true;
        return false;
    }

    static bool IsArmstrong(int number, int[] digits)
    {
        int sum = 0;
        int power = digits.Length;

        foreach (int d in digits)
            sum += (int)Math.Pow(d, power);

        return sum == number;
    }

    static void Main()
    {
        Console.Write("Enter number: ");
        int num = Convert.ToInt32(Console.ReadLine());

        int[] digits = GetDigits(num);

        Console.WriteLine("Duck Number: " + IsDuckNumber(digits));
        Console.WriteLine("Armstrong Number: " + IsArmstrong(num, digits));
    }
}
