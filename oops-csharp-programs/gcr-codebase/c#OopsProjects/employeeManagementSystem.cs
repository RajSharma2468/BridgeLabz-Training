using System;
using System.Collections.Generic;

#region Interface
interface IDepartment
{
    void AssignDepartment(string department);
    string GetDepartmentDetails();
}
#endregion

#region Abstract Class
abstract class Employee
{
    private int employeeId;
    private string name;
    private double baseSalary;

    protected string department;

    public int EmployeeId
    {
        get { return employeeId; }
    }

    public string Name
    {
        get { return name; }
    }

    protected double BaseSalary
    {
        get { return baseSalary; }
    }

    protected Employee(int id, string name, double salary)
    {
        employeeId = id;
        this.name = name;
        baseSalary = salary;
    }

    public abstract double CalculateSalary();

    public virtual void DisplayDetails()
    {
        Console.WriteLine("Employee ID   : " + employeeId);
        Console.WriteLine("Employee Name : " + name);
        Console.WriteLine("Department    : " + department);
        Console.WriteLine("Salary        : " + CalculateSalary());
    }
}
#endregion

#region Full Time Employee
class FullTimeEmployee : Employee, IDepartment
{
    public FullTimeEmployee(int id, string name, double salary)
        : base(id, name, salary)
    {
    }

    public override double CalculateSalary()
    {
        return BaseSalary;
    }

    public void AssignDepartment(string department)
    {
        this.department = department;
    }

    public string GetDepartmentDetails()
    {
        return department;
    }
}
#endregion

#region Part Time Employee
class PartTimeEmployee : Employee, IDepartment
{
    private int workingHours;
    private double hourlyRate;

    public PartTimeEmployee(int id, string name, int hours, double rate)
        : base(id, name, 0)
    {
        workingHours = hours;
        hourlyRate = rate;
    }

    public override double CalculateSalary()
    {
        return workingHours * hourlyRate;
    }

    public void AssignDepartment(string department)
    {
        this.department = department;
    }

    public string GetDepartmentDetails()
    {
        return department;
    }
}
#endregion

#region Main Program
class Program
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>();

        while (true)
        {
            Console.WriteLine("\nEMPLOYEE MANAGEMENT SYSTEM");
            Console.WriteLine("1. Add Full Time Employee");
            Console.WriteLine("2. Add Part Time Employee");
            Console.WriteLine("3. Display All Employees");
            Console.WriteLine("4. Exit");
            Console.Write("Enter Choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddFullTimeEmployee(employees);
                    break;

                case 2:
                    AddPartTimeEmployee(employees);
                    break;

                case 3:
                    DisplayEmployees(employees);
                    break;

                case 4:
                    return;

                default:
                    Console.WriteLine("Invalid Choice!");
                    break;
            }
        }
    }

    static void AddFullTimeEmployee(List<Employee> employees)
    {
        Console.Write("Enter ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Salary: ");
        double salary = double.Parse(Console.ReadLine());

        Console.Write("Enter Department: ");
        string dept = Console.ReadLine();

        FullTimeEmployee emp = new FullTimeEmployee(id, name, salary);
        emp.AssignDepartment(dept);

        employees.Add(emp);

        Console.WriteLine("Full Time Employee Added Successfully.");
    }

    static void AddPartTimeEmployee(List<Employee> employees)
    {
        Console.Write("Enter ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Working Hours: ");
        int hours = int.Parse(Console.ReadLine());

        Console.Write("Enter Hourly Rate: ");
        double rate = double.Parse(Console.ReadLine());

        Console.Write("Enter Department: ");
        string dept = Console.ReadLine();

        PartTimeEmployee emp = new PartTimeEmployee(id, name, hours, rate);
        emp.AssignDepartment(dept);

        employees.Add(emp);

        Console.WriteLine("Part Time Employee Added Successfully.");
    }

    static void DisplayEmployees(List<Employee> employees)
    {
        Console.WriteLine("\nEMPLOYEE LIST\n");

        foreach (Employee emp in employees)
        {
            emp.DisplayDetails();
            Console.WriteLine("----------------------------");
        }
    }
}
#endregion
