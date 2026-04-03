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

    static int[] ReverseArray(int[] arr)
    {
        int[] rev = new int[arr.Length];
        for (int i = 0; i < arr.Length; i++)
            rev[i] = arr[arr.Length - 1 - i];
        return rev;
    }

    static bool CompareArrays(int[] a, int[] b)
    {
        for (int i = 0; i < a.Length; i++)
            if (a[i] != b[i])
                return false;
        return true;
    }

    static bool IsPalindrome(int[] digits)
    {
        return CompareArrays(digits, ReverseArray(digits));
    }

    static bool IsDuck(int[] digits)
    {
        foreach (int d in digits)
            if (d == 0)
                return true;
        return false;
    }

    static void Main()
    {
        Console.Write("Enter number: ");
        int num = Convert.ToInt32(Console.ReadLine());

        int[] digits = GetDigits(num);

        Console.WriteLine("Palindrome: " + IsPalindrome(digits));
        Console.WriteLine("Duck Number: " + IsDuck(digits));
    }
}
