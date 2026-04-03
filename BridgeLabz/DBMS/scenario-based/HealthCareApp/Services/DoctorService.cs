using System;
using HealthCareApp.Models;
using HealthCareApp.Utilities;
using HealthCareApp.Attributes;
using Microsoft.Data.SqlClient;

namespace HealthCareApp.Services
{
    public class DoctorService
    {
        public void AddDoctor(Doctor doctor)
        {
            using (var conn = Database.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"INSERT INTO Doctors (Name, Specialty, Contact, ConsultationFee, IsActive)
                                    VALUES (@name, @specialty, @contact, @fee, @isActive);
                                    SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("@name", doctor.Name);
                cmd.Parameters.AddWithValue("@specialty", doctor.Specialty);
                cmd.Parameters.AddWithValue("@contact", doctor.Contact);
                cmd.Parameters.AddWithValue("@fee", doctor.ConsultationFee);
                cmd.Parameters.AddWithValue("@isActive", true);

                doctor.ID = Convert.ToInt32(cmd.ExecuteScalar());
            }

            Logger.Log("Doctor " + doctor.Name + " added with ID " + doctor.ID);
        }

        // Update, Deactivate, ViewBySpecialty remain same
        [Audit("Update Doctor Specialty")]
        public void UpdateSpecialty(int id, string specialty)
        {
            using (var conn = Database.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"UPDATE Doctors SET Specialty=@specialty WHERE ID=@id";
                cmd.Parameters.AddWithValue("@specialty", specialty);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            Logger.Log("Doctor " + id + " specialty updated to " + specialty);
        }

        [Audit("Deactivate Doctor")]
        public void Deactivate(int id)
        {
            using (var conn = Database.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"UPDATE Doctors SET IsActive=0 WHERE ID=@id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            Logger.Log("Doctor " + id + " deactivated");
        }
    }
}
