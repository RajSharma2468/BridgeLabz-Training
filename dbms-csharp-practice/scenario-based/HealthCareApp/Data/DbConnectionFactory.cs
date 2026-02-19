using Microsoft.Data.SqlClient;

namespace HealthCareApp.Data
{
    public static class DbConnectionFactory
    {
        public static SqlConnection GetConnection()
        {
            string connectionString =
                "Server=RAJ\\SQLEXPRESS;Database=HealthCareDB;Trusted_Connection=True;TrustServerCertificate=True";

            return new SqlConnection(connectionString);
        }
    }
}
