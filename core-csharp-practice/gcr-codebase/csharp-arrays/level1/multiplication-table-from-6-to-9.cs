using System;

class TableSixToNine
{
    static void Main()
    {
        Console.WriteLine("Enter a number");
        int number = Convert.ToInt32(Console.ReadLine());

        int[] result = new int[4];

        int index = 0;
        for (int i = 6; i <= 9; i++)
        {
            result[index] = number * i;
            Console.WriteLine(number + " * " + i + " = " + result[index]);
            index++;
        }
    }
}
