using System;
using System.Data;
using HealthClinicApp.Services;
using HealthClinicApp.Entity;

namespace HealthClinicApp.Menu
{
    public class MenuHandler
    {
        private readonly PatientService patientService = new PatientService();
        private readonly DoctorService doctorService = new DoctorService();
        private readonly AppointmentService appointmentService = new AppointmentService();
        private readonly HealthService healthService = new HealthService();

        public void ShowMenu()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n===== Health Clinic App =====");
                Console.WriteLine("1. View All Patients");
                Console.WriteLine("2. View All Doctors");
                Console.WriteLine("3. Add New Patient");        // NAYA
                Console.WriteLine("4. Add New Doctor");         // NAYA
                Console.WriteLine("5. Book Appointment");
                Console.WriteLine("6. View Patient Appointments");
                Console.WriteLine("7. Update Appointment Status");
                Console.WriteLine("8. View Audit Log");
                Console.WriteLine("9. Clinic Summary");
                Console.WriteLine("10. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": ViewPatients(); break;
                    case "2": ViewDoctors(); break;
                    case "3": AddPatient(); break;               // NAYA
                    case "4": AddDoctor(); break;                // NAYA
                    case "5": BookAppointment(); break;
                    case "6": ViewPatientAppointments(); break;
                    case "7": UpdateStatus(); break;
                    case "8": ViewAuditLog(); break;
                    case "9": healthService.ShowClinicSummary(); break;
                    case "10": exit = true; break;
                    default: Console.WriteLine("Invalid option."); break;
                }
            }
        }

        private void ViewPatients()
        {
            var patients = patientService.GetAllPatients();
            foreach (var p in patients)
                Console.WriteLine($"{p.PatientId} | {p.FirstName} {p.LastName} | {p.Phone}");
        }

        private void ViewDoctors()
        {
            DataTable table = doctorService.GetAllDoctors();
            foreach (DataRow row in table.Rows)
                Console.WriteLine($"{row["DoctorId"]} | {row["FirstName"]} {row["LastName"]} | {row["Specialization"]}");
        }

        // Naya method: Patient add karta hai
        private void AddPatient()
        {
            Patient p = new Patient();

            Console.Write("Enter First Name: ");
            p.FirstName = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            p.LastName = Console.ReadLine();

            Console.Write("Enter Phone: ");
            p.Phone = Console.ReadLine();

            Console.Write("Enter Date of Birth (yyyy-MM-dd): ");
            p.DateOfBirth = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter Gender: ");
            p.Gender = Console.ReadLine();

            try
            {
                patientService.AddPatient(p);
                Console.WriteLine("Patient added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
            }
        }

        // Naya method: Doctor add karta hai
        private void AddDoctor()
        {
            Doctor d = new Doctor();

            Console.Write("Enter First Name: ");
            d.FirstName = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            d.LastName = Console.ReadLine();

            Console.Write("Enter Specialization: ");
            d.Specialization = Console.ReadLine();

            Console.Write("Enter Phone: ");
            d.Phone = Console.ReadLine();

            try
            {
                doctorService.AddDoctor(d);
                Console.WriteLine("Doctor added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
            }
        }

        private void BookAppointment()
        {
            Console.Write("Enter PatientId: ");
            int patientId = int.Parse(Console.ReadLine());

            Console.Write("Enter DoctorId: ");
            int doctorId = int.Parse(Console.ReadLine());

            Console.Write("Enter Appointment Date (yyyy-MM-dd HH:mm): ");
            DateTime apptDate = DateTime.Parse(Console.ReadLine());

            try
            {
                appointmentService.BookAppointment(patientId, doctorId, apptDate);
                Console.WriteLine("Appointment booked successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
            }
        }

        private void ViewPatientAppointments()
        {
            Console.Write("Enter PatientId: ");
            int patientId = int.Parse(Console.ReadLine());

            var results = appointmentService.GetPatientAppointments(patientId);
            foreach (var row in results)
                Console.WriteLine(row);
        }

        private void UpdateStatus()
        {
            Console.Write("Enter AppointmentId: ");
            int apptId = int.Parse(Console.ReadLine());

            Console.Write("Enter New Status: ");
            string status = Console.ReadLine();

            try
            {
                appointmentService.UpdateStatus(apptId, status);
                Console.WriteLine("Status updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
            }
        }

        private void ViewAuditLog()
        {
            Console.Write("Enter AppointmentId: ");
            int apptId = int.Parse(Console.ReadLine());

            var logs = appointmentService.GetAuditLog(apptId);
            foreach (var log in logs)
                Console.WriteLine(log);
        }
    }
}