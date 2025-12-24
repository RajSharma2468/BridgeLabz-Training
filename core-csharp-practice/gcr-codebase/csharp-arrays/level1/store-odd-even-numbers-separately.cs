using System;

class OddEvenArray
{
    static void Main()
    {
        Console.WriteLine("Enter a natural number");
        int number = Convert.ToInt32(Console.ReadLine());

        if (number <= 0)
        {
            Console.WriteLine("Invalid Natural Number");
            return;
        }

        int[] even = new int[number / 2 + 1];
        int[] odd = new int[number / 2 + 1];

        int evenIndex = 0;
        int oddIndex = 0;

        for (int i = 1; i <= number; i++)
        {
            if (i % 2 == 0)
            {
                even[evenIndex] = i;
                evenIndex++;
            }
            else
            {
                odd[oddIndex] = i;
                oddIndex++;
            }
        }

        Console.WriteLine("Even Numbers:");
        for (int i = 0; i < evenIndex; i++)
            Console.WriteLine(even[i]);

        Console.WriteLine("Odd Numbers:");
        for (int i = 0; i < oddIndex; i++)
            Console.WriteLine(odd[i]);
    }
}
