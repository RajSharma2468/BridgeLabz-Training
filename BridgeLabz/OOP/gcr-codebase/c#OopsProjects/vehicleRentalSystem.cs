using System;
using System.Collections.Generic;

#region Interface
interface IInsurable
{
    double CalculateInsurance();
}
#endregion

#region Abstract Class
abstract class Vehicle
{
    private string vehicleNumber;
    protected double rentPerDay;

    public string VehicleNumber
    {
        get { return vehicleNumber; }
    }

    protected Vehicle(string number, double rate)
    {
        vehicleNumber = number;
        rentPerDay = rate;
    }

    public abstract double CalculateRent(int days);

    public virtual void DisplayDetails(int days)
    {
        Console.WriteLine("Vehicle Number : " + vehicleNumber);
        Console.WriteLine("Rent Amount    : " + CalculateRent(days));
    }
}
#endregion

#region Car
class Car : Vehicle, IInsurable
{
    public Car(string number) : base(number, 2000)
    {
    }

    public override double CalculateRent(int days)
    {
        return days * rentPerDay;
    }

    public double CalculateInsurance()
    {
        return 500;
    }
}
#endregion

#region Bike
class Bike : Vehicle, IInsurable
{
    public Bike(string number) : base(number, 800)
    {
    }

    public override double CalculateRent(int days)
    {
        return days * rentPerDay;
    }

    public double CalculateInsurance()
    {
        return 200;
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
            Console.WriteLine("\nVEHICLE RENTAL SYSTEM");
            Console.WriteLine("1. Add Car");
            Console.WriteLine("2. Add Bike");
            Console.WriteLine("3. Display Vehicles");
            Console.WriteLine("4. Exit");
            Console.Write("Enter Choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddCar(vehicles);
                    break;

                case 2:
                    AddBike(vehicles);
                    break;

                case 3:
                    DisplayVehicles(vehicles);
                    break;

                case 4:
                    return;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }

    static void AddCar(List<Vehicle> vehicles)
    {
        Console.Write("Enter Car Number: ");
        string number = Console.ReadLine();

        vehicles.Add(new Car(number));
        Console.WriteLine("Car Added Successfully");
    }

    static void AddBike(List<Vehicle> vehicles)
    {
        Console.Write("Enter Bike Number: ");
        string number = Console.ReadLine();

        vehicles.Add(new Bike(number));
        Console.WriteLine("Bike Added Successfully");
    }

    static void DisplayVehicles(List<Vehicle> vehicles)
    {
        Console.Write("Enter Number of Days: ");
        int days = int.Parse(Console.ReadLine());

        Console.WriteLine("\nVEHICLE LIST\n");

        foreach (Vehicle v in vehicles)
        {
            v.DisplayDetails(days);

            if (v is IInsurable)
            {
                IInsurable ins = (IInsurable)v;
                Console.WriteLine("Insurance Cost : " + ins.CalculateInsurance());
            }

            Console.WriteLine("-----------------------");
        }
    }
}
#endregion
