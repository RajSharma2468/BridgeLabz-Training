using Microsoft.Data.SqlClient;
using HealthCareApp.Models;
using HealthCareApp.Data;
using System.Collections.Generic;

namespace HealthCareApp.Repositories
{
    public class PatientRepository
    {
        public void Add(Patient patient)
        {
            using (SqlConnection conn = DbConnectionFactory.GetConnection())
            {
                conn.Open();

                string query =
                    "INSERT INTO Patients(Name,Phone,Email) VALUES(@Name,@Phone,@Email)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", patient.Name);
                    cmd.Parameters.AddWithValue("@Phone", patient.Phone);
                    cmd.Parameters.AddWithValue("@Email", patient.Email);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Patient> GetAll()
        {
            List<Patient> list = new List<Patient>();

            using (SqlConnection conn = DbConnectionFactory.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Patients";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Patient p = new Patient();
                        p.PatientId = (int)reader["PatientId"];
                        p.Name = reader["Name"].ToString();
                        p.Phone = reader["Phone"].ToString();
                        p.Email = reader["Email"].ToString();
                        list.Add(p);
                    }
                }
            }

            return list;
        }
    }
}
