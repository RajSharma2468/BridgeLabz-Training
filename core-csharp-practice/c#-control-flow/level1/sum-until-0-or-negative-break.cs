using System;

class SumBreakApp
{
    static void Main()
    {
        double total = 0.0;

        while (true)
        {
            double value = Convert.ToDouble(Console.ReadLine());
            if (value <= 0)
                break;

            total = total + value;
        }

        Console.WriteLine("Total is " + total);
    }
}
