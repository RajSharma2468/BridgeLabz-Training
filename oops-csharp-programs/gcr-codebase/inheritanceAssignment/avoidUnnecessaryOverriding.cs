using System;

class BaseClass
{
    public virtual void Show()
    {
        Console.WriteLine("Base Show");
    }
}

class ChildClass : BaseClass
{
}

class Program
{
    static void Main()
    {
        ChildClass c = new ChildClass();
        c.Show();
    }
}
