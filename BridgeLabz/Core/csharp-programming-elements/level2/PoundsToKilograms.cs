using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter weight in pounds: ");
        double pounds = Convert.ToDouble(Console.ReadLine());

        double kg = pounds / 2.2;

        Console.WriteLine("The weight of the person in pounds is " +
                          pounds + " and in kg is " + kg);
    }
}
