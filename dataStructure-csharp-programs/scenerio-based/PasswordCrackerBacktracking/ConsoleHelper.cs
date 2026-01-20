using System;

namespace Utils
{
    public class ConsoleHelper
    {
        public static void PrintTitle()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=======================================");
            Console.WriteLine("   PASSWORD CRACKER - BACKTRACKING     ");
            Console.WriteLine("=======================================");
            Console.ResetColor();
        }

        public static void PrintComplexity()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nTime Complexity:");
            Console.WriteLine("O(k^n) where k = charset size, n = password length");

            Console.WriteLine("\nSpace Complexity:");
            Console.WriteLine("O(n) due to recursion stack");
            Console.ResetColor();
        }
    }
}
