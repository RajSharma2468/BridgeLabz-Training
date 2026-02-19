using System;
using System.Collections.Generic;
using HealthCareApp.Models;
using HealthCareApp.Repositories;
using HealthCareApp.Utilities;

namespace HealthCareApp.Services
{
    public class PatientService
    {
        private PatientRepository repo = new PatientRepository();

        public void AddPatient()
        {
            try
            {
                Patient p = new Patient();

                Console.Write("Enter Patient Name: ");
                p.Name = Console.ReadLine() ?? string.Empty;

                Console.Write("Enter Phone (10 digits): ");
                p.Phone = Console.ReadLine() ?? string.Empty;

                Console.Write("Enter Email: ");
                p.Email = Console.ReadLine() ?? string.Empty;

                // Validate attributes (Required, Regex etc.)
                Validator.Validate(p);

                repo.Add(p);

                AuditLogger.Log("Patient Added: " + p.Name);

                Console.WriteLine("Patient added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public void ViewPatients()
        {
            List<Patient> patients = repo.GetAll();

            if (patients == null || patients.Count == 0)
            {
                Console.WriteLine("No patients found.");
                return;
            }

            foreach (Patient p in patients)
            {
                Console.WriteLine("ID: " + p.PatientId);
                Console.WriteLine("Name: " + p.Name);
                Console.WriteLine("Phone: " + p.Phone);
                Console.WriteLine("Email: " + p.Email);
                Console.WriteLine("------------------------");
            }
        }
    }
}
