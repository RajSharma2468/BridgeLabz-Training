using Microsoft.Data.SqlClient;
using HealthCareApp.Models;
using HealthCareApp.Utilities;
using System;
using System.Collections.Generic;

namespace HealthCareApp.Repositories
{
    public class PatientRepository
    {
        public void AddPatient(Patient p)
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = @"INSERT INTO Patients (Name,DOB,Contact,Address,BloodGroup)
                                        VALUES (@name,@dob,@contact,@address,@bg)";
                    cmd.Parameters.AddWithValue("@name", p.Name);
                    cmd.Parameters.AddWithValue("@dob", p.DOB);
                    cmd.Parameters.AddWithValue("@contact", p.Contact);
                    cmd.Parameters.AddWithValue("@address", p.Address);
                    cmd.Parameters.AddWithValue("@bg", p.BloodGroup);
                    cmd.ExecuteNonQuery();
                }

                Console.WriteLine("Patient added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public List<Patient> GetAllPatients()
        {
            var list = new List<Patient>();
            try
            {
                using (var conn = Database.GetConnection())
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT ID, Name, DOB, Contact, Address, BloodGroup FROM Patients";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Patient
                            {
                                ID = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                DOB = reader.GetDateTime(2),
                                Contact = reader.GetString(3),
                                Address = reader.GetString(4),
                                BloodGroup = reader.GetString(5)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return list;
        }
    }
}
