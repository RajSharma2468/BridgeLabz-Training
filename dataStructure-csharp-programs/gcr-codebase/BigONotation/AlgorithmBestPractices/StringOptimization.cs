using System;

class Program
{
    static void Main()
    {
        int n = 1000; // number of characters to concatenate
        char[] result = new char[n];

        for (int i = 0; i < n; i++)
        {
            result[i] = 'A'; // simulating concatenation
        }

        // Print first 50 characters just to verify
        for (int i = 0; i < 50; i++)
            Console.Write(result[i]);

        Console.WriteLine("\nTotal Length: " + result.Length);
    }
}
