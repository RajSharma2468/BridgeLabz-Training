using System;
using HealthCareApp.Models;
using HealthCareApp.Utilities;
using HealthCareApp.Attributes;
using Microsoft.Data.SqlClient;

namespace HealthCareApp.Services
{
    public class VisitService
    {
        [Audit("Record Visit")]
        public void RecordVisit(int patientId, int doctorId, string diagnosis, string prescription, string notes)
        {
            Visit visit = new Visit
            {
                PatientID = patientId,
                DoctorID = doctorId,
                VisitDate = DateTime.Now,
                Diagnosis = diagnosis ?? "N/A",
                Prescription = prescription ?? "N/A",
                Notes = notes ?? "N/A"
            };

            using (var conn = Database.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"INSERT INTO Visits (PatientID, DoctorID, VisitDate, Diagnosis, Prescription, Notes)
                                    VALUES (@pid,@did,@vdate,@diag,@pres,@notes);
                                    SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("@pid", visit.PatientID);
                cmd.Parameters.AddWithValue("@did", visit.DoctorID);
                cmd.Parameters.AddWithValue("@vdate", visit.VisitDate);
                cmd.Parameters.AddWithValue("@diag", visit.Diagnosis);
                cmd.Parameters.AddWithValue("@pres", visit.Prescription);
                cmd.Parameters.AddWithValue("@notes", visit.Notes);

                visit.ID = Convert.ToInt32(cmd.ExecuteScalar());
            }

            Logger.Log("Visit recorded for patient " + patientId + " with Visit ID " + visit.ID);
        }
    }
}
