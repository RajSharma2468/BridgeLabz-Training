using System;

class RandomNumbers
{
    static int[] Generate4DigitRandomArray(int size)
    {
        Random r = new Random();
        int[] arr = new int[size];

        for (int i = 0; i < size; i++)
            arr[i] = r.Next(1000, 9999);

        return arr;
    }

    static double[] FindAverageMinMax(int[] numbers)
    {
        int min = numbers[0], max = numbers[0], sum = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
            min = Math.Min(min, numbers[i]);
            max = Math.Max(max, numbers[i]);
        }

        return new double[] { sum / (double)numbers.Length, min, max };
    }

    static void Main()
    {
        int[] numbers = Generate4DigitRandomArray(5);
        double[] result = FindAverageMinMax(numbers);

        Console.WriteLine("Average: " + result[0]);
        Console.WriteLine("Min: " + result[1]);
        Console.WriteLine("Max: " + result[2]);
    }
}
