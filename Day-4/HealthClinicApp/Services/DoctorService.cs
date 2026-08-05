using System.Data;
using Microsoft.Data.SqlClient;
using HealthClinicApp.Entity;
// Disconnected Architecture
namespace HealthClinicApp.Services
{
    // Handles doctor data operations
    public class DoctorService
    {
        // Connection string for database
        private readonly string connectionString =
            @"Server=.\SQLEXPRESS;Database=HealthClinic;Trusted_Connection=True;TrustServerCertificate=True;";

        // Fetches all doctors using adapter
        public DataTable GetAllDoctors()
        {
            DataTable table = new DataTable();

            // Fill table then close connection
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT DoctorId, FirstName, LastName, Specialization, Phone FROM Doctors", conn))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(table);
            }
            return table;
        }

        // Inserts new doctor record
        public void AddDoctor(Doctor d)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(
                "INSERT INTO Doctors (FirstName, LastName, Specialization, Phone) VALUES (@FirstName, @LastName, @Specialization, @Phone)", conn))
            {
                // Bind parameters safely
                cmd.Parameters.AddWithValue("@FirstName", d.FirstName);
                cmd.Parameters.AddWithValue("@LastName", d.LastName);
                cmd.Parameters.AddWithValue("@Specialization", d.Specialization);
                cmd.Parameters.AddWithValue("@Phone", d.Phone);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}