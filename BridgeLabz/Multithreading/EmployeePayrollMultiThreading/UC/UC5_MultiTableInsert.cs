using System;
using System.Data.SqlClient;
using EmployeePayrollMultiThreading.Model;

namespace EmployeePayrollMultiThreading.UC
{
    public class UC5_MultiTableInsert
    {
        private static readonly object dbLock = new object();
        private static string connectionString = "YOUR_SQL_CONNECTION_STRING";

        public static void AddEmployeeFullDetails(Employee emp)
        {
            lock (dbLock)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlTransaction transaction = con.BeginTransaction();

                    string query1 = "INSERT INTO employee_payroll (name, salary) OUTPUT INSERTED.id VALUES (@name, @salary)";
                    SqlCommand cmd1 = new SqlCommand(query1, con, transaction);
                    cmd1.Parameters.AddWithValue("@name", emp.Name);
                    cmd1.Parameters.AddWithValue("@salary", emp.Salary);
                    int empId = (int)cmd1.ExecuteScalar();

                    string query2 = "INSERT INTO payroll_details (employee_id, basic_pay) VALUES (@id, @salary)";
                    SqlCommand cmd2 = new SqlCommand(query2, con, transaction);
                    cmd2.Parameters.AddWithValue("@id", empId);
                    cmd2.Parameters.AddWithValue("@salary", emp.Salary);

                    cmd2.ExecuteNonQuery();
                    transaction.Commit();
                }
            }
        }
    }
}
