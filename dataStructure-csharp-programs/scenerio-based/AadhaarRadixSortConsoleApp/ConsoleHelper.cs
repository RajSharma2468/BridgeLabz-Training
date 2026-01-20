using System;
using Models;

namespace Utils
{
    public class ConsoleHelper
    {
        public static void PrintTitle()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("======================================");
            Console.WriteLine("   AADHAAR SORTING SYSTEM (RADIX SORT) ");
            Console.WriteLine("======================================");
            Console.ResetColor();
        }

        public static void PrintRecords(AadhaarRecord[] records)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n--- SORTED AADHAAR RECORDS ---");
            Console.ResetColor();

            foreach (var r in records)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(r);
            }
            Console.ResetColor();
        }

        public static void PrintFooter()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\nProgram Finished Successfully ✔");
            Console.ResetColor();
        }
    }
}
