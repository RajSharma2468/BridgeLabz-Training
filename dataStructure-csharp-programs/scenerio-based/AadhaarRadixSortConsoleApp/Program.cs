using System;
using Services;
using Utils;

class Program
{
    static void Main(string[] args)
    {
        ConsoleHelper.PrintTitle();

        Console.Write("Enter number of Aadhaar records: ");
        int n = int.Parse(Console.ReadLine());

        AadhaarService service = new AadhaarService(n);

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("\nRecord " + (i + 1));

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter 12-digit Aadhaar Number: ");
            long aadhaar = long.Parse(Console.ReadLine());

            service.AddRecord(aadhaar, name);
        }

        Console.WriteLine("\nSorting Aadhaar Numbers using Radix Sort...");
        service.SortRecords();

        ConsoleHelper.PrintRecords(service.GetAllRecords());

        Console.Write("\nEnter Aadhaar number to search: ");
        long search = long.Parse(Console.ReadLine());

        int index = service.SearchRecord(search);

        if (index != -1)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Aadhaar Found");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Aadhaar Not Found");
        }

        Console.ResetColor();
        ConsoleHelper.PrintFooter();
        Console.ReadKey();
    }
}
