using System;
using System.Collections.Generic;

class Subject
{
    public string subjectName;
    public int marks;

    public Subject(string subjectName, int marks)
    {
        this.subjectName = subjectName;
        this.marks = marks;
    }
}

class Student
{
    public string name;
    public List<Subject> subjects = new List<Subject>();

    public Student(string name)
    {
        this.name = name;
    }

    public void AddSubject(Subject s)
    {
        subjects.Add(s);
    }
}

class GradeCalculator
{
    public void CalculateGrade(Student student)
    {
        int total = 0;

        foreach (Subject s in student.subjects)
        {
            total += s.marks;
        }

        int average = total / student.subjects.Count;
        Console.WriteLine("Student: " + student.name);
        Console.WriteLine("Average Marks: " + average);

        if (average >= 90)
            Console.WriteLine("Grade: A");
        else if (average >= 75)
            Console.WriteLine("Grade: B");
        else
            Console.WriteLine("Grade: C");
    }
}

class Program
{
    static void Main()
    {
        Student student = new Student("John");
        student.AddSubject(new Subject("Maths", 90));
        student.AddSubject(new Subject("Science", 85));

        GradeCalculator gc = new GradeCalculator();
        gc.CalculateGrade(student);
    }
}
