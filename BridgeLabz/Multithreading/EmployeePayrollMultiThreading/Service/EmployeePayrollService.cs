using System;
using System.Data.SqlClient;
using EmployeePayrollMultiThreading.Model;

namespace EmployeePayrollMultiThreading.Service
{
    public class EmployeePayrollService
    {
        private string connectionString = "YOUR_SQL_CONNECTION_STRING";

        public void AddEmployeeToPayroll(Employee emp)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    string query = "INSERT INTO employee_payroll (name, salary) VALUES (@name, @salary)";
                    SqlCommand cmd = new SqlCommand(query, con, transaction);
                    cmd.Parameters.AddWithValue("@name", emp.Name);
                    cmd.Parameters.AddWithValue("@salary", emp.Salary);
                    cmd.ExecuteNonQuery();

                    transaction.Commit();
                    Console.WriteLine($"Employee {emp.Name} added by Thread {System.Threading.Thread.CurrentThread.ManagedThreadId}");
                }
                catch
                {
                    transaction.Rollback();
                }
            }
        }

        public void UpdateSalary(int id, double salary)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "UPDATE employee_payroll SET salary=@salary WHERE id=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@salary", salary);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
