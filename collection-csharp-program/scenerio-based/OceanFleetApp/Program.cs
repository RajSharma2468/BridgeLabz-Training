using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        VesselUtil util = new VesselUtil();

        Console.WriteLine("Enter the number of vessels to be added");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter vessel details");
        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            string[] parts = input.Split(':');

            string vesselId = parts[0];
            string vesselName = parts[1];
            double averageSpeed = double.Parse(parts[2]);
            string vesselType = parts[3];

            Vessel vessel = new Vessel(vesselId, vesselName, averageSpeed, vesselType);
            util.AddVesselPerformance(vessel);
        }

        Console.WriteLine("Enter the Vessel Id to check speed");
        string searchId = Console.ReadLine();

        Vessel found = util.GetVesselById(searchId);

        if (found != null)
        {
            Console.WriteLine(found.VesselId + " | " +
                              found.VesselName + " | " +
                              found.VesselType + " | " +
                              found.AverageSpeed + " knots");
        }
        else
        {
            Console.WriteLine("Vessel Id " + searchId + " not found");
        }

        Console.WriteLine("High performance vessels are");
        List<Vessel> highPerf = util.GetHighPerformanceVessels();

        foreach (var v in highPerf)
        {
            Console.WriteLine(v.VesselId + " | " +
                              v.VesselName + " | " +
                              v.VesselType + " | " +
                              v.AverageSpeed + " knots");
        }
    }
}
