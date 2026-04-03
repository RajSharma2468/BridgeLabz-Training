using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter From City: ");
        string fromCity = Console.ReadLine();

        Console.Write("Enter Via City: ");
        string viaCity = Console.ReadLine();

        Console.Write("Enter To City: ");
        string toCity = Console.ReadLine();

        Console.Write("Enter distance From-To-Via (miles): ");
        double fromToVia = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter distance Via-To-Final (miles): ");
        double viaToFinalCity = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Time Taken (hours): ");
        double timeTaken = Convert.ToDouble(Console.ReadLine());

        double totalDistance = fromToVia + viaToFinalCity;
        double speed = totalDistance / timeTaken;

        Console.WriteLine("The results of the trip are: " +
                          totalDistance + " miles, " +
                          timeTaken + " hours, " +
                          speed + " miles/hour");
    }
}
