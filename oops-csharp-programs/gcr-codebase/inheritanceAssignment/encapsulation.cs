using System;

class Person
{
    private int age;

    public void SetAge(int a)
    {
        age = a;
    }

    public int GetAge()
    {
        return age;
    }
}

class Program
{
    static void Main()
    {
        Person p = new Person();
        p.SetAge(22);
        Console.WriteLine("Age: " + p.GetAge());
    }
}
