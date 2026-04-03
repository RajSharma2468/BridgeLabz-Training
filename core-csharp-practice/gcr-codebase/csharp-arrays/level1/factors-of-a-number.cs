using System;

class Factors
{
    static void Main()
    {
        Console.WriteLine("Enter a number");
        int number = Convert.ToInt32(Console.ReadLine());

        int maxSize = 10;
        int[] factors = new int[maxSize];
        int index = 0;

        for (int i = 1; i <= number; i++)
        {
            if (number % i == 0)
            {
                if (index == maxSize)
                {
                    maxSize = maxSize * 2;
                    int[] temp = new int[maxSize];

                    for (int j = 0; j < factors.Length; j++)
                        temp[j] = factors[j];

                    factors = temp;
                }

                factors[index] = i;
                index++;
            }
        }

        Console.WriteLine("Factors are:");
        for (int i = 0; i < index; i++)
            Console.WriteLine(factors[i]);
    }
}
