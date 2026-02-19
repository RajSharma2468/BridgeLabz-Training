using System;
using System.Collections.Generic;
using HealthCareApp.Models;
using HealthCareApp.Repositories;
using HealthCareApp.Utilities;

namespace HealthCareApp.Services
{
    public class DoctorService
    {
        private DoctorRepository repo = new DoctorRepository();

        public void AddDoctor()
        {
            Doctor d = new Doctor();

            Console.Write("Enter Doctor Name: ");
            d.Name = Console.ReadLine();

            Console.Write("Enter Specialization: ");
            d.Specialization = Console.ReadLine();

            Validator.Validate(d);
            repo.Add(d);
            AuditLogger.Log("Doctor Added");

            Console.WriteLine("Doctor added successfully.");
        }

        public void ViewDoctors()
        {
            List<Doctor> doctors = repo.GetAll();

            foreach (Doctor d in doctors)
            {
                Console.WriteLine("ID: " + d.DoctorId);
                Console.WriteLine("Name: " + d.Name);
                Console.WriteLine("Specialization: " + d.Specialization);
                Console.WriteLine("---------------------");
            }
        }
    }
}
