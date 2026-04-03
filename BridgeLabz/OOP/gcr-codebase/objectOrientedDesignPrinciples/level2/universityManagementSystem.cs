using System;
using System.Collections.Generic;

class Course
{
    public string courseName;
    public Professor professor;

    public Course(string courseName)
    {
        this.courseName = courseName;
    }

    public void AssignProfessor(Professor p)
    {
        professor = p;
        Console.WriteLine(p.name + " assigned to " + courseName);
    }
}

class Student
{
    public string name;

    public Student(string name)
    {
        this.name = name;
    }

    public void EnrollCourse(Course c)
    {
        Console.WriteLine(name + " enrolled in " + c.courseName);
    }
}

class Professor
{
    public string name;

    public Professor(string name)
    {
        this.name = name;
    }
}

class Program
{
    static void Main()
    {
        Student s = new Student("John");
        Professor p = new Professor("Dr. Kumar");
        Course c = new Course("Data Structures");

        s.EnrollCourse(c);
        c.AssignProfessor(p);
    }
}
