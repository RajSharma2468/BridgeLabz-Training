using System;

abstract class Employee
{
    public abstract void CalculateSalary();

    public void CompanyName()
    {
        Console.WriteLine("Company: ABC Ltd");
    }
}

class Developer : Employee
{
    public override void CalculateSalary()
    {
        Console.WriteLine("Salary: 50000");
    }
}

class Program
{
    static void Main()
    {
        Developer d = new Developer();
        d.CompanyName();
        d.CalculateSalary();
    }
}
