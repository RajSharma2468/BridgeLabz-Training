using System;
using HealthCareApp.Models;
using HealthCareApp.Utilities;
using HealthCareApp.Attributes;
using Microsoft.Data.SqlClient;

namespace HealthCareApp.Services
{
    public class AppointmentService
    {
        [Audit("Book Appointment")]
        public void BookAppointment(int patientId, int doctorId, DateTime date)
        {
            Appointment appt = new Appointment
            {
                PatientID = patientId,
                DoctorID = doctorId,
                AppointmentDate = date,
                Status = "SCHEDULED"
            };

            using (var conn = Database.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"INSERT INTO Appointments (PatientID, DoctorID, AppointmentDate, Status)
                                    VALUES (@pid, @did, @adate, @status);
                                    SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("@pid", appt.PatientID);
                cmd.Parameters.AddWithValue("@did", appt.DoctorID);
                cmd.Parameters.AddWithValue("@adate", appt.AppointmentDate);
                cmd.Parameters.AddWithValue("@status", appt.Status);

                appt.ID = Convert.ToInt32(cmd.ExecuteScalar());
            }

            Logger.Log("Appointment booked: " + appt.ID);
        }

        [Audit("Cancel Appointment")]
        public void CancelAppointment(int id)
        {
            using (var conn = Database.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"UPDATE Appointments SET Status='CANCELLED' WHERE ID=@id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            Logger.Log("Appointment " + id + " cancelled");
        }
    }
}
