using System;
using System.Collections.Generic;

#region Interface
interface IGPS
{
    void GetCurrentLocation();
    void UpdateLocation(string location);
}
#endregion

#region Abstract Class
abstract class Vehicle
{
    private string vehicleId;
    private string driverName;
    protected double ratePerKm;

    public string VehicleId
    {
        get { return vehicleId; }
    }

    protected Vehicle(string id, string driver, double rate)
    {
        vehicleId = id;
        driverName = driver;
        ratePerKm = rate;
    }

    public abstract double CalculateFare(double distance);

    public virtual void GetVehicleDetails()
    {
        Console.WriteLine("Vehicle ID   : " + vehicleId);
        Console.WriteLine("Driver Name  : " + driverName);
        Console.WriteLine("Rate per Km  : " + ratePerKm);
    }
}
#endregion

#region Car
class Car : Vehicle, IGPS
{
    private string currentLocation;

    public Car(string id, string driver) : base(id, driver, 20) 
    {
        currentLocation = "HQ";
    }

    public override double CalculateFare(double distance)
    {
        return distance * ratePerKm;
    }

    public void GetCurrentLocation()
    {
        Console.WriteLine("Current Location: " + currentLocation);
    }

    public void UpdateLocation(string location)
    {
        currentLocation = location;
        Console.WriteLine("Location Updated");
    }
}
#endregion

#region Bike
class Bike : Vehicle, IGPS
{
    private string currentLocation;

    public Bike(string id, string driver) : base(id, driver, 10)
    {
        currentLocation = "HQ";
    }

    public override double CalculateFare(double distance)
    {
        return distance * ratePerKm;
    }

    public void GetCurrentLocation()
    {
        Console.WriteLine("Current Location: " + currentLocation);
    }

    public void UpdateLocation(string location)
    {
        currentLocation = location;
        Console.WriteLine("Location Updated");
    }
}
#endregion

#region Auto
class Auto : Vehicle, IGPS
{
    private string currentLocation;

    public Auto(string id, string driver) : base(id, driver, 15)
    {
        currentLocation = "HQ";
    }

    public override double CalculateFare(double distance)
    {
        return distance * ratePerKm;
    }

    public void GetCurrentLocation()
    {
        Console.WriteLine("Current Location: " + currentLocation);
    }

    public void UpdateLocation(string location)
    {
        currentLocation = location;
        Console.WriteLine("Location Updated");
    }
}
#endregion

#region Main Program
class Program
{
    static void Main()
    {
        List<Vehicle> vehicles = new List<Vehicle>();

        while (true)
        {
            Console.WriteLine("\nRIDE-HAILING APPLICATION");
            Console.WriteLine("1. Add Car");
            Console.WriteLine("2. Add Bike");
            Console.WriteLine("3. Add Auto");
            Console.WriteLine("4. Display Vehicles & Calculate Fare");
            Console.WriteLine("5. Exit");
            Console.Write("Enter Choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    vehicles.Add(CreateCar());
                    break;

                case 2:
                    vehicles.Add(CreateBike());
                    break;

                case 3:
                    vehicles.Add(CreateAuto());
                    break;

                case 4:
                    DisplayVehicles(vehicles);
                    break;

                case 5:
                    return;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }

    static Car CreateCar()
    {
        Console.Write("Vehicle ID: ");
        string id = Console.ReadLine();
        Console.Write("Driver Name: ");
        string driver = Console.ReadLine();
        return new Car(id, driver);
    }

    static Bike CreateBike()
    {
        Console.Write("Vehicle ID: ");
        string id = Console.ReadLine();
        Console.Write("Driver Name: ");
        string driver = Console.ReadLine();
        return new Bike(id, driver);
    }

    static Auto CreateAuto()
    {
        Console.Write("Vehicle ID: ");
        string id = Console.ReadLine();
        Console.Write("Driver Name: ");
        string driver = Console.ReadLine();
        return new Auto(id, driver);
    }

    static void DisplayVehicles(List<Vehicle> vehicles)
    {
        Console.Write("Enter Distance Travelled (Km): ");
        double distance = double.Parse(Console.ReadLine());

        foreach (Vehicle v in vehicles)
        {
            v.GetVehicleDetails();
            Console.WriteLine("Fare        : " + v.CalculateFare(distance));

            if (v is IGPS)
            {
                ((IGPS)v).GetCurrentLocation();
            }

            Console.WriteLine("---------------------------");
        }
    }
}
#endregion
