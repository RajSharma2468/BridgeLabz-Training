using System;

namespace HealthClinicApp.Services
{
    // Combines all clinic services
    public class HealthService
    {
        // Reference to patient service
        private readonly PatientService patientService = new PatientService();

        // Reference to doctor service
        private readonly DoctorService doctorService = new DoctorService();

        // Displays overall clinic summary
        public void ShowClinicSummary()
        {
            var patients = patientService.GetAllPatients();
            var doctors = doctorService.GetAllDoctors();

            // Print total counts here
            Console.WriteLine($"Total Patients: {patients.Count}");
            Console.WriteLine($"Total Doctors: {doctors.Rows.Count}");
        }
    }
}