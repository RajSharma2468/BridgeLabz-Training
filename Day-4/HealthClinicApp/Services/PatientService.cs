using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using HealthClinicApp.Entity;
// Connected Architecture
namespace HealthClinicApp.Services
{
    // Handles patient data operations
    public class PatientService
    {
        // Connection string for database
        private readonly string connectionString =
            @"Server=.\SQLEXPRESS;Database=HealthClinic;Trusted_Connection=True;TrustServerCertificate=True;";

        // Fetches all patients using reader
        public List<Patient> GetAllPatients()
        {
            List<Patient> patients = new List<Patient>();

            // Open connected architecture connection
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT PatientId, FirstName, LastName, Phone, DateOfBirth, Gender FROM Patients", conn))
            {
                conn.Open();

                // Read rows one by one
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Map row to object
                        Patient p = new Patient();
                        p.PatientId = (int)reader["PatientId"];
                        p.FirstName = reader["FirstName"].ToString();
                        p.LastName = reader["LastName"].ToString();
                        p.Phone = reader["Phone"].ToString();
                        p.DateOfBirth = (DateTime)reader["DateOfBirth"];
                        p.Gender = reader["Gender"].ToString();

                        patients.Add(p);
                    }
                }
            }
            return patients;
        }

        // Inserts new patient record
        public void AddPatient(Patient p)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(
                "INSERT INTO Patients (FirstName, LastName, Phone, DateOfBirth, Gender) VALUES (@FirstName, @LastName, @Phone, @DOB, @Gender)", conn))
            {
                // Bind parameters safely
                cmd.Parameters.AddWithValue("@FirstName", p.FirstName);
                cmd.Parameters.AddWithValue("@LastName", p.LastName);
                cmd.Parameters.AddWithValue("@Phone", p.Phone);
                cmd.Parameters.AddWithValue("@DOB", p.DateOfBirth);
                cmd.Parameters.AddWithValue("@Gender", p.Gender);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}