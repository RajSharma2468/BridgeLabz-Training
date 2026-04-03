using System;

class HarshadNumberApp
{
    static void Main()
    {
        int number = Convert.ToInt32(Console.ReadLine());
        int originalNumber = number;
        int sum = 0;

        while (number != 0)
        {
            int digit = number % 10;
            sum = sum + digit;
            number = number / 10;
        }

        if (originalNumber % sum == 0)
            Console.WriteLine("Harshad Number");
        else
            Console.WriteLine("Not a Harshad Number");
    }
}
