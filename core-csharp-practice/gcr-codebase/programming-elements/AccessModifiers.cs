
//  Access Modifiers

using System;
class Demo
{
    public int number=10;
    // Public
    public void show()
    {
        Console.WriteLine("Welcome to Capgemini");
    }

    // private
      private int a=20;
    private void display()
    {
        Console.WriteLine("jai hind");
    }
}

class AccessModifiers
    {
        static void Main()
        {
            Demo d=new Demo();
            Console.WriteLine(d.number);
            d.show();
            /*
            * 
            */
            // d.display();

        }
    }