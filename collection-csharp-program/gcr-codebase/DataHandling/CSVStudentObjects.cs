using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public int ID;
    public string Name;
    public int Age;
}

class Program
{
    static void Main()
    {
        var students = new List<Student>();

        foreach (var line in File.ReadAllLines("students.csv").Skip(1))
        {
            var d = line.Split(',');
            Student s = new Student();
            s.ID = int.Parse(d[0]);
            s.Name = d[1];
            s.Age = int.Parse(d[2]);
            students.Add(s);
        }

        foreach (var s in students)
            Console.WriteLine(s.ID + " " + s.Name + " " + s.Age);
    }
}
