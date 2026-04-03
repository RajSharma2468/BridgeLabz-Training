using System;

class Employee
{
    public static string CompanyName = "TechSoft";
    private static int totalEmployees = 0;

    public string name;
    public readonly int id;
    public string designation;

    public Employee(string name, int id, string designation)
    {
        this.name = name;
        this.id = id;
        this.designation = designation;
        totalEmployees++;
    }

    public static void DisplayTotalEmployees()
    {
        Console.WriteLine("Total Employees: " + totalEmployees);
    }

    public void DisplayDetails(object obj)
    {
        if (obj is Employee)
        {
            Console.WriteLine("Company: " + CompanyName);
            Console.WriteLine("Name: " + name);
            Console.WriteLine("ID: " + id);
            Console.WriteLine("Designation: " + designation);
        }
    }
}

class Program
{
    static void Main()
    {
        Employee e = new Employee("Amit", 201, "Developer");
        e.DisplayDetails(e);
        Employee.DisplayTotalEmployees();
    }
}
