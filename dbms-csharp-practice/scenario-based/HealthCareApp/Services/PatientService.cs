using Microsoft.Data.SqlClient;
using HealthCareApp.Models;
using HealthCareApp.Utilities;
using System;

namespace HealthCareApp.Services
{
    public class PatientService
    {
        public void Register(Patient patient)
        {
            using (var conn = Database.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"INSERT INTO Patients (Name, DOB, Contact, Address, BloodGroup)
                                    VALUES (@name, @dob, @contact, @address, @bg);
                                    SELECT SCOPE_IDENTITY();"; // Get DB-generated ID
                cmd.Parameters.AddWithValue("@name", patient.Name);
                cmd.Parameters.AddWithValue("@dob", patient.DOB);
                cmd.Parameters.AddWithValue("@contact", patient.Contact);
                cmd.Parameters.AddWithValue("@address", patient.Address);
                cmd.Parameters.AddWithValue("@bg", patient.BloodGroup);

                // Assign database-generated ID
                patient.ID = Convert.ToInt32(cmd.ExecuteScalar());
            }

            Console.WriteLine("[" + DateTime.Now + "] Patient " + patient.Name + " registered with ID " + patient.ID);
        }

        public void DisplayAllPatients()
        {
            using (var conn = Database.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ID, Name, Contact FROM Patients";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("ID: " + reader.GetInt32(0) +
                                          ", Name: " + reader.GetString(1) +
                                          ", Contact: " + reader.GetString(2));
                    }
                }
            }
        }
    }
}
