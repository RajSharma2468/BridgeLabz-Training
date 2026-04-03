using System;
using EmployeeWageComputation.Models;
using EmployeeWageComputation.Services;
using EmployeeWageComputation.Interfaces;

namespace EmployeeWageComputation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Employee Wage Computation Program");

            int wagePerHour = ReadNumber("Enter Wage Per Hour : ");
            int fullDayHours = ReadNumber("Enter Full Day Working Hours : ");
            int partTimeHours = ReadNumber("Enter Part Time Working Hours : ");
            int maxDays = ReadNumber("Enter Maximum Working Days : ");
            int maxHours = ReadNumber("Enter Maximum Working Hours : ");

            Employee employee = new Employee(wagePerHour, fullDayHours, partTimeHours);
            IWageCalculator calculator = new WageCalculator(employee);

            int choice;

            do
            {
                Console.WriteLine("\nMenu");
                Console.WriteLine("1. Calculate Daily Wage");
                Console.WriteLine("2. Calculate Monthly Wage");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice : ");

                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.Write("Invalid input. Enter number : ");
                }

                switch (choice)
                {
                    case 1:
                        calculator.CalculateDailyWage();
                        break;

                    case 2:
                        calculator.CalculateMonthlyWage(maxDays, maxHours);
                        break;

                    case 3:
                        Console.WriteLine("Thank You");
                        break;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }

            } while (choice != 3);
        }

        static int ReadNumber(string message)
        {
            int value;
            Console.Write(message);

            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.Write("Invalid input. Enter number : ");
            }

            return value;
        }
    }
}
