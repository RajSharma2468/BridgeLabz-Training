using System;
using System.Threading;
using EmployeePayrollMultiThreading.Model;
using EmployeePayrollMultiThreading.Service;

namespace EmployeePayrollMultiThreading.UC
{
    public class UC4_ThreadLogs
    {
        public static void Run(Employee emp)
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} starting for {emp.Name}");
            new EmployeePayrollService().AddEmployeeToPayroll(emp);
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} finished for {emp.Name}");
        }
    }
}
