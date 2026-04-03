using System;

class Person
{
    public Person(string name)
    {
        Console.WriteLine("Name: " + name);
    }
}

class Student : Person
{
    public Student(string name) : base(name)
    {
        Console.WriteLine("Student created");
    }
}

class Program
{
    static void Main()
    {
        Student s = new Student("Raj");
    }
}
