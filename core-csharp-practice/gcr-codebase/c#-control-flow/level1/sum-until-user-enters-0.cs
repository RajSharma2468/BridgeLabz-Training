using System;

class SumUntilZeroApp
{
    static void Main()
    {
        double total = 0.0;
        double value = Convert.ToDouble(Console.ReadLine());

        while (value != 0)
        {
            total = total + value;
            value = Convert.ToDouble(Console.ReadLine());
        }

        Console.WriteLine("Total is " + total);
    }
}
