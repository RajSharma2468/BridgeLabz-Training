using Microsoft.Data.SqlClient;
using HealthCareApp.Models;
using HealthCareApp.Utilities;
using System;
using System.Collections.Generic;

namespace HealthCareApp.Repositories
{
    public class AppointmentRepository
    {
        // Add new appointment
        public void AddAppointment(Appointment a)
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = @"INSERT INTO Appointments (PatientID, DoctorID, AppointmentDate, Status)
                                        VALUES (@pid, @did, @adate, @status)";
                    cmd.Parameters.AddWithValue("@pid", a.PatientID);
                    cmd.Parameters.AddWithValue("@did", a.DoctorID);
                    cmd.Parameters.AddWithValue("@adate", a.AppointmentDate);
                    cmd.Parameters.AddWithValue("@status", a.Status);

                    cmd.ExecuteNonQuery();
                }

                Console.WriteLine("Appointment booked successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while adding appointment: " + ex.Message);
            }
        }

        // Get all appointments
        public List<Appointment> GetAllAppointments()
        {
            var list = new List<Appointment>();
            try
            {
                using (var conn = Database.GetConnection())
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT ID, PatientID, DoctorID, AppointmentDate, Status FROM Appointments";

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Appointment
                            {
                                ID = reader.GetInt32(0),
                                PatientID = reader.GetInt32(1),
                                DoctorID = reader.GetInt32(2),
                                AppointmentDate = reader.GetDateTime(3),
                                Status = reader.GetString(4)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while fetching appointments: " + ex.Message);
            }

            return list;
        }

        // Update appointment status
        public void UpdateStatus(int appointmentId, string status)
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = @"UPDATE Appointments SET Status=@status WHERE ID=@id";
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@id", appointmentId);
                    cmd.ExecuteNonQuery();
                }

                Console.WriteLine("Appointment status updated!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while updating appointment: " + ex.Message);
            }
        }

        // Delete appointment
        public void DeleteAppointment(int appointmentId)
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = @"DELETE FROM Appointments WHERE ID=@id";
                    cmd.Parameters.AddWithValue("@id", appointmentId);
                    cmd.ExecuteNonQuery();
                }

                Console.WriteLine("Appointment deleted successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while deleting appointment: " + ex.Message);
            }
        }
    }
}
