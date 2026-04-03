using System.Collections.Generic;
using System.Threading;
using EmployeePayrollMultiThreading.Model;
using EmployeePayrollMultiThreading.Service;

namespace EmployeePayrollMultiThreading.UC
{
    public class UC6_UpdateSalary
    {
        public static void Run(List<Employee> employees)
        {
            List<Thread> threads = new List<Thread>();
            EmployeePayrollService service = new EmployeePayrollService();

            foreach (var emp in employees)
            {
                Thread t = new Thread(() => service.UpdateSalary(emp.Id, emp.Salary + 5000));
                threads.Add(t);
                t.Start();
            }

            foreach (var t in threads)
                t.Join();
        }
    }
}
