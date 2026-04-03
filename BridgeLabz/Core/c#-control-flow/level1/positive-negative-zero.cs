using System;

class NumberTypeApp
{
    static void Main()
    {
        int number = Convert.ToInt32(Console.ReadLine());

        if (number > 0)
            Console.WriteLine("positive");
        else if (number < 0)
            Console.WriteLine("negative");
        else
            Console.WriteLine("zero");
    }
}
