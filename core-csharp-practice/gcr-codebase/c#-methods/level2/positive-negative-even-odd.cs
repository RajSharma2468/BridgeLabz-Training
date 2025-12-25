using System;

class NumberAnalysis
{
    // Method to check positive or negative
    public static int IsPositive(int number)
    {
        if (number > 0)
            return 1;
        else
            return -1;
    }

    // Method to check even or odd
    public static bool IsEven(int number)
    {
        if (number % 2 == 0)
            return true;
        else
            return false;
    }

    // Method to compare two numbers
    // Returns 1 if first > second, 0 if equal, -1 if first < second
    public static int Compare(int num1, int num2)
    {
        if (num1 > num2)
            return 1;
        else if (num1 == num2)
            return 0;
        else
            return -1;
    }

    static void Main()
    {
        int[] numbers = new int[5];

        // Input
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write("Enter number " + (i + 1) + ": ");
            numbers[i] = Convert.ToInt32(Console.ReadLine());
        }

        // Check positive/negative and even/odd
        for (int i = 0; i < numbers.Length; i++)
        {
            int result = IsPositive(numbers[i]);

            if (result == 1)
            {
                if (IsEven(numbers[i]))
                    Console.WriteLine(numbers[i] + " is Positive and Even");
                else
                    Console.WriteLine(numbers[i] + " is Positive and Odd");
            }
            else
            {
                Console.WriteLine(numbers[i] + " is Negative");
            }
        }

        // Compare first and last element
        int comparison = Compare(numbers[0], numbers[4]);

        if (comparison == 1)
            Console.WriteLine("First element is Greater than Last element");
        else if (comparison == 0)
            Console.WriteLine("First element is Equal to Last element");
        else
            Console.WriteLine("First element is Less than Last element");
    }
}
