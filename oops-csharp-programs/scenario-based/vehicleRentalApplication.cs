using System;
using System.Collections.Generic;

#region Interface
public interface IRentable
{
    double CalculateRent(int days);
}
#endregion

#region Vehicle Base Class
public abstract class Vehicle : IRentable
{
    protected int vehicleId;
    protected string vehicleNumber;
    protected double rentPerDay;

    public int VehicleId
    {
        get { return vehicleId; }
    }

    public string VehicleNumber
    {
        get { return vehicleNumber; }
    }

    protected Vehicle(int id, string number, double rent)
    {
        vehicleId = id;
        vehicleNumber = number;
        rentPerDay = rent;
    }

    public abstract double CalculateRent(int days);

    public virtual void DisplayVehicle()
    {
        Console.WriteLine("Vehicle ID: " + vehicleId);
        Console.WriteLine("Vehicle Number: " + vehicleNumber);
        Console.WriteLine("Rent Per Day: Rs. " + rentPerDay);
    }
}
#endregion

#region Bike Class
public class Bike : Vehicle
{
    public Bike(int id, string number)
        : base(id, number, 300)
    {
    }

    public override double CalculateRent(int days)
    {
        return rentPerDay * days;
    }
}
#endregion

#region Car Class
public class Car : Vehicle
{
    public Car(int id, string number)
        : base(id, number, 1000)
    {
    }

    public override double CalculateRent(int days)
    {
        return rentPerDay * days;
    }
}
#endregion

#region Truck Class
public class Truck : Vehicle
{
    public Truck(int id, string number)
        : base(id, number, 2000)
    {
    }

    public override double CalculateRent(int days)
    {
        return (rentPerDay * days) + 500; // loading charge
    }
}
#endregion

#region Customer Class
public class Customer
{
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }

    public Customer(int id, string name)
    {
        CustomerId = id;
        CustomerName = name;
    }

    public void RentVehicle(Vehicle vehicle, int days)
    {
        Console.WriteLine("\nCustomer Name: " + CustomerName);
        vehicle.DisplayVehicle();
        Console.WriteLine("Days: " + days);
        Console.WriteLine("Total Rent: Rs. " + vehicle.CalculateRent(days));
    }
}
#endregion

#region Main Program
class Program
{
    static List<Vehicle> vehicles = new List<Vehicle>();

    static void Main()
    {
        SeedVehicles();

        Customer customer = new Customer(1, "Raj");

        while (true)
        {
            Console.WriteLine("\nVEHICLE RENTAL APPLICATION");
            Console.WriteLine("1. View Vehicles");
            Console.WriteLine("2. Rent Vehicle");
            Console.WriteLine("3. Exit");
            Console.Write("Enter choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    ViewVehicles();
                    break;

                case 2:
                    RentVehicle(customer);
                    break;

                case 3:
                    return;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }

    static void SeedVehicles()
    {
        vehicles.Add(new Bike(1, "BIKE-101"));
        vehicles.Add(new Car(2, "CAR-202"));
        vehicles.Add(new Truck(3, "TRUCK-303"));
    }

    static void ViewVehicles()
    {
        Console.WriteLine("\nAVAILABLE VEHICLES:");
        foreach (Vehicle v in vehicles)
        {
            Console.WriteLine("--------------------");
            v.DisplayVehicle();
        }
    }

    static void RentVehicle(Customer customer)
    {
        Console.Write("Enter Vehicle ID: ");
        int id = int.Parse(Console.ReadLine());

        Vehicle vehicle = vehicles.Find(v => v.VehicleId == id);

        if (vehicle != null)
        {
            Console.Write("Enter number of days: ");
            int days = int.Parse(Console.ReadLine());

            customer.RentVehicle(vehicle, days);
        }
        else
        {
            Console.WriteLine("Vehicle not found!");
        }
    }
}
#endregion
