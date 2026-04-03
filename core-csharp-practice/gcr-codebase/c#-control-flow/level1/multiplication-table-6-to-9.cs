using System;

class TableSixToNineApp
{
    static void Main()
    {
        int number = Convert.ToInt32(Console.ReadLine());

        for (int i = 6; i <= 9; i++)
        {
            Console.WriteLine(number + " * " + i + " = " + (number * i));
        }
    }
}
