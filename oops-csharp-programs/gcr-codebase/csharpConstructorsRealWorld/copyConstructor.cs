using System;

class Person
{
    public string name;
    public int age;

    // Parameterized Constructor
    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    // Copy Constructor
    public Person(Person p)
    {
        name = p.name;
        age = p.age;
    }

    public void Display()
    {
        Console.WriteLine("Name: " + name);
        Console.WriteLine("Age: " + age);
    }
}

class Program
{
    static void Main()
    {
        Person p1 = new Person("Raj", 21);
        Person p2 = new Person(p1);

        p2.Display();
    }
}
