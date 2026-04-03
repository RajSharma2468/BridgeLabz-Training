using Microsoft.Data.SqlClient;
using System;

namespace HealthCareApp.Utilities
{
    public static class Database
    {
        private static string connectionString = 
    "Server=RAJ\\SQLEXPRESS;Database=HealthCareAppDB;Trusted_Connection=True;TrustServerCertificate=True;";

        // Returns an open SQL connection
        public static SqlConnection GetConnection()
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        // Initialize all tables
        public static void Initialize()
        {
            try
            {
                using (var conn = GetConnection())
                {
                    string[] tableCommands = new string[]
                    {
                        // Patients
                        @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Patients' AND xtype='U')
                          CREATE TABLE Patients (
                              ID INT IDENTITY(1,1) PRIMARY KEY,
                              Name NVARCHAR(100),
                              DOB DATE,
                              Contact NVARCHAR(20),
                              Address NVARCHAR(200),
                              BloodGroup NVARCHAR(10)
                          );",

                        // Doctors
                        @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Doctors' AND xtype='U')
                          CREATE TABLE Doctors (
                              ID INT IDENTITY(1,1) PRIMARY KEY,
                              Name NVARCHAR(100),
                              Specialty NVARCHAR(50),
                              Contact NVARCHAR(20),
                              ConsultationFee DECIMAL(10,2),
                              IsActive BIT
                          );",

                        // Appointments
                        @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Appointments' AND xtype='U')
                          CREATE TABLE Appointments (
                              ID INT IDENTITY(1,1) PRIMARY KEY,
                              PatientID INT,
                              DoctorID INT,
                              AppointmentDate DATETIME,
                              Status NVARCHAR(20)
                          );",

                        // Visits
                        @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Visits' AND xtype='U')
                          CREATE TABLE Visits (
                              ID INT IDENTITY(1,1) PRIMARY KEY,
                              PatientID INT,
                              DoctorID INT,
                              VisitDate DATETIME,
                              Diagnosis NVARCHAR(200),
                              Prescription NVARCHAR(500),
                              Notes NVARCHAR(500)
                          );",

                        // Bills
                        @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Bills' AND xtype='U')
                          CREATE TABLE Bills (
                              ID INT IDENTITY(1,1) PRIMARY KEY,
                              VisitID INT,
                              Amount DECIMAL(10,2),
                              PaymentStatus NVARCHAR(20),
                              PaymentDate DATETIME,
                              PaymentMode NVARCHAR(50)
                          );"
                    };

                    foreach (var cmdText in tableCommands)
                    {
                        using (var cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = cmdText;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                Console.WriteLine("Database connected and tables are ready on RAJ\\SQLEXPRESS!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database initialization error: " + ex.Message);
            }
        }
    }
}
