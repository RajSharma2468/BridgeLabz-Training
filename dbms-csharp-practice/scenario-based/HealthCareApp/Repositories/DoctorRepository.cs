using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using HealthCareApp.Models;
using HealthCareApp.Utilities;

namespace HealthCareApp.Repositories
{
    public class DoctorRepository
    {
        // Add new doctor
        public void AddDoctor(Doctor doctor)
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = @"INSERT INTO Doctors (Name, Specialty, Contact, ConsultationFee, IsActive)
                                        VALUES (@name, @specialty, @contact, @fee, @isActive)";
                    cmd.Parameters.AddWithValue("@name", doctor.Name);
                    cmd.Parameters.AddWithValue("@specialty", doctor.Specialty);
                    cmd.Parameters.AddWithValue("@contact", doctor.Contact);
                    cmd.Parameters.AddWithValue("@fee", doctor.ConsultationFee);
                    cmd.Parameters.AddWithValue("@isActive", doctor.IsActive);

                    cmd.ExecuteNonQuery();
                }

                Console.WriteLine("Doctor added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding doctor: " + ex.Message);
            }
        }

        // Get all doctors
        public List<Doctor> GetAllDoctors()
        {
            var list = new List<Doctor>();
            try
            {
                using (var conn = Database.GetConnection())
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = @"SELECT ID, Name, Specialty, Contact, ConsultationFee, IsActive FROM Doctors";

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Doctor
                            {
                                ID = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Specialty = reader.GetString(2),
                                Contact = reader.GetString(3),
                                ConsultationFee = reader.GetDouble(4),
                                IsActive = reader.GetBoolean(5)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching doctors: " + ex.Message);
            }

            return list;
        }

        // Update doctor details
        public void UpdateDoctor(Doctor doctor)
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = @"UPDATE Doctors 
                                        SET Name=@name, Specialty=@specialty, Contact=@contact, ConsultationFee=@fee, IsActive=@isActive
                                        WHERE ID=@id";
                    cmd.Parameters.AddWithValue("@name", doctor.Name);
                    cmd.Parameters.AddWithValue("@specialty", doctor.Specialty);
                    cmd.Parameters.AddWithValue("@contact", doctor.Contact);
                    cmd.Parameters.AddWithValue("@fee", doctor.ConsultationFee);
                    cmd.Parameters.AddWithValue("@isActive", doctor.IsActive);
                    cmd.Parameters.AddWithValue("@id", doctor.ID);

                    cmd.ExecuteNonQuery();
                }

                Console.WriteLine("Doctor updated successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating doctor: " + ex.Message);
            }
        }

        // Deactivate doctor (soft delete)
        public void DeactivateDoctor(int doctorId)
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = @"UPDATE Doctors SET IsActive=0 WHERE ID=@id";
                    cmd.Parameters.AddWithValue("@id", doctorId);

                    cmd.ExecuteNonQuery();
                }

                Console.WriteLine("Doctor deactivated successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deactivating doctor: " + ex.Message);
            }
        }

        // Get doctor by ID
        public Doctor GetDoctorById(int doctorId)
        {
            Doctor doctor = null;
            try
            {
                using (var conn = Database.GetConnection())
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = @"SELECT ID, Name, Specialty, Contact, ConsultationFee, IsActive 
                                        FROM Doctors WHERE ID=@id";
                    cmd.Parameters.AddWithValue("@id", doctorId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            doctor = new Doctor
                            {
                                ID = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Specialty = reader.GetString(2),
                                Contact = reader.GetString(3),
                                ConsultationFee = reader.GetDouble(4),
                                IsActive = reader.GetBoolean(5)
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching doctor: " + ex.Message);
            }

            return doctor;
        }
    }
}
