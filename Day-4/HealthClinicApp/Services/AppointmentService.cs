using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
// Connected + Stored Procedures
namespace HealthClinicApp.Services
{
    // Handles appointment operations
    public class AppointmentService
    {
        // Connection string for database
        private readonly string connectionString =
            @"Server=.\SQLEXPRESS;Database=HealthClinic;Trusted_Connection=True;TrustServerCertificate=True;";

        // Books new patient appointment
        public void BookAppointment(int patientId, int doctorId, DateTime appointmentDate)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_BookAppointment", conn))
            {
                // Calling stored procedure here
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PatientId", patientId);
                cmd.Parameters.AddWithValue("@DoctorId", doctorId);
                cmd.Parameters.AddWithValue("@AppointmentDate", appointmentDate);

                conn.Open();
                cmd.ExecuteNonQuery();

                // Insert automatically fires trigger
            }
        }

        // Fetches appointments for patient
        public List<string> GetPatientAppointments(int patientId)
        {
            List<string> results = new List<string>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_GetPatientAppointments", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PatientId", patientId);

                conn.Open();

                // Read results row by row
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add($"{reader["AppointmentId"]} | Dr. {reader["DoctorName"]} | {reader["Specialization"]} | {reader["AppointmentDate"]} | {reader["Status"]}");
                    }
                }
            }
            return results;
        }

        // Updates appointment status value
        public void UpdateStatus(int appointmentId, string newStatus)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_UpdateAppointmentStatus", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AppointmentId", appointmentId);
                cmd.Parameters.AddWithValue("@NewStatus", newStatus);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        

        // Fetches audit trail entries
        public List<string> GetAuditLog(int appointmentId)
        {
            List<string> logs = new List<string>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_GetAppointmentAuditLog", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AppointmentId", appointmentId);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        logs.Add($"{reader["AuditId"]} | {reader["ActionType"]} | {reader["ActionBy"]} | {reader["ActionDate"]}");
                    }
                }
            }
            return logs;
        }
    }
}