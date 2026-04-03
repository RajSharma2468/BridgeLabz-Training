using System;
using System.Reflection;

class Student
{
    public string Name = "Raj";
}

class Program
{
    static void Main()
    {
        Type t = typeof(Student);
        object obj = Activator.CreateInstance(t);

        Console.WriteLine(((Student)obj).Name);
    }
}
