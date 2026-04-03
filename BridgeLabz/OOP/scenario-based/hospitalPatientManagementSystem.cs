using System;
using System.Collections.Generic;

#region Interface
public interface IPayable
{
    double CalculateBill();
}
#endregion

#region Doctor Class
public class Doctor
{
    public int DoctorId { get; set; }
    public string DoctorName { get; set; }
    public string Specialization { get; set; }

    public Doctor(int id, string name, string specialization)
    {
        DoctorId = id;
        DoctorName = name;
        Specialization = specialization;
    }

    public void DisplayDoctor()
    {
        Console.WriteLine("Doctor: " + DoctorName + " (" + Specialization + ")");
    }
}
#endregion

#region Patient Base Class
public abstract class Patient
{
    public int PatientId { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public Doctor Doctor { get; set; }

    protected double baseCharge;

    protected Patient(int id, string name, int age, Doctor doctor)
    {
        PatientId = id;
        Name = name;
        Age = age;
        Doctor = doctor;
    }

    public abstract void DisplayInfo();
}
#endregion

#region InPatient Class
public class InPatient : Patient, IPayable
{
    public int DaysAdmitted { get; set; }
    public double RoomChargePerDay { get; set; }

    public InPatient(int id, string name, int age, Doctor doctor,
                     int days, double roomCharge)
        : base(id, name, age, doctor)
    {
        DaysAdmitted = days;
        RoomChargePerDay = roomCharge;
        baseCharge = 1500;
    }

    public double CalculateBill()
    {
        return baseCharge + (DaysAdmitted * RoomChargePerDay);
    }

    public override void DisplayInfo()
    {
        Console.WriteLine("\n--- IN-PATIENT DETAILS ---");
        Console.WriteLine("ID: " + PatientId);
        Console.WriteLine("Name: " + Name);
        Console.WriteLine("Age: " + Age);
        Doctor.DisplayDoctor();
        Console.WriteLine("Days Admitted: " + DaysAdmitted);
        Console.WriteLine("Total Bill: Rs. " + CalculateBill());
    }
}
#endregion

#region OutPatient Class
public class OutPatient : Patient, IPayable
{
    public double ConsultationFee { get; set; }

    public OutPatient(int id, string name, int age, Doctor doctor, double fee)
        : base(id, name, age, doctor)
    {
        ConsultationFee = fee;
        baseCharge = 500;
    }

    public double CalculateBill()
    {
        return baseCharge + ConsultationFee;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine("\n--- OUT-PATIENT DETAILS ---");
        Console.WriteLine("ID: " + PatientId);
        Console.WriteLine("Name: " + Name);
        Console.WriteLine("Age: " + Age);
        Doctor.DisplayDoctor();
        Console.WriteLine("Total Bill: Rs. " + CalculateBill());
    }
}
#endregion

#region Bill Class
public class Bill
{
    public int BillId { get; set; }
    public Patient Patient { get; set; }
    public double Amount { get; set; }

    public Bill(int billId, Patient patient)
    {
        BillId = billId;
        Patient = patient;
        Amount = ((IPayable)patient).CalculateBill();
    }

    public void PrintBill()
    {
        Console.WriteLine("\n===== BILL DETAILS =====");
        Console.WriteLine("Bill ID: " + BillId);
        Console.WriteLine("Patient Name: " + Patient.Name);
        Console.WriteLine("Amount Payable: Rs. " + Amount);
        Console.WriteLine("========================");
    }
}
#endregion

#region Main Program
class Program
{
    static List<Patient> patients = new List<Patient>();
    static List<Doctor> doctors = new List<Doctor>();
    static int billCounter = 1001;

    static void Main()
    {
        SeedDoctors();

        while (true)
        {
            Console.WriteLine("\nHOSPITAL PATIENT MANAGEMENT SYSTEM");
            Console.WriteLine("1. Add In-Patient");
            Console.WriteLine("2. Add Out-Patient");
            Console.WriteLine("3. View All Patients");
            Console.WriteLine("4. Generate Bill");
            Console.WriteLine("5. Exit");
            Console.Write("Enter choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddInPatient();
                    break;
                case 2:
                    AddOutPatient();
                    break;
                case 3:
                    ViewPatients();
                    break;
                case 4:
                    GenerateBill();
                    break;
                case 5:
                    return;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }

    static void SeedDoctors()
    {
        doctors.Add(new Doctor(1, "Dr. Sharma", "Cardiology"));
        doctors.Add(new Doctor(2, "Dr. Mehta", "General"));
    }

    static Doctor SelectDoctor()
    {
        Console.WriteLine("Select Doctor:");
        foreach (Doctor d in doctors)
        {
            Console.WriteLine(d.DoctorId + ". " + d.DoctorName + " - " + d.Specialization);
        }

        int id = int.Parse(Console.ReadLine());
        return doctors.Find(d => d.DoctorId == id);
    }

    static void AddInPatient()
    {
        Console.Write("Patient ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Age: ");
        int age = int.Parse(Console.ReadLine());

        Doctor doctor = SelectDoctor();

        Console.Write("Days Admitted: ");
        int days = int.Parse(Console.ReadLine());

        Console.Write("Room Charge Per Day: ");
        double charge = double.Parse(Console.ReadLine());

        patients.Add(new InPatient(id, name, age, doctor, days, charge));
        Console.WriteLine("In-Patient added successfully!");
    }

    static void AddOutPatient()
    {
        Console.Write("Patient ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Age: ");
        int age = int.Parse(Console.ReadLine());

        Doctor doctor = SelectDoctor();

        Console.Write("Consultation Fee: ");
        double fee = double.Parse(Console.ReadLine());

        patients.Add(new OutPatient(id, name, age, doctor, fee));
        Console.WriteLine("Out-Patient added successfully!");
    }

    static void ViewPatients()
    {
        foreach (Patient p in patients)
        {
            p.DisplayInfo();
        }
    }

    static void GenerateBill()
    {
        Console.Write("Enter Patient ID: ");
        int id = int.Parse(Console.ReadLine());

        Patient patient = patients.Find(p => p.PatientId == id);

        if (patient != null)
        {
            Bill bill = new Bill(billCounter++, patient);
            bill.PrintBill();
        }
        else
        {
            Console.WriteLine("Patient not found!");
        }
    }
}
#endregion
