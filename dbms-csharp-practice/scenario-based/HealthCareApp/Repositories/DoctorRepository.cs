using Microsoft.Data.SqlClient;
using HealthCareApp.Models;
using HealthCareApp.Data;
using System.Collections.Generic;

namespace HealthCareApp.Repositories
{
    public class DoctorRepository
    {
        public void Add(Doctor doctor)
        {
            using (SqlConnection conn = DbConnectionFactory.GetConnection())
            {
                conn.Open();

                string query =
                    "INSERT INTO Doctors(Name, Specialization) VALUES(@Name, @Spec)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", doctor.Name);
                    cmd.Parameters.AddWithValue("@Spec", doctor.Specialization);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Doctor> GetAll()
        {
            List<Doctor> list = new List<Doctor>();

            using (SqlConnection conn = DbConnectionFactory.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Doctors";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Doctor d = new Doctor();
                        d.DoctorId = (int)reader["DoctorId"];
                        d.Name = reader["Name"].ToString();
                        d.Specialization = reader["Specialization"].ToString();
                        list.Add(d);
                    }
                }
            }

            return list;
        }
    }
}
