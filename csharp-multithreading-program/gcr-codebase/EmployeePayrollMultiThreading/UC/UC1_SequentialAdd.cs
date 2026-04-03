using System;
using System.Collections.Generic;
using System.Diagnostics;
using EmployeePayrollMultiThreading.Model;
using EmployeePayrollMultiThreading.Service;

namespace EmployeePayrollMultiThreading.UC
{
    public class UC1_SequentialAdd
    {
        public static void Run(List<Employee> employees)
        {
            EmployeePayrollService service = new EmployeePayrollService();
            Stopwatch sw = Stopwatch.StartNew();

            foreach (var emp in employees)
            {
                service.AddEmployeeToPayroll(emp);
            }

            sw.Stop();
            Console.WriteLine("UC1 Sequential Time: " + sw.ElapsedMilliseconds);
        }
    }
}
