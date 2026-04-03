using System;

class Patient
{
    public static string HospitalName = "City Hospital";
    private static int totalPatients = 0;

    public string name;
    public int age;
    public string ailment;
    public readonly int patientID;

    public Patient(string name, int age, string ailment, int patientID)
    {
        this.name = name;
        this.age = age;
        this.ailment = ailment;
        this.patientID = patientID;
        totalPatients++;
    }

    public static void GetTotalPatients()
    {
        Console.WriteLine("Total Patients: " + totalPatients);
    }

    public void DisplayDetails(object obj)
    {
        if (obj is Patient)
        {
            Console.WriteLine("Hospital: " + HospitalName);
            Console.WriteLine("Patient Name: " + name);
            Console.WriteLine("Patient ID: " + patientID);
            Console.WriteLine("Age: " + age);
            Console.WriteLine("Ailment: " + ailment);
        }
    }
}

class Program
{
    static void Main()
    {
        Patient p = new Patient("Suman", 35, "Fever", 701);
        p.DisplayDetails(p);
        Patient.GetTotalPatients();
    }
}
