using System;
using System.IO;

class Program
{
    static void Main()
    {
        string[] employees =
        {
            "ID,Name,Department,Salary",
            "1,Rahul,IT,50000",
            "2,Anita,HR,45000",
            "3,Sam,Finance,55000",
            "4,Priya,IT,60000",
            "5,Amit,Marketing,48000"
        };

        File.WriteAllLines("employees.csv", employees);
        Console.WriteLine("CSV file created successfully!");
    }
}
