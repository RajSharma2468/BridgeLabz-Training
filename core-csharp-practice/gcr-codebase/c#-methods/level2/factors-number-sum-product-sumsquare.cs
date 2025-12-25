using System;

class FactorsProgram
{
    static int[] FindFactors(int number)
    {
        int count = 0;
        for (int i = 1; i <= number; i++)
            if (number % i == 0)
                count++;

        int[] factors = new int[count];
        int index = 0;

        for (int i = 1; i <= number; i++)
            if (number % i == 0)
                factors[index++] = i;

        return factors;
    }

    static int Sum(int[] arr)
    {
        int sum = 0;
        for (int i = 0; i < arr.Length; i++)
            sum += arr[i];
        return sum;
    }

    static long Product(int[] arr)
    {
        long product = 1;
        for (int i = 0; i < arr.Length; i++)
            product *= arr[i];
        return product;
    }

    static double SumOfSquares(int[] arr)
    {
        double sum = 0;
        for (int i = 0; i < arr.Length; i++)
            sum += Math.Pow(arr[i], 2);
        return sum;
    }

    static void Main()
    {
        Console.WriteLine("Enter number");
        int number = Convert.ToInt32(Console.ReadLine());

        int[] factors = FindFactors(number);

        Console.WriteLine("Factors:");
        for (int i = 0; i < factors.Length; i++)
            Console.WriteLine(factors[i]);

        Console.WriteLine("Sum = " + Sum(factors));
        Console.WriteLine("Product = " + Product(factors));
        Console.WriteLine("Sum of Squares = " + SumOfSquares(factors));
    }
}
