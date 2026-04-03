using System;

class Vehicle
{
    public static double RegistrationFee = 2000;

    public string ownerName;
    public string vehicleType;
    public readonly string registrationNumber;

    public Vehicle(string ownerName, string vehicleType, string registrationNumber)
    {
        this.ownerName = ownerName;
        this.vehicleType = vehicleType;
        this.registrationNumber = registrationNumber;
    }

    public static void UpdateRegistrationFee(double fee)
    {
        RegistrationFee = fee;
    }

    public void DisplayDetails(object obj)
    {
        if (obj is Vehicle)
        {
            Console.WriteLine("Owner: " + ownerName);
            Console.WriteLine("Vehicle Type: " + vehicleType);
            Console.WriteLine("Registration No: " + registrationNumber);
            Console.WriteLine("Fee: " + RegistrationFee);
        }
    }
}

class Program
{
    static void Main()
    {
        Vehicle v = new Vehicle("Rohit", "Car", "UP32AB1234");
        Vehicle.UpdateRegistrationFee(2500);
        v.DisplayDetails(v);
    }
}
