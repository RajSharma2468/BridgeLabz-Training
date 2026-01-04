using System;
using System.Collections.Generic;

class Faculty
{
    public string name;

    public Faculty(string name)
    {
        this.name = name;
    }
}

class Department
{
    public string deptName;

    public Department(string deptName)
    {
        this.deptName = deptName;
    }
}

class University
{
    public string name;
    public List<Department> departments = new List<Department>();
    public List<Faculty> faculties = new List<Faculty>();

    public University(string name)
    {
        this.name = name;
    }

    public void AddDepartment(string deptName)
    {
        departments.Add(new Department(deptName));
    }

    public void AddFaculty(Faculty f)
    {
        faculties.Add(f);
    }

    public void DeleteUniversity()
    {
        departments.Clear(); // composition
        Console.WriteLine("University deleted, departments removed");
    }
}

class Program
{
    static void Main()
    {
        University uni = new University("XYZ University");

        Faculty f1 = new Faculty("Dr. Smith");
        uni.AddFaculty(f1);

        uni.AddDepartment("CSE");
        uni.AddDepartment("ECE");

        uni.DeleteUniversity();

        Console.WriteLine("Faculty still exists: " + f1.name);
    }
}
