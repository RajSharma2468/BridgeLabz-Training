using System;

class Student
{
    public static string UniversityName = "ABC University";
    private static int totalStudents = 0;

    public string name;
    public readonly int rollNumber;
    public char grade;

    public Student(string name, int rollNumber, char grade)
    {
        this.name = name;
        this.rollNumber = rollNumber;
        this.grade = grade;
        totalStudents++;
    }

    public static void DisplayTotalStudents()
    {
        Console.WriteLine("Total Students: " + totalStudents);
    }

    public void DisplayDetails(object obj)
    {
        if (obj is Student)
        {
            Console.WriteLine("University: " + UniversityName);
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Roll Number: " + rollNumber);
            Console.WriteLine("Grade: " + grade);
        }
    }
}

class Program
{
    static void Main()
    {
        Student s = new Student("Neha", 401, 'A');
        s.DisplayDetails(s);
        Student.DisplayTotalStudents();
    }
}
