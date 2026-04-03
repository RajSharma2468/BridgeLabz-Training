using System;

class SimpleInterestProgram
{
    static double CalculateSimpleInterest(double principal, double rate, double time)
    {
        return (principal * rate * time) / 100;
    }

    static void Main()
    {
        Console.WriteLine("Enter Principal");
        double principal = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter Rate of Interest");
        double rate = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter Time");
        double time = Convert.ToDouble(Console.ReadLine());

        double interest = CalculateSimpleInterest(principal, rate, time);

        Console.WriteLine("The Simple Interest is " + interest +
                          " for Principal " + principal +
                          ", Rate of Interest " + rate +
                          " and Time " + time);
    }
}
