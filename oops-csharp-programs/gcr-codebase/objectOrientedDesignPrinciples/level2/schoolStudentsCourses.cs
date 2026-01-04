using System;
using System.Collections.Generic;

class Course
{
    public string courseName;
    public List<Student> students = new List<Student>();

    public Course(string courseName)
    {
        this.courseName = courseName;
    }

    public void ShowStudents()
    {
        Console.WriteLine("Students in " + courseName + ":");
        foreach (Student s in students)
            Console.WriteLine(s.name);
    }
}

class Student
{
    public string name;
    public List<Course> courses = new List<Course>();

    public Student(string name)
    {
        this.name = name;
    }

    public void EnrollCourse(Course c)
    {
        courses.Add(c);
        c.students.Add(this);
    }

    public void ShowCourses()
    {
        Console.WriteLine(name + " enrolled courses:");
        foreach (Course c in courses)
            Console.WriteLine(c.courseName);
    }
}

class School
{
    public string schoolName;
    public List<Student> students = new List<Student>();

    public School(string schoolName)
    {
        this.schoolName = schoolName;
    }

    public void AddStudent(Student s)
    {
        students.Add(s);
    }
}

class Program
{
    static void Main()
    {
        School school = new School("ABC School");

        Student s1 = new Student("John");
        Student s2 = new Student("Emma");

        Course c1 = new Course("Maths");
        Course c2 = new Course("Science");

        school.AddStudent(s1);
        school.AddStudent(s2);

        s1.EnrollCourse(c1);
        s1.EnrollCourse(c2);
        s2.EnrollCourse(c1);

        s1.ShowCourses();
        c1.ShowStudents();
    }
}
