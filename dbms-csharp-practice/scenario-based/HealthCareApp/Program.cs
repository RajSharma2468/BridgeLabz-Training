using System;
using HealthCareApp.Services;

namespace HealthCareApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DoctorService doctorService = new DoctorService();
            PatientService patientService = new PatientService();

            while (true)
            {
                Console.WriteLine("\n===== HEALTH CARE MANAGEMENT SYSTEM =====");
                Console.WriteLine("1. Add Doctor");
                Console.WriteLine("2. View Doctors");
                Console.WriteLine("3. Add Patient");
                Console.WriteLine("4. View Patients");
                Console.WriteLine("5. Exit");
                Console.Write("Enter Choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        doctorService.AddDoctor();
                        break;

                    case "2":
                        doctorService.ViewDoctors();
                        break;

                    case "3":
                        patientService.AddPatient();
                        break;

                    case "4":
                        patientService.ViewPatients();
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }
    }
}
