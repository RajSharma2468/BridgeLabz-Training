using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;

class Employee
{
    public int id;
    public string name;
    public string department;
    public double salary;
}

class EmployeeData
{
    static void Main()
    {
        string file = "employee.json";

        List<Employee> list = new List<Employee>();
        list.Add(new Employee { id = 1, name = "Amit", department = "IT", salary = 50000 });
        list.Add(new Employee { id = 2, name = "Neha", department = "HR", salary = 45000 });

        try
        {
            string jsonData = JsonSerializer.Serialize(list);
            File.WriteAllText(file, jsonData);

            string readData = File.ReadAllText(file);
            List<Employee> empList = JsonSerializer.Deserialize<List<Employee>>(readData);

            foreach (Employee e in empList)
            {
                Console.WriteLine(e.id + " " + e.name + " " + e.department + " " + e.salary);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
