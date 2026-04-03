using System;
class Employee
{
    public String name;
    public int id;
    public int salary;

    public void displayDetails()
    {
        Console.WriteLine("Employee name is "+name);
        Console.WriteLine("Employee id is "+id);
        Console.WriteLine("Employee salary is "+salary);
    }
}

class Program
{
    static void Main()
    {
        Employee emp=new Employee();
        emp.name="Raj Sharma";
        emp.id=23;
        emp.salary=150000;

        emp.displayDetails();
    }
}