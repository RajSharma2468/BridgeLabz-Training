using System;
using System.Reflection;
using EmployeeWageApp.Attributes;
using EmployeeWageApp.Data;
using Microsoft.Data.SqlClient;

namespace EmployeeWageApp
{
    [Info(Description = "Employee Wage Computation Program", Version = "1.0")]
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to Employee Wage Computation Program");

            // Ensure database and table exist
            DbConnectionFactory.CreateDatabaseIfNotExists();

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n--- Main Menu ---");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Show All Employees");
                Console.WriteLine("3. Calculate Daily Wage");
                Console.WriteLine("4. Exit");

                string? choiceInput = Console.ReadLine();
                string choice = choiceInput ?? "";

                switch (choice)
                {
                    case "1":
                        AddEmployee();
                        break;
                    case "2":
                        ShowEmployees();
                        break;
                    case "3":
                        CalculateDailyWage();
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Try again.");
                        break;
                }
            }

            Console.WriteLine("Thank you for using Employee Wage App!");
        }

        static void AddEmployee()
        {
            Console.Write("Enter Employee Name: ");
            string? nameInput = Console.ReadLine();
            string name = nameInput ?? "";

            Console.Write("Enter Employee Type (FullTime/PartTime): ");
            string? typeInput = Console.ReadLine();
            string type = typeInput ?? "";

            int dailyHours = 0;
            if (type.Equals("FullTime", StringComparison.OrdinalIgnoreCase))
            {
                dailyHours = 8;
            }
            else if (type.Equals("PartTime", StringComparison.OrdinalIgnoreCase))
            {
                dailyHours = 4;
            }
            else
            {
                Console.WriteLine("Invalid employee type! Using default 8 hours.");
                dailyHours = 8;
            }

            using (var conn = DbConnectionFactory.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Employees (Name, Type, DailyHours, TotalHoursWorked) VALUES (@name, @type, @hours, 0)";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@hours", dailyHours);
                    cmd.ExecuteNonQuery();
                }
            }

            Console.WriteLine(string.Format("Employee {0} added successfully!", name));
        }

        static void ShowEmployees()
        {
            using (var conn = DbConnectionFactory.GetConnection())
            {
                conn.Open();
                string query = "SELECT Id, Name, Type, DailyHours, TotalHoursWorked FROM Employees";
                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    Console.WriteLine("\n--- Employees ---");
                    Console.WriteLine("ID | Name | Type | DailyHours | TotalHoursWorked");

                    while (reader.Read())
                    {
                        int id = (int)reader["Id"];
                        string name = (string)reader["Name"];
                        string type = (string)reader["Type"];
                        int dailyHours = (int)reader["DailyHours"];
                        int totalHours = (int)reader["TotalHoursWorked"];

                        Console.WriteLine(string.Format("{0} | {1} | {2} | {3} | {4}", id, name, type, dailyHours, totalHours));
                    }
                }
            }
        }

        static void CalculateDailyWage()
        {
            const int wagePerHour = 20;

            using (var conn = DbConnectionFactory.GetConnection())
            {
                conn.Open();
                string selectQuery = "SELECT Id, Name, Type, DailyHours FROM Employees";

                using (var cmd = new SqlCommand(selectQuery, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    Console.WriteLine("\n--- Daily Wages ---");

                    while (reader.Read())
                    {
                        int id = (int)reader["Id"];
                        string name = (string)reader["Name"];
                        string type = (string)reader["Type"];
                        int hours = (int)reader["DailyHours"];

                        int dailyWage = hours * wagePerHour;
                        Console.WriteLine(string.Format("{0} ({1}) -> {2} per day", name, type, dailyWage));

                        // Update TotalHoursWorked using a separate command
                        using (var updateCmd = new SqlCommand("UPDATE Employees SET TotalHoursWorked = TotalHoursWorked + @hours WHERE Id = @id", conn))
                        {
                            updateCmd.Parameters.AddWithValue("@hours", hours);
                            updateCmd.Parameters.AddWithValue("@id", id);
                            updateCmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
    }
}
