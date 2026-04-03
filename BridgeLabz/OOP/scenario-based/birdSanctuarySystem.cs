using System;

#region Interfaces
public interface IFlyable
{
    void Fly();
}

public interface ISwimmable
{
    void Swim();
}
#endregion

#region Base Class
public abstract class Bird
{
    public string Name { get; set; }
    public string Color { get; set; }
    public int Age { get; set; }

    protected Bird(string name, string color, int age)
    {
        Name = name;
        Color = color;
        Age = age;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine("Name: " + Name);
        Console.WriteLine("Color: " + Color);
        Console.WriteLine("Age: " + Age);
    }
}
#endregion

#region Derived Classes

public class Eagle : Bird, IFlyable
{
    public Eagle(string name, string color, int age)
        : base(name, color, age) { }

    public void Fly()
    {
        Console.WriteLine("Eagle is flying at high altitude.");
    }
}

public class Sparrow : Bird, IFlyable
{
    public Sparrow(string name, string color, int age)
        : base(name, color, age) { }

    public void Fly()
    {
        Console.WriteLine("Sparrow is flying short distances.");
    }
}

public class Duck : Bird, ISwimmable
{
    public Duck(string name, string color, int age)
        : base(name, color, age) { }

    public void Swim()
    {
        Console.WriteLine("Duck is swimming in the pond.");
    }
}

public class Penguin : Bird, ISwimmable
{
    public Penguin(string name, string color, int age)
        : base(name, color, age) { }

    public void Swim()
    {
        Console.WriteLine("Penguin is swimming in cold water.");
    }
}

public class Seagull : Bird, IFlyable, ISwimmable
{
    public Seagull(string name, string color, int age)
        : base(name, color, age) { }

    public void Fly()
    {
        Console.WriteLine("Seagull is flying near the sea.");
    }

    public void Swim()
    {
        Console.WriteLine("Seagull is swimming on sea surface.");
    }
}

#endregion

#region Main Program
class Program
{
    static void Main()
    {
        Bird[] birds = new Bird[5];

        birds[0] = new Eagle("Eagle", "Brown", 5);
        birds[1] = new Sparrow("Sparrow", "Grey", 2);
        birds[2] = new Duck("Duck", "White", 3);
        birds[3] = new Penguin("Penguin", "Black & White", 6);
        birds[4] = new Seagull("Seagull", "White", 4);

        Console.WriteLine("ECO WING BIRD SANCTUARY\n");

        for (int i = 0; i < birds.Length; i++)
        {
            Console.WriteLine("---------------");
            birds[i].DisplayInfo();

            // Polymorphism using interface checking
            if (birds[i] is IFlyable)
            {
                ((IFlyable)birds[i]).Fly();
            }

            if (birds[i] is ISwimmable)
            {
                ((ISwimmable)birds[i]).Swim();
            }
        }

        Console.ReadLine();
    }
}
#endregion
