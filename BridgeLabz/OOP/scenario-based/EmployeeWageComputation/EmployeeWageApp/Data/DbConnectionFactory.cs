using Microsoft.Data.SqlClient;
using System;

namespace EmployeeWageApp.Data
{
    public static class DbConnectionFactory
    {
        private static readonly string SqlExpressConn =
            @"Server=rajsharma\SQLEXPRESS;Database=EmployeeWageDB;Trusted_Connection=True;TrustServerCertificate=True";

        private static readonly string LocalDbConn =
            @"Server=(localdb)\MSSQLLocalDB;Database=EmployeeWageDB;Trusted_Connection=True;TrustServerCertificate=True";

        private static bool triedSqlExpress = false;

        public static SqlConnection GetConnection()
        {
            if (!triedSqlExpress)
            {
                triedSqlExpress = true;
                try
                {
                    var conn = new SqlConnection(SqlExpressConn);
                    conn.Open();
                    conn.Close();
                    return new SqlConnection(SqlExpressConn);
                }
                catch
                {
                    Console.WriteLine("SQL Express not reachable. Using LocalDB instead.");
                }
            }
            return new SqlConnection(LocalDbConn);
        }

        public static void CreateDatabaseIfNotExists()
        {
            string masterConnStr = SqlExpressConn.Replace("EmployeeWageDB", "master");
            try
            {
                using (var testConn = new SqlConnection(masterConnStr))
                {
                    testConn.Open();
                }
            }
            catch
            {
                masterConnStr = LocalDbConn.Replace("EmployeeWageDB", "master");
                Console.WriteLine("SQL Express not reachable. Using LocalDB for database creation.");
            }

            using (var conn = new SqlConnection(masterConnStr))
            {
                conn.Open();
                string checkDb = "IF DB_ID('EmployeeWageDB') IS NULL CREATE DATABASE EmployeeWageDB";
                using (var cmd = new SqlCommand(checkDb, conn))
                    cmd.ExecuteNonQuery();
            }

            // Create table
            string tableScript = @"
                IF OBJECT_ID('Employees', 'U') IS NULL
                CREATE TABLE Employees (
                    Id INT IDENTITY(1,1) PRIMARY KEY,
                    Name NVARCHAR(50) NOT NULL,
                    Type NVARCHAR(20) NOT NULL,
                    DailyHours INT NOT NULL DEFAULT 0,
                    TotalHoursWorked INT NOT NULL DEFAULT 0
                )";

            using (var dbConn = GetConnection())
            {
                dbConn.Open();
                using (var cmd = new SqlCommand(tableScript, dbConn))
                    cmd.ExecuteNonQuery();
            }
        }
    }
}