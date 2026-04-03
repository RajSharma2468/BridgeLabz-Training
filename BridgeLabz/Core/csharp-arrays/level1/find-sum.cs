using System;

class StoreNumbers
{
    static void Main()
    {
        double[] numbers = new double[10];
        double total = 0.0;
        int index = 0;

        while (true)
        {
            Console.WriteLine("Enter a number");
            double input = Convert.ToDouble(Console.ReadLine());

            if (input <= 0 || index == 10)
                break;

            numbers[index] = input;
            index++;
        }

        for (int i = 0; i < index; i++)
        {
            Console.WriteLine(numbers[i]);
            total = total + numbers[i];
        }

        Console.WriteLine("Total = " + total);
    }
}
