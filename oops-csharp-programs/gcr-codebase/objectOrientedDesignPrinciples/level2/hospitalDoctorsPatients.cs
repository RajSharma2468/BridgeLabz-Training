using System;
using System.Collections.Generic;

class Patient
{
    public string name;

    public Patient(string name)
    {
        this.name = name;
    }
}

class Doctor
{
    public string name;

    public Doctor(string name)
    {
        this.name = name;
    }

    public void Consult(Patient p)
    {
        Console.WriteLine("Doctor " + name + " consults patient " + p.name);
    }
}

class Hospital
{
    public List<Doctor> doctors = new List<Doctor>();
    public List<Patient> patients = new List<Patient>();
}

class Program
{
    static void Main()
    {
        Doctor d1 = new Doctor("Dr. Raj");
        Patient p1 = new Patient("Amit");

        d1.Consult(p1);
    }
}
