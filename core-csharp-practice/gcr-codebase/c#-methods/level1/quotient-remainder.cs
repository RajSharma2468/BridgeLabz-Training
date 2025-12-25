using System;

class QuotientRemainder
{
    public static int[] FindRemainderAndQuotient(int number, int divisor)
    {
        int quotient = number / divisor;
        int remainder = number % divisor;

        return new int[] { quotient, remainder };
    }

    static void Main()
    {
        Console.WriteLine("Enter number");
        int number = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter divisor");
        int divisor = Convert.ToInt32(Console.ReadLine());

        int[] result = FindRemainderAndQuotient(number, divisor);

        Console.WriteLine("Quotient = " + result[0]);
        Console.WriteLine("Remainder = " + result[1]);
    }
}
