using System;

class FizzBuzz
{
    static void Main()
    {
        Console.WriteLine("Enter a positive number");
        int number = Convert.ToInt32(Console.ReadLine());

        if (number <= 0)
        {
            Console.WriteLine("Invalid number");
            return;
        }

        string[] result = new string[number + 1];

        for (int i = 1; i <= number; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
                result[i] = "FizzBuzz";
            else if (i % 3 == 0)
                result[i] = "Fizz";
            else if (i % 5 == 0)
                result[i] = "Buzz";
            else
                result[i] = i.ToString();
        }

        for (int i = 1; i <= number; i++)
        {
            Console.WriteLine("Position " + i + " = " + result[i]);
        }
    }
}
