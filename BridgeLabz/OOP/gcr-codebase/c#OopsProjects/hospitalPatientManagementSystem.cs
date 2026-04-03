using System;
using System.Collections.Generic;

#region Interface
interface IMedicalRecord
{
    void AddRecord(string record);
    void ViewRecords();
}
#endregion

#region Abstract Class
abstract class Patient
{
    private int patientId;
    private string name;
    private int age;

    protected List<string> records = new List<string>();

    public int PatientId { get { return patientId; } }
    public string Name { get { return name; } }

    protected Patient(int id, string name, int age)
    {
        patientId = id;
        this.name = name;
        this.age = age;
    }

    public abstract double CalculateBill();

    public virtual void DisplayDetails()
    {
        Console.WriteLine("Patient ID   : " + patientId);
        Console.WriteLine("Patient Name : " + name);
        Console.WriteLine("Age          : " + age);
        Console.WriteLine("Bill Amount  : " + CalculateBill());
    }
}
#endregion

#region InPatient
class InPatient : Patient, IMedicalRecord
{
    private int days;

    public InPatient(int id, string name, int age, int days)
        : base(id, name, age)
    {
        this.days = days;
    }

    public override double CalculateBill()
    {
        return days * 2000;
    }

    public void AddRecord(string record)
    {
        records.Add(record);
    }

    public void ViewRecords()
    {
        foreach (string r in records)
            Console.WriteLine(r);
    }
}
#endregion

#region OutPatient
class OutPatient : Patient, IMedicalRecord
{
    public OutPatient(int id, string name, int age)
        : base(id, name, age)
    {
    }

    public override double CalculateBill()
    {
        return 500;
    }

    public void AddRecord(string record)
    {
        records.Add(record);
    }

    public void ViewRecords()
    {
        foreach (string r in records)
            Console.WriteLine(r);
    }
}
#endregion

#region Main Program
class Program
{
    static void Main()
    {
        List<Patient> patients = new List<Patient>();

        while (true)
        {
            Console.WriteLine("\nHOSPITAL PATIENT MANAGEMENT SYSTEM");
            Console.WriteLine("1. Add In-Patient");
            Console.WriteLine("2. Add Out-Patient");
            Console.WriteLine("3. Display All Patients");
            Console.WriteLine("4. Exit");
            Console.Write("Enter Choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddInPatient(patients);
                    break;

                case 2:
                    AddOutPatient(patients);
                    break;

                case 3:
                    DisplayPatients(patients);
                    break;

                case 4:
                    return;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }

    static void AddInPatient(List<Patient> patients)
    {
        Console.Write("Enter ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Age: ");
        int age = int.Parse(Console.ReadLine());

        Console.Write("Enter Days Admitted: ");
        int days = int.Parse(Console.ReadLine());

        Patient p = new InPatient(id, name, age, days);
        patients.Add(p);

        Console.WriteLine("In-Patient Added Successfully");
    }

    static void AddOutPatient(List<Patient> patients)
    {
        Console.Write("Enter ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Age: ");
        int age = int.Parse(Console.ReadLine());

        Patient p = new OutPatient(id, name, age);
        patients.Add(p);

        Console.WriteLine("Out-Patient Added Successfully");
    }

    static void DisplayPatients(List<Patient> patients)
    {
        Console.WriteLine("\nPATIENT LIST\n");

        foreach (Patient p in patients)
        {
            p.DisplayDetails();
            Console.WriteLine("------------------------");
        }
    }
}
#endregion
