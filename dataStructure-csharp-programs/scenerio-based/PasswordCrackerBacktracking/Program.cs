using System;
using Services;
using Utils;

class Program
{
    static void Main()
    {
        ConsoleHelper.PrintTitle();

        Console.Write("Enter password length: ");
        int length = int.Parse(Console.ReadLine());

        Console.Write("Enter secret password: ");
        string password = Console.ReadLine();

        CrackerService service = new CrackerService();
        service.StartCracking(password, length);

        ConsoleHelper.PrintComplexity();

        Console.ReadLine();
    }
}
